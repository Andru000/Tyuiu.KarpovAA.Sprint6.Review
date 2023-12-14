using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tyuiu.KarpovAA.Sprint6.Review.V26.Lib;

namespace Tyuiu.KarpovAA.Sprint6.Review.V26.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {

            DataService ds = new DataService();

            int R = 1; //строка
            int k = 2; //от столбца
            int l = 4; //до столбца

            int[,] valueArray = new int[5, 5]  { { 5, 7, 3, 2, 7 },
                                                 { -8, -4, -1, -3, -2 },
                                                 { 4, 7, 9, 1, 6 },
                                                 { -3, -2, -5, -9, -4 }, 
                                                 { 1, 7, 8, 9, 3 }
                                                                        };

            int res = ds.GetMatrix(valueArray, R, k, l);

            int wait = 3; 

            Assert.AreEqual(wait, res);

        }
    }
}
