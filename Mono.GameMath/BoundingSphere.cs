// 
// BoundingSphere.cs
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
using System.Collections.Generic;

namespace Mono.GameMath
{
	[Serializable]
	public struct BoundingSphere : IEquatable<BoundingSphere>
	{
		public Vector3 Center;
		public float Radius;
		
		public BoundingSphere (Vector3 center, float radius)
		{
			if (radius < 0)
				throw new ArgumentException ("Radius cannot be less that zero", "radius");
			
			this.Center = center;
			this.Radius = radius;
		}
		
		#region Contains
		
		public ContainmentType Contains (BoundingBox box)
		{
			ContainmentType result;
			Contains (ref box, out result);
			return result;
		}
		
		public void Contains (ref BoundingBox box, out ContainmentType result)
		{
			throw new NotImplementedException ();
		}
		
		public ContainmentType Contains (BoundingFrustum frustrum)
		{
			throw new NotImplementedException ();
		}
		
		public ContainmentType Contains (BoundingSphere sphere)
		{
			ContainmentType result;
			Contains (ref sphere, out result);
			return result;
		}
		
		public void Contains (ref BoundingSphere sphere, out ContainmentType result)
		{
			throw new NotImplementedException ();
		}
		
		public ContainmentType Contains (Vector3 point)
		{
			ContainmentType result;
			Contains (ref point, out result);
			return result;
		}
		
		public void Contains (ref Vector3 point, out ContainmentType result)
		{
			throw new NotImplementedException ();
		}
		
		#endregion
		
		#region Creation
		
		public static BoundingSphere CreateFromBoundingBox (BoundingBox box)
		{
			BoundingSphere result;
			CreateFromBoundingBox (ref box, out result);
			return result;
		}
		
		public static void CreateFromBoundingBox (ref BoundingBox box, out BoundingSphere result)
		{
			throw new NotImplementedException ();
		}
		
		public static BoundingSphere CreateFromFrustum (BoundingFrustum frustum)
		{
			throw new NotImplementedException ();
		}
		
		public static BoundingSphere CreateFromPoints (IEnumerable<Vector3> points)
		{
			throw new NotImplementedException ();
		}
		
		public static BoundingSphere CreateMerged (BoundingSphere original, BoundingSphere additional)
		{
			BoundingSphere result;
			CreateMerged (ref original, ref additional, out result);
			return result;
		}
		
		public static void CreateMerged (ref BoundingSphere original, ref BoundingSphere additional, out BoundingSphere result)
		{
			throw new NotImplementedException ();
		}
		
		#endregion
		
		#region Intersects
		
		public bool Intersects (BoundingBox box)
		{
			bool result;
			Intersects (ref box, out result);
			return result;
		}
		
		public void Intersects (ref BoundingBox box, out bool result)
		{
			throw new NotImplementedException ();
		}
		
		public bool Intersects (BoundingFrustum frustum)
		{
			throw new NotImplementedException ();
		}
		
		public bool Intersects (BoundingSphere sphere)
		{
			bool result;
			Intersects (ref sphere, out result);
			return result;
		}
		
		public void Intersects (ref BoundingSphere sphere, out bool result)
		{
			throw new NotImplementedException ();
		}
		
		public PlaneIntersectionType Intersects (Plane plane)
		{
			PlaneIntersectionType result;
			Intersects (ref plane, out result);
			return result;
		}
		
		public void Intersects (ref Plane plane, out PlaneIntersectionType result)
		{
			throw new NotImplementedException ();
		}
		
		public float? Intersects (Ray ray)
		{
			float? result;
			Intersects (ref ray, out result);
			return result;
		}
		
		public void Intersects (ref Ray ray, out float? result)
		{
			throw new NotImplementedException ();
		}
		
		#endregion
		
		public BoundingSphere Transform (Matrix matrix)
		{
			BoundingSphere result;
			Transform (ref matrix, out result);
			return result;
		}
		
		public void Transform (ref Matrix matrix, out BoundingSphere result)
		{
			throw new NotImplementedException ();
		}
		
		#region Equality
		
		public bool Equals (BoundingSphere other)
		{
			return other == this;
		}
		
		public override bool Equals (object obj)
		{
			return obj is BoundingSphere && ((BoundingSphere)obj) == this;
		}
		
		public override int GetHashCode ()
		{
			return Radius.GetHashCode () ^ Center.GetHashCode ();
		}
		
		public static bool operator == (BoundingSphere a, BoundingSphere b)
		{
			return a.Radius == b.Radius && a.Center == b.Center;
		}
		
		public static bool operator != (BoundingSphere a, BoundingSphere b)
		{
			return a.Radius != b.Radius || a.Center != b.Center;
		}
		
		#endregion
		
		public override string ToString ()
		{
			return string.Format("{{Center:{0} Radius:{1}}}", Center, Radius);
		}
	}
}

