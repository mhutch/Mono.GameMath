// 
// Vector4.cs
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
using Mono.GameMath;

#pragma warning disable 0219

namespace Benchmark
{
	public static class Vector4Test
	{
		#region Arithmetic
		
		public static void Add (int times)
		{
			Vector4 a = new Vector4 (1f, 2f, 3f, 4f);
			Vector4 result = Vector4.Zero;
			for (int i = 0; i < times; i++) {
				result = Vector4.Add (result, a);
			}
		}
		
		public static void AddRef (int times)
		{
			Vector4 a = new Vector4 (1f, 2f, 3f, 4f);
			Vector4 result = Vector4.Zero;
			for (int i = 0; i < times; i++) {
				Vector4.Add (ref result, ref a, out result);
			}
		}
		
		public static void DivideScalar (int times)
		{
			Vector4 result = new Vector4 (1f, 2f, 3f, 4f);
			for (int i = 0; i < times; i++) {
				result = Vector4.Divide (result, 0.9f);
			}
		}
		
		public static void DivideScalarRef (int times)
		{
			Vector4 result = new Vector4 (1f, 2f, 3f, 4f);
			for (int i = 0; i < times; i++) {
				Vector4.Divide (ref result, 0.9f, out result);
			}
		}
		
		public static void Divide (int times)
		{
			Vector4 a = new Vector4 (0.9f, 0.91f, 0.92f, 0.93f);
			Vector4 result = new Vector4 (1, 2, 3, 4);
			for (int i = 0; i < times; i++) {
				result = Vector4.Divide (result, a);
			}
		}
		
		public static void DivideRef (int times)
		{
			Vector4 a = new Vector4 (0.9f, 0.91f, 0.92f, 0.93f);
			Vector4 result = new Vector4 (1, 2, 3, 4);
			for (int i = 0; i < times; i++) {
				Vector4.Divide (ref result, ref a, out result);
			}
		}
		
		public static void MultiplyScalar (int times)
		{
			Vector4 result = new Vector4 (1f, 2f, 3f, 4f);
			for (int i = 0; i < times; i++) {
				result = Vector4.Multiply (result, 1.1f);
			}
		}
		
		public static void MultiplyScalarRef (int times)
		{
			Vector4 result = new Vector4 (1f, 2f, 3f, 4f);
			for (int i = 0; i < times; i++) {
				Vector4.Multiply (ref result, 1.1f, out result);
			}
		}
		
		public static void Multiply (int times)
		{
			Vector4 a = new Vector4 (1.1f, 1.11f, 1.12f, 1.13f);
			Vector4 result = new Vector4 (1, 2, 3, 4);
			for (int i = 0; i < times; i++) {
				result = Vector4.Multiply (result, a);
			}
		}
		
		public static void MultiplyRef (int times)
		{
			Vector4 a = new Vector4 (1.1f, 1.11f, 1.12f, 1.13f);
			Vector4 result = new Vector4 (1, 2, 3, 4);
			for (int i = 0; i < times; i++) {
				Vector4.Multiply (ref result, ref a, out result);
			}
		}
		
		public static void Negate (int times)
		{
			Vector4 result = new Vector4 (1, 2, 3, 4);
			for (int i = 0; i < times; i++) {
				result = Vector4.Negate (result);
			}
		}
		
		public static void NegateRef (int times)
		{
			Vector4 result = new Vector4 (1, 2, 3, 4);
			for (int i = 0; i < times; i++) {
				Vector4.Negate (ref result, out result);
			}
		}
		
		public static void Subtract (int times)
		{
			Vector4 a = new Vector4 (1f, 2f, 3f, 4f);
			Vector4 result = Vector4.Zero;
			for (int i = 0; i < times; i++) {
				result = Vector4.Subtract (result, a);
			}
		}
		
		public static void SubtractRef (int times)
		{
			Vector4 a = new Vector4 (1f, 2f, 3f, 4f);
			Vector4 result = Vector4.Zero;
			for (int i = 0; i < times; i++) {
				Vector4.Subtract (ref result, ref a, out result);
			}
		}
		
		#endregion
		
		#region Operator overloads
		
		public static void OpAdd (int times)
		{
			Vector4 a = new Vector4 (1f, 2f, 3f, 4f);
			Vector4 result = Vector4.Zero;
			for (int i = 0; i < times; i++) {
				result = result + a;
			}
		}
		
		public static void OpDivideScalar (int times)
		{
			Vector4 result = new Vector4 (1f, 2f, 3f, 4f);
			for (int i = 0; i < times; i++) {
				result = result / 0.9f;
			}
		}
		
		public static void OpDivide (int times)
		{
			Vector4 a = new Vector4 (0.9f, 0.91f, 0.92f, 0.93f);
			Vector4 result = new Vector4 (1, 2, 3, 4);
			for (int i = 0; i < times; i++) {
				result = result / a;
			}
		}
		
		public static void OpMultiply (int times)
		{
			Vector4 a = new Vector4 (1.1f, 1.11f, 1.12f, 1.13f);
			Vector4 result = new Vector4 (1, 2, 3, 4);
			for (int i = 0; i < times; i++) {
				result = result * a;
			}
		}
		
		public static void OpMultiplyScalar (int times)
		{
			Vector4 result = new Vector4 (1f, 2f, 3f, 4f);
			for (int i = 0; i < times; i++) {
				result = result * 1.1f;
			}
		}
		
		public static void OpMultiplyScalarPre (int times)
		{
			Vector4 result = new Vector4 (1f, 2f, 3f, 4f);
			for (int i = 0; i < times; i++) {
				result = 1.1f * result;
			}
		}
		
		public static void OpSubtract (int times)
		{
			Vector4 a = new Vector4 (1f, 2f, 3f, 4f);
			Vector4 result = Vector4.Zero;
			for (int i = 0; i < times; i++) {
				result =  result - a;
			}
		}
		
		public static void OpNegate (int times)
		{
			Vector4 result = new Vector4 (1f, 2f, 3f, 4f);
			for (int i = 0; i < times; i++) {
				result = -result;
			}
		}
		
		#endregion
	
		#region Interpolation
		
		public static void CatmullRom (int times)
		{
			var value1 = new Vector4 (0f, 2f, 4f, 6f);
			var value2 = new Vector4 (1f, 3f, 5f, 7f);
			var value3 = new Vector4 (3f, 5f, 7f, 9f);
			var value4 = new Vector4 (6f, 8f, 10f, 12f);
			float amount = 0.6f;
			Vector4 result;
			
			for (int i = 0; i < times; i++) {
				result = Vector4.CatmullRom (value1, value2, value3, value4, amount);
			}
		}
		
		public static void CatmullRomRef (int times)
		{
			var value1 = new Vector4 (0f, 2f, 4f, 6f);
			var value2 = new Vector4 (1f, 3f, 5f, 7f);
			var value3 = new Vector4 (3f, 5f, 7f, 9f);
			var value4 = new Vector4 (6f, 8f, 10f, 12f);
			float amount = 0.6f;
			Vector4 result;
			
			for (int i = 0; i < times; i++) {
				Vector4.CatmullRom (ref value1, ref value2, ref value3, ref value4, amount, out result);
			}
		}
		
		public static void Hermite (int times)
		{
			var value1 = new Vector4 (0f, 2f, 4f, 6f);
			var tangent1 = new Vector4 (1f, 3f, 5f, 7f);
			var value2 = new Vector4 (3f, 5f, 7f, 9f);
			var tangent2 = new Vector4 (6f, 8f, 10f, 12f);
			float amount = 0.6f;
			Vector4 result;
			
			for (int i = 0; i < times; i++) {
				result = Vector4.Hermite (value1, tangent1, value2, tangent2, amount);
			}
		}
		
		public static void HermiteRef (int times)
		{
			var value1 = new Vector4 (0f, 2f, 4f, 6f);
			var tangent1 = new Vector4 (1f, 3f, 5f, 7f);
			var value2 = new Vector4 (3f, 5f, 7f, 9f);
			var tangent2 = new Vector4 (6f, 8f, 10f, 12f);
			float amount = 0.6f;
			Vector4 result;
			
			for (int i = 0; i < times; i++) {
				Vector4.Hermite (ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
			}
		}
		
		public static void Lerp (int times)
		{
			var value1 = new Vector4 (0f, 2f, 4f, 6f);
			var value2 = new Vector4 (3f, 5f, 7f, 9f);
			float amount = 0.6f;
			Vector4 result;
			
			for (int i = 0; i < times; i++) {
				result = Vector4.Lerp (value1, value2, amount);
			}
		}
		
		public static void LerpRef (int times)
		{
			var value1 = new Vector4 (0f, 2f, 4f, 6f);
			var value2 = new Vector4 (3f, 5f, 7f, 9f);
			float amount = 0.6f;
			Vector4 result;
			
			for (int i = 0; i < times; i++) {
				Vector4.Lerp (ref value1, ref value2, amount, out result);
			}
		}
		
		public static void SmoothStep (int times)
		{
			var value1 = new Vector4 (0f, 2f, 4f, 6f);
			var value2 = new Vector4 (3f, 5f, 7f, 9f);
			float amount = 0.95f;
			Vector4 result;
			
			for (int i = 0; i < times; i++) {
				result = Vector4.SmoothStep (value1, value2, amount);
			}
		}
		
		public static void SmoothStepRef (int times)
		{
			var value1 = new Vector4 (0f, 2f, 4f, 6f);
			var value2 = new Vector4 (3f, 5f, 7f, 9f);
			float amount = 0.95f;
			Vector4 result;
			
			for (int i = 0; i < times; i++) {
				Vector4.SmoothStep (ref value1, ref value2, amount, out result);
			}
		}
		
		#endregion
		
		#region Other maths
		
		public static void Barycentric (int times)
		{
			var value1 = new Vector4 (0f, 2f, 4f, 6f);
			var value2 = new Vector4 (1f, 3f, 5f, 7f);
			var value3 = new Vector4 (3f, 5f, 7f, 9f);
			float amount1 = 0.3f;
			float amount2 = 0.6f;
			Vector4 result;
			
			for (int i = 0; i < times; i++) {
				result = Vector4.Barycentric (value1, value2, value3, amount1, amount2);
			}
		}
		
		public static void BarycentricRef (int times)
		{
			var value1 = new Vector4 (0f, 2f, 4f, 6f);
			var value2 = new Vector4 (1f, 3f, 5f, 7f);
			var value3 = new Vector4 (3f, 5f, 7f, 9f);
			float amount1 = 0.3f;
			float amount2 = 0.6f;
			Vector4 result;
			
			for (int i = 0; i < times; i++) {
				Vector4.Barycentric (ref value1, ref value2, ref value3, amount1, amount2, out result);
			}
		}
		
		public static void Clamp (int times)
		{
			var max = Vector4.One;
			var min = Vector4.Zero;
			var value = new Vector4 (0.1f, -2f, -0.2f, 0.56f);
			Vector4 result;
			
			for (int i = 0; i < times; i++) {
				result = Vector4.Clamp (value, min, max);
			}
		}
		
		public static void ClampRef (int times)
		{
			var max = Vector4.One;
			var min = Vector4.Zero;
			var value = new Vector4 (0.1f, -2f, -0.2f, 0.56f);
			Vector4 result;
			
			for (int i = 0; i < times; i++) {
				Vector4.Clamp (ref value, ref min, ref max, out result);
			}
		}
		
		public static void Distance (int times)
		{
			var value1 = new Vector4 (0f, 2f, 4f, 6f);
			var value2 = new Vector4 (1f, 3f, 5f, 7f);
			float result;
			
			for (int i = 0; i < times; i++) {
				result = Vector4.Distance (value1, value2);
			}
		}
		
		public static void DistanceRef (int times)
		{
			var value1 = new Vector4 (0f, 2f, 4f, 6f);
			var value2 = new Vector4 (1f, 3f, 5f, 7f);
			float result;
			
			for (int i = 0; i < times; i++) {
				Vector4.Distance (ref value1, ref value2, out result);
			}
		}
		
		public static void DistanceSquared (int times)
		{
			var value1 = new Vector4 (0f, 2f, 4f, 6f);
			var value2 = new Vector4 (1f, 3f, 5f, 7f);
			float result;
			
			for (int i = 0; i < times; i++) {
				result = Vector4.DistanceSquared (value1, value2);
			}
		}
		
		public static void DistanceSquaredRef (int times)
		{
			var value1 = new Vector4 (0f, 2f, 4f, 6f);
			var value2 = new Vector4 (1f, 3f, 5f, 7f);
			float result;
			
			for (int i = 0; i < times; i++) {
				Vector4.DistanceSquared (ref value1, ref value2, out result);
			}
		}
		
		public static void Dot (int times)
		{
			var value1 = new Vector4 (0f, 2f, 4f, 6f);
			var value2 = new Vector4 (1f, 3f, 5f, 7f);
			float result;
			
			for (int i = 0; i < times; i++) {
				result = Vector4.Dot (value1, value2);
			}
		}
		
		public static void DotRef (int times)
		{
			var value1 = new Vector4 (0f, 2f, 4f, 6f);
			var value2 = new Vector4 (1f, 3f, 5f, 7f);
			float result;
			
			for (int i = 0; i < times; i++) {
				Vector4.Dot (ref value1, ref value2, out result);
			}
		}
		
		public static void Length (int times)
		{
			var value = new Vector4 (0.1f, -2f, -0.2f, 0.56f);
			float result;
			
			for (int i = 0; i < times; i++) {
				result = value.Length ();
			}
		}
		
		public static void LengthSquared (int times)
		{
			var value = new Vector4 (0.1f, -2f, -0.2f, 0.56f);
			float result;
			
			for (int i = 0; i < times; i++) {
				result = value.LengthSquared ();
			}
		}
		
		public static void Max (int times)
		{
			var max = Vector4.One;
			var value = new Vector4 (0.1f, -2f, -0.2f, 0.56f);
			Vector4 result;
			
			for (int i = 0; i < times; i++) {
				result = Vector4.Max (value, max);
			}
		}
		
		public static void MaxRef (int times)
		{
			var max = Vector4.One;
			var value = new Vector4 (0.1f, -2f, -0.2f, 0.56f);
			Vector4 result;
			
			for (int i = 0; i < times; i++) {
				Vector4.Max (ref value, ref max, out result);
			}
		}
		
		public static void Min (int times)
		{
			var min = Vector4.Zero;
			var value = new Vector4 (0.1f, -2f, -0.2f, 0.56f);
			Vector4 result;
			
			for (int i = 0; i < times; i++) {
				result = Vector4.Min (value, min);
			}
		}
		
		public static void MinRef (int times)
		{
			var min = Vector4.Zero;
			var value = new Vector4 (0.1f, -2f, -0.2f, 0.56f);
			Vector4 result;
			
			for (int i = 0; i < times; i++) {
				Vector4.Min (ref value, ref min, out result);
			}
		}
		
		public static void NormalizeInstance (int times)
		{
			var value = new Vector4 (0.1f, -2f, -0.2f, 0.56f);
			
			for (int i = 0; i < times; i++) {
				value.Normalize ();
			}
		}
		
		public static void Normalize (int times)
		{
			var value = new Vector4 (0.1f, -2f, -0.2f, 0.56f);
			Vector4 result;
			
			for (int i = 0; i < times; i++) {
				result = Vector4.Normalize (value);
			}
		}
		
		public static void NormalizeRef (int times)
		{
			var value = new Vector4 (0.1f, -2f, -0.2f, 0.56f);
			Vector4 result;
			
			for (int i = 0; i < times; i++) {
				Vector4.Normalize (ref value, out result);
			}
		}
		
		#endregion
		/*
		#region Transform
		
		public static void TransformVector2Matrix (int times)
		{
		}
		
		public static void TransformVector2MatrixRef (int times)
		{
		}
		
		public static void TransformVector2Quaternion (int times)
		{
		}
		
		public static void TransformVector2QuaternionRef (int times)
		{
		}
		
		public static void TransformVector3Matrix (int times)
		{
		}
		
		public static void TransformVector3MatrixRef (int times)
		{
		}
		
		public static void TransformVector3Quaternion (int times)
		{
		}
		
		public static void TransformVector3QuaternionRef (int times)
		{
		}
		
		public static void TransformMatrix (int times)
		{
		}
		
		public static void TransformMatrixRef (int times)
		{
		}
		
		public static void TransformQuaternon (int times)
		{
		}
		
		public static void TransformQuaternonRef (int times)
		{
		}
		
		public static void TransformArrayMatrixWithIndices (int times)
		{
		}
		
		public static void TransformArrayQuaternionWithIndices (int times)
		{
		}
		
		public static void TransformArrayMatrix (int times)
		{
		}
		
		public static void TransformArrayQuaternion (int times)
		{
		}
		
		#endregion
		*/
		
		#region Equality
		
		public static void IEquatableEquals (int times)
		{
			var value1 = new Vector4 (0f, 0f, 0f, 0.56f);
			var value2 = new Vector4 (0f, 0f, 0f, -0.56f);
			bool result;
			
			for (int i = 0; i < times; i++) {
				result = value1.Equals (value2);
			}
		}
		
		public static void HashCode (int times)
		{
			var value = new Vector4 (0.1f, -2f, -0.2f, 0.56f);
			int result;
			
			for (int i = 0; i < times; i++) {
				result = value.GetHashCode ();
			}
		}
		
		public static void OpEqual (int times)
		{
			var value1 = new Vector4 (0f, 0f, 0f, 0.56f);
			var value2 = new Vector4 (0f, 0f, 0f, -0.56f);
			bool result;
			
			for (int i = 0; i < times; i++) {
				result = value1 == value2;
			}
		}
		
		public static void OpNotEqual (int times)
		{
			var value1 = new Vector4 (0f, 0f, 0f, 0.56f);
			var value2 = new Vector4 (0f, 0f, 0f, -0.56f);
			bool result;
			
			for (int i = 0; i < times; i++) {
				result = value1 != value2;
			}
		}
		
		#endregion
	}
}