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

namespace Benchmark
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Type[] testTypes = new [] {
				typeof (Vector4Test),
				typeof (Vector3Test),
				typeof (Vector2Test),
			};
			
			int times =10 * 1000 * 1000 ;
			var sw = new System.Diagnostics.Stopwatch ();
			
			foreach (var t in testTypes) {
				MethodInfo[] methodInfos = t.GetMethods (BindingFlags.Static | BindingFlags.Public);
				Action<int>[] methods = new Action<int> [methodInfos.Length];
				for (int i = 0; i < methodInfos.Length; i++) {
					methods[i] = (Action<int>) Delegate.CreateDelegate (typeof (Action<int>), methodInfos[i]);
					methods[i] (1);
				}
				
				for (int i = 0; i < methodInfos.Length; i++) {
					sw.Reset ();
					sw.Start ();
					methods[i] (times);
					sw.Stop ();
					System.Console.WriteLine ("{0}.{1}: {2}", t.Name, methodInfos[i].Name, sw.ElapsedMilliseconds);
				}
			}
		}
	}
}
