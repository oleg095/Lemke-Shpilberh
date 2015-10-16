using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemke_Shpilberh
{
    class AlgorithmLemkeShpilberh
    {
        public byte[] x;
        private int[,] a;
        private int[] b;
        private int[] c;
        private int[] z;
        private int maxZ;
        private int[] admissibleVariables;
        private int m; //number of rows
        private int n; // number of columns
        public AlgorithmLemkeShpilberh(int[,] matrixA, int[] vectorB, int[] targetFunction)
        {
            m = vectorB.Length;
            n = targetFunction.Length;
            a = matrixA;
            b = vectorB;
            c = targetFunction;
            x = new byte[n];
            z = new int[m + 1];
            admissibleVariables = new int[n];
            for (int j=0; j<n; j++)
            {
                x[j] = 0;
                admissibleVariables[j] = 0; // ??????????
            }
        }
        public bool ExclusionCriterionForAlternatives()
        {
            int s = 0;
            for (int j = 0; j < n; j++)
            {
                s += c[j] * x[j];
            }
            z[0] = maxZ - s;
            if (z[0] < 0)
                return false;
            for (int j = 0; j < n; j++)
            {
                if ((x[j] == 1) || c[j] > z[0])
                {
                    admissibleVariables[j] = 0; // ??????????
                }
            }
            return true;
        }
        public bool AdmissibilityCriterion()
        {
            int s;
            for (int i = 0; i < m; i++)
            {
                s = 0;
                if (z[i + 1] < 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if ((x[j]==0)&&(a[i, j] < 0))
                            s += a[i, j];
                    }
                    if (s < z[i + 1])
                        return false;
                }
            }
            return true;
        }
        public int BestVariableCriterion()
        {
           int s;
           for (int j=0; j< n; j++)
           {
                s = 0;
                if (x[j] == 0)
                {
                    for (int i = 0; i < m; i++)
                    {
                        if (z[i + 1] < 0)
                            s += a[i, j];
                    }
                    admissibleVariables[j] = s;
                }
           }
            int max = admissibleVariables[0];
            int maxN=0;
            for (int j=1; j< n; j++)
            {
                if (admissibleVariables[j]>max)
                {
                    max = admissibleVariables[j];
                    maxN = j;
                }
            }
            return maxN; // ??????????
        }
    }
}
