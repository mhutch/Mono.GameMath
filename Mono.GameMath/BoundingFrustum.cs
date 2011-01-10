// 
// BoundingFrustum.cs
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
	public class BoundingFrustum : IEquatable<BoundingFrustum>
	{
		public const int CornerCount = 8;
		
		public BoundingFrustum (Matrix value)
		{
			this.Matrix = value;
		}
		
		public Matrix Matrix { get; set; }
		
		#region Plane Properties
		
		public Plane Bottom {
			get {
				throw new NotImplementedException ();
			}
		}
		
		public Plane Far {
			get {
				throw new NotImplementedException ();
			}
		}
		
		public Plane Left {
			get {
				throw new NotImplementedException ();
			}
		}
		
		public Plane Near {
			get {
				throw new NotImplementedException ();
			}
		}
		
		public Plane Right {
			get {
				throw new NotImplementedException ();
			}
		}
		
		public Plane Top {
			get {
				throw new NotImplementedException ();
			}
		}
		
		#endregion
		
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
		
		public ContainmentType Contains (BoundingFrustum frustum)
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
		
		public Vector3[] GetCorners ()
		{
			var arr = new Vector3[CornerCount];
			GetCorners (arr);
			return arr;
		}
		
		public void GetCorners (Vector3[] corners)
		{
			throw new NotImplementedException ();
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
		
		#region Equality
				
		public bool Equals (BoundingFrustum other)
		{
			return other == this;
		}
		
		public override bool Equals (object obj)
		{
			return this == (obj as BoundingFrustum);
		}
		
		public override int GetHashCode ()
		{
			return Matrix.GetHashCode ();
		}
		
		public static bool operator == (BoundingFrustum a, BoundingFrustum b)
		{
			return a.Matrix == b.Matrix;
		}
		
		public static bool operator != (BoundingFrustum a, BoundingFrustum b)
		{
			return a.Matrix != b.Matrix;
		}
		
		#endregion
		
		public override string ToString ()
		{
			return string.Format ("{{Near:{0} Far:{1} Left:{2} Right:{3} Top:{4} Bottom:{5}}}",
				Near, Far, Left, Right, Top, Bottom);
		}
	}
}