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
            //arrange
            float sideA = 0;
            float sideB = 20;
            float sideC = 30;
            bool expected = false;

            //act
            bool actual = Triangle.DoesTheTriangleExist(sideA, sideB, sideC);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoesTheTriangleExist_if_sum_sideA_and_sideB_is_not_greater_than_sideC()
        {
            //arrange
            float sideA = 1;
            float sideB = 2;
            float sideC = 3;
            bool expected = false;

            //act
            bool actual = Triangle.DoesTheTriangleExist(sideA, sideB, sideC);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoesTheTriangleExist_if_sideA_less_than_0()
        {
            //arrange
            float sideA = -2;
            float sideB = 20;
            float sideC = 30;
            bool expected = false;

            //act
            bool actual = Triangle.DoesTheTriangleExist(sideA, sideB, sideC);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoesTheTriangleExist_if_sideA_less_than_0_and_sideB_equally_0()
        {
            //arrange
            float sideA = -5;
            float sideB = 0;
            float sideC = 30;
            bool expected = false;

            //act
            bool actual = Triangle.DoesTheTriangleExist(sideA, sideB, sideC);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoesTheTriangleExist_if_sum_sideB_and_sideC_is_not_greater_than_sideA()
        {
            //arrange
            float sideA = 10;
            float sideB = 2;
            float sideC = 3;
            bool expected = false;

            //act
            bool actual = Triangle.DoesTheTriangleExist(sideA, sideB, sideC);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoesTheTriangleExist_if_sum_sideA_and_sideB_equally_sideC()
        {
            //arrange
            float sideA = 1;
            float sideB = 2;
            float sideC = 3;
            bool expected = false;

            //act
            bool actual = Triangle.DoesTheTriangleExist(sideA, sideB, sideC);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoesTheTriangleExist_if_sum_sideA_and_sideC_is_not_greater_than_sideB()
        {
            //arrange
            float sideA = 1;
            float sideB = 3;
            float sideC = 2;
            bool expected = false;

            //act
            bool actual = Triangle.DoesTheTriangleExist(sideA, sideB, sideC);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoesTheTriangleExist_if_sideA_0_sideB_0_sideC_0()
        {
            //arrange
            float sideA = 0;
            float sideB = 0;
            float sideC = 0;
            bool expected = false;

            //act
            bool actual = Triangle.DoesTheTriangleExist(sideA, sideB, sideC);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoesTheTriangleExist_if_sideA_3_sideB_4_sideC_5()
        {
            //arrange
            float sideA = 3;
            float sideB = 4;
            float sideC = 5;
            bool expected = true;

            //act
            bool actual = Triangle.DoesTheTriangleExist(sideA, sideB, sideC);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoesTheTriangleExist_if_all_sides_less_than_0()
        {
            //arrange
            float sideA = -1;
            float sideB = -2;
            float sideC = -3;
            bool expected = false;

            //act
            bool actual = Triangle.DoesTheTriangleExist(sideA, sideB, sideC);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}