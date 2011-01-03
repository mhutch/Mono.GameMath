// 
// Vector2.cs
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

#if SIMD
using Mono.Simd;
#endif

namespace Mono.GameMath
{
	[Serializable]
	public struct Vector2 : IEquatable<Vector2>
	{
		public float X, Y;
		
		public Vector2 (float value)
		{
			X = Y = value;
		}
		
		public Vector2 (float x, float y)
		{
			X = x;
			Y = y;
		}
		
		#region Static properties
		
		public static Vector2 UnitX {
			get {
				return new Vector2 (1f, 0f);
			}
		}
		
		public static Vector2 UnitY {
			get {
				return new Vector2 (0f, 1f);
			}
		}
		
		public static Vector2 One {
			get {
				return new Vector2 (1f);
			}
		}
		
		public static Vector2 Zero {
			get {
				return new Vector2 (0f);
			}
		}
		
		#endregion
		
		#region Arithmetic
		
		public static Vector2 Add (Vector2 value1, Vector2 value2)
		{
			Add (ref value1, ref value2, out value1);
			return value1;
		}
		
		public static void Add (ref Vector2 value1, ref Vector2 value2, out Vector2 result)
		{
			result.X = value1.X + value2.X;
			result.Y = value1.Y + value2.Y;
		}
		
		public static Vector2 Multiply (Vector2 value1, float scaleFactor)
		{
#if SIMD
			var v4 = new Vector4f (value1.X, value1.Y, 0f, 0f) * new Vector4f (scaleFactor);
			return new Vector2 (v4.X, v4.Y);
#else
			return new Vector2 (value1.X * scaleFactor, value1.Y * scaleFactor);
#endif
		}
		
		public static void Multiply (ref Vector2 value1, float scaleFactor, out Vector2 result)
		{
#if SIMD
			var v4 = new Vector4f (value1.X, value1.Y, 0f, 0f) * new Vector4f (scaleFactor);
			result.X = v4.X;
			result.Y = v4.Y;
#else
			result.X = value1.X * scaleFactor;
			result.Y = value1.Y * scaleFactor;
#endif
		}
		
		public static Vector2 Multiply (Vector2 value1, Vector2 value2)
		{
#if SIMD
			var v4 = new Vector4f (value1.X, value1.Y, 0f, 0f) * new Vector4f (value2.X, value2.Y, 0f, 0f);
			return new Vector2 (v4.X, v4.Y);
#else
			return new Vector2 (value1.X * value2.X, value1.Y * value2.Y);
#endif
		}
		
		public static void Multiply (ref Vector2 value1, ref Vector2 value2, out Vector2 result)
		{
#if SIMD
			var v4 = new Vector4f (value1.X, value1.Y, 0f, 0f) * new Vector4f (value2.X, value2.Y, 0f, 0f);
			result.X = v4.X;
			result.Y = v4.Y;
#else
			result.X = value1.X * value2.X;
			result.Y = value1.Y * value2.Y;
#endif
		}
		
		public static Vector2 Negate (Vector2 value)
		{
			Negate (ref value, out value);
			return value;
		}
		
		public static void Negate (ref Vector2 value, out Vector2 result)
		{
			result.X = - value.X;
			result.Y = - value.Y;
		}
		
		public static Vector2 Divide (Vector2 value1, float divider)
		{
#if SIMD
			var v4 = new Vector4f (value1.X, value1.Y, 0f, 0f) / new Vector4f (divider);
			return new Vector2 (v4.X, v4.Y);
#else
			return new Vector2 (value1.X / divider, value1.Y / divider);
#endif
		}
		
		public static void Divide (ref Vector2 value1, float divider, out Vector2 result)
		{
#if SIMD
			var v4 = new Vector4f (value1.X, value1.Y, 0f, 0f) / new Vector4f (divider);
			result.X = v4.X;
			result.Y = v4.Y;
#else
			result.X = value1.X / divider;
			result.Y = value1.Y / divider;
#endif
		}
		
		public static Vector2 Divide (Vector2 value1, Vector2 value2)
		{
#if SIMD
			var v4 = new Vector4f (value1.X, value1.Y, 0f, 0f) / new Vector4f (value2.X, value2.Y, 0f, 0f);
			return new Vector2 (v4.X, v4.Y);
#else
			return new Vector2 (value1.X / value2.X, value1.Y / value2.X);
#endif
		}
		
		public static void Divide (ref Vector2 value1, ref Vector2 value2, out Vector2 result)
		{
#if SIMD
			var v4 = new Vector4f (value1.X, value1.Y, 0f, 0f) / new Vector4f (value2.X, value2.Y, 0f, 0f);
			result.X = v4.X;
			result.Y = v4.Y;
#else
			result.X = value1.X * value2.X;
			result.Y = value1.Y * value2.X;
#endif
		}
		
		public static Vector2 Subtract (Vector2 value1, Vector2 value2)
		{
			Subtract (ref value1, ref value2, out value1);
			return value1;
		}
		
		public static void Subtract (ref Vector2 value1, ref Vector2 value2, out Vector2 result)
		{
			result.X = value1.X - value2.X;
			result.Y = value1.Y - value2.X;
		}
		
		#endregion
		
		#region Operator overloads
		
		public static Vector2 operator + (Vector2 value1, Vector2 value2)
		{
			return new Vector2 (value1.X + value2.X, value1.Y + value2.Y);
		}
		
		public static Vector2 operator / (Vector2 value, float divider)
		{
#if SIMD
			var v4 = new Vector4f (value.X, value.Y, 0f, 0f) / new Vector4f (divider);
			return new Vector2 (v4.X, v4.Y);
#else
			return new Vector2 (value.X / divider, value.Y / divider);
#endif
		}
		
		public static Vector2 operator / (Vector2 value1, Vector2 value2)
		{
#if SIMD
			var v4 = new Vector4f (value1.X, value1.Y, 0f, 0f) / new Vector4f (value2.X, value2.Y, 0f, 0f);
			return new Vector2 (v4.X, v4.Y);
#else
			return new Vector2 (value1.X / value2.X, value1.Y / value2.Y);
#endif
		}
		
		public static Vector2 operator * (Vector2 value1, Vector2 value2)
		{
#if SIMD
			var v4 = new Vector4f (value1.X, value1.Y, 0f, 0f) * new Vector4f (value2.X, value2.Y, 0f, 0f);
			return new Vector2 (v4.X, v4.Y);
#else
			return new Vector2 (value1.X * value2.X, value1.Y * value2.Y);
#endif
		}
		
		public static Vector2 operator * (Vector2 value, float scaleFactor)
		{
#if SIMD
			var v4 = new Vector4f (value.X, value.Y, 0f, 0f) * new Vector4f (scaleFactor);
			return new Vector2 (v4.X, v4.Y);	
#else
		return new Vector2 (value.X * scaleFactor, value.Y * scaleFactor);
#endif
		}
		
		public static Vector2 operator * (float scaleFactor, Vector2 value)
		{
#if SIMD
			var v4 = new Vector4f (value.X, value.Y, 0f, 0f) * new Vector4f (scaleFactor);
			return new Vector2 (v4.X, v4.Y);	
#else
			return new Vector2 (value.X * scaleFactor, value.Y * scaleFactor);
#endif
		}
		
		public static Vector2 operator - (Vector2 value1, Vector2 value2)
		{
			return new Vector2 (value1.X - value2.X, value1.Y - value2.Y);
		}
		
		public static Vector2 operator - (Vector2 value)
		{
			return new Vector2 (- value.X, - value.Y);
		}
		
		#endregion
		
		#region Interpolation
		
		public static Vector2 CatmullRom (Vector2 value1, Vector2 value2, Vector2 value3, Vector2 value4, float amount)
		{
			CatmullRom (ref value1, ref value2, ref value3, ref value4, amount, out value1);
			return value1;
		}
		
		public static void CatmullRom (ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, ref Vector2 value4,
			float amount, out Vector2 result)
		{
			//FIXME: probably more efficient to share work between values
			result.X = MathHelper.CatmullRom (value1.X, value2.X, value3.X, value4.X, amount);
			result.Y = MathHelper.CatmullRom (value1.Y, value2.Y, value3.Y, value4.Y, amount);;
		}
		
		public static Vector2 Hermite (Vector2 value1, Vector2 tangent1, Vector2 value2, Vector2 tangent2, float amount)
		{
			Hermite (ref value1, ref tangent1, ref value2, ref tangent2, amount, out value1);
			return value1;
		}
		
		public static void Hermite (ref Vector2 value1, ref Vector2 tangent1, ref Vector2 value2, ref Vector2 tangent2,
			float amount, out Vector2 result)
		{
			float s = amount;
			float s2 = s * s;
			float s3 = s2 * s;
			
			float h1 =  2 * s3 - 3 * s2 + 1;
			float h2 = -2 * s3 + 3 * s2    ;
			float h3 =      s3 - 2 * s2 + s;
			float h4 =      s3 -     s2    ;
			
			result.X = h1 * value1.X + h2 * value2.X + h3 * tangent1.X + h4 * tangent2.X;
			result.Y = h1 * value1.Y + h2 * value2.Y + h3 * tangent1.Y + h4 * tangent2.Y;
		}
		
		public static Vector2 Lerp (Vector2 value1, Vector2 value2, float amount)
		{
			Lerp (ref value1, ref value2, amount, out value1);
			return value1;
		}
		
		public static void Lerp (ref Vector2 value1, ref Vector2 value2, float amount, out Vector2 result)
		{
			Subtract (ref value2, ref value1, out result);
			Multiply (ref result, amount, out result);
			Add (ref value1, ref result, out result);
		}
		
		public static Vector2 SmoothStep (Vector2 value1, Vector2 value2, float amount)
		{
			SmoothStep (ref value1, ref value2, amount, out value1);
			return value1;
		}
		
		public static void SmoothStep (ref Vector2 value1, ref Vector2 value2, float amount, out Vector2 result)
		{
			float scale = (amount * amount * (3 - 2 * amount));
			Subtract (ref value2, ref value1, out result);
			Multiply (ref result, scale, out result);
			Add (ref value1, ref result, out result);
		}
		
		#endregion
		
		#region Other maths
		
		public static Vector2 Barycentric (Vector2 value1, Vector2 value2, Vector2 value3, float amount1, float amount2)
		{
			Barycentric (ref value1, ref value2, ref value3, amount1, amount2, out value1);
			return value1;
		}
		
		public static void Barycentric (ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, float amount1,
			float amount2, out Vector2 result)
		{
			//FIXME: probably more efficient to share work between values
			result.X = MathHelper.Barycentric (value1.X, value2.X, value3.X, amount1, amount2);
			result.Y = MathHelper.Barycentric (value1.X, value2.X, value3.X, amount1, amount2);
		}
		
		public static Vector2 Clamp (Vector2 value1, Vector2 min, Vector2 max)
		{
			Clamp (ref value1, ref min, ref max, out value1);
			return value1;
		}
		
		public static void Clamp (ref Vector2 value1, ref Vector2 min, ref Vector2 max, out Vector2 result)
		{
/*#if SIMD
			var v4 = VectorOperations.Min (VectorOperations.Max (
				new Vector4f (value1.X, value1.Y, 0f, 0f),
				new Vector4f (min.X, min.Y, 0f, 0f)),
				new Vector4f (max.X, max.Y, 0f, 0f));
			result = new Vector2 (v4.X, v4.Y);
#else*/
			result.X = MathHelper.Clamp (value1.X, min.X, max.X);
			result.Y = MathHelper.Clamp (value1.Y, min.Y, max.Y);
//#endif
		}
		
		public static float Distance (Vector2 value1, Vector2 value2)
		{
			float result;
			Distance (ref value1, ref value2, out result);
			return result;
		}
		
		public static void Distance (ref Vector2 value1, ref Vector2 value2, out float result)
		{
#if SIMD
			Vector4f r0 = new Vector4f (value2.X - value1.X, value2.Y - value1.Y, 0f, 0f);
			r0 = r0 * r0;
			r0 = r0 + r0.Shuffle (ShuffleSel.Swap);
			r0 = r0 + r0.Shuffle (ShuffleSel.RotateLeft);
			result = r0.Sqrt ().X;
#else
			DistanceSquared (ref value1, ref value2, out result);
			result = (float) System.Math.Sqrt (result);
#endif
		}
		
		public static float DistanceSquared (Vector2 value1, Vector2 value2)
		{
			float result;
			DistanceSquared (ref value1, ref value2, out result);
			return result;
		}
		
		public static void DistanceSquared (ref Vector2 value1, ref Vector2 value2, out float result)
		{
			Vector2 val;
			Subtract (ref value1, ref value2, out val);
			result = val.LengthSquared ();
		}
		
		public static float Dot (Vector2 value1, Vector2 value2)
		{
			float result;
			Dot (ref value1, ref value2, out result);
			return result;
		}
		
		public static void Dot (ref Vector2 value1, ref Vector2 value2, out float result)
		{
			result = value1.X * value2.X + value1.Y * value2.Y;
		}
		
		public float Length ()
		{
			return (float) System.Math.Sqrt (LengthSquared ());
		}
		
		public float LengthSquared ()
		{
			return X * X + Y * Y;
		}
		
		public static Vector2 Max (Vector2 value1, Vector2 value2)
		{
			Max (ref value1, ref value2, out value1);
			return value1;
		}
		
		public static void Max (ref Vector2 value1, ref Vector2 value2, out Vector2 result)
		{
			result.X = MathHelper.Max (value1.X, value2.X);
			result.Y = MathHelper.Max (value1.X, value2.X);
		}
		
		public static Vector2 Min (Vector2 value1, Vector2 value2)
		{
			Min (ref value1, ref value2, out value1);
			return value1;
		}
		
		public static void Min (ref Vector2 value1, ref Vector2 value2, out Vector2 result)
		{
			result.X = MathHelper.Min (value1.X, value2.X);
			result.Y = MathHelper.Min (value1.X, value2.X);
		}
		
		public void Normalize ()
		{
			Normalize (ref this, out this);
		}
		
		public static Vector2 Normalize (Vector2 value)
		{
			value.Normalize ();
			return value;
		}
		
		public static void Normalize (ref Vector2 value, out Vector2 result)
		{
/*#if SIMD
			Vector4f v4 = new Vector4f (value.X, value.Y, 0f, 0f);
			Vector4f r0 = v4 * v4;
			r0 = r0 + r0.Shuffle (ShuffleSel.Swap);
			r0 = r0 + r0.Shuffle (ShuffleSel.RotateLeft);
			v4 = v4 / r0.Sqrt ();
			result.X = v4.X;
			result.Y = v4.Y;
#else*/
			var l = value.Length ();
			result.X = value.X / l;
			result.Y = value.Y / l;
//#endif
		}
		
		public static Vector2 Reflect (Vector2 vector, Vector2 normal)
		{
			Vector2 result;
			Reflect (ref vector, ref normal, out result);
			return result;
		}
		
		public static void Reflect (ref Vector2 vector, ref Vector2 normal, out Vector2 result)
		{
			throw new NotImplementedException ();
		}
		
		#endregion
		
		#region Transform
		
		public static Vector2 Transform (Vector2 position, Matrix matrix)
		{
			Vector2 result;
			Transform (ref position, ref matrix, out result);
			return result;
		}
		
		public static void Transform (ref Vector2 position, ref Matrix matrix, out Vector2 result)
		{
			throw new NotImplementedException ();
		}
		
		public static Vector2 Transform (Vector2 value, Quaternion rotation)
		{
			Vector2 result;
			Transform (ref value, ref rotation, out result);
			return result;
		}
		
		public static void Transform (ref Vector2 value, ref Quaternion rotation, out Vector2 result)
		{
			throw new NotImplementedException ();
		}
		
		static void CheckArrayArgs (Vector2[] sourceArray, int sourceIndex, Vector2[] destinationArray,
			int destinationIndex, int length)
		{
			if (sourceArray == null)
				throw new ArgumentNullException ("sourceArray");
			if (destinationArray == null)
				throw new ArgumentNullException ("destinationArray");
			if (sourceIndex + length > sourceArray.Length)
				throw new ArgumentException ("Source is smaller than specified length and index");
			if (destinationIndex + length > destinationArray.Length)
				throw new ArgumentException ("Destination is smaller than specified length and index");
		}
		
		static void CheckArrayArgs (Vector2[] sourceArray, Vector2[] destinationArray)
		{
			if (sourceArray == null)
				throw new ArgumentNullException ("sourceArray");
			if (destinationArray == null)
				throw new ArgumentNullException ("destinationArray");
			if (destinationArray.Length < sourceArray.Length)
				throw new ArgumentException ("Destination is smaller than source", "destinationArray");
		}
		
		public static void Transform (Vector2[] sourceArray, int sourceIndex, ref Matrix matrix,
			Vector2[] destinationArray, int destinationIndex, int length)
		{
			CheckArrayArgs (sourceArray, sourceIndex, destinationArray, destinationIndex, length);
			
			int smax = sourceIndex + length;
			for (int s = sourceIndex, d = destinationIndex; s < smax; s++, d++)
				Transform (ref sourceArray[s], ref matrix, out destinationArray[d]);
		}
		
		public static void Transform (Vector2[] sourceArray, int sourceIndex, ref Quaternion rotation,
			Vector2[] destinationArray, int destinationIndex, int length)
		{
			CheckArrayArgs (sourceArray, sourceIndex, destinationArray, destinationIndex, length);
			
			int smax = sourceIndex + length;
			for (int s = sourceIndex, d = destinationIndex; s < smax; s++, d++)
				Transform (ref sourceArray[s], ref rotation, out destinationArray[d]);
		}
		
		public static void Transform (Vector2[] sourceArray, ref Matrix matrix, Vector2[] destinationArray)
		{
			CheckArrayArgs (sourceArray, destinationArray);
			
			for (int i = 0; i < sourceArray.Length; i++)
				Transform (ref sourceArray[i], ref matrix, out destinationArray[i]);
		}
		
		public static void Transform (Vector2[] sourceArray, ref Quaternion rotation, Vector2[] destinationArray)
		{
			CheckArrayArgs (sourceArray, destinationArray);
			
			for (int i = 0; i < sourceArray.Length; i++)
				Transform (ref sourceArray[i], ref rotation, out destinationArray[i]);
		}
		
		#endregion
		
		#region TransformNormal
		
		public static Vector2 TransformNormal (Vector2 normal, Matrix matrix)
		{
			Vector2 result;
			TransformNormal (ref normal, ref matrix, out result);
			return result;
		}
		
		public static void TransformNormal (ref Vector2 normal, ref Matrix matrix, out Vector2 result)
		{
			throw new NotImplementedException ();
		}
		
		public static void TransformNormal (Vector2[] sourceArray, int sourceIndex, ref Matrix matrix,
			Vector2[] destinationArray, int destinationIndex, int length)
		{
			CheckArrayArgs (sourceArray, sourceIndex, destinationArray, destinationIndex, length);
			
			int smax = sourceIndex + length;
			for (int s = sourceIndex, d = destinationIndex; s < smax; s++, d++)
				TransformNormal (ref sourceArray[s], ref matrix, out destinationArray[d]);
		}
		
		public static void TransformNormal (Vector2[] sourceArray, ref Matrix matrix, Vector2[] destinationArray)
		{
			CheckArrayArgs (sourceArray, destinationArray);
			
			for (int i = 0; i < sourceArray.Length; i++)
				TransformNormal (ref sourceArray[i], ref matrix, out destinationArray[i]);
		}
		
		#endregion
		
		#region Equality
		
		public bool Equals (Vector2 other)
		{
			return X == other.X && Y == other.Y;
		}
		
		public override bool Equals (object obj)
		{
			return obj is Vector2 && ((Vector2)obj) == this;
		}
		
		public override int GetHashCode ()
		{
			return X.GetHashCode () ^ Y.GetHashCode ();
		}
		
		public static bool operator == (Vector2 a, Vector2 b)
		{
			return a.X == b.X && a.Y == b.Y;
		}
		
		public static bool operator != (Vector2 a, Vector2 b)
		{
			return a.X != b.X || a.Y != b.Y;
		}
		
		# endregion
		
		public override string ToString ()
		{
			throw new NotImplementedException ();
		}
	}
}