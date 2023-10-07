using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConAppsExercises
{
    public class MultiDArray
    {
        public void RunMultiDArray()
        {
            //int[3,3]
            int[,] arr = new int[3,3]{{ 0,1,2},
                                                { 3,4,5},
                                                { 6,7,8} };

            int uBound0 = arr.GetUpperBound(0); //2
            int uBound1 = arr.GetUpperBound(1); //2

            for (int i = 0; i <= uBound0; i++)
            {
                for (int j = 0; j <= uBound1; j++)
                {
                    Write($"{arr[i,j]}  ");
                }
                WriteLine();
            }
        }
    }
}
