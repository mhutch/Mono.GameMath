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
		internal Vector4f r1, r2, r3, r4;
		
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
		float
			m11, m12, m13, m14,
			m21, m22, m23, m24,
			m31, m32, m33, m34,
			m41, m42, m43, m44;
		
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
#if SIMD
				return new Vector3 (r1 ^ new Vector4f (-0.0f));
#else
				return new Vector3 (-m11, -m12, -m13);
#endif
			}
			set {
#if SIMD
				var minus = value.v4 ^ new Vector4f (-0.0f);
				minus.W = M14;
				r1 = minus;
#else
				m11 = -value.X;
				m12 = -value.Y;
				m13 = -value.Z;
#endif
			}
		}
		
		public Vector3 Down {
			get {
#if SIMD
				return new Vector3 (r2 ^ new Vector4f (-0.0f));
#else
				return new Vector3 (-m21, -m22, -m23);
#endif
			}
			set {
#if SIMD
				var minus = value.v4 ^ new Vector4f (-0.0f);
				minus.W = M24;
				r2 = minus;
#else
				m21 = -value.X;
				m22 = -value.Y;
				m23 = -value.Z;
#endif
			}
		}
		
		public Vector3 Forward {
			get {
#if SIMD
				return new Vector3 (r3 ^ new Vector4f (-0.0f));
#else
				return new Vector3 (-m31, -m32, -m33);
#endif
			}
			set {
#if SIMD
				var minus = value.v4 ^ new Vector4f (-0.0f);
				minus.W = M34;
				r3 = minus;
#else
				m31 = -value.X;
				m32 = -value.Y;
				m33 = -value.Z;
#endif
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
			Quaternion quat;
			Quaternion.CreateFromYawPitchRoll (yaw, pitch, roll, out quat);
			CreateFromQuaternion (ref quat, out result);
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
			// http://msdn.microsoft.com/en-us/library/bb205343%28VS.85%29.aspx
			
			Vector3 pos;
			Vector3.Subtract (ref cameraPosition, ref cameraTarget, out pos);
			Vector3 vz;
			Vector3.Normalize (ref pos, out vz);
			
			Vector3 cross;
			Vector3.Cross (ref cameraUpVector, ref vz, out cross);
			Vector3 vx;
			Vector3.Normalize (ref cross, out vx);
			
			Vector3 vy;
			Vector3.Cross (ref vz, ref vx, out vy);
			
			float dvx, dvy, dvz;
			Vector3.Dot (ref vx, ref cameraPosition, out dvx);
			Vector3.Dot (ref vy, ref cameraPosition, out dvy);
			Vector3.Dot (ref vz, ref cameraPosition, out dvz);
			
			result = Identity;
			result.M11 = vx.X;
			result.M12 = vy.X;
			result.M13 = vz.X;
			result.M21 = vx.Y;
			result.M22 = vy.Y;
			result.M23 = vz.Y;
			result.M31 = vx.Z;
			result.M32 = vy.Z;
			result.M33 = vz.Z;
			result.M41 = -dvx;
			result.M42 = -dvy;
			result.M43 = -dvz;
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
			float cos = (float) System.Math.Cos (radians);
			float sin = (float) System.Math.Sin (radians);
			
			result = new Matrix ();
			result.M11 = 1.0f;
			result.M22 = cos;
			result.M23 = sin;
			result.M32 = -sin;
			result.M33 = cos;
			result.M44 = 1.0f;
		}
		
		public static Matrix CreateRotationY (float radians)
		{
			Matrix result;
			CreateRotationY (radians, out result);
			return result;
		}
		
		public static void CreateRotationY (float radians, out Matrix result)
		{
			float cos = (float) System.Math.Cos (radians);
			float sin = (float) System.Math.Sin (radians);
			
			result = new Matrix ();
			result.M11 = cos;
			result.M13 = -sin;
			result.M22 = 1.0f;
			result.M31 = sin;
			result.M33 = cos;
			result.M44 = 1.0f;
		}
		
		public static Matrix CreateRotationZ (float radians)
		{
			Matrix result;
			CreateRotationZ (radians, out result);
			return result;
		}
		
		public static void CreateRotationZ (float radians, out Matrix result)
		{
			float cos = (float) System.Math.Cos (radians);
			float sin = (float) System.Math.Sin (radians);
			
			result = new Matrix ();
			result.M11 = cos;
			result.M12 = sin;
			result.M21 = -sin;
			result.M22 = cos;
			result.M33 = 1.0f;
			result.M44 = 1.0f;
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
			result = new Matrix ();
			result.M11 = scales.X;
			result.M22 = scales.Y;
			result.M33 = scales.Z;
			result.M44 = 1.0f;
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
			result = new Matrix ();
			result.M11 = 1.0f;
			result.M22 = 1.0f;
			result.M33 = 1.0f;
			result.M41 = position.X;
			result.M42 = position.Y;
			result.M43 = position.Z;
			result.M44 = 1.0f;
		}
		
		public static Matrix CreateWorld (Vector3 position, Vector3 forward, Vector3 up)
		{
			Matrix result;
			CreateWorld (ref position, ref forward, ref up, out result);
			return result;
		}
		
		public static void CreateWorld (ref Vector3 position, ref Vector3 forward, ref Vector3 up, out Matrix result)
		{
			Vector3 x, y, z;
			
			Vector3.Cross (ref forward, ref up, out x);
			Vector3.Cross (ref x, ref forward, out y);
			Vector3.Normalize (ref forward, out z);
			
			x.Normalize ();
			y.Normalize ();
			
			result = new Matrix ();
			result.Right = x;
			result.Up = y;
			result.Forward = z;
			result.Translation = position;
			result.M44 = 1.0f;
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
			result.m11 = matrix1.m11 + matrix2.m11;
			result.m12 = matrix1.m12 + matrix2.m12;
			result.m13 = matrix1.m13 + matrix2.m13;
			result.m14 = matrix1.m14 + matrix2.m14;
			
			result.m21 = matrix1.m21 + matrix2.m21;
			result.m22 = matrix1.m22 + matrix2.m22;
			result.m23 = matrix1.m23 + matrix2.m23;
			result.m24 = matrix1.m24 + matrix2.m24;
			
			result.m31 = matrix1.m31 + matrix2.m31;
			result.m32 = matrix1.m32 + matrix2.m32;
			result.m33 = matrix1.m33 + matrix2.m33;
			result.m34 = matrix1.m34 + matrix2.m34;
			
			result.m41 = matrix1.m41 + matrix2.m41;
			result.m42 = matrix1.m42 + matrix2.m42;
			result.m43 = matrix1.m43 + matrix2.m43;
			result.m44 = matrix1.m44 + matrix2.m44;
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
			result.m11 = matrix1.m11*matrix2.m11 + matrix1.m12*matrix2.m21 + matrix1.m13*matrix2.m31 + matrix1.m14*matrix2.m41;
			result.m12 = matrix1.m11*matrix2.m12 + matrix1.m12*matrix2.m22 + matrix1.m13*matrix2.m32 + matrix1.m14*matrix2.m42;
			result.m13 = matrix1.m11*matrix2.m13 + matrix1.m12*matrix2.m23 + matrix1.m13*matrix2.m33 + matrix1.m14*matrix2.m43;
			result.m14 = matrix1.m11*matrix2.m14 + matrix1.m12*matrix2.m24 + matrix1.m13*matrix2.m34 + matrix1.m14*matrix2.m44;
				
			result.m21 = matrix1.m21*matrix2.m11 + matrix1.m22*matrix2.m21 + matrix1.m23*matrix2.m31 + matrix1.m24*matrix2.m41;
			result.m22 = matrix1.m21*matrix2.m12 + matrix1.m22*matrix2.m22 + matrix1.m23*matrix2.m32 + matrix1.m24*matrix2.m42;
			result.m23 = matrix1.m21*matrix2.m13 + matrix1.m22*matrix2.m23 + matrix1.m23*matrix2.m33 + matrix1.m24*matrix2.m43;
			result.m24 = matrix1.m21*matrix2.m14 + matrix1.m22*matrix2.m24 + matrix1.m23*matrix2.m34 + matrix1.m24*matrix2.m44;
			
			result.m31 = matrix1.m31*matrix2.m11 + matrix1.m32*matrix2.m21 + matrix1.m33*matrix2.m31 + matrix1.m34*matrix2.m41;
			result.m32 = matrix1.m31*matrix2.m12 + matrix1.m32*matrix2.m22 + matrix1.m33*matrix2.m32 + matrix1.m34*matrix2.m42;
			result.m33 = matrix1.m31*matrix2.m13 + matrix1.m32*matrix2.m23 + matrix1.m33*matrix2.m33 + matrix1.m34*matrix2.m43;
			result.m34 = matrix1.m31*matrix2.m14 + matrix1.m32*matrix2.m24 + matrix1.m33*matrix2.m34 + matrix1.m34*matrix2.m44;
			
			result.m41 = matrix1.m41*matrix2.m11 + matrix1.m42*matrix2.m21 + matrix1.m43*matrix2.m31 + matrix1.m44*matrix2.m41;
			result.m42 = matrix1.m41*matrix2.m12 + matrix1.m42*matrix2.m22 + matrix1.m43*matrix2.m32 + matrix1.m44*matrix2.m42;
			result.m43 = matrix1.m41*matrix2.m13 + matrix1.m42*matrix2.m23 + matrix1.m43*matrix2.m33 + matrix1.m44*matrix2.m43;
			result.m44 = matrix1.m41*matrix2.m14 + matrix1.m42*matrix2.m24 + matrix1.m43*matrix2.m34 + matrix1.m44*matrix2.m44;
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
			result.m11 = matrix1.m11 * scaleFactor;
			result.m12 = matrix1.m12 * scaleFactor;
			result.m13 = matrix1.m13 * scaleFactor;
			result.m14 = matrix1.m14 * scaleFactor;
			
			result.m21 = matrix1.m21 * scaleFactor;
			result.m22 = matrix1.m22 * scaleFactor;
			result.m23 = matrix1.m23 * scaleFactor;
			result.m24 = matrix1.m24 * scaleFactor;
			
			result.m31 = matrix1.m31 * scaleFactor;
			result.m32 = matrix1.m32 * scaleFactor;
			result.m33 = matrix1.m33 * scaleFactor;
			result.m34 = matrix1.m34 * scaleFactor;
			
			result.m41 = matrix1.m41 * scaleFactor;
			result.m42 = matrix1.m42 * scaleFactor;
			result.m43 = matrix1.m43 * scaleFactor;
			result.m44 = matrix1.m44 * scaleFactor;
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
			result.m11 = -matrix.m11;
			result.m12 = -matrix.m12;
			result.m13 = -matrix.m13;
			result.m14 = -matrix.m14;
			
			result.m21 = -matrix.m21;
			result.m22 = -matrix.m22;
			result.m23 = -matrix.m23;
			result.m24 = -matrix.m24;
			
			result.m31 = -matrix.m31;
			result.m32 = -matrix.m32;
			result.m33 = -matrix.m33;
			result.m34 = -matrix.m34;
			
			result.m41 = -matrix.m41;
			result.m42 = -matrix.m42;
			result.m43 = -matrix.m43;
			result.m44 = -matrix.m44;
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
			result.m11 = matrix1.m11 - matrix2.m11;
			result.m12 = matrix1.m12 - matrix2.m12;
			result.m13 = matrix1.m13 - matrix2.m13;
			result.m14 = matrix1.m14 - matrix2.m14;
			
			result.m21 = matrix1.m21 - matrix2.m21;
			result.m22 = matrix1.m22 - matrix2.m22;
			result.m23 = matrix1.m23 - matrix2.m23;
			result.m24 = matrix1.m24 - matrix2.m24;
			
			result.m31 = matrix1.m31 - matrix2.m31;
			result.m32 = matrix1.m32 - matrix2.m32;
			result.m33 = matrix1.m33 - matrix2.m33;
			result.m34 = matrix1.m34 - matrix2.m34;
			
			result.m41 = matrix1.m41 - matrix2.m41;
			result.m42 = matrix1.m42 - matrix2.m42;
			result.m43 = matrix1.m43 - matrix2.m43;
			result.m44 = matrix1.m44 - matrix2.m44;
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
			result.m11 = matrix1.m11 / matrix2.m11;
			result.m12 = matrix1.m12 / matrix2.m12;
			result.m13 = matrix1.m13 / matrix2.m13;
			result.m14 = matrix1.m14 / matrix2.m14;
			
			result.m21 = matrix1.m21 / matrix2.m21;
			result.m22 = matrix1.m22 / matrix2.m22;
			result.m23 = matrix1.m23 / matrix2.m23;
			result.m24 = matrix1.m24 / matrix2.m24;
			
			result.m31 = matrix1.m31 / matrix2.m31;
			result.m32 = matrix1.m32 / matrix2.m32;
			result.m33 = matrix1.m33 / matrix2.m33;
			result.m34 = matrix1.m34 / matrix2.m34;
			
			result.m41 = matrix1.m41 / matrix2.m41;
			result.m42 = matrix1.m42 / matrix2.m42;
			result.m43 = matrix1.m43 / matrix2.m43;
			result.m44 = matrix1.m44 / matrix2.m44;
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
			result.m11 = matrix1.m11 / divider;
			result.m12 = matrix1.m12 / divider;
			result.m13 = matrix1.m13 / divider;
			result.m14 = matrix1.m14 / divider;
			
			result.m21 = matrix1.m21 / divider;
			result.m22 = matrix1.m22 / divider;
			result.m23 = matrix1.m23 / divider;
			result.m24 = matrix1.m24 / divider;
			
			result.m31 = matrix1.m31 / divider;
			result.m32 = matrix1.m32 / divider;
			result.m33 = matrix1.m33 / divider;
			result.m34 = matrix1.m34 / divider;
			
			result.m41 = matrix1.m41 / divider;
			result.m42 = matrix1.m42 / divider;
			result.m43 = matrix1.m43 / divider;
			result.m44 = matrix1.m44 / divider;
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
			return
				M11 * M22 * M33 * M44 - M11 * M22 * M34 * M43 + M11 * M23 * M34 * M42 - M11 * M23 * M32 * M44 +
				M11 * M24 * M32 * M43 - M11 * M24 * M33 * M42 - M12 * M23 * M34 * M41 + M12 * M23 * M31 * M44 -
				M12 * M24 * M31 * M43 + M12 * M24 * M33 * M41 - M12 * M21 * M33 * M44 + M12 * M21 * M34 * M43 +
				M13 * M24 * M31 * M42 - M13 * M24 * M32 * M41 + M13 * M21 * M32 * M44 - M13 * M21 * M34 * M42 +
				M13 * M22 * M34 * M41 - M13 * M22 * M31 * M44 - M14 * M21 * M32 * M43 + M14 * M21 * M33 * M42 -
				M14 * M22 * M33 * M41 + M14 * M22 * M31 * M43 - M14 * M23 * M31 * M42 + M14 * M23 * M32 * M41;
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
			result.r2 = matrix1.r2 + amount * (matrix2.r2 - matrix1.r2);
			result.r3 = matrix1.r3 + amount * (matrix2.r3 - matrix1.r3);
			result.r4 = matrix1.r4 + amount * (matrix2.r4 - matrix1.r4);
#else
			result.m11 = matrix1.m11 + amount * (matrix2.m11 - matrix1.m11);
			result.m12 = matrix1.m12 + amount * (matrix2.m12 - matrix1.m12);
			result.m13 = matrix1.m13 + amount * (matrix2.m13 - matrix1.m13);
			result.m14 = matrix1.m14 + amount * (matrix2.m14 - matrix1.m14);
			
			result.m21 = matrix1.m21 + amount * (matrix2.m21 - matrix1.m21);
			result.m22 = matrix1.m22 + amount * (matrix2.m22 - matrix1.m22);
			result.m23 = matrix1.m23 + amount * (matrix2.m23 - matrix1.m23);
			result.m24 = matrix1.m24 + amount * (matrix2.m24 - matrix1.m24);
			
			result.m31 = matrix1.m31 + amount * (matrix2.m31 - matrix1.m31);
			result.m32 = matrix1.m32 + amount * (matrix2.m32 - matrix1.m32);
			result.m33 = matrix1.m33 + amount * (matrix2.m33 - matrix1.m33);
			result.m34 = matrix1.m34 + amount * (matrix2.m34 - matrix1.m34);
			
			result.m41 = matrix1.m41 + amount * (matrix2.m41 - matrix1.m41);
			result.m42 = matrix1.m42 + amount * (matrix2.m42 - matrix1.m42);
			result.m43 = matrix1.m43 + amount * (matrix2.m43 - matrix1.m43);
			result.m44 = matrix1.m44 + amount * (matrix2.m44 - matrix1.m44);
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
			Vector4f xmm0 = matrix.r1, xmm1 = matrix.r2, xmm2 = matrix.r3, xmm3 = matrix.r4;
			Vector4f xmm4 = xmm0;
			xmm0 = VectorOperations.InterleaveLow  (xmm0, xmm2);
			xmm4 = VectorOperations.InterleaveHigh (xmm4, xmm2);
			xmm2 = xmm1;
			xmm1 = VectorOperations.InterleaveLow  (xmm1, xmm3);
			xmm2 = VectorOperations.InterleaveHigh (xmm2, xmm3);
			xmm3 = xmm0;
			xmm0 = VectorOperations.InterleaveLow  (xmm0, xmm1);
			xmm3 = VectorOperations.InterleaveHigh (xmm3, xmm1);
			xmm1 = xmm4;
			xmm1 = VectorOperations.InterleaveLow  (xmm1, xmm2);
			xmm4 = VectorOperations.InterleaveHigh (xmm4, xmm2);
			
			return new Matrix (xmm0, xmm3, xmm1, xmm4);
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
			result.m11 = matrix.m11;
			result.m12 = matrix.m21;
			result.m13 = matrix.m31;
			result.m14 = matrix.m41;
			
			result.m21 = matrix.m12;
			result.m22 = matrix.m22;
			result.m23 = matrix.m32;
			result.m24 = matrix.m42;
			
			result.m31 = matrix.m13;
			result.m32 = matrix.m23;
			result.m33 = matrix.m33;
			result.m34 = matrix.m43;
			
			result.m41 = matrix.m14;
			result.m42 = matrix.m24;
			result.m43 = matrix.m34;
			result.m44 = matrix.m44;
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
				m11 == other.m11 && m12 == other.m12 && m13 == other.m13 && m14 == other.m14 &&
				m21 == other.m21 && m22 == other.m22 && m23 == other.m23 && m24 == other.m24 &&
				m31 == other.m31 && m32 == other.m32 && m33 == other.m33 && m34 == other.m34 &&
				m41 == other.m41 && m42 == other.m42 && m43 == other.m43 && m44 == other.m44;
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
				float f = m11;
				int acc = *((int*)&f);
				f = m12; acc ^= *((int*)&f);
				f = m13; acc ^= *((int*)&f);
				f = m14; acc ^= *((int*)&f);
				
				f = m21; acc ^= *((int*)&f);
				f = m22; acc ^= *((int*)&f);
				f = m23; acc ^= *((int*)&f);
				f = m24; acc ^= *((int*)&f);
				
				f = m31; acc ^= *((int*)&f);
				f = m32; acc ^= *((int*)&f);
				f = m33; acc ^= *((int*)&f);
				f = m34; acc ^= *((int*)&f);
				
				f = m41; acc ^= *((int*)&f);
				f = m42; acc ^= *((int*)&f);
				f = m43; acc ^= *((int*)&f);
				f = m44; acc ^= *((int*)&f);
				return acc;
			}
			
#else
			return
				m11.GetHashCode () ^ m12.GetHashCode () ^ m13.GetHashCode () ^ m14.GetHashCode () ^
				m21.GetHashCode () ^ m22.GetHashCode () ^ m23.GetHashCode () ^ m24.GetHashCode () ^
				m31.GetHashCode () ^ m32.GetHashCode () ^ m33.GetHashCode () ^ m34.GetHashCode () ^
				m41.GetHashCode () ^ m42.GetHashCode () ^ m43.GetHashCode () ^ m44.GetHashCode (); 
#endif
		}
		
		public static bool operator == (Matrix a, Matrix b)
		{
#if SIMD
			return a.r1 == b.r1 && a.r2 == b.r2 && a.r3 == b.r3 && a.r4 == b.r4; 
#else
			return
				a.m11 == b.m11 && a.m12 == b.m12 && a.m13 == b.m13 && a.m14 == b.m14 &&
				a.m21 == b.m21 && a.m22 == b.m22 && a.m23 == b.m23 && a.m24 == b.m24 &&
				a.m31 == b.m31 && a.m32 == b.m32 && a.m33 == b.m33 && a.m34 == b.m34 &&
				a.m41 == b.m41 && a.m42 == b.m42 && a.m43 == b.m43 && a.m44 == b.m44;
#endif
		}
		
		public static bool operator != (Matrix a, Matrix b)
		{
#if SIMD
			return a.r1 != b.r1 || a.r2 != b.r2 || a.r3 != b.r3 || a.r4 != b.r4; 
#else
			return
				a.m11 != b.m11 || a.m12 != b.m12 || a.m13 != b.m13 && a.m14 != b.m14 ||
				a.m21 != b.m21 || a.m22 != b.m22 || a.m23 != b.m23 && a.m24 != b.m24 ||
				a.m31 != b.m31 || a.m32 != b.m32 || a.m33 != b.m33 && a.m34 != b.m34 ||
				a.m41 != b.m41 || a.m42 != b.m42 || a.m43 != b.m43 && a.m44 != b.m44;
#endif
		}
		
		# endregion
		
		public override string ToString ()
		{
			return string.Format (
				"{{" +
				"{{M11:{0} M12:{1} M13:{2} M14:{3}}} " +
				"{{M21:{4} M22:{5} M23:{6} M24:{7}}} " +
				"{{M31:{8} M32:{9} M33:{10} M34:{11}}} " +
				"{{M41:{12} M42:{13} M43:{14} M44:{15}}}" +
				"}}",
				M11, M12, M13, M14,
				M21, M22, M23, M24,
				M31, M32, M33, M34,
				M41, M42, M43, M44);
		}
	}
}

