// 
// Matrix4.cs
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
	public struct Matrix : IEquatable<Matrix>
	{
#if SIMD
		Vector4f r1, r2, r3, r4;
		
		public float M11 { get { return r1.X; } set { r1.X = value; } }
		public float M12 { get { return r1.Y; } set { r1.Y = value; } }
		public float M13 { get { return r1.Z; } set { r1.Z = value; } }
		public float M14 { get { return r1.W; } set { r1.W = value; } }
		public float M21 { get { return r2.X; } set { r2.X = value; } }
		public float M22 { get { return r2.Y; } set { r2.Y = value; } }
		public float M23 { get { return r2.Z; } set { r2.Z = value; } }
		public float M24 { get { return r2.W; } set { r2.W = value; } }
		public float M31 { get { return r3.X; } set { r3.X = value; } }
		public float M32 { get { return r3.Y; } set { r3.Y = value; } }
		public float M33 { get { return r3.Z; } set { r3.Z = value; } }
		public float M34 { get { return r3.W; } set { r3.W = value; } }
		public float M41 { get { return r4.X; } set { r4.X = value; } }
		public float M42 { get { return r4.Y; } set { r4.Y = value; } }
		public float M43 { get { return r4.Z; } set { r4.Z = value; } }
		public float M44 { get { return r4.W; } set { r4.W = value; } }
		
		Matrix (Vector4f r1, Vector4f r2, Vector4f r3, Vector4f r4)
		{
			this.r1 = r1;
			this.r2 = r2;
			this.r3 = r3;
			this.r4 = r4;
		}
		
		Matrix (float v)
		{
			r1 = new Vector4f (v);
			r2 = new Vector4f (v);
			r3 = new Vector4f (v);
			r4 = new Vector4f (v);
		}
#else
		float m11, m12, m13, m14;
		float m21, m22, m23, m24;
		float m31, m32, m33, m34;
		float m41, m42, m43, m44;
		
		public float M11 { get { return m11; } set { m11 = value; } }
		public float M12 { get { return m12; } set { m12 = value; } }
		public float M13 { get { return m13; } set { m13 = value; } }
		public float M14 { get { return m14; } set { m14 = value; } }
		public float M21 { get { return m21; } set { m21 = value; } }
		public float M22 { get { return m22; } set { m22 = value; } }
		public float M23 { get { return m23; } set { m23 = value; } }
		public float M24 { get { return m24; } set { m24 = value; } }
		public float M31 { get { return m31; } set { m31 = value; } }
		public float M32 { get { return m32; } set { m32 = value; } }
		public float M33 { get { return m33; } set { m33 = value; } }
		public float M34 { get { return m34; } set { m34 = value; } }
		public float M41 { get { return m41; } set { m41 = value; } }
		public float M42 { get { return m42; } set { m42 = value; } }
		public float M43 { get { return m43; } set { m43 = value; } }
		public float M44 { get { return m44; } set { m44 = value; } }
		
		Matrix (float v)
		{
			m11 = v; m12 = v; m13 = v; m14 = v;
			m21 = v; m22 = v; m23 = v; m24 = v;
			m31 = v; m32 = v; m33 = v; m34 = v;
			m41 = v; m42 = v; m43 = v; m44 = v;
		}
#endif
		
		public Matrix (
			float m11, float m12, float m13, float m14,
			float m21, float m22, float m23, float m24,
			float m31, float m32, float m33, float m34,
			float m41, float m42, float m43, float m44)
		{
#if SIMD
			r1 = new Vector4f (m11, m12, m13, m14);
			r2 = new Vector4f (m21, m22, m23, m24);
			r3 = new Vector4f (m31, m32, m33, m34);
			r4 = new Vector4f (m41, m42, m43, m44);
#else
			this.m11 = m11; this.m12 = m12; this.m13 = m13; this.m14 = m14;
			this.m21 = m21; this.m22 = m22; this.m23 = m23; this.m24 = m24;
			this.m31 = m31; this.m32 = m32; this.m33 = m33; this.m34 = m34;
			this.m41 = m41; this.m42 = m42; this.m43 = m43; this.m44 = m44;
#endif
		}
		
		#region Vector Properties
		
		//See http://stevehazen.wordpress.com/2010/02/15/
		//matrix-basics-how-to-step-away-from-storing-an-orientation-as-3-angles/
		public Vector3 Right {
			get {
				return new Vector3 (M11, M12, M13);
			}
			set {
				M11 = value.X;
				M12 = value.Y;
				M13 = value.Z;
			}
		}
		
		public Vector3 Up {
			get {
				return new Vector3 (M21, M22, M23);
			}
			set {
				M21 = value.X;
				M22 = value.Y;
				M23 = value.Z;
			}
		}
		
		public Vector3 Backward {
			get {
				return new Vector3 (M31, M32, M33);
			}
			set {
				M31 = value.X;
				M32 = value.Y;
				M33 = value.Z;
			}
		}
		
		public Vector3 Left {
			get {
				return new Vector3 (-M21, -M22, -M23);
			}
			set {
				M21 = -value.X;
				M22 = -value.Y;
				M23 = -value.Z;
			}
		}
		
		public Vector3 Down {
			get {
				return new Vector3 (-M21, -M22, -M23);
			}
			set {
				M21 = -value.X;
				M22 = -value.Y;
				M23 = -value.Z;
			}
		}
		
		public Vector3 Forward {
			get {
				return new Vector3 (-M31, -M32, -M33);
			}
			set {
				M31 = -value.X;
				M32 = -value.Y;
				M33 = -value.Z;
			}
		}
		
		public Vector3 Translation {
			get {
				return new Vector3 (M41, M42, M43);
			}
			set {
				M41 = value.X;
				M42 = value.Y;
				M43 = value.Z;
			}
		}
		
		#endregion
		
		#region Static properties
		
		public static Matrix Identity {
			get {
				return new Matrix (
					1f, 0f, 0f, 0f,
					0f, 1f, 0f, 0f,
					0f, 0f, 1f, 0f,
					0f, 0f, 0f, 1f);
			}
		}
		
		#endregion
		
		#region Creation
		
		public static Matrix CreateBillboard (Vector3 objectPosition, Vector3 cameraPosition, Vector3 cameraUpVector,
			Vector3? cameraForwardVector)
		{
			Matrix result;
			CreateBillboard (ref objectPosition, ref cameraPosition, ref cameraUpVector, cameraForwardVector, out result);
			return result;
		}
		
		public static void CreateBillboard (ref Vector3 objectPosition, ref Vector3 cameraPosition,
			ref Vector3 cameraUpVector, Vector3? cameraForwardVector, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix CreateConstrainedBillboard (Vector3 objectPosition, Vector3 cameraPosition,
			Vector3 rotateAxis, Vector3? cameraForwardVector, Vector3? objectForwardVector)
		{
			Matrix result;
			CreateConstrainedBillboard (ref objectPosition, ref cameraPosition, ref rotateAxis, cameraForwardVector,
				objectForwardVector, out result);
			return result;
		}
		
		public static void CreateConstrainedBillboard (ref Vector3 objectPosition, ref Vector3 cameraPosition, 
			ref Vector3 rotateAxis, Vector3? cameraForwardVector, Vector3? objectForwardVector, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix CreateFromAxisAngle (Vector3 axis, float angle)
		{
			Matrix result;
			CreateFromAxisAngle (ref axis, angle, out result);
			return result;
		}
		
		public static void CreateFromAxisAngle (ref Vector3 axis, float angle, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix CreateFromQuaternion (Quaternion quaternion)
		{
			Matrix result;
			CreateFromQuaternion (ref quaternion, out result);
			return result;
		}
		
		public static void CreateFromQuaternion (ref Quaternion quaternion, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix CreateFromYawPitchRoll (float yaw, float pitch, float roll)
		{
			Matrix result;
			CreateFromYawPitchRoll (yaw, pitch, roll, out result);
			return result;
		}
		
		public static void CreateFromYawPitchRoll (float yaw, float pitch, float roll, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix CreateLookAt (Vector3 cameraPosition, Vector3 cameraTarget, Vector3 cameraUpVector)
		{
			Matrix result;
			CreateLookAt (ref cameraPosition, ref cameraTarget, ref cameraUpVector, out result);
			return result;
		}
		
		public static void CreateLookAt (ref Vector3 cameraPosition, ref Vector3 cameraTarget, ref Vector3 cameraUpVector, out Matrix result
)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix CreateOrthographic (float width, float height, float zNearPlane, float zFarPlane)
		{
			Matrix result;
			CreateOrthographic (width, height, zNearPlane, zFarPlane, out result);
			return result;
		}
		
		public static void CreateOrthographic (float width, float height, float zNearPlane, float zFarPlane,
			out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix CreateOrthographicOffCenter (float left, float right, float bottom, float top,
			float zNearPlane, float zFarPlane)
		{
			Matrix result;
			CreateOrthographicOffCenter (left, right, bottom, top, zNearPlane, zFarPlane, out result);
			return result;
		}
		
		public static void CreateOrthographicOffCenter (float left, float right, float bottom, float top,
			float zNearPlane, float zFarPlane, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix CreatePerspective (float width, float height, float nearPlaneDistance, 
			float farPlaneDistance)
		{
			Matrix result;
			CreatePerspective (width, height, nearPlaneDistance, farPlaneDistance, out result);
			return result;
		}
		
		public static void CreatePerspective (float width, float height, float nearPlaneDistance,
			float farPlaneDistance, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix CreatePerspectiveFieldOfView (float fieldOfView, float aspectRatio,
			float nearPlaneDistance, float farPlaneDistance)
		{
			Matrix result;
			CreatePerspectiveFieldOfView (fieldOfView, aspectRatio, nearPlaneDistance, farPlaneDistance, out result);
			return result;
		}
		
		public static void CreatePerspectiveFieldOfView (float fieldOfView, float aspectRatio, float nearPlaneDistance,
			float farPlaneDistance, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix CreatePerspectiveOffCenter (float left, float right, float bottom, float top,
			float nearPlaneDistance, float farPlaneDistance)
		{
			Matrix result;
			CreatePerspectiveOffCenter (left, right, bottom, top, nearPlaneDistance, farPlaneDistance, out result);
			return result;
		}
		
		public static void CreatePerspectiveOffCenter (float left, float right, float bottom, float top, 
			float nearPlaneDistance, float farPlaneDistance, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix CreateReflection (Plane value)
		{
			Matrix result;
			CreateReflection (ref value, out result);
			return result;
		}
		
		public static void CreateReflection (ref Plane value, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix CreateRotationX (float radians)
		{
			Matrix result;
			CreateRotationX (radians, out result);
			return result;
		}
		
		public static void CreateRotationX (float radians, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix CreateRotationY (float radians)
		{
			Matrix result;
			CreateRotationY (radians, out result);
			return result;
		}
		
		public static void CreateRotationY (float radians, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix CreateRotationZ (float radians)
		{
			Matrix result;
			CreateRotationZ (radians, out result);
			return result;
		}
		
		public static void CreateRotationZ (float radians, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix CreateScale (float scale)
		{
			return CreateScale (scale, scale, scale);
		}
		
		public static void CreateScale (float scale, out Matrix result)
		{
			CreateScale (scale, scale, scale, out result);
		}
		
		public static Matrix CreateScale (float xScale, float yScale, float zScale)
		{
			Matrix result;
			CreateScale (xScale, yScale, zScale, out result);
			return result;
		}
		
		public static void CreateScale (float xScale, float yScale, float zScale, out Matrix result)
		{
			var scale = new Vector3 (xScale, yScale, zScale);
			CreateScale (ref scale, out result);
		}
		
		public static Matrix CreateScale (Vector3 scales)
		{
			Matrix result;
			CreateScale (ref scales, out result);
			return result;
		}
		
		public static void CreateScale (ref Vector3 scales, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix CreateShadow (Vector3 lightDirection, Plane plane)
		{
			Matrix result;
			CreateShadow (ref lightDirection, ref plane, out result);
			return result;
		}
		
		public static void CreateShadow (ref Vector3 lightDirection, ref Plane plane, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix CreateTranslation (float xPosition, float yPosition, float zPosition)
		{
			Matrix result;
			CreateTranslation (xPosition, yPosition, zPosition, out result);
			return result;
		}
		
		public static void CreateTranslation (float xPosition, float yPosition, float zPosition, out Matrix result)
		{
			var position = new Vector3 (xPosition, yPosition, zPosition);
			CreateTranslation (ref position, out result);
		}
		
		public static Matrix CreateTranslation (Vector3 position)
		{
			Matrix result;
			CreateTranslation (ref position, out result);
			return result;
		}
		
		public static void CreateTranslation (ref Vector3 position, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix CreateWorld (Vector3 position, Vector3 forward, Vector3 up)
		{
			Matrix result;
			CreateWorld (ref position, ref forward, ref up, out result);
			return result;
		}
		
		public static void CreateWorld (ref Vector3 position, ref Vector3 forward, ref Vector3 up, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		#endregion
		
		#region Arithmetic
		
		public static Matrix Add (Matrix matrix1, Matrix matrix2)
		{
			Add (ref matrix1, ref matrix2, out matrix1);
			return matrix1;
		}
		
		public static void Add (ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
		{
#if SIMD
			result.r1 = matrix1.r1 + matrix2.r1;
			result.r2 = matrix1.r2 + matrix2.r2;
			result.r3 = matrix1.r3 + matrix2.r3;
			result.r4 = matrix1.r4 + matrix2.r4;
#else
			result.M11 = matrix1.M11 + matrix2.M11;
			result.M12 = matrix1.M12 + matrix2.M12;
			result.M13 = matrix1.M13 + matrix2.M13;
			result.M14 = matrix1.M14 + matrix2.M14;
			
			result.M21 = matrix1.M21 + matrix2.M21;
			result.M22 = matrix1.M22 + matrix2.M22;
			result.M23 = matrix1.M23 + matrix2.M23;
			result.M24 = matrix1.M24 + matrix2.M24;
			
			result.M31 = matrix1.M31 + matrix2.M31;
			result.M32 = matrix1.M32 + matrix2.M32;
			result.M33 = matrix1.M33 + matrix2.M33;
			result.M34 = matrix1.M34 + matrix2.M34;
			
			result.M41 = matrix1.M41 + matrix2.M41;
			result.M42 = matrix1.M42 + matrix2.M42;
			result.M43 = matrix1.M43 + matrix2.M43;
			result.M44 = matrix1.M44 + matrix2.M44;
#endif
		}
		
		public static Matrix Multiply (Matrix matrix1, Matrix matrix2)
		{
#if SIMD
			//sse version only sets the result when the calculation is complete
			Multiply (ref matrix1, ref matrix2, out matrix1);
			return matrix1;
#else
			//non-sse version needs m1 and m1 to remain unchanged
			Matrix result;
			Multiply (ref matrix1, ref matrix2, out result);
			return result;
#endif
		}
		
		public static void Multiply (ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
		{
#if SIMD
			//http://www.freevec.org/function/matrix_4x4_multiplication_floats
			//FIXME does Mono.Simd have fused multiply-add?
			Vector4f a1 = matrix1.r1, a2 = matrix1.r2, a3 = matrix1.r3, a4 = matrix1.r4;
			Vector4f b1 = matrix2.r1, b2 = matrix2.r2, b3 = matrix2.r3, b4 = matrix2.r4;
			
			Vector4f c1 = a1.Shuffle (ShuffleSel.ExpandX) * b1;
			Vector4f c2 = a2.Shuffle (ShuffleSel.ExpandX) * b2;
			Vector4f c3 = a3.Shuffle (ShuffleSel.ExpandX) * b3;
			Vector4f c4 = a4.Shuffle (ShuffleSel.ExpandX) * b4;
			
			c1 += a1.Shuffle (ShuffleSel.ExpandY) * b1;
			c2 += a2.Shuffle (ShuffleSel.ExpandY) * b2;
			c3 += a3.Shuffle (ShuffleSel.ExpandY) * b3;
			c4 += a4.Shuffle (ShuffleSel.ExpandY) * b4;
			
			c1 += a1.Shuffle (ShuffleSel.ExpandZ) * b1;
			c2 += a2.Shuffle (ShuffleSel.ExpandZ) * b2;
			c3 += a3.Shuffle (ShuffleSel.ExpandZ) * b3;
			c4 += a4.Shuffle (ShuffleSel.ExpandZ) * b4;
			
			c1 += a1.Shuffle (ShuffleSel.ExpandW) * b1;
			c2 += a2.Shuffle (ShuffleSel.ExpandW) * b2;
			c3 += a3.Shuffle (ShuffleSel.ExpandW) * b3;
			c4 += a4.Shuffle (ShuffleSel.ExpandW) * b4;
			
			result.r1 = c1;
			result.r2 = c2;
			result.r3 = c3;
			result.r4 = c4;
#else
			result.M11 = matrix1.M11*matrix2.M11 + matrix1.M12*matrix2.M21 + matrix1.M13*matrix2.M31 + matrix1.M14*matrix2.M41;
			result.M12 = matrix1.M11*matrix2.M12 + matrix1.M12*matrix2.M22 + matrix1.M13*matrix2.M32 + matrix1.M14*matrix2.M42;
			result.M13 = matrix1.M11*matrix2.M13 + matrix1.M12*matrix2.M23 + matrix1.M13*matrix2.M33 + matrix1.M14*matrix2.M43;
			result.M14 = matrix1.M11*matrix2.M14 + matrix1.M12*matrix2.M24 + matrix1.M13*matrix2.M34 + matrix1.M14*matrix2.M44;
				
			result.M21 = matrix1.M21*matrix2.M11 + matrix1.M22*matrix2.M21 + matrix1.M23*matrix2.M31 + matrix1.M24*matrix2.M41;
			result.M22 = matrix1.M21*matrix2.M12 + matrix1.M22*matrix2.M22 + matrix1.M23*matrix2.M32 + matrix1.M24*matrix2.M42;
			result.M23 = matrix1.M21*matrix2.M13 + matrix1.M22*matrix2.M23 + matrix1.M23*matrix2.M33 + matrix1.M24*matrix2.M43;
			result.M24 = matrix1.M21*matrix2.M14 + matrix1.M22*matrix2.M24 + matrix1.M23*matrix2.M34 + matrix1.M24*matrix2.M44;
			
			result.M31 = matrix1.M31*matrix2.M11 + matrix1.M32*matrix2.M21 + matrix1.M33*matrix2.M31 + matrix1.M34*matrix2.M41;
			result.M32 = matrix1.M31*matrix2.M12 + matrix1.M32*matrix2.M22 + matrix1.M33*matrix2.M32 + matrix1.M34*matrix2.M42;
			result.M33 = matrix1.M31*matrix2.M13 + matrix1.M32*matrix2.M23 + matrix1.M33*matrix2.M33 + matrix1.M34*matrix2.M43;
			result.M34 = matrix1.M31*matrix2.M14 + matrix1.M32*matrix2.M24 + matrix1.M33*matrix2.M34 + matrix1.M34*matrix2.M44;
			
			result.M41 = matrix1.M41*matrix2.M11 + matrix1.M42*matrix2.M21 + matrix1.M43*matrix2.M31 + matrix1.M44*matrix2.M41;
			result.M42 = matrix1.M41*matrix2.M12 + matrix1.M42*matrix2.M22 + matrix1.M43*matrix2.M32 + matrix1.M44*matrix2.M42;
			result.M43 = matrix1.M41*matrix2.M13 + matrix1.M42*matrix2.M23 + matrix1.M43*matrix2.M33 + matrix1.M44*matrix2.M43;
			result.M44 = matrix1.M41*matrix2.M14 + matrix1.M42*matrix2.M24 + matrix1.M43*matrix2.M34 + matrix1.M44*matrix2.M44;
#endif
		}
		
		public static Matrix Multiply (Matrix matrix1, float scaleFactor)
		{
			Multiply (ref matrix1, scaleFactor, out matrix1);
			return matrix1;
		}
		
		public static void Multiply (ref Matrix matrix1, float scaleFactor, out Matrix result)
		{
#if SIMD
			Vector4f scale = new Vector4f (scaleFactor);
			result.r1 = matrix1.r1 * scale;
			result.r2 = matrix1.r2 * scale;
			result.r3 = matrix1.r3 * scale;
			result.r4 = matrix1.r4 * scale;
#else
			result.M11 = matrix1.M11 * scaleFactor;
			result.M12 = matrix1.M12 * scaleFactor;
			result.M13 = matrix1.M13 * scaleFactor;
			result.M14 = matrix1.M14 * scaleFactor;
			
			result.M21 = matrix1.M21 * scaleFactor;
			result.M22 = matrix1.M22 * scaleFactor;
			result.M23 = matrix1.M23 * scaleFactor;
			result.M24 = matrix1.M24 * scaleFactor;
			
			result.M31 = matrix1.M31 * scaleFactor;
			result.M32 = matrix1.M32 * scaleFactor;
			result.M33 = matrix1.M33 * scaleFactor;
			result.M34 = matrix1.M34 * scaleFactor;
			
			result.M41 = matrix1.M41 * scaleFactor;
			result.M42 = matrix1.M42 * scaleFactor;
			result.M43 = matrix1.M43 * scaleFactor;
			result.M44 = matrix1.M44 * scaleFactor;
#endif
		}
		
		public static Matrix Negate (Matrix matrix)
		{
			Negate (ref matrix, out matrix);
			return matrix;
		}
		
		public static void Negate (ref Matrix matrix, out Matrix result)
		{
#if SIMD
			Vector4f sign = new Vector4f (-0.0f);
			result.r1 = matrix.r1 ^ sign;
			result.r2 = matrix.r2 ^ sign;
			result.r3 = matrix.r3 ^ sign;
			result.r4 = matrix.r4 ^ sign;
#else
			result.M11 = -matrix.M11;
			result.M12 = -matrix.M12;
			result.M13 = -matrix.M13;
			result.M14 = -matrix.M14;
			
			result.M21 = -matrix.M21;
			result.M22 = -matrix.M22;
			result.M23 = -matrix.M23;
			result.M24 = -matrix.M24;
			
			result.M31 = -matrix.M31;
			result.M32 = -matrix.M32;
			result.M33 = -matrix.M33;
			result.M34 = -matrix.M34;
			
			result.M41 = -matrix.M41;
			result.M42 = -matrix.M42;
			result.M43 = -matrix.M43;
			result.M44 = -matrix.M44;
#endif
		}
		
		public static Matrix Subtract (Matrix matrix1, Matrix matrix2)
		{
			Subtract (ref matrix1, ref matrix2, out matrix1);
			return matrix1;
		}
		
		public static void Subtract (ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
		{
#if SIMD
			result.r1 = matrix1.r1 - matrix2.r1;
			result.r2 = matrix1.r2 - matrix2.r2;
			result.r3 = matrix1.r3 - matrix2.r3;
			result.r4 = matrix1.r4 - matrix2.r4;
#else
			result.M11 = matrix1.M11 - matrix2.M11;
			result.M12 = matrix1.M12 - matrix2.M12;
			result.M13 = matrix1.M13 - matrix2.M13;
			result.M14 = matrix1.M14 - matrix2.M14;
			
			result.M21 = matrix1.M21 - matrix2.M21;
			result.M22 = matrix1.M22 - matrix2.M22;
			result.M23 = matrix1.M23 - matrix2.M23;
			result.M24 = matrix1.M24 - matrix2.M24;
			
			result.M31 = matrix1.M31 - matrix2.M31;
			result.M32 = matrix1.M32 - matrix2.M32;
			result.M33 = matrix1.M33 - matrix2.M33;
			result.M34 = matrix1.M34 - matrix2.M34;
			
			result.M41 = matrix1.M41 - matrix2.M41;
			result.M42 = matrix1.M42 - matrix2.M42;
			result.M43 = matrix1.M43 - matrix2.M43;
			result.M44 = matrix1.M44 - matrix2.M44;
#endif
		}
		
		public static Matrix Divide (Matrix matrix1, Matrix matrix2)
		{
			Divide (ref matrix1, ref matrix2, out matrix1);
			return matrix1;
		}
		
		public static void Divide (ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
		{
#if SIMD
			result.r1 = matrix1.r1 * matrix2.r1;
			result.r2 = matrix1.r2 * matrix2.r2;
			result.r3 = matrix1.r3 * matrix2.r3;
			result.r4 = matrix1.r4 * matrix2.r4;
#else
			result.M11 = matrix1.M11 / matrix2.M11;
			result.M12 = matrix1.M12 / matrix2.M12;
			result.M13 = matrix1.M13 / matrix2.M13;
			result.M14 = matrix1.M14 / matrix2.M14;
			
			result.M21 = matrix1.M21 / matrix2.M21;
			result.M22 = matrix1.M22 / matrix2.M22;
			result.M23 = matrix1.M23 / matrix2.M23;
			result.M24 = matrix1.M24 / matrix2.M24;
			
			result.M31 = matrix1.M31 / matrix2.M31;
			result.M32 = matrix1.M32 / matrix2.M32;
			result.M33 = matrix1.M33 / matrix2.M33;
			result.M34 = matrix1.M34 / matrix2.M34;
			
			result.M41 = matrix1.M41 / matrix2.M41;
			result.M42 = matrix1.M42 / matrix2.M42;
			result.M43 = matrix1.M43 / matrix2.M43;
			result.M44 = matrix1.M44 / matrix2.M44;
#endif
		}
		
		public static Matrix Divide (Matrix matrix1, float divider)
		{
			Divide (ref matrix1, divider, out matrix1);
			return matrix1;
		}
		
		public static void Divide (ref Matrix matrix1, float divider, out Matrix result)
		{
#if SIMD
			Vector4f divisor = new Vector4f (divider);
			result.r1 = matrix1.r1 / divisor;
			result.r2 = matrix1.r2 / divisor;
			result.r3 = matrix1.r3 / divisor;
			result.r4 = matrix1.r4 / divisor;
#else
			result.M11 = matrix1.M11 / divider;
			result.M12 = matrix1.M12 / divider;
			result.M13 = matrix1.M13 / divider;
			result.M14 = matrix1.M14 / divider;
			
			result.M21 = matrix1.M21 / divider;
			result.M22 = matrix1.M22 / divider;
			result.M23 = matrix1.M23 / divider;
			result.M24 = matrix1.M24 / divider;
			
			result.M31 = matrix1.M31 / divider;
			result.M32 = matrix1.M32 / divider;
			result.M33 = matrix1.M33 / divider;
			result.M34 = matrix1.M34 / divider;
			
			result.M41 = matrix1.M41 / divider;
			result.M42 = matrix1.M42 / divider;
			result.M43 = matrix1.M43 / divider;
			result.M44 = matrix1.M44 / divider;
#endif
		}
		
		#endregion
		
		#region Operator overloads
		
		public static Matrix operator + (Matrix matrix1, Matrix matrix2)
		{
			Add (ref matrix1, ref matrix2, out matrix1);
			return matrix1;
		}
		
		public static Matrix operator / (Matrix matrix, float divider)
		{
			Divide (ref matrix, divider, out matrix);
			return matrix;
		}
		
		public static Matrix operator / (Matrix matrix1, Matrix matrix2)
		{
			Divide (ref matrix1, ref matrix2, out matrix1);
			return matrix1;
		}
		
		public static Matrix operator * (Matrix matrix1, Matrix matrix2)
		{
#if SIMD
			//sse version only sets the result when the calculation is complete
			Multiply (ref matrix1, ref matrix2, out matrix1);
			return matrix1;
#else
			//non-sse version needs m1 and m1 to remain unchanged
			Matrix result;
			Multiply (ref matrix1, ref matrix2, out result);
			return result;
#endif
		}
		
		public static Matrix operator * (Matrix matrix, float scaleFactor)
		{
			Multiply (ref matrix, scaleFactor, out matrix);
			return matrix;
		}
		
		public static Matrix operator * (float scaleFactor, Matrix matrix)
		{
			Multiply (ref matrix, scaleFactor, out matrix);
			return matrix;
		}
		
		public static Matrix operator - (Matrix matrix1, Matrix matrix2)
		{
			Subtract (ref matrix1, ref matrix2, out matrix1);
			return matrix1;
		}
		
		public static Matrix operator - (Matrix matrix)
		{
			Negate (ref matrix, out matrix);
			return matrix;
		}
		
		#endregion
		
		#region Other maths
		
		public bool Decompose (out Vector3 scale, out Quaternion rotation, out Vector3 translation)
		{
			throw new NotImplementedException ();
		}
		
		public float Determinant ()
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix Invert (Matrix matrix)
		{
			Matrix result;
			Invert (ref matrix, out result);
			return result;
		}
		
		public static void Invert (ref Matrix matrix, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix Lerp (Matrix matrix1, Matrix matrix2, float amount)
		{
			Lerp (ref matrix1, ref matrix2, amount, out matrix1);
			return matrix1;
		}
		
		public static void Lerp (ref Matrix matrix1, ref Matrix matrix2, float amount, out Matrix result)
		{
#if SIMD
			result.r1 = matrix1.r1 + amount * (matrix2.r1 - matrix1.r1);
			result.r1 = matrix1.r2 + amount * (matrix2.r2 - matrix1.r2);
			result.r1 = matrix1.r3 + amount * (matrix2.r3 - matrix1.r3);
			result.r1 = matrix1.r4 + amount * (matrix2.r4 - matrix1.r4);
#else
			result.M11 = matrix1.M11 + amount * (matrix2.M11 - matrix1.M11);
			result.M12 = matrix1.M12 + amount * (matrix2.M12 - matrix1.M12);
			result.M13 = matrix1.M13 + amount * (matrix2.M13 - matrix1.M13);
			result.M14 = matrix1.M14 + amount * (matrix2.M14 - matrix1.M14);
			
			result.M21 = matrix1.M21 + amount * (matrix2.M21 - matrix1.M21);
			result.M22 = matrix1.M22 + amount * (matrix2.M22 - matrix1.M22);
			result.M23 = matrix1.M23 + amount * (matrix2.M23 - matrix1.M23);
			result.M24 = matrix1.M24 + amount * (matrix2.M24 - matrix1.M24);
			
			result.M31 = matrix1.M31 + amount * (matrix2.M31 - matrix1.M31);
			result.M32 = matrix1.M32 + amount * (matrix2.M32 - matrix1.M32);
			result.M33 = matrix1.M33 + amount * (matrix2.M33 - matrix1.M33);
			result.M34 = matrix1.M34 + amount * (matrix2.M34 - matrix1.M34);
			
			result.M41 = matrix1.M41 + amount * (matrix2.M41 - matrix1.M41);
			result.M42 = matrix1.M42 + amount * (matrix2.M42 - matrix1.M42);
			result.M43 = matrix1.M43 + amount * (matrix2.M43 - matrix1.M43);
			result.M44 = matrix1.M44 + amount * (matrix2.M44 - matrix1.M44);
#endif
		}
		
		public static Matrix Transform (Matrix value, Quaternion rotation)
		{
			Matrix result;
			Transform (ref value, ref rotation, out result);
			return result;
		}
		
		public static void Transform (ref Matrix value, ref Quaternion rotation, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		public static Matrix Transpose (Matrix matrix)
		{
#if SIMD
			//sse version of transpose doesn't need source unaltered
			Transpose (ref matrix, out matrix);
			return matrix;
#else
			return new Matrix (
				matrix.m11, matrix.m21, matrix.m31, matrix.m41,
				matrix.m12, matrix.m22, matrix.m32, matrix.m42,
				matrix.m13, matrix.m23, matrix.m33, matrix.m43,
				matrix.m14, matrix.m24, matrix.m34, matrix.m44);
#endif
		}
		
		public static void Transpose (ref Matrix matrix, out Matrix result)
		{
#if SIMD
			//algorithm from public domain - http://0x80.pl/snippets/asm/sse-transpose.c
			Vector4f xmm0 = matrix.r1; // xmm0 = a0 a1 a2 a3
			Vector4f xmm1 = matrix.r2; // xmm1 = b0 b1 b2 b3
			Vector4f xmm2 = matrix.r3; // xmm2 = c0 c1 c2 c3
			Vector4f xmm3 = matrix.r4; // xmm3 = d0 d1 d2 d3
			
			Vector4f xmm4 = xmm0;
			xmm0 = VectorOperations.InterleaveLow  (xmm0, xmm2); // xmm0 = a0 c0 a1 c1
			xmm4 = VectorOperations.InterleaveHigh (xmm4, xmm2); // xmm4 = a2 c2 a3 c3
			
			xmm2 = xmm1;
			xmm1 = VectorOperations.InterleaveLow  (xmm1, xmm3); // xmm1 = b0 d0 b1 d1
			xmm2 = VectorOperations.InterleaveHigh (xmm2, xmm3); // xmm2 = b2 d2 b3 d3
			
			xmm3 = xmm0;
			xmm0 = VectorOperations.InterleaveLow  (xmm0, xmm1); // xmm0 = a0 b0 c0 d0
			xmm3 = VectorOperations.InterleaveHigh (xmm3, xmm1); // xmm3 = a1 b1 c1 d1
			
			xmm1 = xmm4;
			xmm1 = VectorOperations.InterleaveLow  (xmm1, xmm2); // xmm1 = a2 b2 c2 d2
			xmm4 = VectorOperations.InterleaveHigh (xmm4, xmm2); // xmm4 = a3 b3 c3 d3
			
			result.r1 = xmm0;
			result.r2 = xmm3;
			result.r3 = xmm1;
			result.r4 = xmm4;
#else
			result.M11 = matrix.M11;
			result.M12 = matrix.M21;
			result.M13 = matrix.M31;
			result.M14 = matrix.M41;
			
			result.M21 = matrix.M12;
			result.M22 = matrix.M22;
			result.M23 = matrix.M32;
			result.M24 = matrix.M42;
			
			result.M31 = matrix.M13;
			result.M32 = matrix.M23;
			result.M33 = matrix.M33;
			result.M34 = matrix.M43;
			
			result.M41 = matrix.M14;
			result.M42 = matrix.M24;
			result.M43 = matrix.M34;
			result.M44 = matrix.M44;
#endif
		}
		
		#endregion
		
		#region Equality
		
		public bool Equals (Matrix other)
		{
#if SIMD
			return r1 == other.r1 && r2 == other.r2 && r3 == other.r3 && r4 == other.r4; 
#else
			return
				M11 == other.M11 && M12 == other.M12 && M13 == other.M13 && M14 == other.M14 &&
				M21 == other.M21 && M22 == other.M22 && M23 == other.M23 && M24 == other.M24 &&
				M31 == other.M31 && M32 == other.M32 && M33 == other.M33 && M34 == other.M34 &&
				M41 == other.M41 && M42 == other.M42 && M43 == other.M43 && M44 == other.M44;
#endif
		}
		
		public override bool Equals (object obj)
		{
			return obj is Matrix && ((Matrix)obj) == this;
		}
		
		public override int GetHashCode ()
		{
#if SIMD
			unsafe {
				Vector4f f = r1;
				Vector4i i = *((Vector4i*)&f);
				i = i ^ i.Shuffle (ShuffleSel.Swap);
				i = i ^ i.Shuffle (ShuffleSel.RotateLeft);
				f = r2;
				Vector4i j =  *((Vector4i*)&f);
				j = j ^ j.Shuffle (ShuffleSel.Swap);
				j = j ^ j.Shuffle (ShuffleSel.RotateLeft);
				f = r3;
				Vector4i k =  *((Vector4i*)&f);
				k = k ^ k.Shuffle (ShuffleSel.Swap);
				k = k ^ k.Shuffle (ShuffleSel.RotateLeft);
				f = r4;
				Vector4i l =  *((Vector4i*)&f);
				l = l ^ l.Shuffle (ShuffleSel.Swap);
				l = l ^ l.Shuffle (ShuffleSel.RotateLeft);
				return (i ^ j ^ k ^ l).X;
			}
#elif UNSAFE
			unsafe {
				float f = M11;
				int acc = *((int*)&f);
				f = M12; acc ^= *((int*)&f);
				f = M13; acc ^= *((int*)&f);
				f = M14; acc ^= *((int*)&f);
				
				f = M21; acc ^= *((int*)&f);
				f = M22; acc ^= *((int*)&f);
				f = M23; acc ^= *((int*)&f);
				f = M24; acc ^= *((int*)&f);
				
				f = M31; acc ^= *((int*)&f);
				f = M32; acc ^= *((int*)&f);
				f = M33; acc ^= *((int*)&f);
				f = M34; acc ^= *((int*)&f);
				
				f = M41; acc ^= *((int*)&f);
				f = M42; acc ^= *((int*)&f);
				f = M43; acc ^= *((int*)&f);
				f = M44; acc ^= *((int*)&f);
				return acc;
			}
			
#else
			return
				M11.GetHashCode () ^ M12.GetHashCode () ^ M13.GetHashCode () ^ M14.GetHashCode () ^
				M21.GetHashCode () ^ M22.GetHashCode () ^ M23.GetHashCode () ^ M24.GetHashCode () ^
				M31.GetHashCode () ^ M32.GetHashCode () ^ M33.GetHashCode () ^ M34.GetHashCode () ^
				M41.GetHashCode () ^ M42.GetHashCode () ^ M43.GetHashCode () ^ M44.GetHashCode (); 
#endif
		}
		
		public static bool operator == (Matrix a, Matrix b)
		{
#if SIMD
			return a.r1 == b.r1 && a.r2 == b.r2 && a.r3 == b.r3 && a.r4 == b.r4; 
#else
			return
				a.M11 == b.M11 && a.M12 == b.M12 && a.M13 == b.M13 && a.M14 == b.M14 &&
				a.M21 == b.M21 && a.M22 == b.M22 && a.M23 == b.M23 && a.M24 == b.M24 &&
				a.M31 == b.M31 && a.M32 == b.M32 && a.M33 == b.M33 && a.M34 == b.M34 &&
				a.M41 == b.M41 && a.M42 == b.M42 && a.M43 == b.M43 && a.M44 == b.M44;
#endif
		}
		
		public static bool operator != (Matrix a, Matrix b)
		{
#if SIMD
			return a.r1 != b.r1 || a.r2 != b.r2 || a.r3 != b.r3 || a.r4 != b.r4; 
#else
			return
				a.M11 != b.M11 || a.M12 != b.M12 || a.M13 != b.M13 && a.M14 != b.M14 ||
				a.M21 != b.M21 || a.M22 != b.M22 || a.M23 != b.M23 && a.M24 != b.M24 ||
				a.M31 != b.M31 || a.M32 != b.M32 || a.M33 != b.M33 && a.M34 != b.M34 ||
				a.M41 != b.M41 || a.M42 != b.M42 || a.M43 != b.M43 && a.M44 != b.M44;
#endif
		}
		
		# endregion
		
		public override string ToString ()
		{
			throw new NotImplementedException ();
		}
	}
}

