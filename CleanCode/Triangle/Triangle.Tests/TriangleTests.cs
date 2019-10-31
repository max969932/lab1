using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Triangle.Tests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void DoesTheTriangleExist_if_sideA_0_and_other_side_greater_than_0()
        {
            Assert.IsFalse(Triangle.DoesTheTriangleExist(0,20,30));
        }

        [TestMethod]
        public void DoesTheTriangleExist_if_sum_sideA_and_sideB_is_not_greater_than_sideC()
        {
            Assert.IsFalse(Triangle.DoesTheTriangleExist(1, 2, 3));
        }

        [TestMethod]
        public void DoesTheTriangleExist_if_sideA_less_than_0()
        {
            Assert.IsFalse(Triangle.DoesTheTriangleExist(-2, 20, 30));
        }

        [TestMethod]
        public void DoesTheTriangleExist_if_sideA_less_than_0_and_sideB_equally_0()
        {
            Assert.IsFalse(Triangle.DoesTheTriangleExist(-5, 0, 30));
        }

        [TestMethod]
        public void DoesTheTriangleExist_if_sum_sideB_and_sideC_is_not_greater_than_sideA()
        {
            Assert.IsFalse(Triangle.DoesTheTriangleExist(10, 2, 3));
        }

        [TestMethod]
        public void DoesTheTriangleExist_if_sum_sideA_and_sideB_equally_sideC()
        {
            Assert.IsFalse(Triangle.DoesTheTriangleExist(1, 2, 3));
        }

        [TestMethod]
        public void DoesTheTriangleExist_if_sum_sideA_and_sideC_is_not_greater_than_sideB()
        {
            Assert.IsFalse(Triangle.DoesTheTriangleExist(1, 3, 2));
        }

        [TestMethod]
        public void DoesTheTriangleExist_if_sideA_0_sideB_0_sideC_0()
        {
            Assert.IsFalse(Triangle.DoesTheTriangleExist(0, 0, 0));
        }

        [TestMethod]
        public void DoesTheTriangleExist_if_sideA_3_sideB_4_sideC_5()
        {
            Assert.IsTrue(Triangle.DoesTheTriangleExist(3, 4, 5));
        }

        [TestMethod]
        public void DoesTheTriangleExist_if_all_sides_less_than_0()
        {
            Assert.IsFalse(Triangle.DoesTheTriangleExist(-1, -2, -3));
        }
    }
}