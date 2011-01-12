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
				throw new ArgumentException ("Radius cannot be less than zero", "radius");
			
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
			if (!box.Intersects (this))
			{
				result = ContainmentType.Disjoint;
				return;
			}
			
			float radiusSq = Radius * Radius;
			float cx = Center.X;
			float cy = Center.Y;
			float cz = Center.Z;
			
			if (new Vector3 (cx - box.Min.X, cy - box.Max.Y, cz - box.Max.Z).LengthSquared () > radiusSq ||
				new Vector3 (cx - box.Max.X, cy - box.Max.Y, cz - box.Max.Z).LengthSquared () > radiusSq ||
				new Vector3 (cx - box.Max.X, cy - box.Min.Y, cz - box.Max.Z).LengthSquared () > radiusSq ||
				new Vector3 (cx - box.Min.X, cy - box.Min.Y, cz - box.Max.Z).LengthSquared () > radiusSq ||
				new Vector3 (cx - box.Min.X, cy - box.Max.Y, cz - box.Min.Z).LengthSquared () > radiusSq ||
				new Vector3 (cx - box.Max.X, cy - box.Max.Y, cz - box.Min.Z).LengthSquared () > radiusSq ||
				new Vector3 (cx - box.Max.X, cy - box.Min.Y, cz - box.Min.Z).LengthSquared () > radiusSq ||
				new Vector3 (cx - box.Min.X, cy - box.Min.Y, cz - box.Min.Z).LengthSquared () > radiusSq) {
				result = ContainmentType.Intersects;
				return;
			}
			
			result = ContainmentType.Contains;
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
			float dist;
			Vector3.Distance (ref Center, ref sphere.Center, out dist);
			float sphereRadius = sphere.Radius;
			
			if (Radius + sphereRadius < dist) {
				result = ContainmentType.Disjoint;
				return;
			}
			
			if (Radius - sphereRadius < dist) {
				result = ContainmentType.Intersects;
				return;
			}
			
			result = ContainmentType.Contains;
		}
		
		public ContainmentType Contains (Vector3 point)
		{
			ContainmentType result;
			Contains (ref point, out result);
			return result;
		}
		
		public void Contains (ref Vector3 point, out ContainmentType result)
		{
			if (Vector3.DistanceSquared (point, Center) >= Radius * Radius) {
				result = ContainmentType.Disjoint;
				return;
			}
			
			result = ContainmentType.Contains;
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
			Vector3.Lerp (ref box.Min, ref box.Max, 0.5f, out result.Center);
			
			float distance;
			Vector3.Distance (ref box.Min, ref box.Max, out distance);
			result.Radius = distance * 0.5f;
		}
		
		public static BoundingSphere CreateFromFrustum (BoundingFrustum frustum)
		{
			if (frustum == null)
				throw new ArgumentNullException ("frustum");
			
			return CreateFromPoints (frustum.GetCorners ());
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
			ContainmentType containment;
			Contains (ref box, out containment);
			result = containment == ContainmentType.Intersects;
		}
		
		public bool Intersects (BoundingFrustum frustum)
		{
			return (Contains (frustum) == ContainmentType.Intersects);
		}
		
		public bool Intersects (BoundingSphere sphere)
		{
			bool result;
			Intersects (ref sphere, out result);
			return result;
		}
		
		public void Intersects (ref BoundingSphere sphere, out bool result)
		{
			ContainmentType containment;
			Contains (ref sphere, out containment);
			result = containment == ContainmentType.Intersects;
		}
		
		public PlaneIntersectionType Intersects (Plane plane)
		{
			PlaneIntersectionType result;
			Intersects (ref plane, out result);
			return result;
		}
		
		public void Intersects (ref Plane plane, out PlaneIntersectionType result)
		{
			float distance;
			Vector3.Dot (ref plane.Normal, ref Center, out distance);
			distance += plane.D;
			
			if (distance > Radius) {
				result = PlaneIntersectionType.Front;
				return;
			}
			
			if (distance < -Radius) {
				result = PlaneIntersectionType.Back;
				return;
			}
			
			result = PlaneIntersectionType.Intersecting;
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
			return string.Format ("{{Center:{0} Radius:{1}}}", Center, Radius);
		}
	}
}

