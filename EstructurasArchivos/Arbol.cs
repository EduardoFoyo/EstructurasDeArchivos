using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasArchivos
{
    public class Arbol
    {
        public List<Nodo> nodos;
        public Atributo atributo;

        public Arbol(List<Nodo> nodos, Atributo atributo)
        {
            this.nodos = nodos;
            this.atributo = atributo;
        }

        public bool ContieneRaiz()
        {
            foreach (var nodo in nodos)
            {
                if (nodo.tipo == 'R')
                    return true;
            }
            return false;
        }

        public Nodo GetRaiz()
        {
            foreach (var nodo in nodos)
            {
                if (nodo.tipo == 'R')
                    return nodo;
            }
            return null;
        }

        public Nodo GetNodo(long direccion)
        {
            foreach (var nodo in nodos)
            {
                if (nodo.direccion == direccion)
                    return nodo;
            }
            return null;
        }

        public Nodo GetPadre(Nodo hijo)
        {
            foreach (var nodo in nodos)
            {
                foreach (var item in nodo.apuntadores)
                {
                    if (item == hijo.direccion)
                    {
                        return nodo;
                    }
                }
            }
            return null;
        }

        public bool ContieneClave(int dato)
        {
            foreach (Nodo nodo in nodos)
            {
                if (nodo.tipo == 'H' && nodo.claves.Contains(dato))
                {
                    return true;
                }
            }
            return false;
        }

        // De la Clave
        public long GetDireccion(int dato)
        {
            foreach (Nodo nodo in nodos)
            {
                if (nodo.tipo == 'H' && nodo.claves.Contains(dato))
                {
                    int index = nodo.claves.IndexOf(dato);
                    return nodo.apuntadores[index];
                }
            }
            return -1;
        }

        public Nodo GetNodoDeLlave(int dato)
        {
            foreach (Nodo nodo in nodos)
            {
                if (nodo.tipo == 'H' && nodo.claves.Contains(dato))
                {
                    return nodo;
                }
            }
            return null;
        }

        public Nodo GetVecinoIzq(Nodo nodo)
        {
            Nodo padre = GetPadre(nodo);
            int index_nodo = padre.apuntadores.IndexOf(nodo.direccion);
            if (index_nodo != 0)
            {
                return GetNodo(padre.apuntadores[index_nodo - 1]);
            }
            else
                return null;
        }

        public Nodo GetVecinoDer(Nodo nodo)
        {
            Nodo padre = GetPadre(nodo);
            int index_nodo;
            if (padre != null)
            {
                index_nodo = padre.apuntadores.IndexOf(nodo.direccion);
            }
            else
            {
                return null;
            }

            if (index_nodo < padre.apuntadores.Count - 1)
            {
                return GetNodo(padre.apuntadores[index_nodo + 1]);
            }
            else
                return null;
        }

        public bool CheckMismoPadre(Nodo nodo1, Nodo nodo2)
        {
            Nodo padre = GetPadre(nodo1);
            return padre.apuntadores.Contains(nodo2.direccion);
        }
    }

}
