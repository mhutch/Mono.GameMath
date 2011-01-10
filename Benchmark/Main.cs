// 
// Main.cs
//  
// Author:
//       Michael Hutchinson <mhutchinson@novell.com>
// 
// Copyright (c) 2010 Novell, Inc.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Reflection;
using System.IO;

namespace Benchmark
{
	class Driver
	{
		public static int Main (string[] args)
		{
			string type = null;
			string method = null;
			if (args.Length > 0 && args[0] != "*")
				type = args[0];
			if (args.Length > 1)
				method = args[1];
			
			PrintInfo ();
			
			return RunTests (type, method);
		}
		
		static void PrintInfo ()
		{
			var mtype = System.Type.GetType ("Mono.Runtime");
			if (mtype != null) {
				var monoVersion = (string) mtype.GetMethod ("GetDisplayName", 
						System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic)
					.Invoke (null, null);
				System.Console.WriteLine ("Runtime: Mono {0}", monoVersion);
			} else {
				System.Console.WriteLine ("Runtime: .NET");
			}
			System.Console.WriteLine ("CLR version: {0}",  System.Environment.Version.ToString ());
			System.Console.WriteLine ("{0}-bit", IntPtr.Size * 8);
			
			System.Console.Write ("Math Assembly: ");
#if XNA
			var xnaName = typeof (Microsoft.Xna.Framework.Vector4).Assembly.GetName ();
			System.Console.WriteLine ("{0} {1}", xnaName.Name, xnaName.Version);
#else
			var att =  (AssemblyDescriptionAttribute) typeof (Mono.GameMath.Vector4)
				.Assembly.GetCustomAttributes (typeof (AssemblyDescriptionAttribute), false)[0];
			System.Console.WriteLine (att.Description);
#endif
			System.Console.WriteLine ();
		}
		
		static int RunTests (string type, string method)
		{
			Type[] testTypes;
			if (type != null) {
				try {
					testTypes = new Type[] { typeof (Driver).Assembly.GetType ("Benchmark." + type, true) };
				} catch {
					System.Console.Error.WriteLine ("Test type '{0}' not found", type);
					return 2;
				}
			} else {
				testTypes = new Type[] {
					typeof (MatrixTest),
					typeof (Vector4Test),
					typeof (Vector3Test),
					typeof (Vector2Test),
				};
			}
			
			int times =10 * 1000 * 1000 ;
			var sw = new System.Diagnostics.Stopwatch ();
			long total = 0;
			
			foreach (var t in testTypes) {
				MethodInfo[] methodInfos;
				if (method != null) {
					methodInfos = new MethodInfo[] { t.GetMethod (method, BindingFlags.Static | BindingFlags.Public) };
					if (methodInfos[0] == null) {
						System.Console.WriteLine ("{0}.{1}: NotFound", t.Name, method);
						continue;
					}
				} else {
					methodInfos = t.GetMethods (BindingFlags.Static | BindingFlags.Public);
				}
				
				Action<int>[] methods = new Action<int> [methodInfos.Length];
				for (int i = 0; i < methodInfos.Length; i++) {
					methods[i] = (Action<int>) Delegate.CreateDelegate (typeof (Action<int>), methodInfos[i]);
					try {
						methods[i] (1);
					} catch (NotImplementedException) {
						methods[i] = null;
					}
				}
				
				for (int i = 0; i < methodInfos.Length; i++) {
					if (methods[i] == null) {
						System.Console.WriteLine ("{0}.{1}: NotImplemented", t.Name, methodInfos[i].Name);	
						continue;
					}
					sw.Reset ();
					sw.Start ();
					methods[i] (times);
					sw.Stop ();
					System.Console.WriteLine ("{0}.{1}: {2}", t.Name, methodInfos[i].Name, sw.ElapsedMilliseconds);
					total += sw.ElapsedMilliseconds;
				}
			}
			
			System.Console.WriteLine ("Total: {0}", total);
			return 0;
		}
	}
}
