using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mono.GameMath;

namespace GameMathTests
{
	[TestClass]
	public class Vector3Tests
	{
		[TestMethod]
		public void NaNEquality()
		{
			Vector3 nanVec = new Vector3(float.NaN, float.NaN, float.NaN);
			Assert.IsFalse(nanVec == nanVec);
			Assert.IsTrue(nanVec != nanVec);
			Assert.IsTrue(nanVec.Equals(nanVec));
		}

		[TestMethod]
		public void SimpleEquality()
		{
			Assert.IsTrue(Vector3.Zero == Vector3.Zero);
			Assert.IsFalse(Vector3.Zero != Vector3.Zero);

			Assert.IsFalse(Vector3.Zero == Vector3.UnitX);
			Assert.IsFalse(Vector3.Zero == Vector3.UnitY);
			Assert.IsFalse(Vector3.Zero == Vector3.UnitZ);

			Assert.IsTrue(Vector3.Zero.Equals(Vector3.Zero));
			Assert.IsTrue(Vector3.UnitX.Equals(Vector3.UnitX));
			Assert.IsTrue(Vector3.UnitY.Equals(Vector3.UnitY));
			Assert.IsTrue(Vector3.UnitZ.Equals(Vector3.UnitZ));

			Assert.IsFalse(Vector3.Zero.Equals(Vector3.UnitX));
			Assert.IsFalse(Vector3.Zero.Equals(Vector3.UnitY));
			Assert.IsFalse(Vector3.Zero.Equals(Vector3.UnitZ));
		}

		[TestMethod]
		public void GoodHashCode()
		{
			Assert.IsTrue(Vector3.UnitX.GetHashCode() != Vector3.UnitY.GetHashCode());

			Assert.IsTrue(Vector3.Zero.GetHashCode() != Vector3.UnitX.GetHashCode());
			Assert.IsTrue(Vector3.Zero.GetHashCode() != Vector3.UnitY.GetHashCode());
			Assert.IsTrue(Vector3.Zero.GetHashCode() != Vector3.UnitZ.GetHashCode());
		}
	}
}
