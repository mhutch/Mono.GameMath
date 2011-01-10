// 
// Quaternion.cs
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

namespace Mono.GameMath
{
	public struct Quaternion
	{
		public float X, Y, Z, W;
		
		public Quaternion (float x, float y, float z, float w)
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}
		
		public Quaternion (Vector3 vectorPart, float scalarPart)
		{
			X = vectorPart.X;
			Y = vectorPart.Y;
			Z = vectorPart.Z;
			W = scalarPart;
		}
		
		public static Quaternion Identity {
			get {
				return new Quaternion (0, 0, 0, 1);
			}
		}
		
		#region Creation
		
		public static Quaternion CreateFromAxisAngle (Vector3 axis, float angle)
		{
			Quaternion result;
			CreateFromAxisAngle (ref axis, angle, out result);
			return result;
		}
		
		public static void CreateFromAxisAngle (ref Vector3 axis, float angle, out Quaternion result)
		{
			throw new NotImplementedException ();
		}
		
		public static Quaternion CreateFromRotationMatrix (Matrix matrix)
		{
			Quaternion result;
			CreateFromRotationMatrix (ref matrix, out result);
			return result;
		}
		
		public static void CreateFromRotationMatrix (ref Matrix matrix, out Quaternion result)
		{
			throw new NotImplementedException ();
		}
		
		public static Quaternion CreateFromYawPitchRoll (float yaw, float pitch, float roll)
		{
			Quaternion result;
			CreateFromYawPitchRoll (yaw, pitch, roll, out result);
			return result;
		}
		
		public static void CreateFromYawPitchRoll (float yaw, float pitch, float roll, out Quaternion result)
		{
			throw new NotImplementedException ();
		}
		
		#endregion
		
		#region Arithmetic
		
		public static Quaternion Add (Quaternion quaternion1, Quaternion quaternion2)
		{
			Add (ref quaternion1, ref quaternion2, out quaternion1);
			return quaternion1;
		}
		
		public static void Add (ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
		{
			result.X = quaternion1.X + quaternion2.X;
			result.Y = quaternion1.Y + quaternion2.Y;
			result.Z = quaternion1.Z + quaternion2.Z;
			result.W = quaternion1.W + quaternion2.W;
		}
		
		public static Quaternion Subtract (Quaternion quaternion1, Quaternion quaternion2)
		{
			Subtract (ref quaternion1, ref quaternion2, out quaternion1);
			return quaternion1;
		}
		
		public static void Subtract (ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
		{
			result.X = quaternion1.X - quaternion2.X;
			result.Y = quaternion1.Y - quaternion2.Y;
			result.Z = quaternion1.Z - quaternion2.Z;
			result.W = quaternion1.W - quaternion2.W;
		}
		
		public static Quaternion Multiply (Quaternion quaternion1, Quaternion quaternion2)
		{
			Quaternion result;
			Multiply (ref quaternion1, ref quaternion2, out result);
			return result;
		}
		
		public static void Multiply (ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
		{
			throw new NotImplementedException ();
		}
		
		public static Quaternion Multiply (Quaternion quaternion1, float scaleFactor)
		{
			Multiply (ref quaternion1, scaleFactor, out quaternion1);
			return quaternion1;
		}
		
		public static void Multiply (ref Quaternion quaternion1, float scaleFactor, out Quaternion result)
		{
			result.X = quaternion1.X * scaleFactor;
			result.Y = quaternion1.Y * scaleFactor;
			result.Z = quaternion1.Z * scaleFactor;
			result.W = quaternion1.W * scaleFactor;
		}
		
		public static Quaternion Divide (Quaternion quaternion1, Quaternion quaternion2)
		{
			Quaternion result;
			Divide (ref quaternion1, ref quaternion2, out result);
			return result;
		}
		
		public static void Divide (ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
		{
			throw new NotImplementedException ();
		}
		
		public static Quaternion Negate (Quaternion quaternion)
		{
			Negate (ref quaternion, out quaternion);
			return quaternion;
		}
		
		public static void Negate (ref Quaternion quaternion, out Quaternion result)
		{
			result.X = - quaternion.X;
			result.Y = - quaternion.Y;
			result.Z = - quaternion.Z;
			result.W = - quaternion.W;
		}
		
		#endregion
		
		#region Operator overloads
		
		public static Quaternion operator + (Quaternion quaternion1, Quaternion quaternion2)
		{
			return Add (quaternion1, quaternion2);
		}
		
		public static Quaternion operator / (Quaternion quaternion1, Quaternion quaternion2)
		{
			return Divide (quaternion1, quaternion2);
		}
		
		public static Quaternion operator * (Quaternion quaternion1, Quaternion quaternion2)
		{
			return Multiply (quaternion1, quaternion2);
		}
		
		public static Quaternion operator * (Quaternion quaternion, float scaleFactor)
		{
			return Multiply (quaternion, scaleFactor);
		}
		
		public static Quaternion operator - (Quaternion quaternion1, Quaternion quaternion2)
		{
			return Subtract (quaternion1, quaternion2);
		}
		
		public static Quaternion operator - (Quaternion quaternion)
		{
			return Negate (quaternion);
		}
		
		#endregion
		
		#region Other maths
		
		public static Quaternion Concatenate (Quaternion value1, Quaternion value2)
		{
			Quaternion result;
			Concatenate (ref value1, ref value2, out result);
			return result;
		}
		
		public static void Concatenate (ref Quaternion value1, ref Quaternion value2, out Quaternion result)
		{
			throw new NotImplementedException ();
		}
		
		public void Conjugate ()
		{
			Conjugate (ref this, out this);
		}
		
		public static Quaternion Conjugate (Quaternion value)
		{
			Conjugate (ref value, out value);
			return value;
		}
		
		public static void Conjugate (ref Quaternion value, out Quaternion result)
		{
			result.X = - value.X;
			result.Y = - value.Y;
			result.Z = - value.Z;
			result.W = value.W;
		}

		public static float Dot (Quaternion quaternion1, Quaternion quaternion2)
		{
			float result;
			Dot (ref quaternion1, ref quaternion2, out result);
			return result;
		}
		
		public static void Dot (ref Quaternion quaternion1, ref Quaternion quaternion2, out float result)
		{
			throw new NotImplementedException ();
		}
		
		public static Quaternion Inverse (Quaternion quaternion)
		{
			Quaternion result;
			Inverse (ref quaternion, out result);
			return result;
		}
		
		public static void Inverse (ref Quaternion quaternion, out Quaternion result)
		{
			throw new NotImplementedException ();
		}
		
		public float Length ()
		{
			return (float) System.Math.Sqrt (LengthSquared ());
		}
		
		public float LengthSquared ()
		{
			return (X * X) + (Y * Y) + (Z * Z) + (W * W);
		}
		
		public static Quaternion Lerp (Quaternion quaternion1, Quaternion quaternion2, float amount)
		{
			Quaternion result;
			Lerp (ref quaternion1, ref quaternion2, amount, out result);
			return result;
		}
		
		public static void Lerp (ref Quaternion quaternion1, ref Quaternion quaternion2, float amount, out Quaternion result)
		{
			throw new NotImplementedException ();
		}
		
		public void Normalize ()
		{
			Normalize (ref this, out this);
		}
		
		public static Quaternion Normalize (Quaternion quaternion)
		{
			Normalize (ref quaternion, out quaternion);
			return quaternion;
		}
		
		public static void Normalize (ref Quaternion quaternion, out Quaternion result)
		{
			Multiply (ref quaternion, 1f / quaternion.Length (), out result);
		}
		
		public static Quaternion Slerp (Quaternion quaternion1, Quaternion quaternion2, float amount)
		{
			Quaternion result;
			Slerp (ref quaternion1, ref quaternion2, amount, out result);
			return result;
		}
		
		public static void Slerp (ref Quaternion quaternion1, ref Quaternion quaternion2, float amount, out Quaternion result)
		{
			throw new NotImplementedException ();
		}
		
		#endregion

		#region Equality
		
		public bool Equals (Quaternion other)
		{
			return other == this;
		}
		
		public override bool Equals (object obj)
		{
			return obj is Quaternion && ((Quaternion)obj) == this;
		}
		
		public override int GetHashCode ()
		{
			return X.GetHashCode () ^ Y.GetHashCode () ^ Z.GetHashCode () ^ W.GetHashCode ();
		}
		
		public static bool operator == (Quaternion a, Quaternion b)
		{
			return a.X == b.X && a.Y == b.Y && a.Z == b.Z && a.W == b.W;
		}
		
		public static bool operator != (Quaternion a, Quaternion b)
		{
			return a.X != b.X || a.Y != b.Y || a.Z != b.Z || a.W != b.W;
		}
		
		# endregion
		
		public override string ToString ()
		{
			return string.Format("{{X:{0} Y:{1} Z:{2} W:{3}}}", X, Y, Z, W);
		}
	}
}