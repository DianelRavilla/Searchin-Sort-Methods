using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodos
{
    class MOrdenamiento
    {
        private int[] vec;
        private int n;
        private const int MAX = 100;

        public MOrdenamiento()
        {
            this.vec = null;
            this.n = 0;
        }

        public void SetVector(int[] v)
        {
            this.vec = v;
        }
        public int[] GetVector()
        {
            return vec;
        }
        public void SetDimension(int dimension)
        {
            this.n = dimension;
        }
        public int GetDimension()
        {
            return n;
        }

        //METODOS_METODOS_METODOS_METODOS_METODOS_METODOS_
        public void Burbuja()
        {
            int aux;
            for (int a = 1; a < n; a++)
            {
                for (int b = n - 1; b >= a; b--)
                {
                    if (vec[b - 1] > vec[b])
                    {
                        aux = vec[b - 1];
                        vec[b - 1] = vec[b];
                        vec[b] = aux;
                    }
                }
            }
        }

        public void Intercambio()
        {
            int aux;
            for (int i = 0; i <= n - 2; i++)
            {
                for (int j = i + 1; j <= n - 1; j++)
                {
                    if (vec[i] > vec[j])
                    {
                        aux = vec[i];
                        vec[i] = vec[j];
                        vec[j] = aux;
                    }
                }
            }
        }

        public void insercionDirecta()
        {
            int aux;
            int j;
            for (int i = 0; i < n; i++)
            {
                aux = vec[i];
                j = i - 1;
                while (j >= 0 && vec[j] > aux)
                {
                    vec[j + 1] = vec[j];
                    j--;
                }
                vec[j + 1] = aux;
            }
        }

        public void Shell()
        {
            int salto = n / 2, sw = 0, aux = 0, e = 0;
            while (salto > 0)
            {
                sw = 1;
                while (sw != 0)
                {
                    sw = 0;
                    e = 1;
                    while (e <= (n - salto))
                    {
                        if (vec[e - 1] > vec[(e - 1) + salto])
                        {
                            aux = vec[(e - 1) + salto];
                            vec[(e - 1) + salto] = vec[e - 1];
                            vec[(e - 1)] = aux;
                            sw = 1;
                        }
                        e++;
                    }
                }
                salto = salto / 2;
            }
        }

        public void QuickSort()
        {
            quicksort(0, n - 1);
        }
        private void quicksort(int primero, int ultimo)
        {
            int i, j, central, pivote;
            central = (primero + ultimo) / 2;
            pivote = vec[central];
            i = primero;
            j = ultimo;
            do
            {
                while (vec[i] < pivote)
                    i++;
                while (vec[j] > pivote)
                    j--;
                if (i <= j)
                {
                    int temp;
                    temp = vec[i];
                    vec[i] = vec[j];
                    vec[j] = temp;
                    i++;
                    j--;
                }
            }
            while (i <= j);
            if (primero < j)
                quicksort(primero, j);
            if (i < ultimo)
                quicksort(i, ultimo);
        }

        public void MergeSort()
        {
            mergesort(vec, 0, n - 1);
        }
        private void mergesort(int[] vector, int li, int ls)
        {
            int mitad;
            if (ls > li)
            {
                mitad = (ls + li) / 2;
                mergesort(vector, li, mitad);
                mergesort(vector, mitad + 1, ls);
                merge(vector, li, mitad + 1, ls);
            }
        }
        private void merge(int[] vector, int li, int mitad, int ls)
        {
            int[] aux = new int[vector.Length];//Vector auxiliar
            int i = li;//Indice de la parte izquierda
            int j = mitad;//Indice de la parte derecha
            int k = li;//Indice del vector resultante

            while ((i <= mitad - 1) && (j <= ls))
            {
                //Mientras que i esta en la parte izq y j en la dcha
                if (vector[i] <= vector[j])
                {
                    aux[k++] = vector[i++];
                }
                else
                {
                    aux[k++] = vector[j++];
                }

            }
            //Copia los elementos que estaban en la posicion correcta:
            while (i <= mitad - 1)
            {
                aux[k++] = vector[i++];
            }

            while (j <= ls)
            {
                aux[k++] = vector[j++];
            }

            //Copia los elementos en el vector original
            for (i = li; i <= ls; i++)
            {
                vector[i] = aux[i];
            }
        }

        public void RadixSort()
        {
            int[] t = new int[vec.Length];
            int r = 16;
            int b = 32;
            int[] count = new int[1 << r];
            int[] pref = new int[1 << r];
            int groups = (int)Math.Ceiling((double)b / (double)r);
            int mask = (1 << r) - 1;
            for (int c = 0, shift = 0; c < groups; c++, shift += r)
            {
                for (int j = 0; j < count.Length; j++)
                    count[j] = 0;
                for (int i = 0; i < vec.Length; i++)
                    count[(vec[i] >> shift) & mask]++;
                pref[0] = 0;
                for (int i = 1; i < count.Length; i++)
                    pref[i] = pref[i - 1] + count[i - 1];
                for (int i = 0; i < vec.Length; i++)
                    t[pref[(vec[i] >> shift) & mask]++] = vec[i];
                t.CopyTo(vec, 0);
            }
        }

        public void Seleccion()
        {
            int i = 0, j = 0;
            int temp = 0, minimo = 0;
            for (i = 0; i < n - 1; i++)
            {
               minimo = i;
               for (j = i + 1; j < n; j++)
               {
                   if (vec[minimo] > vec[j])
                   {
                        minimo = j;
                   }
               }
               temp = vec[minimo];
               vec[minimo] = vec[i];
               vec[i] = temp;
            }
        }

        public void BucketSort()
        {
            //Verify input
            if (vec == null || vec.Length == 0)
                return;
            //Find the maximum and minimum values in the array
            int maxValue = vec[0]; //start with first element
            int minValue = vec[0];
            //Note: start from index 1
            for (int i = 1; i < vec.Length; i++)
            {
                if (vec[i] > maxValue)
                    maxValue = vec[i];

                if (vec[i] < minValue)
                    minValue = vec[i];
            }
            //Create a temporary "bucket" to store the values in order
            //each value will be stored in its corresponding index
            //scooting everything over to the left as much as possible (minValue)
            //e.g. 34 => index at 34 - minValue
            List<int>[] bucket = new List<int>[maxValue - minValue + 1];
            //Initialize the bucket
            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }
            //Move items to bucket
            for (int i = 0; i < vec.Length; i++)
            {
                bucket[vec[i] - minValue].Add(vec[i]);
            }
            //Move items in the bucket back to the original array in order
            int k = 0; //index for original array
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        vec[k] = bucket[i][j];
                        k++;
                    }
                }
            }
        }

        public void HeapSort()  //por monticulos
        {
            int i;
            int temp;
            for (i = (n / 2) ; i >= 0; i--)
            {
                HacerMonticulo(i, n - 1);
            }
            for (i = n - 1; i >= 0; i--)
            {
                temp = vec[0];
                vec[0] = vec[i];
                vec[i] = temp;
                HacerMonticulo(0, i - 1);   //SiftDown 
            }
        }
        private void HacerMonticulo(int root, int bottom)
        {
            int izq = 2 * root;
            int der = izq + 1;
            int may;
            if (izq > bottom)
                return;
            if (der > bottom)
                may = izq;
            else
            {
                //may = vec[izq] > vec[der] ? izq : der;
                if (vec[izq] > vec[der])
                    may = izq;
                else
                    may = der;
            }
            if (vec[root] < vec[may])
            {
                int temp = vec[root];
                vec[root] = vec[may];
                vec[may] = temp;
                HacerMonticulo(may, bottom);
            }
        }
    }
}