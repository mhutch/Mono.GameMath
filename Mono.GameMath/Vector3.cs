// 
// Vector3.cs
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
	public struct Vector3 : IEquatable<Vector3>
	{
#if SIMD
		internal Vector4f v4;
		public float X { get { return v4.X; } set { v4.X = value; } }
		public float Y { get { return v4.Y; } set { v4.Y = value; } }
		public float Z { get { return v4.Z; } set { v4.Z = value; } }
		internal Vector3 (Vector4f v4) { this.v4 = v4; }
#else
		internal float x, y, z;
		public float X { get { return x; } set { x = value; } }
		public float Y { get { return y; } set { y = value; } }
		public float Z { get { return z; } set { z = value; } }
#endif
		
		public Vector3 (float value)
#if SIMD
		{
			v4 = new Vector4f (value);
		}
#else
		: this (value, value, value)
		{
		}
#endif
		
		public Vector3 (Vector2 value, float z) : this (value.X, value.Y, z)
		{
		}
		
		public Vector3 (float x, float y, float z)
		{
#if SIMD
			v4 = new Vector4f (x, y, z, 0f);
#else
			this.x = x;
			this.y = y;
			this.z = z;
#endif
		}
		
		#region Static properties
		
		public static Vector3 Right {
			get { return new Vector3 (1f, 0f, 0f); }
		}
		
		public static Vector3 Left {
			get { return new Vector3 (-1f, 0f, 0f); }
		}
		
		public static Vector3 Up {
			get { return new Vector3 (0f, 1f, 0f); }
		}
		
		public static Vector3 Down {
			get { return new Vector3 (0f, -1f, 0f); }
		}
		
		public static Vector3 Backward {
			get { return new Vector3 (0f, 0f, 1f); }
		}
		
		public static Vector3 Forward {
			get { return new Vector3 (0f, 0f, -1f); }
		}
		
		public static Vector3 UnitX {
			get { return new Vector3 (1f, 0f, 0f); }
		}
		
		public static Vector3 UnitY {
			get { return new Vector3 (0f, 1f, 0f); }
		}
		
		public static Vector3 UnitZ {
			get { return new Vector3 (0f, 0f, 1f); }
		}
		
		public static Vector3 One {
			get { return new Vector3 (1f); }
		}
		
		public static Vector3 Zero {
			get { return new Vector3 (0f); }
		}
		
		#endregion
		
		#region Arithmetic
		
		public static Vector3 Add (Vector3 value1, Vector3 value2)
		{
#if SIMD
			return new Mono.GameMath.Vector3 (value1.v4 + value2.v4);
#else
			return new Vector3 (value1.x + value2.x, value1.y + value2.y, value1.z + value2.z);
#endif
		}
		
		public static void Add (ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
#if SIMD
			result.v4 = value1.v4 + value2.v4;
#else
			result.x = value1.x + value2.x;
			result.y = value1.y + value2.y;
			result.z = value1.z + value2.z;
#endif
		}
		
		public static Vector3 Divide (Vector3 value1, float value2)
		{
#if SIMD
			return new Vector3 (value1.v4 / new Vector4f (value2));
#else
			return new Vector3 (value1.x / value2, value1.y / value2, value1.z / value2);
#endif
		}
		
		public static void Divide (ref Vector3 value1, float value2, out Vector3 result)
		{
#if SIMD
			result.v4 = value1.v4 / new Vector4f (value2);
#else
			result.x = value1.x / value2;
			result.y = value1.y / value2;
			result.z = value1.z / value2;
#endif
		}
		
		public static Vector3 Divide (Vector3 value1, Vector3 value2)
		{
#if SIMD
			return new Vector3 (value1.v4 / value2.v4);
#else
			return new Vector3 (value1.x / value2.x, value1.y / value2.y, value1.z / value2.z);
#endif
		}
		
		public static void Divide (ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
#if SIMD
			result.v4 = value1.v4 / value2.v4;
#else
			result.x = value1.x / value2.x;
			result.y = value1.y / value2.y;
			result.z = value1.z / value2.z;
#endif
		}
		
		public static Vector3 Multiply (Vector3 value1, float scaleFactor)
		{
#if SIMD
			return new Vector3 (value1.v4 * new Vector4f (scaleFactor));
#else
			return new Vector3 (value1.x * scaleFactor, value1.y * scaleFactor, value1.z * scaleFactor);
#endif
		}
		
		public static void Multiply (ref Vector3 value1, float scaleFactor, out Vector3 result)
		{
#if SIMD
			result.v4 = value1.v4 * new Vector4f (scaleFactor);
#else
			result.x = value1.x * scaleFactor;
			result.y = value1.y * scaleFactor;
			result.z = value1.z * scaleFactor;
#endif
		}
		
		public static Vector3 Multiply (Vector3 value1, Vector3 value2)
		{
#if SIMD
		return new Vector3 (value1.v4 * value2.v4);	
#else
		return new Vector3 (value1.x * value2.x, value1.y * value2.y, value1.z * value2.z);
#endif
		}
		
		public static void Multiply (ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
#if SIMD
			result.v4 = value1.v4 * value2.v4;
#else
			result.x = value1.x * value2.x;
			result.y = value1.y * value2.y;
			result.z = value1.z * value2.z;
#endif
		}
		
		public static Vector3 Negate (Vector3 value)
		{
#if SIMD
			return new Vector3 (value.v4 ^ new Vector4f (-0.0f));
#else
			return new Vector3 (- value.x, - value.y, - value.z);
#endif
		}
		
		public static void Negate (ref Vector3 value, out Vector3 result)
		{
#if SIMD
			result.v4 = value.v4 ^ new Vector4f (-0.0f);
#else
			result.x = - value.x;
			result.y = - value.y;
			result.z = - value.z;
#endif
		}
		
		public static Vector3 Subtract (Vector3 value1, Vector3 value2)
		{
#if SIMD
			return new Vector3 (value1.v4 - value2.v4);
#else
			return new Vector3 (value1.x - value2.x, value1.y - value2.y, value1.z - value2.z);
#endif
		}
		
		public static void Subtract (ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
#if SIMD
			result.v4 = value1.v4 - value2.v4;
#else
			result.x = value1.x - value2.x;
			result.y = value1.y - value2.y;
			result.z = value1.z - value2.z;
#endif
		}
		
		#endregion
		
		#region Operator overloads
		
		public static Vector3 operator + (Vector3 value1, Vector3 value2)
		{
#if SIMD
			return new Mono.GameMath.Vector3 (value1.v4 + value2.v4);
#else
			return new Vector3 (value1.x + value2.x, value1.y + value2.y, value1.z + value2.z);
#endif
		}
		
		public static Vector3 operator / (Vector3 value, float divider)
		{
#if SIMD
			return new Vector3 (value.v4 / new Vector4f (divider));
#else
			return new Vector3 (value.x / divider, value.y / divider, value.z / divider);
#endif
		}
		
		public static Vector3 operator / (Vector3 value1, Vector3 value2)
		{
#if SIMD
			return new Vector3 (value1.v4 / value2.v4);
#else
			return new Vector3 (value1.x / value2.x, value1.y / value2.y, value1.z / value2.z);
#endif
		}
		
		public static Vector3 operator * (Vector3 value1, Vector3 value2)
		{
#if SIMD
			return new Vector3 (value1.v4 * value2.v4);
#else
			return new Vector3 (value1.x * value2.x, value1.y * value2.y, value1.z * value2.z);
#endif
		}
		
		public static Vector3 operator * (Vector3 value, float scaleFactor)
		{
#if SIMD
		return new Vector3 (value.v4 * scaleFactor);	
#else
		return new Vector3 (value.x * scaleFactor, value.y * scaleFactor, value.z * scaleFactor);
#endif
		}
		
		public static Vector3 operator * (float scaleFactor, Vector3 value)
		{
#if SIMD
		return new Vector3 (scaleFactor* value.v4);	
#else
		return new Vector3 (value.x * scaleFactor, value.y * scaleFactor, value.z * scaleFactor);
#endif
		}
		
		public static Vector3 operator - (Vector3 value1, Vector3 value2)
		{
#if SIMD
			return new Vector3 (value1.v4 - value2.v4);
#else
			return new Vector3 (value1.x - value2.x, value1.y - value2.y, value1.z - value2.z);
#endif
		}
		
		public static Vector3 operator - (Vector3 value)
		{
#if SIMD
			return new Vector3 (value.v4 ^ new Vector4f (-0.0f));
#else
			return new Vector3 (- value.x, - value.y, - value.z);
#endif
		}
		
		#endregion
		
		#region Interpolation
		
		public static Vector3 CatmullRom (Vector3 value1, Vector3 value2, Vector3 value3, Vector3 value4, float amount)
		{
			CatmullRom (ref value1, ref value2, ref value3, ref value4, amount, out value1);
			return value1;
		}
		
		public static void CatmullRom (ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, ref Vector3 value4,
			float amount, out Vector3 result)
		{
#if SIMD
			result.v4 = new Vector4f (
				MathHelper.CatmullRom (value1.X, value2.X, value3.X, value4.X, amount),
				MathHelper.CatmullRom (value1.Y, value2.Y, value3.Y, value4.Y, amount),
				MathHelper.CatmullRom (value1.Z, value2.Z, value3.Z, value4.Z, amount),
				0);
#else
			result.x = MathHelper.CatmullRom (value1.x, value2.x, value3.x, value4.x, amount);
			result.y = MathHelper.CatmullRom (value1.y, value2.y, value3.y, value4.y, amount);
			result.z = MathHelper.CatmullRom (value1.z, value2.z, value3.z, value4.z, amount);
#endif
		}
		
		public static Vector3 Hermite (Vector3 value1, Vector3 tangent1, Vector3 value2, Vector3 tangent2, float amount)
		{
			Hermite (ref value1, ref tangent1, ref value2, ref tangent2, amount, out value1);
			return value1;
		}
		
		public static void Hermite (ref Vector3 value1, ref Vector3 tangent1, ref Vector3 value2, ref Vector3 tangent2,
			float amount, out Vector3 result)
		{
#if SIMD
			var s = new Vector4f (amount);
			var s2 = s * s;
			var s3 = s2 * s;
			var c1 = new Vector4f (1f);
			var c2 = new Vector4f (2f);
			var m2 = new Vector4f (-2f);
			var c3 = new Vector4f (3f);
			
			var h1 = c2 * s3 - c3 * s2 + c1;
			var h2 = m2 * s3 + c3 * s2;
			var h3 = s3 - 2 * s2 + s;
			var h4 = s3 - s2;
			
			result.v4 = h1 * value1.v4 + h2 * value2.v4 + h3 * tangent1.v4 + h4 * tangent2.v4;
#else
			float s = amount;
			float s2 = s * s;
			float s3 = s2 * s;
			
			float h1 =  2 * s3 - 3 * s2 + 1;
			float h2 = -2 * s3 + 3 * s2    ;
			float h3 =      s3 - 2 * s2 + s;
			float h4 =      s3 -     s2    ;
			
			result.x = h1 * value1.x + h2 * value2.x + h3 * tangent1.x + h4 * tangent2.x;
			result.y = h1 * value1.y + h2 * value2.y + h3 * tangent1.y + h4 * tangent2.y;
			result.z = h1 * value1.z + h2 * value2.z + h3 * tangent1.z + h4 * tangent2.z;
#endif
		}
		
		public static Vector3 Lerp (Vector3 value1, Vector3 value2, float amount)
		{
			Lerp (ref value1, ref value2, amount, out value1);
			return value1;
		}
		
		public static void Lerp (ref Vector3 value1, ref Vector3 value2, float amount, out Vector3 result)
		{
#if SIMD
			result.v4 = value1.v4 + (value2.v4 - value1.v4) * amount; 
#else
			result.x = value1.x + (value2.x - value1.x) * amount;
			result.y = value1.y + (value2.y - value1.y) * amount;
			result.z = value1.z + (value2.z - value1.z) * amount;
#endif
		}
		
		public static Vector3 SmoothStep (Vector3 value1, Vector3 value2, float amount)
		{
			SmoothStep (ref value1, ref value2, amount, out value1);
			return value1;
		}
		
		public static void SmoothStep (ref Vector3 value1, ref Vector3 value2, float amount, out Vector3 result)
		{
			float scale = (amount * amount * (3 - 2 * amount));	
#if SIMD
			result.v4 = value1.v4 + (value2.v4 - value1.v4) * scale; 
#else
			result.x = value1.x + (value2.x - value1.x) * scale;
			result.y = value1.y + (value2.y - value1.y) * scale;
			result.z = value1.z + (value2.z - value1.z) * scale;
#endif
		}
		
		#endregion
		
		#region Other maths
		
		public static Vector3 Barycentric (Vector3 value1, Vector3 value2, Vector3 value3, float amount1, float amount2)
		{
			Barycentric (ref value1, ref value2, ref value3, amount1, amount2, out value1);
			return value1;
		}
		
		public static void Barycentric (ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, float amount1,
			float amount2, out Vector3 result)
		{
#if SIMD
			result.v4 = new Vector4f (
				MathHelper.Barycentric (value1.X, value2.X, value3.X, amount1, amount2),
				MathHelper.Barycentric (value1.Y, value2.Y, value3.Y, amount1, amount2),
				MathHelper.Barycentric (value1.Z, value2.Z, value3.Z, amount1, amount2),
				0);
#else
			result.x = MathHelper.Barycentric (value1.x, value2.x, value3.x, amount1, amount2);
			result.y = MathHelper.Barycentric (value1.y, value2.y, value3.y, amount1, amount2);
			result.z = MathHelper.Barycentric (value1.z, value2.z, value3.z, amount1, amount2);
#endif
		}
		
		public static Vector3 Clamp (Vector3 value1, Vector3 min, Vector3 max)
		{
			Clamp (ref value1, ref min, ref max, out value1);
			return value1;
		}
		
		public static void Clamp (ref Vector3 value1, ref Vector3 min, ref Vector3 max, out Vector3 result)
		{
#if SIMD
			result.v4 = VectorOperations.Min (VectorOperations.Max (value1.v4, min.v4), max.v4);
#else
			result.x = MathHelper.Clamp (value1.x, min.x, max.x);
			result.y = MathHelper.Clamp (value1.y, min.y, max.y);
			result.z = MathHelper.Clamp (value1.z, min.z, max.z);
#endif
		}
		
		public static Vector3 Cross (Vector3 vector1, Vector3 vector2)
		{
			Vector3 result;
			Cross (ref vector1, ref vector2, out result);
			return result;
		}
		
		public static void Cross (ref Vector3 vector1, ref Vector3 vector2, out Vector3 result)
		{
#if SIMD
			Vector4f r1 = vector1.v4;
			Vector4f r2 = vector2.v4;
			result.v4 =
				r1.Shuffle (ShuffleSel.XFromY | ShuffleSel.YFromZ | ShuffleSel.ZFromX | ShuffleSel.WFromW) *
				r2.Shuffle (ShuffleSel.XFromZ | ShuffleSel.YFromX | ShuffleSel.ZFromY | ShuffleSel.WFromW) -
				r1.Shuffle (ShuffleSel.XFromZ | ShuffleSel.YFromX | ShuffleSel.ZFromY | ShuffleSel.WFromW) *
				r2.Shuffle (ShuffleSel.XFromY | ShuffleSel.YFromZ | ShuffleSel.ZFromX | ShuffleSel.WFromW);
#else
			result.x = vector1.y * vector2.z - vector1.z * vector2.y;
			result.y = vector1.z * vector2.x - vector1.x * vector2.z;
			result.z = vector1.x * vector2.y - vector1.y * vector2.x;
#endif
		}
		
		public static float Distance (Vector3 value1, Vector3 value2)
		{
			float result;
			Distance (ref value1, ref value2, out result);
			return result;
		}
		
		public static void Distance (ref Vector3 value1, ref Vector3 value2, out float result)
		{
#if SIMD
			Vector4f r0 = value2.v4 - value1.v4;
			r0 = r0 * r0;
			r0 = r0 + r0.Shuffle (ShuffleSel.Swap);
			r0 = r0 + r0.Shuffle (ShuffleSel.RotateLeft);
			result = r0.Sqrt ().X;
#else
			DistanceSquared (ref value1, ref value2, out result);
			result = (float) System.Math.Sqrt (result);
#endif
		}
		
		public static float DistanceSquared (Vector3 value1, Vector3 value2)
		{
			float result;
			DistanceSquared (ref value1, ref value2, out result);
			return result;
		}
		
		public static void DistanceSquared (ref Vector3 value1, ref Vector3 value2, out float result)
		{
#if SIMD
			Vector4f r0 = value2.v4 - value1.v4;
			r0 = r0 * r0;
			r0 = r0 + r0.Shuffle (ShuffleSel.Swap);
			r0 = r0 + r0.Shuffle (ShuffleSel.RotateLeft);
			result = r0.X;
#else
			Subtract (ref value1, ref value2, out value1);
			result = value1.LengthSquared ();
#endif
		}
		
		public static float Dot (Vector3 vector1, Vector3 vector2)
		{
			float result;
			Dot (ref vector1, ref vector2, out result);
			return result;
		}
		
		public static void Dot (ref Vector3 vector1, ref Vector3 vector2, out float result)
		{
#if SIMD
			Vector4f r0 = vector2.v4 * vector1.v4;
			r0 = r0 + r0.Shuffle (ShuffleSel.Swap);
			r0 = r0 + r0.Shuffle (ShuffleSel.RotateLeft);
			result = r0.Sqrt ().X;
#else
			result = (vector1.x * vector2.x) + (vector1.y * vector2.y) + (vector1.z * vector2.z);
#endif
		}
		
		public float Length ()
		{
#if SIMD
			Vector4f r0 = v4;
			r0 = r0 * r0;
			r0 = r0 + r0.Shuffle (ShuffleSel.Swap);
			r0 = r0 + r0.Shuffle (ShuffleSel.RotateLeft);
			return r0.Sqrt ().X;
#else
			return (float) System.Math.Sqrt (LengthSquared ());
#endif	
		}
		
		public float LengthSquared ()
		{
#if SIMD
			Vector4f r0 = v4;
			r0 = r0 * r0;
			r0 = r0 + r0.Shuffle (ShuffleSel.Swap);
			r0 = r0 + r0.Shuffle (ShuffleSel.RotateLeft);
			return r0.X;
#else
			return (x * x) + (y * y) + (z * z);
#endif
		}
		
		public static Vector3 Max (Vector3 value1, Vector3 value2)
		{
			Max (ref value1, ref value2, out value1);
			return value1;
		}
		
		public static void Max (ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
#if SIMD
			result.v4 = VectorOperations.Max (value1.v4, value2.v4);
#else
			result.x = System.Math.Max (value1.x, value2.x);
			result.y = System.Math.Max (value1.y, value2.y);
			result.z = System.Math.Max (value1.z, value2.z);
#endif
		}
		
		public static Vector3 Min (Vector3 value1, Vector3 value2)
		{
			Min (ref value1, ref value2, out value1);
			return value1;
		}
		
		public static void Min (ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
#if SIMD
			result.v4 = VectorOperations.Min (value1.v4, value2.v4);
#else
			result.x = System.Math.Min (value1.x, value2.x);
			result.y = System.Math.Min (value1.y, value2.y);
			result.z = System.Math.Min (value1.z, value2.z);
#endif
		}
		
		public void Normalize ()
		{
			Normalize (ref this, out this);
		}
		
		public static Vector3 Normalize (Vector3 value)
		{
			value.Normalize ();
			return value;
		}
		
		public static void Normalize (ref Vector3 value, out Vector3 result)
		{
#if SIMD
			Vector4f r0 = value.v4;
			r0 = r0 * r0;
			r0 = r0 + r0.Shuffle (ShuffleSel.Swap);
			r0 = r0 + r0.Shuffle (ShuffleSel.RotateLeft);
			result.v4 = value.v4 / r0.Sqrt ();
#else
			var l = value.Length ();
			result.x = value.x / l;
			result.y = value.y / l;
			result.z = value.z / l;
#endif
		}
		
		public static Vector3 Reflect (Vector3 vector, Vector3 normal)
		{
			Vector3 result;
			Reflect (ref vector, ref normal, out result);
			return result;
		}
		
		public static void Reflect (ref Vector3 vector, ref Vector3 normal, out Vector3 result)
		{
#if SIMD
			Vector4f v = vector.v4, n = normal.v4;
			Vector4f r0 = v * n;
			r0 = r0 + r0.Shuffle (ShuffleSel.Swap);
			r0 = r0 + r0.Shuffle (ShuffleSel.RotateLeft);
			r0 = r0.Sqrt ();
			result.v4 = (r0 + r0) * n - v;
			
#else
			float d2 = (float) System.Math.Sqrt (normal.x * vector.x + normal.y * vector.y + normal.z * vector.z);
			d2 = d2 + d2;
			result.x = d2 * normal.x - vector.x;
			result.y = d2 * normal.y - vector.y;
			result.z = d2 * normal.z - vector.z;
#endif
		}
		
		#endregion
		
		#region Transform
		
		public static Vector3 Transform (Vector3 position, Matrix matrix)
		{
			Vector3 result;
			Transform (ref position, ref matrix, out result);
			return result;
		}
		
		public static void Transform (ref Vector3 position, ref Matrix matrix, out Vector3 result)
		{
			throw new NotImplementedException ();
		}
		
		public static Vector3 Transform (Vector3 value, Quaternion rotation)
		{
			Vector3 result;
			Transform (ref value, ref rotation, out result);
			return result;
		}
		
		public static void Transform (ref Vector3 value, ref Quaternion rotation, out Vector3 result)
		{
			throw new NotImplementedException ();
		}
		
		static void CheckArrayArgs (Vector3[] sourceArray, int sourceIndex, Vector3[] destinationArray,
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
		
		static void CheckArrayArgs (Vector3[] sourceArray, Vector3[] destinationArray)
		{
			if (sourceArray == null)
				throw new ArgumentNullException ("sourceArray");
			if (destinationArray == null)
				throw new ArgumentNullException ("destinationArray");
			if (destinationArray.Length < sourceArray.Length)
				throw new ArgumentException ("Destination is smaller than source", "destinationArray");
		}
		
		public static void Transform (Vector3[] sourceArray, int sourceIndex, ref Matrix matrix,
			Vector3[] destinationArray, int destinationIndex, int length)
		{
			CheckArrayArgs (sourceArray, sourceIndex, destinationArray, destinationIndex, length);
			
			int smax = sourceIndex + length;
			for (int s = sourceIndex, d = destinationIndex; s < smax; s++, d++)
				Transform (ref sourceArray[s], ref matrix, out destinationArray[d]);
		}
		
		public static void Transform (Vector3[] sourceArray, int sourceIndex, ref Quaternion rotation,
			Vector3[] destinationArray, int destinationIndex, int length)
		{
			CheckArrayArgs (sourceArray, sourceIndex, destinationArray, destinationIndex, length);
			
			int smax = sourceIndex + length;
			for (int s = sourceIndex, d = destinationIndex; s < smax; s++, d++)
				Transform (ref sourceArray[s], ref rotation, out destinationArray[d]);
		}
		
		public static void Transform (Vector3[] sourceArray, ref Matrix matrix, Vector3[] destinationArray)
		{
			CheckArrayArgs (sourceArray, destinationArray);
			
			for (int i = 0; i < sourceArray.Length; i++)
				Transform (ref sourceArray[i], ref matrix, out destinationArray[i]);
		}
		
		public static void Transform (Vector3[] sourceArray, ref Quaternion rotation, Vector3[] destinationArray)
		{
			CheckArrayArgs (sourceArray, destinationArray);
			
			for (int i = 0; i < sourceArray.Length; i++)
				Transform (ref sourceArray[i], ref rotation, out destinationArray[i]);
		}
		
		#endregion
		
		#region TransformNormal
		
		public static Vector3 TransformNormal (Vector3 normal, Matrix matrix)
		{
			Vector3 result;
			TransformNormal (ref normal, ref matrix, out result);
			return result;
		}
		
		public static void TransformNormal (ref Vector3 normal, ref Matrix matrix, out Vector3 result)
		{
			throw new NotImplementedException ();
		}
		
		public static void TransformNormal (Vector3[] sourceArray, int sourceIndex, ref Matrix matrix,
			Vector3[] destinationArray, int destinationIndex, int length)
		{
			CheckArrayArgs (sourceArray, sourceIndex, destinationArray, destinationIndex, length);
			
			int smax = sourceIndex + length;
			for (int s = sourceIndex, d = destinationIndex; s < smax; s++, d++)
				TransformNormal (ref sourceArray[s], ref matrix, out destinationArray[d]);
		}
		
		public static void TransformNormal (Vector3[] sourceArray, ref Matrix matrix, Vector3[] destinationArray)
		{
			CheckArrayArgs (sourceArray, destinationArray);
			
			for (int i = 0; i < sourceArray.Length; i++)
				TransformNormal (ref sourceArray[i], ref matrix, out destinationArray[i]);
		}
		
		#endregion
		
		#region Equality
		
		public bool Equals (Vector3 other)
		{
#if SIMD
			return v4 == other.v4;
#else
			return x == other.x && y == other.y && z == other.z;
#endif
		}
		
		public override bool Equals (object obj)
		{
			return obj is Vector3 && ((Vector3)obj) == this;
		}
		
		public override int GetHashCode ()
		{
#if SIMD
			unsafe {
				Vector4f f = v4;
				Vector4i i = *((Vector4i*)&f);
				i = i ^ i.Shuffle (ShuffleSel.Swap);
				i = i ^ i.Shuffle (ShuffleSel.RotateLeft);
				return i.X;
			}
#elif UNSAFE
			unsafe {
				float f = x;
				int acc = *((int*)&f);
				f = y;
				acc ^= *((int*)&f);
				f = z;
				acc ^= *((int*)&f);
				return acc;
			}
			
#else
			return x.GetHashCode () ^ y.GetHashCode () ^ z.GetHashCode ();
#endif
		}
		
		public static bool operator == (Vector3 a, Vector3 b)
		{
#if SIMD
			return a.v4 == b.v4;
#else
			return a.x == b.x && a.y == b.y && a.z == b.z;
#endif
		}
		
		public static bool operator != (Vector3 a, Vector3 b)
		{
#if SIMD
			return a.v4 != b.v4;
#else
			return a.x != b.x || a.y != b.y || a.z != b.z;
#endif
		}
		
		# endregion
		
		public override string ToString ()
		{
			return string.Format ("{{X:{0} Y:{1} Z:{2}}}", X, Y, Z);
		}
	}
}