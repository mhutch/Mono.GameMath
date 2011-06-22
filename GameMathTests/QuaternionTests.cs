using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mono.GameMath;

namespace GameMathTests
{
	[TestClass]
	public class QuaternionTests
	{
		public Quaternion Zero { get { return new Quaternion(); } }
		public Quaternion UnitX { get { return new Quaternion(1, 0, 0, 0); } }
		public Quaternion UnitY { get { return new Quaternion(0, 1, 0, 0); } }
		public Quaternion UnitZ { get { return new Quaternion(0, 0, 1, 0); } }
		public Quaternion UnitW { get { return new Quaternion(0, 0, 0, 1); } }


		[TestMethod]
		public void NaNEquality()
		{
			Quaternion nanQuat = new Quaternion(float.NaN, float.NaN, float.NaN, float.NaN);
			Assert.IsFalse(nanQuat == nanQuat);
			Assert.IsTrue(nanQuat != nanQuat);
			Assert.IsTrue(nanQuat.Equals(nanQuat));
		}

		[TestMethod]
		public void SimpleEquality()
		{
			Assert.IsTrue(Zero == Zero);
			Assert.IsFalse(Zero != Zero);

			Assert.IsFalse(Zero == UnitX);
			Assert.IsFalse(Zero == UnitY);
			Assert.IsFalse(Zero == UnitZ);
			Assert.IsFalse(Zero == UnitW);

			Assert.IsTrue(Zero.Equals(Zero));
			Assert.IsTrue(UnitX.Equals(UnitX));
			Assert.IsTrue(UnitY.Equals(UnitY));
			Assert.IsTrue(UnitZ.Equals(UnitZ));
			Assert.IsTrue(UnitW.Equals(UnitW));

			Assert.IsFalse(Zero.Equals(UnitX));
			Assert.IsFalse(Zero.Equals(UnitY));
			Assert.IsFalse(Zero.Equals(UnitZ));
			Assert.IsFalse(Zero.Equals(UnitW));
		}

		[TestMethod]
		public void GoodHashCode()
		{
			Assert.IsTrue(UnitX.GetHashCode() != UnitY.GetHashCode());

			Assert.IsTrue(Zero.GetHashCode() != UnitX.GetHashCode());
			Assert.IsTrue(Zero.GetHashCode() != UnitY.GetHashCode());
			Assert.IsTrue(Zero.GetHashCode() != UnitZ.GetHashCode());
			Assert.IsTrue(Zero.GetHashCode() != UnitW.GetHashCode());
		}
	}
}
