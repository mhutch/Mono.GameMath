// 
// BoundingBox.cs
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
	public struct BoundingBox : IEquatable<BoundingBox>
	{
		public Vector3 Min, Max;
		
		public const int CornerCount = 8;
		
		public BoundingBox (Vector3 min, Vector3 max)
		{
			this.Min = min;
			this.Max = max;
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
			if ((Max.X < box.Min.X || Min.X > box.Max.X) ||
			    (Max.Y < box.Min.Y || Min.Y > box.Max.Y) ||
			    (Max.Z < box.Min.Z || Min.Z > box.Max.Z)) {
				result = ContainmentType.Disjoint;
				return;
			}
			
			if ((Min.X <= box.Min.X && Max.X >= box.Max.X) &&
			    (Min.Y <= box.Min.Y && Max.Y >= box.Max.Y) &&
			    (Min.Z <= box.Min.Z && Max.Z >= box.Max.Z)) {
				result = ContainmentType.Contains;
				return;
			}
			
			result = ContainmentType.Intersects;
		}
		
		public ContainmentType Contains (BoundingFrustum frustum)
		{
			if (frustum == null)
				throw new ArgumentNullException ("frustum");
			
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
			Vector3 center = sphere.Center;
			
			Vector3 point;
			Vector3.Clamp (ref center, ref Min, ref Max, out point);
			
			float dist;
			Vector3.DistanceSquared (ref center, ref point, out dist);
			
			float radius = sphere.Radius;
			
			if (dist > radius) {
				result = ContainmentType.Disjoint;
				return;
			}
			
			if (Min.X + radius <= center.X && Max.X - radius >= center.X && Max.X - Min.X > radius &&
			    Min.Y + radius <= center.Y && Max.Y - radius >= center.Y && Max.Y - Min.Y > radius &&
			    Min.Z + radius <= center.Z && Max.Z - radius >= center.Z && Max.X - Min.X > radius) {
				result = ContainmentType.Contains;
				return;
			}
			
			result = ContainmentType.Intersects;
		}
		
		public ContainmentType Contains (Vector3 point)
		{
			ContainmentType result;
			Contains (ref point, out result);
			return result;
		}
		
		public void Contains (ref Vector3 point, out ContainmentType result)
		{
			if ((Min.X <= point.X && Max.X >= point.X) &&
			    (Min.Y <= point.Y && Max.Y >= point.Y) &&
			    (Min.Z <= point.Z && Max.Z >= point.Z)) {
				result = ContainmentType.Contains;
				return;
			}
			
			result = ContainmentType.Disjoint;
		}
		
		#endregion
		
		#region Creation
		
		public static BoundingBox CreateFromPoints (IEnumerable<Vector3> points)
		{
			if (points == null)
				throw new ArgumentNullException ("points");
			
			bool hasPoints = false;
			Vector3 min = new Vector3 (float.MaxValue);
			Vector3 max = new Vector3 (float.MinValue);
			
			foreach (Vector3 point in points) {
				Vector3 pt = point;
				
				Vector3.Min (ref min, ref pt, out min);
				Vector3.Max (ref max, ref pt, out max);
				
				hasPoints = true;
			}
			
			if (!hasPoints)
				throw new ArgumentException ("No points were given.", "points");
			
			return new BoundingBox (min, max);
		}
		
		public static BoundingBox CreateFromSphere (BoundingSphere sphere)
		{
			BoundingBox result;
			CreateFromSphere (ref sphere, out result);
			return result;
		}
		
		public static void CreateFromSphere (ref BoundingSphere sphere, out BoundingBox result)
		{
			Vector3 min = new Vector3 (sphere.Center.X - sphere.Radius, sphere.Center.Y - sphere.Radius,
				sphere.Center.Z - sphere.Radius);
			Vector3 max = new Vector3 (sphere.Center.X + sphere.Radius, sphere.Center.Y + sphere.Radius,
				sphere.Center.Z + sphere.Radius);
			
			result = new BoundingBox (min, max);
		}
		
		public static BoundingBox CreateMerged (BoundingBox original, BoundingBox additional)
		{
			BoundingBox result;
			CreateMerged (ref original, ref additional, out result);
			return result;
		}
		
		public static void CreateMerged (ref BoundingBox original, ref BoundingBox additional, out BoundingBox result)
		{
			Vector3 min, max;
			
			Vector3.Min (ref original.Min, ref additional.Min, out min);
			Vector3.Max (ref original.Max, ref additional.Max, out max);
			
			result = new BoundingBox (min, max);
		}
		
		#endregion
		
		public Vector3[] GetCorners ()
		{
			var arr = new Vector3 [CornerCount];
			GetCorners (arr);
			return arr;
		}
		
		public void GetCorners (Vector3[] corners)
		{
			if (corners == null)
				throw new ArgumentNullException ("corners");
			
			if (corners.Length != CornerCount)
				throw new ArgumentOutOfRangeException ("You must have at least 8 elements to copy corners.", "corners");
			
			corners[0] = new Vector3 (Min.X, Max.Y, Max.Z);
			corners[1] = new Vector3 (Max.X, Max.Y, Max.Z);
			corners[2] = new Vector3 (Max.X, Min.Y, Max.Z);
			corners[3] = new Vector3 (Min.X, Min.Y, Max.Z);
			corners[4] = new Vector3 (Min.X, Max.Y, Min.Z);
			corners[5] = new Vector3 (Max.X, Max.Y, Min.Z);
			corners[6] = new Vector3 (Max.X, Min.Y, Min.Z);
			corners[7] = new Vector3 (Min.X, Min.Y, Min.Z);
		}
		
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
		
		#region Equality
		
		public bool Equals (BoundingBox other)
		{
			return other == this;
		}
		
		public override bool Equals (object obj)
		{
			return obj is BoundingBox && ((BoundingBox)obj) == this;
		}
		
		public override int GetHashCode ()
		{
			return Min.GetHashCode () ^ Max.GetHashCode ();
		}
		
		public static bool operator == (BoundingBox a, BoundingBox b)
		{
			return a.Min == b.Min && a.Max == b.Max;
		}
		
		public static bool operator != (BoundingBox a, BoundingBox b)
		{
			return a.Min != b.Min || a.Max != b.Max;
		}
		
		# endregion
		
		public override string ToString ()
		{
			return string.Format ("{{Min:{0} Max:{1}}}", Min, Max);
		}
	}
}