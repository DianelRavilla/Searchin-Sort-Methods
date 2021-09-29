using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodos
{
    class MBusqueda
    {
        private int[] vec;

        public MBusqueda()
        {
            this.vec = null;
        }

        public void SetVector(int[] v)
        {
            this.vec = v;
        }
        public int[] GetVector()
        {
            return vec;
        }


        //METODOS_METODOS_METODOS_METODOS_METODOS_METODOS_
        public int Secuencial(double elemento)
        {
            for (int i = 0; i < vec.Length; i++)
            {
                if (elemento == vec[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public int Binario(double elemento)
        {
            int l = 0;
            int h = vec.Length - 1;
            int m = 0;
            bool encontrar = false;
            while (l <= h && encontrar == false)
            {
                m = (l + h) / 2;
                if (vec[m] == elemento)
                    encontrar = true;
                if (vec[m] > elemento)
                    h = m - 1;
                else
                    l = m + 1;
            }
            if (encontrar == false)
                return -1;
            else
                return m;
        }
    }
}
