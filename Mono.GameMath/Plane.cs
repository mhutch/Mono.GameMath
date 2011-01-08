// 
// Plane.cs
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
	public struct Plane : IEquatable<Plane>
	{
		public float D;
		public Vector3 Normal;
		
		#region Constructors
		
		public Plane (float a, float b, float c, float d)
		{
			Normal = new Vector3 (a, b, c);
			D = d;
		}
		
		public Plane (Vector3 normal, float d)
		{
			Normal = normal;
			D = d;
		}
		
		public Plane (Vector3 point1, Vector3 point2, Vector3 point3)
		{
			throw new NotImplementedException ();
		}
		
		public Plane (Vector4 value)
		{
			throw new NotImplementedException ();
		}
		
		#endregion
		
		public float Dot (Vector4 value)
		{
			float result;
			Dot (ref value, out result);
			return result;
		}
		
		public void Dot (ref Vector4 value, out float result)
		{
			throw new NotImplementedException ();
		}
		
		public float DotCoordinate (Vector3 value)
		{
			float result;
			DotCoordinate (ref value, out result);
			return result;
		}
		
		public void DotCoordinate (ref Vector3 value, out float result)
		{
			throw new NotImplementedException ();
		}
		
		public float DotNormal (Vector3 value)
		{
			float result;
			DotNormal (ref value, out result);
			return result;
		}
		
		public void DotNormal (ref Vector3 value, out float result)
		{
			throw new NotImplementedException ();
		}
		
		#region Intersects
		
		public PlaneIntersectionType Intersects (BoundingBox box)
		{
			PlaneIntersectionType result;
			Intersects (ref box, out result);
			return result;
		}
		
		public void Intersects (ref BoundingBox box, out PlaneIntersectionType result)
		{
			throw new NotImplementedException ();
		}
		
		public PlaneIntersectionType Intersects (BoundingFrustum frustum)
		{
			throw new NotImplementedException ();
		}
		
		public PlaneIntersectionType Intersects (BoundingSphere sphere)
		{
			PlaneIntersectionType result;
			Intersects (ref sphere, out result);
			return result;
		}
		
		public void Intersects (ref BoundingSphere sphere, out PlaneIntersectionType result)
		{
			throw new NotImplementedException ();
		}
		
		#endregion
		
		public void Normalize ()
		{
			Normalize (ref this, out this);
		}
		
		public static Plane Normalize (Plane value)
		{
			Normalize (ref value, out value);
			return value;
		}
		
		public static void Normalize (ref Plane value, out Plane result)
		{
			throw new NotImplementedException ();
		}
		
		public static Plane Transform (Plane plane, Matrix matrix)
		{
			Plane result;
			Transform (ref plane, ref matrix, out result);
			return result;
		}
		
		public static void Transform (ref Plane plane, ref Matrix matrix, out Plane result)
		{
			throw new NotImplementedException ();
		}
		
		public static Plane Transform (Plane plane, Quaternion rotation)
		{
			Plane result;
			Transform (ref plane, ref rotation, out result);
			return result;
		}
		
		public static void Transform (ref Plane plane, ref Quaternion rotation, out Plane result)
		{
			throw new NotImplementedException ();
		}
		
		#region Equality
		
		public bool Equals (Plane other)
		{
			return other == this;
		}
		
		public override bool Equals (object obj)
		{
			return obj is Plane && ((Plane)obj) == this;
		}
		
		public override int GetHashCode ()
		{
			return Normal.GetHashCode () ^ D.GetHashCode ();
		}
		
		public static bool operator == (Plane a, Plane b)
		{
			return a.D == b.D && a.Normal == b.Normal;
		}
		
		public static bool operator != (Plane a, Plane b)
		{
			return a.D != b.D || a.Normal != b.Normal;
		}
		
		# endregion
		
		public override string ToString ()
		{
			throw new NotImplementedException ();
		}
	}
}

