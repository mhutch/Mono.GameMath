using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mono.GameMath;

namespace GameMathTests
{
	[TestClass]
	public class Vector2Tests
	{
		[TestMethod]
		public void NaNEquality()
		{
			Vector2 nanVec = new Vector2(float.NaN, float.NaN);
			Assert.IsFalse(nanVec == nanVec);
			Assert.IsTrue(nanVec != nanVec);
			Assert.IsTrue(nanVec.Equals(nanVec));
		}

		[TestMethod]
		public void SimpleEquality()
		{
			Assert.IsTrue(Vector2.Zero == Vector2.Zero);
			Assert.IsFalse(Vector2.Zero != Vector2.Zero);

			Assert.IsFalse(Vector2.Zero == Vector2.UnitX);
			Assert.IsFalse(Vector2.Zero == Vector2.UnitY);

			Assert.IsTrue(Vector2.Zero.Equals(Vector2.Zero));
			Assert.IsTrue(Vector2.UnitX.Equals(Vector2.UnitX));
			Assert.IsTrue(Vector2.UnitY.Equals(Vector2.UnitY));

			Assert.IsFalse(Vector2.Zero.Equals(Vector2.UnitX));
			Assert.IsFalse(Vector2.Zero.Equals(Vector2.UnitY));
		}

		[TestMethod]
		public void GoodHashCode()
		{
			Assert.IsTrue(Vector2.UnitX.GetHashCode() != Vector2.UnitY.GetHashCode());
			Assert.IsTrue(Vector2.Zero.GetHashCode() != Vector2.UnitX.GetHashCode());
			Assert.IsTrue(Vector2.Zero.GetHashCode() != Vector2.UnitY.GetHashCode());
		}
	}
}
