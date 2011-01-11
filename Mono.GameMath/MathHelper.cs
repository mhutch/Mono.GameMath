// 
// MathHelper.cs
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
	public static class MathHelper
	{
		public const float E       = (float) System.Math.E;
		public const float Log10E  = (float) 0.4342944819032f;
		public const float Log2E   = (float) 1.442695040888f;
		public const float Pi      = (float) System.Math.PI;
		public const float PiOver2 = (float) (System.Math.PI / 2.0);
		public const float PiOver4 = (float) (System.Math.PI / 4.0);
		public const float TwoPi   = (float) (System.Math.PI * 2.0);
		
		public static float Barycentric (float value1, float value2, float value3, float amount1, float amount2)
		{
			return value1 + (value2 - value1) * amount1 + (value3 - value1) * amount2;
		}
		
		public static float CatmullRom (float value1, float value2, float value3, float value4, float amount)
		{
			// http://stephencarmody.wikispaces.com/Catmull-Rom+splines
			
			//value1 *= ((-amount + 2.0f) * amount - 1) * amount * 0.5f;
			//value2 *= (((3.0f * amount - 5.0f) * amount) * amount + 2.0f) * 0.5f;
			//value3 *= ((-3.0f * amount + 4.0f) * amount + 1.0f) * amount * 0.5f;
			//value4 *= ((amount - 1.0f) * amount * amount) * 0.5f;
			//
			//return value1 + value2 + value3 + value4;
			
			// http://www.mvps.org/directx/articles/catmull/
			
			float amountSq = amount * amount;
			float amountCube = amountSq * amount;
			
			// value1..4 = P0..3
			// amount = t
			return ((2.0f * value2 +
				(-value1 + value3) * amount +
				(2.0f * value1 - 5.0f * value2 + 4.0f * value3 - value4) * amountSq +
				(3.0f * value2 - 3.0f * value3 - value1 + value4) * amountCube) * 0.5f);
		}
		
		public static float Clamp (float value, float min, float max)
		{
			return System.Math.Min (System.Math.Max (min, value), max);
		}
		
		public static float Distance (float value1, float value2)
		{
			return System.Math.Abs (value1 - value2);
		}
		
		public static float Hermite (float value1, float tangent1, float value2, float tangent2, float amount)
		{
			//http://www.cubic.org/docs/hermite.htm
			float s = amount;
			float s2 = s * s;
			float s3 = s2 * s;
			float h1 =  2 * s3 - 3 * s2 + 1;
			float h2 = -2 * s3 + 3 * s2;
			float h3 =      s3 - 2 * s2 + s;
			float h4 =      s3 -     s2;
			return value1 * h1 + value2 * h2 + tangent1 * h3 + tangent2 * h4;
		}
		
		public static float Lerp (float value1, float value2, float amount)
		{
			return value1 + (value2 - value1) * amount;
		}
		
		public static float Max (float value1, float value2)
		{
			return System.Math.Max (value1, value2);
		}
		
		public static float Min (float value1, float value2)
		{
			return System.Math.Min (value1, value2);
		}
		
		public static float SmoothStep (float value1, float value2, float amount)
		{
			//FIXME: check this
			//the function is Smoothstep (http://en.wikipedia.org/wiki/Smoothstep) but the usage has been altered
			// to be similar to Lerp
			amount = amount * amount * (3f - 2f * amount);
			return value1 + (value2 - value1) * amount;
		}
		
		public static float ToDegrees (float radians)
		{
			return radians * (180f / Pi);
		}
		
		public static float ToRadians (float degrees)
		{
			return degrees * (Pi / 180f);
		}
		
		public static float WrapAngle (float angle)
		{
			angle = angle % TwoPi;
			if (angle > Pi)
				return angle - TwoPi;
			if (angle < -Pi)
				return angle + TwoPi;
			return angle;
		}
	}
}