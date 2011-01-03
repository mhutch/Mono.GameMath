// 
// Matrix.cs
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
	public static class MatrixTest
	{
		static Matrix TestMatrix0 = new Matrix (
			0f, 1f, 2f, 3f,
			4f, 5f, 6f, 7f,
			8f, 9f, 10f, 11f,
			12f, 13f, 14f, 15f);
		
		static Matrix TestMatrix1 = new Matrix (
			0.9910f, 0.9920f, 0.9930f, 0.9940f,
			0.9912f, 0.9921f, 0.9931f, 0.9941f,
			0.9913f, 0.9922f, 0.9932f, 0.9942f,
			0.9914f, 0.9923f, 0.9933f, 0.9943f);
		
		/*
		#region Creation
		
		public static void CreateBillboard (int times)
		{
		}
		
		public static void CreateBillboardRef (int times)
		{
		}
		
		public static void CreateConstrainedBillboard (int times)
		{
		}
		
		public static void CreateConstrainedBillboardRef (int times)
		{
		}
		
		public static void CreateFromAxisAngle (int times)
		{
		}
		
		public static void CreateFromAxisAngleRef (int times)
		{
		}
		
		public static void CreateFromQuaternion (int times)
		{
		}
		
		public static void CreateFromQuaternionRef (int times)
		{
		}
		
		public static void CreateFromYawPitchRoll (int times)
		{
		}
		
		public static void CreateFromYawPitchRollRef (int times)
		{
		}
		
		public static void CreateLookAt (int times)
		{
		}
		
		public static void CreateLookAtRef (int times)
		{
		}
		
		public static void CreateOrthographic (int times)
		{
		}
		
		public static void CreateOrthographicRef (int times)
		{
		}
		
		public static void CreateOrthographicOffCenter (int times)
		{
		}
		
		public static void CreateOrthographicOffCenterRef (int times)
		{
		}
		
		public static void CreatePerspective (int times)
		{
		}
		
		public static void CreatePerspectiveRef (int times)
		{
		}
		
		public static void CreatePerspectiveFieldOfView (int times)
		{
		}
		
		public static void CreatePerspectiveFieldOfViewRef (int times)
		{
		}
		
		public static void CreatePerspectiveOffCenter (int times)
		{
		}
		
		public static void CreatePerspectiveOffCenterRef (int times)
		{
		}
		
		public static void CreateReflection (int times)
		{
		}
		
		public static void CreateReflectionRef (int times)
		{
		}
		
		public static void CreateRotationX (int times)
		{
		}
		
		public static void CreateRotationXRef (int times)
		{
		}
		
		public static void CreateRotationY (int times)
		{
		}
		
		public static void CreateRotationYRef (int times)
		{
		}
		
		public static void CreateRotationZ (int times)
		{
		}
		
		public static void CreateRotationZ (int times)
		{
		}
		
		public static void CreateScale (int times)
		{
		}
		
		public static void CreateScaleRef (int times)
		{
		}
		
		public static void CreateScaleWithAxes (int times)
		{
		}
		
		public static void CreateScaleWithAxesRef (int times)
		{
		}
		
		public static void CreateScaleWithVector (int times)
		{
		}
		
		public static void CreateScaleWithVectorRef (int times)
		{
		}
		
		public static void CreateShadow (int times)
		{
		}
		
		public static void CreateShadowRef (int times)
		{
		}
		
		public static void CreateTranslation (int times)
		{
		}
		
		public static void CreateTranslation (int times)
		{
		}
		
		public static void CreateTranslationWithVector (int times)
		{
		}
		
		public static void CreateTranslationWithVectorRef (int times)
		{
		}
		
		public static void CreateWorld (int times)
		{
		}
		
		public static void CreateWorldRef (int times)
		{
		}
		
		#endregion
		*/
		
		#region Arithmetic
		
		public static void Add (int times)
		{
			Matrix a = TestMatrix0;
			Matrix result = a;
			
			for (int i = 0; i < times; i++) {
				result = Matrix.Add (result, a);
			}
		}
		
		public static void AddRef (int times)
		{
			Matrix a = TestMatrix0;
			Matrix result = a;
			
			for (int i = 0; i < times; i++) {
				Matrix.Add (ref result, ref a, out result);
			}
		}
		
		public static void Multiply (int times)
		{
			Matrix a = TestMatrix0;
			Matrix result = a;
			
			for (int i = 0; i < times; i++) {
				result = Matrix.Multiply (result, a);
			}
		}
		
		public static void MultiplyRef (int times)
		{
			Matrix a = TestMatrix0;
			Matrix result = a;
			
			for (int i = 0; i < times; i++) {
				Matrix.Multiply (ref result, ref a, out result);
			}
		}
		
		public static void MultiplyScalar (int times)
		{
			Matrix result = TestMatrix0;
			float scaleFactor = 0.991f;
			
			for (int i = 0; i < times; i++) {
				result = Matrix.Multiply (result, scaleFactor);
			}
		}
		
		public static void MultiplyScalarRef (int times)
		{
			Matrix result = TestMatrix0;
			float scaleFactor = 0.991f;
			
			for (int i = 0; i < times; i++) {
				Matrix.Multiply (ref result, scaleFactor, out result);
			}
		}
		
		public static void Negate (int times)
		{
			Matrix result = TestMatrix0;
			
			for (int i = 0; i < times; i++) {
				result = Matrix.Negate (result);
			}
		}
		
		public static void NegateRef (int times)
		{
			Matrix result = TestMatrix0;
			
			for (int i = 0; i < times; i++) {
				Matrix.Negate (ref result, out result);
			}
		}
		
		public static void Subtract (int times)
		{
			Matrix a = TestMatrix0;
			Matrix result = a;
			
			for (int i = 0; i < times; i++) {
				result = Matrix.Subtract (result, a);
			}
		}
		
		public static void SubtractRef (int times)
		{
			Matrix a = TestMatrix0;
			Matrix result = a;
			
			for (int i = 0; i < times; i++) {
				Matrix.Subtract (ref result, ref a, out result);
			}
		}
		
		public static void Divide (int times)
		{
			Matrix a = TestMatrix1;
			Matrix result = TestMatrix0;
			
			for (int i = 0; i < times; i++) {
				result = Matrix.Divide (result, a);
			}
		}
		
		public static void DivideRef (int times)
		{
			Matrix a = TestMatrix1;
			Matrix result = TestMatrix0;
			
			for (int i = 0; i < times; i++) {
				Matrix.Divide (ref result, ref a, out result);
			}
		}
		
		public static void DivideScalar (int times)
		{
			Matrix result = TestMatrix0;
			float divisor = 0.991f;
			
			for (int i = 0; i < times; i++) {
				result = Matrix.Divide (result, divisor);
			}
		}
		
		public static void DivideScalarRef (int times)
		{
			Matrix result = TestMatrix0;
			float divisor = 0.991f;
			
			for (int i = 0; i < times; i++) {
				Matrix.Divide (ref result, divisor, out result);
			}
		}
		
		#endregion
		
		#region Operator overloads
		
		public static void OpAdd (int times)
		{
			Matrix a = TestMatrix0;
			Matrix result = a;
			
			for (int i = 0; i < times; i++) {
				result = result + a;
			}
		}
		
		public static void OpDivideScalar (int times)
		{
			Matrix result = TestMatrix0;
			float divisor = 0.991f;
			
			for (int i = 0; i < times; i++) {
				result = result / divisor;
			}
		}
		
		public static void OpDivide (int times)
		{
			Matrix a = TestMatrix1;
			Matrix result = TestMatrix0;
			
			for (int i = 0; i < times; i++) {
				result = result / a;
			}
		}
		
		public static void OpMultiply (int times)
		{
			Matrix a = TestMatrix0;
			Matrix result = a;
			
			for (int i = 0; i < times; i++) {
				result = result * a;
			}
		}
		
		public static void OpMultiplyScalar (int times)
		{
			Matrix result = TestMatrix0;
			float scaleFactor = 0.991f;
			
			for (int i = 0; i < times; i++) {
				result = result * scaleFactor;
			}
		}
		
		public static void OpMultiplyScalarPref (int times)
		{
			Matrix result = TestMatrix0;
			float scaleFactor = 0.991f;
			
			for (int i = 0; i < times; i++) {
				result = scaleFactor * result;
			}
		}
		
		public static void OpSubtract (int times)
		{
			Matrix a = TestMatrix0;
			Matrix result = a;
			
			for (int i = 0; i < times; i++) {
				result = result - a;
			}
		}
		
		public static void OpNegate (int times)
		{
			Matrix result = TestMatrix0;
			
			for (int i = 0; i < times; i++) {
				result = - result;
			}
		}
		
		#endregion
		
		#region Other maths
		
		/*
		
		public static void Decompose (int times)
		{
			Matrix a = TestMatrix0;
			Vector3 scale, translation;
			Quaternion rotation;
			bool result;
			
			for (int i = 0; i < times; i++) {
				result = a.Decompose (out scale, out rotation, out translation);
			}
		}
		
		public static void Determinant (int times)
		{
			Matrix a = TestMatrix0;
			float result;
			
			for (int i = 0; i < times; i++) {
				result = a.Determinant ();
			}
		}
		
		public static void Invert (int times)
		{
			Matrix a = TestMatrix0;
			Matrix result;
			
			for (int i = 0; i < times; i++) {
				result = Matrix.Invert (a);
			}
		}
		
		public static void InvertRef (int times)
		{
			Matrix a = TestMatrix0;
			Matrix result;
			
			for (int i = 0; i < times; i++) {
				Matrix.Invert (ref a, out result);
			}
		}
		*/
		
		public static void Lerp (int times)
		{
			Matrix a = TestMatrix0;
			Matrix b = TestMatrix1;
			float amount = 0.6f;
			Matrix result;
			
			for (int i = 0; i < times; i++) {
				result = Matrix.Lerp (a, b, amount);
			}
		}
		
		public static void LerpRef (int times)
		{
			Matrix a = TestMatrix0;
			Matrix b = TestMatrix1;
			float amount = 0.6f;
			Matrix result;
			
			for (int i = 0; i < times; i++) {
				Matrix.Lerp (ref a, ref b, amount, out result);
			}
		}
		
		/*
		
		public static void Transform (int times)
		{
		}
		
		public static void TransformRef (int times)
		{
		}
		*/
		public static void Transpose (int times)
		{
			Matrix a = TestMatrix0;
			Matrix result;
			
			for (int i = 0; i < times; i++) {
				result = Matrix.Transpose (a);
			}
		}
		
		public static void TransposeRef (int times)
		{
			Matrix a = TestMatrix0;
			Matrix result;
			
			for (int i = 0; i < times; i++) {
				Matrix.Transpose (ref a, out result);
			}
		}
		
		#endregion
		
		#region Equality
		
		public static void IEquatableEquals (int times)
		{
			var value1 = new Matrix (
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 1f
			);
			var value2 = new Matrix (
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, -1f
			);
			bool result;
			
			for (int i = 0; i < times; i++) {
				result = value1.Equals (value2);
			}
		}
		
		public static void HashCode (int times)
		{
			var value = new Matrix (
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 1f
			);
			int result;
			
			for (int i = 0; i < times; i++) {
				result = value.GetHashCode ();
			}
		}
		
		public static void OpEqual (int times)
		{
			var value1 = new Matrix (
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 1f
			);
			var value2 = new Matrix (
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 1f
			);
			bool result;
			
			for (int i = 0; i < times; i++) {
				result = value1 == value2;
			}
		}
		
		public static void OpNotEqual (int times)
		{
			var value1 = new Matrix (
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 1f
			);
			var value2 = new Matrix (
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 0f,
				0f, 0f, 0f, 0f
			);
			bool result;
			
			for (int i = 0; i < times; i++) {
				result = value1 != value2;
			}
		}
		
		#endregion
	}
}