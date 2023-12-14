using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyuiu.KarpovAA.Sprint6.Review.V26.Lib
{
    public class DataService
    {

        public int GetMatrix(int[,] array, int R, int k, int l)
        {
            if (k > l || R < 0 || R >= array.GetLength(0))
                throw new ArgumentException("Некорректные интервалы или значение R");

            int p = 1;
            bool oddNumber = false; 

            for (int j = k; j <= l; j++) 
            {
                if (array[R, j] % 2 != 0)
                {
                    oddNumber = true;
                    p *= array[R, j];
                }
            }

            if (!oddNumber)
            {
                return 0;
            }

            return p;
        }
    
    }
}
