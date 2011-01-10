// 
// Rectangle.cs
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
	public struct Rectangle : IEquatable<Rectangle>
	{
		public int X, Y, Width, Height;
		
		public Rectangle (int x, int y, int width, int height)
		{
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}
		
		#region Properties
		
		public int Top {
			get { return Y; }
		}
		
		public int Bottom {
			get { return Y + Height; }
		}
		
		public int Left {
			get { return X; }
		}
		
		public int Right {
			get { return X + Width; }
		}
		
		public Point Location {
			get {
				return new Point (X, Y);
			}
			set {
				X = value.X;
				Y = value.Y;
			}
		}
		
		public Point Center {
			get {
				return new Point (X + Width / 2, Y + Height / 2);
			}
		}
		
		public bool IsEmpty {
			get {
				return X == 0 && Y == 0;
			}
		}
		
		public static Rectangle Empty {
			get {
				return new Rectangle (0, 0, 0, 0);
			}
		}
		
		#endregion
		
		#region Contains
		
		public bool Contains (int x, int y)
		{
			return Contains (new Point (x, y));
		}
		
		public bool Contains (Point value)
		{
			bool result;
			Contains (ref value, out result);
			return result;
		}
		
		public void Contains (ref Point value, out bool result)
		{
			result = value.X >= Left && value.X <= Right && value.Y >= Top && value.Y <= Bottom;  
		}
		
		public bool Contains (Rectangle value)
		{
			bool result;
			Contains (ref value, out result);
			return result;
		}
		
		public void Contains (ref Rectangle value, out bool result)
		{
			result = value.Left >= Left && value.Right <= Right && value.Top >= Top && value.Bottom <= Bottom;
		}
		
		#endregion
		
		public void Inflate (int horizontalAmount, int verticalAmount)
		{
			Width += horizontalAmount;
			Height += verticalAmount;
		}
		
		public static Rectangle Intersect (Rectangle value1, Rectangle value2)
		{
			Rectangle result;
			Intersect (ref value1, ref value2, out result);
			return result;
		}
		
		public static void Intersect (ref Rectangle value1, ref Rectangle value2, out Rectangle result)
		{
			int x = System.Math.Max (value1.X, value2.X);
			int y = System.Math.Max (value1.Y, value2.Y);
			int w = System.Math.Min (value1.Right, value2.Right) - x;
			int h = System.Math.Min (value1.Bottom, value2.Bottom) - y;
			if (w <= 0 || h <= 0)
				result = Rectangle.Empty;
			else
				result = new Rectangle (x, y, w, h);
		}
		
		public bool Intersects (Rectangle value)
		{
			bool result;
			Intersects (ref value, out result);
			return result;
		}
		
		public void Intersects (ref Rectangle value, out bool result)
		{
			int w = System.Math.Min (value.Right, Right) - System.Math.Max (value.X, X);
			int h = System.Math.Min (value.Bottom, Bottom) - System.Math.Max (value.Y, Y);
			result = w > 0 && h > 0;
		}
		
		public void Offset (int offsetX, int offsetY)
		{
			X += offsetX;
			Y += offsetY;
		}
		
		public void Offset (Point amount)
		{
			X += amount.X;
			Y += amount.Y;
		}
		
		public static Rectangle Union (Rectangle value1, Rectangle value2)
		{
			Rectangle result;
			Union (ref value1, ref value2, out result);
			return result;
		}
		
		public static void Union (ref Rectangle value1, ref Rectangle value2, out Rectangle result)
		{
			int x = System.Math.Min (value1.X, value2.X);
			int y = System.Math.Min (value1.Y, value2.Y);
			int w = System.Math.Max (value1.Right, value2.Right) - x;
			int h = System.Math.Max (value1.Bottom, value2.Bottom) - y;
			result = new Rectangle (x, y, w, h);
		}
		
		#region Equality
		
		public bool Equals (Rectangle other)
		{
			return other == this;
		}
		
		public override bool Equals (object obj)
		{
			return obj is Rectangle && ((Rectangle)obj) == this;
		}
		
		public override int GetHashCode ()
		{
			return X ^ Y ^ Width ^ Height;
		}
		
		public static bool operator == (Rectangle a, Rectangle b)
		{
			return a.X == b.X && a.Y == b.Y && a.Width == b.Width && a.Height == b.Height;
		}
		
		public static bool operator != (Rectangle a, Rectangle b)
		{
			return a.X != b.X || a.Y != b.Y || a.Width != b.Width || a.Height != b.Height;
		}
		
		# endregion
		
		public override string ToString ()
		{
			return string.Format ("{{X:{0} Y:{1} Width:{2} Height:{3}}}", X, Y, Width, Height);
		}
	}
}

