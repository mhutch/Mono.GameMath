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

namespace Mono.GameMath
{
	[Serializable]
	public struct Matrix : IEquatable<Matrix>
	{
		public float M11, M12, M13, M14;
		public float M21, M22, M23, M24;
		public float M31, M32, M33, M34;
		public float M41, M42, M43, M44;
		
		public Matrix (
			float m11, float m12, float m13, float m14,
			float m21, float m22, float m23, float m24,
			float m31, float m32, float m33, float m34,
			float m41, float m42, float m43, float m44)
		{
			M11 = m11; M12 = m12; M13 = m13; M14 = m14;
			M21 = m21; M22 = m22; M23 = m23; M24 = m24;
			M31 = m31; M32 = m32; M33 = m33; M34 = m34;
			M41 = m41; M42 = m42; M43 = m43; M44 = m44;
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
		}
		
		public static Matrix Multiply (Matrix matrix1, Matrix matrix2)
		{
			Matrix result;
			Multiply (ref matrix1, ref matrix2, out result);
			return result;
		}
		
		public static void Multiply (ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
		{
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
		}
		
		public static Matrix Multiply (Matrix matrix1, float scaleFactor)
		{
			Matrix result;
			Multiply (ref matrix1, scaleFactor, out result);
			return result;
		}
		
		public static void Multiply (ref Matrix matrix1, float scaleFactor, out Matrix result)
		{
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
		}
		
		public static Matrix Negate (Matrix matrix)
		{
			Matrix result;
			Negate (ref matrix, out result);
			return result;
		}
		
		public static void Negate (ref Matrix matrix, out Matrix result)
		{
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
		}
		
		public static Matrix Subtract (Matrix matrix1, Matrix matrix2)
		{
			Matrix result;
			Subtract (ref matrix1, ref matrix2, out result);
			return result;
		}
		
		public static void Subtract (ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
		{
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
		}
		
		public static Matrix Divide (Matrix matrix1, Matrix matrix2)
		{
			Matrix result;
			Divide (ref matrix1, ref matrix2, out result);
			return result;
		}
		
		public static void Divide (ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
		{
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
		}
		
		public static Matrix Divide (Matrix matrix1, float divider)
		{
			Matrix result;
			Divide (ref matrix1, divider, out result);
			return result;
		}
		
		public static void Divide (ref Matrix matrix1, float divider, out Matrix result)
		{
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
		}
		
		#endregion
		
		#region Operator overloads
		
		public static Matrix operator + (Matrix matrix1, Matrix matrix2)
		{
			return Add (matrix1, matrix2);
		}
		
		public static Matrix operator / (Matrix matrix, float divider)
		{
			return Divide (matrix, divider);
		}
		
		public static Matrix operator / (Matrix matrix1, Matrix matrix2)
		{
			return Divide (matrix1, matrix2);
		}
		
		public static Matrix operator * (Matrix matrix1, Matrix matrix2)
		{
			return Multiply (matrix1, matrix2);
		}
		
		public static Matrix operator * (Matrix matrix, float scaleFactor)
		{
			return Multiply (matrix, scaleFactor);
		}
		
		public static Matrix operator * (float scaleFactor, Matrix matrix)
		{
			return Multiply (matrix, scaleFactor);
		}
		
		public static Matrix operator - (Matrix matrix1, Matrix matrix2)
		{
			return Subtract (matrix1, matrix2);
		}
		
		public static Matrix operator - (Matrix matrix)
		{
			return Negate (matrix);
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
			Matrix result;
			Lerp (ref matrix1, ref matrix2, amount, out result);
			return result;
		}
		
		public static void Lerp (ref Matrix matrix1, ref Matrix matrix2, float amount, out Matrix result)
		{
			throw new NotImplementedException ();
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
			Matrix result;
			Transpose (ref matrix, out result);
			return result;
		}
		
		public static void Transpose (ref Matrix matrix, out Matrix result)
		{
			throw new NotImplementedException ();
		}
		
		#endregion
		
		#region Equality
		
		public bool Equals (Matrix other)
		{
			return other == this;
		}
		
		public override bool Equals (object obj)
		{
			return obj is Matrix && ((Matrix)obj) == this;
		}
		
		public override int GetHashCode ()
		{
			return
				M11.GetHashCode () ^ M12.GetHashCode () ^ M13.GetHashCode () ^ M14.GetHashCode () ^
				M21.GetHashCode () ^ M22.GetHashCode () ^ M23.GetHashCode () ^ M24.GetHashCode () ^
				M31.GetHashCode () ^ M32.GetHashCode () ^ M33.GetHashCode () ^ M34.GetHashCode () ^
				M41.GetHashCode () ^ M42.GetHashCode () ^ M43.GetHashCode () ^ M44.GetHashCode (); 
		}
		
		public static bool operator == (Matrix a, Matrix b)
		{
			return
				a.M11 == b.M11 && a.M12 == b.M12 && a.M13 == b.M13 && a.M14 == b.M14 &&
				a.M21 == b.M21 && a.M22 == b.M22 && a.M23 == b.M23 && a.M24 == b.M24 &&
				a.M31 == b.M31 && a.M32 == b.M32 && a.M33 == b.M33 && a.M34 == b.M34 &&
				a.M41 == b.M41 && a.M42 == b.M42 && a.M43 == b.M43 && a.M44 == b.M44;
		}
		
		public static bool operator != (Matrix a, Matrix b)
		{
			return
				a.M11 != b.M11 || a.M12 != b.M12 || a.M13 != b.M13 && a.M14 != b.M14 ||
				a.M21 != b.M21 || a.M22 != b.M22 || a.M23 != b.M23 && a.M24 != b.M24 ||
				a.M31 != b.M31 || a.M32 != b.M32 || a.M33 != b.M33 && a.M34 != b.M34 ||
				a.M41 != b.M41 || a.M42 != b.M42 || a.M43 != b.M43 && a.M44 != b.M44;
		}
		
		# endregion
		
		public override string ToString ()
		{
			throw new NotImplementedException ();
		}
	}
}

