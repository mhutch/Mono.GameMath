using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mono.GameMath;

namespace GameMathTests
{
	[TestClass]
	public class Vector4Tests
	{
		[TestMethod]
		public void NaNEquality()
		{
			Vector4 nanVec = new Vector4(float.NaN, float.NaN, float.NaN, float.NaN);
			Assert.IsFalse(nanVec == nanVec);
			Assert.IsTrue(nanVec != nanVec);
			Assert.IsTrue(nanVec.Equals(nanVec));
		}

		[TestMethod]
		public void SimpleEquality()
		{
			Assert.IsTrue(Vector4.Zero == Vector4.Zero);
			Assert.IsFalse(Vector4.Zero != Vector4.Zero);

			Assert.IsFalse(Vector4.Zero == Vector4.UnitX);
			Assert.IsFalse(Vector4.Zero == Vector4.UnitY);
			Assert.IsFalse(Vector4.Zero == Vector4.UnitZ);
			Assert.IsFalse(Vector4.Zero == Vector4.UnitW);

			Assert.IsTrue(Vector4.Zero.Equals(Vector4.Zero));
			Assert.IsTrue(Vector4.UnitX.Equals(Vector4.UnitX));
			Assert.IsTrue(Vector4.UnitY.Equals(Vector4.UnitY));
			Assert.IsTrue(Vector4.UnitZ.Equals(Vector4.UnitZ));
			Assert.IsTrue(Vector4.UnitW.Equals(Vector4.UnitW));

			Assert.IsFalse(Vector4.Zero.Equals(Vector4.UnitX));
			Assert.IsFalse(Vector4.Zero.Equals(Vector4.UnitY));
			Assert.IsFalse(Vector4.Zero.Equals(Vector4.UnitZ));
			Assert.IsFalse(Vector4.Zero.Equals(Vector4.UnitW));
		}

		[TestMethod]
		public void GoodHashCode()
		{
			Assert.IsTrue(Vector4.UnitX.GetHashCode() != Vector4.UnitY.GetHashCode());

			Assert.IsTrue(Vector4.Zero.GetHashCode() != Vector4.UnitX.GetHashCode());
			Assert.IsTrue(Vector4.Zero.GetHashCode() != Vector4.UnitY.GetHashCode());
			Assert.IsTrue(Vector4.Zero.GetHashCode() != Vector4.UnitZ.GetHashCode());
			Assert.IsTrue(Vector4.Zero.GetHashCode() != Vector4.UnitW.GetHashCode());
		}
	}
}
