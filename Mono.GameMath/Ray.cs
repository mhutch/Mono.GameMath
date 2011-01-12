// 
// Ray.cs
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
	public struct Ray : IEquatable<Ray>
	{
		public Vector3 Position, Direction;
		
		public Ray (Vector3 position, Vector3 direction)
		{
			Position = position;
			Direction = direction;
		}
		
		#region Intersects
		
		public Nullable<float> Intersects (BoundingBox box)
		{
			Nullable<float> result;
			Intersects (ref box, out result);
			return result;
		}
		
		public void Intersects (ref BoundingBox box, out Nullable<float> result)
		{
			box.Intersects (ref this, out result);
		}
		
		public Nullable<float> Intersects (BoundingFrustum frustum)
		{
			if (frustum == null)
				throw new ArgumentNullException ("frustum");
			
			return frustum.Intersects (this);
		}
		
		public Nullable<float> Intersects (BoundingSphere sphere)
		{
			Nullable<float> result;
			Intersects (ref sphere, out result);
			return result;
		}
		
		public void Intersects (ref BoundingSphere sphere, out Nullable<float> result)
		{
			sphere.Intersects (ref this, out result);
		}
		
		public Nullable<float> Intersects (Plane plane)
		{
			Nullable<float> result;
			Intersects (ref plane, out result);
			return result;
		}
		
		public void Intersects (ref Plane plane, out Nullable<float> result)
		{
			throw new NotImplementedException ();
		}
		
		#endregion
		
		#region Equality
		
		public bool Equals (Ray other)
		{
			return other == this;
		}
		
		public override bool Equals (object obj)
		{
			return obj is Ray && ((Ray)obj) == this;
		}
		
		public override int GetHashCode ()
		{
			return Position.GetHashCode () ^ Direction.GetHashCode ();
		}
		
		public static bool operator == (Ray a, Ray b)
		{
			return a.Position == b.Position && a.Direction == b.Direction;
		}
		
		public static bool operator != (Ray a, Ray b)
		{
			return a.Position != b.Position || a.Direction != b.Direction;
		}
		
		# endregion
		
		public override string ToString ()
		{
			return string.Format ("{{Position:{0} Direction:{1}}}", Position, Direction);
		}
	}
}

