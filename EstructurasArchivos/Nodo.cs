using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasArchivos
{
    public class Nodo
    {
        public char tipo;
        public long direccion;
        public List<long> apuntadores;
        public List<int> claves;

        public const int CAP = 5;
        public Nodo()
        {
            apuntadores = new List<long>();
            claves = new List<int>();
            for (int i = 0; i < CAP; i++)
            {
                apuntadores.Add(-1);
                if (i != CAP - 1)
                    claves.Add(-1);
            }
        }


        // Inserta una clave EN ORDEN dentro de una hoja
        public bool InsertaEnHoja(int dato, long direccion)
        {
            if (CountClaves() < CAP - 1)
            {
                List<long> direcciones_temp = new List<long>();
                List<int> claves_temp = new List<int>();

                foreach (var item in claves)
                    if (item != -1)
                        claves_temp.Add(item);

                foreach (var item in apuntadores)
                    if (item != -1)
                        direcciones_temp.Add(item);

                claves_temp.Add(dato);
                claves_temp.Sort();
                int idx_temp = 0;
                for (int i = 0; i < claves_temp.Count; i++)
                {
                    claves[i] = claves_temp[i];
                    if (claves_temp[i] != dato)
                        apuntadores[i] = direcciones_temp[idx_temp++];
                    else
                        apuntadores[i] = direccion;
                }
                return true;
            }
            return false;
        }

        // Inserta una clave EN ORDEN dentro de una nodo denso (intermedio o raiz)
        public bool InsertaEnNodoDenso(int dato, long direccion)
        {
            if (CountClaves() < CAP - 1)
            {
                List<long> direcciones_temp = new List<long>();
                List<int> claves_temp = new List<int>();

                foreach (var item in claves)
                    if (item != -1)
                        claves_temp.Add(item);

                foreach (var item in apuntadores)
                    if (item != -1)
                        direcciones_temp.Add(item);

                if (direcciones_temp.Count > 1) direcciones_temp.RemoveAt(0);

                claves_temp.Add(dato);
                claves_temp.Sort();

                int idx_temp = 0;

                for (int i = 0; i < claves_temp.Count; i++)
                {
                    claves[i] = claves_temp[i];
                    if (claves_temp[i] != dato)
                        apuntadores[i + 1] = direcciones_temp[idx_temp++];
                    else
                        apuntadores[i + 1] = direccion;
                }
                return true;
            }
            return false;
        }

        public int DevuelvePosicion(int dato)
        {
            if (claves.Count == 0) return 0;
            int index;

            for (index = 0; index < CAP - 1; index++)
            {
                if (dato < claves[index] || claves[index] == -1)
                    return index;
            }

            return index;
        }


        public int CountClaves()
        {
            int res = 0;
            foreach (var item in claves)
            {
                if (item != -1)
                    res++;
                else
                    return res;
            }
            return res;
        }

        // Elimina una clave EN ORDEN dentro de una hoja
        public bool EliminaEnHoja(int dato)
        {
            if (claves.Contains(dato))
            {
                int index = claves.IndexOf(dato);
                long ap_sig = apuntadores[CAP - 1];
                apuntadores[CAP - 1] = (long)-1;

                claves.RemoveAt(index);
                apuntadores.RemoveAt(index);
                claves.Add(-1);
                apuntadores.Add(ap_sig);
                return true;
            }
            else
                return false;
        }

        public bool EliminaEnNodoDenso(int dato, long direccion)
        {
            if (claves.Contains(dato) && apuntadores.Contains(direccion))
            {
                apuntadores.Remove(direccion);
                claves.Remove(dato);
                apuntadores.Add((long)-1);
                claves.Add(-1);
                return true;
            }
            else
                return false;
        }

        public long GetApuntadorHoja(int dato)
        {
            return apuntadores[claves.IndexOf(dato)];
        }
    }
}

