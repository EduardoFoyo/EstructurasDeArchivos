using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstructurasArchivos
{
    public partial class ArbolSecundario : Form
    {
        List<NodoArbol> nodos;
        public ArbolSecundario(List<NodoArbol> nodos)
        {
            InitializeComponent();
            this.nodos = nodos;
            imprimeArbol();
        }

        public void imprimeArbol()
        {
            archivo_idx_secu_ab.Rows.Clear();

            string[] filas = new string[11];
            foreach (NodoArbol nodo in nodos)
            {
                filas[0] = nodo.tipo.ToString();
                filas[1] = nodo.direccion.ToString();
                for (int i = 0; i < 4; i++)
                {
                    filas[2 * (i + 1)] = nodo.apuntadores[i].ToString();
                    filas[2 * (i + 1) + 1] = nodo.claves[i].ToString();
                }

                filas[10] = nodo.apuntadores[NodoArbol.K_ARBOL - 1].ToString();
                archivo_idx_secu_ab.Rows.Add(filas);
            }
        }
    }
}
