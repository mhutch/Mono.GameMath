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

#if XNA
namespace Microsoft.Xna.Framework
#else
namespace Mono.GameMath
#endif
{
#if !(SILVERLIGHT)
    [Serializable]
#endif
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
            Vector3 vector;
            Vector3 vector2;
            Vector3 vector3;
            vector.x = objectPosition.X - cameraPosition.X;
            vector.y = objectPosition.Y - cameraPosition.Y;
            vector.z = objectPosition.Z - cameraPosition.Z;
            float num = vector.LengthSquared();
            if (num < 0.0001f)
            {
                vector = cameraForwardVector.HasValue ? -cameraForwardVector.Value : Vector3.Forward;
            }
            else
            {
                Vector3.Multiply(ref vector, (float)(1f / ((float)Math.Sqrt((double)num))), out vector);
            }
            Vector3.Cross(ref cameraUpVector, ref vector, out vector3);
            vector3.Normalize();
            Vector3.Cross(ref vector, ref vector3, out vector2);
            result = new Matrix();
            result.M11 = vector3.X;
            result.M12 = vector3.Y;
            result.M13 = vector3.Z;
            result.M14 = 0f;
            result.M21 = vector2.X;
            result.M22 = vector2.Y;
            result.M23 = vector2.Z;
            result.M24 = 0f;
            result.M31 = vector.X;
            result.M32 = vector.Y;
            result.M33 = vector.Z;
            result.M34 = 0f;
            result.M41 = objectPosition.X;
            result.M42 = objectPosition.Y;
            result.M43 = objectPosition.Z;
            result.M44 = 1f;
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
            float num;
            Vector3 vector;
            Vector3 vector2;
            Vector3 vector3;
            vector2.x = objectPosition.X - cameraPosition.X;
            vector2.y = objectPosition.Y - cameraPosition.Y;
            vector2.z = objectPosition.Z - cameraPosition.Z;
            float num2 = vector2.LengthSquared();
            if (num2 < 0.0001f)
            {
                vector2 = cameraForwardVector.HasValue ? -cameraForwardVector.Value : Vector3.Forward;
            }
            else
            {
                Vector3.Multiply(ref vector2, (float)(1f / ((float)Math.Sqrt((double)num2))), out vector2);
            }
            Vector3 vector4 = rotateAxis;
            Vector3.Dot(ref rotateAxis, ref vector2, out num);
            if (Math.Abs(num) > 0.9982547f)
            {
                if (objectForwardVector.HasValue)
                {
                    vector = objectForwardVector.Value;
                    Vector3.Dot(ref rotateAxis, ref vector, out num);
                    if (Math.Abs(num) > 0.9982547f)
                    {
                        num = ((rotateAxis.X * Vector3.Forward.X) + (rotateAxis.Y * Vector3.Forward.Y)) + (rotateAxis.Z * Vector3.Forward.Z);
                        vector = (Math.Abs(num) > 0.9982547f) ? Vector3.Right : Vector3.Forward;
                    }
                }
                else
                {
                    num = ((rotateAxis.X * Vector3.Forward.X) + (rotateAxis.Y * Vector3.Forward.Y)) + (rotateAxis.Z * Vector3.Forward.Z);
                    vector = (Math.Abs(num) > 0.9982547f) ? Vector3.Right : Vector3.Forward;
                }
                Vector3.Cross(ref rotateAxis, ref vector, out vector3);
                vector3.Normalize();
                Vector3.Cross(ref vector3, ref rotateAxis, out vector);
                vector.Normalize();
            }
            else
            {
                Vector3.Cross(ref rotateAxis, ref vector2, out vector3);
                vector3.Normalize();
                Vector3.Cross(ref vector3, ref vector4, out vector);
                vector.Normalize();
            }
            result = new Matrix();
            result.M11 = vector3.X;
            result.M12 = vector3.Y;
            result.M13 = vector3.Z;
            result.M14 = 0f;
            result.M21 = vector4.X;
            result.M22 = vector4.Y;
            result.M23 = vector4.Z;
            result.M24 = 0f;
            result.M31 = vector.X;
            result.M32 = vector.Y;
            result.M33 = vector.Z;
            result.M34 = 0f;
            result.M41 = objectPosition.X;
            result.M42 = objectPosition.Y;
            result.M43 = objectPosition.Z;
            result.M44 = 1f;
		}
		
		public static Matrix CreateFromAxisAngle (Vector3 axis, float angle)
		{
			Matrix result;
			CreateFromAxisAngle (ref axis, angle, out result);
			return result;
		}
		
		public static void CreateFromAxisAngle (ref Vector3 axis, float angle, out Matrix result)
		{
            result = new Matrix();
            float x = axis.X;
            float y = axis.Y;
            float z = axis.Z;
            float sin = (float)Math.Sin((double)angle);
            float cos = (float)Math.Cos((double)angle);
            float xx = x * x;
            float yy = y * y;
            float zz = z * z;
            float xy = x * y;
            float xz = x * z;
            float yz = y * z;
            result.M11 = xx + (cos * (1f - xx));
            result.M12 = (xy - (cos * xy)) + (sin * z);
            result.M13 = (xz - (cos * xz)) - (sin * y);
            //result.M14 = 0f;
            result.M21 = (xy - (cos * xy)) - (sin * z);
            result.M22 = yy + (cos * (1f - yy));
            result.M23 = (yz - (cos * yz)) + (sin * x);
            //result.M24 = 0f;
            result.M31 = (xz - (cos * xz)) + (sin * y);
            result.M32 = (yz - (cos * yz)) - (sin * x);
            result.M33 = zz + (cos * (1f - zz));
            //result.M34 = 0f;
            //result.M41 = 0f;
            //result.M42 = 0f;
            //result.M43 = 0f;
            result.M44 = 1f;
		}
		
		public static Matrix CreateFromQuaternion (Quaternion quaternion)
		{
			Matrix result;
			CreateFromQuaternion (ref quaternion, out result);
			return result;
		}
		
		public static void CreateFromQuaternion (ref Quaternion quaternion, out Matrix result)
		{            
            float xx = quaternion.X * quaternion.X;
            float yy = quaternion.Y * quaternion.Y;
            float zz = quaternion.Z * quaternion.Z;
            float xy = quaternion.X * quaternion.Y;
            float zw = quaternion.Z * quaternion.W;
            float zx = quaternion.Z * quaternion.X;
            float yw = quaternion.Y * quaternion.W;
            float yz = quaternion.Y * quaternion.Z;
            float xw = quaternion.X * quaternion.W;

            result = new Matrix();
            
            result.M11 = 1f - (2f * (yy + zz));            
            result.M12 = 2f * (xy + zw);
            result.M13 = 2f * (zx - yw);
            //result.M14 = 0f;
            result.M21 = 2f * (xy - zw);
            result.M22 = 1f - (2f * (zz + xx));
            result.M23 = 2f * (yz + xw);
            //result.M24 = 0f;
            result.M31 = 2f * (zx + yw);
            result.M32 = 2f * (yz - xw);
            result.M33 = 1f - (2f * (yy + xx));
            //result.M34 = 0f;
            //result.M41 = 0f;
            //result.M42 = 0f;
            //result.M43 = 0f;
            result.M44 = 1f;
            
            
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
            result = new Matrix();
            result.M11 = 2f / width;
            //result.M12 = result.M13 = result.M14 = 0f;
            result.M22 = 2f / height;
            //result.M21 = result.M23 = result.M24 = 0f;
            result.M33 = 1f / (zNearPlane - zFarPlane);
            result.M31 = result.M32 = result.M34 = 0f;
            //result.M41 = result.M42 = 0f;
            result.M43 = zNearPlane / (zNearPlane - zFarPlane);
            result.M44 = 1f;
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
            result = new Matrix();
            result.M11 = 2f / (right - left);
            //result.M12 = result.M13 = result.M14 = 0f;
            result.M22 = 2f / (top - bottom);
            //result.M21 = result.M23 = result.M24 = 0f;
            result.M33 = 1f / (zNearPlane - zFarPlane);
            //result.M31 = result.M32 = result.M34 = 0f;
            result.M41 = (left + right) / (left - right);
            result.M42 = (top + bottom) / (bottom - top);
            result.M43 = zNearPlane / (zNearPlane - zFarPlane);
            result.M44 = 1f;
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
            if (nearPlaneDistance <= 0f)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance"); //, string.Format(CultureInfo.CurrentCulture, FrameworkResources.NegativePlaneDistance, new object[] { "nearPlaneDistance" }));
            }
            if (farPlaneDistance <= 0f)
            {
                throw new ArgumentOutOfRangeException("farPlaneDistance"); //, string.Format(CultureInfo.CurrentCulture, FrameworkResources.NegativePlaneDistance, new object[] { "farPlaneDistance" }));
            }
            if (nearPlaneDistance >= farPlaneDistance)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance"); //, FrameworkResources.OppositePlanes);
            }
            result = new Matrix();
            result.M11 = (2f * nearPlaneDistance) / width;
            //result.M12 = result.M13 = result.M14 = 0f;
            result.M22 = (2f * nearPlaneDistance) / height;
            //result.M21 = result.M23 = result.M24 = 0f;
            result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            //result.M31 = result.M32 = 0f;
            result.M34 = -1f;
            //result.M41 = result.M42 = result.M44 = 0f;
            result.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
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
            if ((fieldOfView <= 0f) || (fieldOfView >= MathHelper.Pi))
            {
                throw new ArgumentOutOfRangeException("fieldOfView"); 
            }
            if (nearPlaneDistance <= 0f)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance");
            }
            if (farPlaneDistance <= 0f)
            {
                throw new ArgumentOutOfRangeException("farPlaneDistance");
            }
            if (nearPlaneDistance >= farPlaneDistance)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance");
            }
            float num = 1f / ((float)Math.Tan((double)(fieldOfView * 0.5f)));
            float num9 = num / aspectRatio;
            result = new Matrix();
            result.M11 = num9;
            //result.M12 = result.m13 = result.m14 = 0f;
            result.M22 = num;
            //result.M21 = result.m23 = result.m24 = 0f;
            //result.M31 = result.m32 = 0f;
            result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            result.M34 = -1f;
           // result.M41 = result.m42 = result.m44 = 0f;
            result.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
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
            if (nearPlaneDistance <= 0f)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance"); //, string.Format(CultureInfo.CurrentCulture, FrameworkResources.NegativePlaneDistance, new object[] { "nearPlaneDistance" }));
            }
            if (farPlaneDistance <= 0f)
            {
                throw new ArgumentOutOfRangeException("farPlaneDistance"); //, string.Format(CultureInfo.CurrentCulture, FrameworkResources.NegativePlaneDistance, new object[] { "farPlaneDistance" }));
            }
            if (nearPlaneDistance >= farPlaneDistance)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance"); //, FrameworkResources.OppositePlanes);
            }
            result = new Matrix();
            result.M11 = (2f * nearPlaneDistance) / (right - left);
            //result.M12 = result.M13 = result.M14 = 0f;
            result.M22 = (2f * nearPlaneDistance) / (top - bottom);
            //result.M21 = result.M23 = result.M24 = 0f;
            result.M31 = (left + right) / (right - left);
            result.M32 = (top + bottom) / (top - bottom);
            result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            result.M34 = -1f;
            result.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
            result.M41 = result.M42 = result.M44 = 0f;
		}
		
		public static Matrix CreateReflection (Plane value)
		{
			Matrix result;
			CreateReflection (ref value, out result);
			return result;
		}
		
		public static void CreateReflection (ref Plane value, out Matrix result)
		{
            Plane plane;
            Plane.Normalize(ref value, out plane);
            value.Normalize();
            float x = plane.Normal.X;
            float y = plane.Normal.Y;
            float z = plane.Normal.Z;
            float num3 = -2f * x;
            float num2 = -2f * y;
            float num = -2f * z;
            result = new Matrix();
            result.M11 = (num3 * x) + 1f;
            result.M12 = num2 * x;
            result.M13 = num * x;
            //result.M14 = 0f;
            result.M21 = num3 * y;
            result.M22 = (num2 * y) + 1f;
            result.M23 = num * y;
            //result.M24 = 0f;
            result.M31 = num3 * z;
            result.M32 = num2 * z;
            result.M33 = (num * z) + 1f;
            //result.M34 = 0f;
            result.M41 = num3 * plane.D;
            result.M42 = num2 * plane.D;
            result.M43 = num * plane.D;
            result.M44 = 1f;

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
            float num16 = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            float num15 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            float num14 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            float num13 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            float num12 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            float num11 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            float num10 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            float num9 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            float num8 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            float num7 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            float num6 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            float num5 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            float num4 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            float num3 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            float num2 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
            float num = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
            result.m11 = num16;
            result.m12 = num15;
            result.m13 = num14;
            result.m14 = num13;
            result.m21 = num12;
            result.m22 = num11;
            result.m23 = num10;
            result.m24 = num9;
            result.m31 = num8;
            result.m32 = num7;
            result.m33 = num6;
            result.m34 = num5;
            result.m41 = num4;
            result.m42 = num3;
            result.m43 = num2;
            result.m44 = num;
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
            float num5 = matrix.M11;
            float num4 = matrix.M12;
            float num3 = matrix.M13;
            float num2 = matrix.M14;
            float num9 = matrix.M21;
            float num8 = matrix.M22;
            float num7 = matrix.M23;
            float num6 = matrix.M24;
            float num17 = matrix.M31;
            float num16 = matrix.M32;
            float num15 = matrix.M33;
            float num14 = matrix.M34;
            float num13 = matrix.M41;
            float num12 = matrix.M42;
            float num11 = matrix.M43;
            float num10 = matrix.M44;
            float num23 = (num15 * num10) - (num14 * num11);
            float num22 = (num16 * num10) - (num14 * num12);
            float num21 = (num16 * num11) - (num15 * num12);
            float num20 = (num17 * num10) - (num14 * num13);
            float num19 = (num17 * num11) - (num15 * num13);
            float num18 = (num17 * num12) - (num16 * num13);
            float num39 = ((num8 * num23) - (num7 * num22)) + (num6 * num21);
            float num38 = -(((num9 * num23) - (num7 * num20)) + (num6 * num19));
            float num37 = ((num9 * num22) - (num8 * num20)) + (num6 * num18);
            float num36 = -(((num9 * num21) - (num8 * num19)) + (num7 * num18));
            float num = 1f / ((((num5 * num39) + (num4 * num38)) + (num3 * num37)) + (num2 * num36));
            result.m11 = num39 * num;
            result.m21 = num38 * num;
            result.m31 = num37 * num;
            result.m41 = num36 * num;
            result.m12 = -(((num4 * num23) - (num3 * num22)) + (num2 * num21)) * num;
            result.m22 = (((num5 * num23) - (num3 * num20)) + (num2 * num19)) * num;
            result.m32 = -(((num5 * num22) - (num4 * num20)) + (num2 * num18)) * num;
            result.m42 = (((num5 * num21) - (num4 * num19)) + (num3 * num18)) * num;
            float num35 = (num7 * num10) - (num6 * num11);
            float num34 = (num8 * num10) - (num6 * num12);
            float num33 = (num8 * num11) - (num7 * num12);
            float num32 = (num9 * num10) - (num6 * num13);
            float num31 = (num9 * num11) - (num7 * num13);
            float num30 = (num9 * num12) - (num8 * num13);
            result.m13 = (((num4 * num35) - (num3 * num34)) + (num2 * num33)) * num;
            result.m23 = -(((num5 * num35) - (num3 * num32)) + (num2 * num31)) * num;
            result.m33 = (((num5 * num34) - (num4 * num32)) + (num2 * num30)) * num;
            result.m43 = -(((num5 * num33) - (num4 * num31)) + (num3 * num30)) * num;
            float num29 = (num7 * num14) - (num6 * num15);
            float num28 = (num8 * num14) - (num6 * num16);
            float num27 = (num8 * num15) - (num7 * num16);
            float num26 = (num9 * num14) - (num6 * num17);
            float num25 = (num9 * num15) - (num7 * num17);
            float num24 = (num9 * num16) - (num8 * num17);
            result.m14 = -(((num4 * num29) - (num3 * num28)) + (num2 * num27)) * num;
            result.m24 = (((num5 * num29) - (num3 * num26)) + (num2 * num25)) * num;
            result.m34 = -(((num5 * num28) - (num4 * num26)) + (num2 * num24)) * num;
            result.m44 = (((num5 * num27) - (num4 * num25)) + (num3 * num24)) * num;
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
            float num21 = rotation.X + rotation.X;
            float num11 = rotation.Y + rotation.Y;
            float num10 = rotation.Z + rotation.Z;
            float num20 = rotation.W * num21;
            float num19 = rotation.W * num11;
            float num18 = rotation.W * num10;
            float num17 = rotation.X * num21;
            float num16 = rotation.X * num11;
            float num15 = rotation.X * num10;
            float num14 = rotation.Y * num11;
            float num13 = rotation.Y * num10;
            float num12 = rotation.Z * num10;
            float num9 = (1f - num14) - num12;
            float num8 = num16 - num18;
            float num7 = num15 + num19;
            float num6 = num16 + num18;
            float num5 = (1f - num17) - num12;
            float num4 = num13 - num20;
            float num3 = num15 - num19;
            float num2 = num13 + num20;
            float num = (1f - num17) - num14;
            float num37 = ((value.M11 * num9) + (value.M12 * num8)) + (value.M13 * num7);
            float num36 = ((value.M11 * num6) + (value.M12 * num5)) + (value.M13 * num4);
            float num35 = ((value.M11 * num3) + (value.M12 * num2)) + (value.M13 * num);
            float num34 = value.M14;
            float num33 = ((value.M21 * num9) + (value.M22 * num8)) + (value.M23 * num7);
            float num32 = ((value.M21 * num6) + (value.M22 * num5)) + (value.M23 * num4);
            float num31 = ((value.M21 * num3) + (value.M22 * num2)) + (value.M23 * num);
            float num30 = value.M24;
            float num29 = ((value.M31 * num9) + (value.M32 * num8)) + (value.M33 * num7);
            float num28 = ((value.M31 * num6) + (value.M32 * num5)) + (value.M33 * num4);
            float num27 = ((value.M31 * num3) + (value.M32 * num2)) + (value.M33 * num);
            float num26 = value.M34;
            float num25 = ((value.M41 * num9) + (value.M42 * num8)) + (value.M43 * num7);
            float num24 = ((value.M41 * num6) + (value.M42 * num5)) + (value.M43 * num4);
            float num23 = ((value.M41 * num3) + (value.M42 * num2)) + (value.M43 * num);
            float num22 = value.M44;
#if SIMD
			r1 = new Vector4f (num37, num36, num35, num34);
			r2 = new Vector4f (num33, num32, num31, num30);
			r3 = new Vector4f (num29, num28, num27, num26);
			r4 = new Vector4f (num25, num24, num23, num22);
#else
            result.m11 = num37;
            result.m12 = num36;
            result.m13 = num35;
            result.m14 = num34;
            result.m21 = num33;
            result.m22 = num32;
            result.m23 = num31;
            result.m24 = num30;
            result.m31 = num29;
            result.m32 = num28;
            result.m33 = num27;
            result.m34 = num26;
            result.m41 = num25;
            result.m42 = num24;
            result.m43 = num23;
            result.m44 = num22;
#endif
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
            float newM11 = matrix.m11;
            float newM21 = matrix.m12;
            float newM31 = matrix.m13;
            float newM41 = matrix.m14;
            float newM12 = matrix.m21;
            float newM22 = matrix.m22;
            float newM32 = matrix.m23;
            float newM42 = matrix.m24;
            float newM13 = matrix.m31;
            float newM23 = matrix.m32;
            float newM33 = matrix.m33;
            float newM43 = matrix.m34;
            float newM14 = matrix.m41;
            float newM24 = matrix.m42;
            float newM34 = matrix.m43;
            float newM44 = matrix.m44;
            result.m11 = newM11;
            result.m12 = newM12;
            result.m13 = newM13;
            result.m14 = newM14;
            result.m21 = newM21;
            result.m22 = newM22;
            result.m23 = newM23;
            result.m24 = newM24;
            result.m31 = newM31;
            result.m32 = newM32;
            result.m33 = newM33;
            result.m34 = newM34;
            result.m41 = newM41;
            result.m42 = newM42;
            result.m43 = newM43;
            result.m44 = newM44;
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

