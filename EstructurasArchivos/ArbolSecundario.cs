using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstructurasArchivos
{
    public partial class ArbolSecundario : Form
    {
        public List<Nodo> nodos;
        public int entidad;
        public int atributo_id;
        public List<Atributo> listAtributo;
        List<long> direcciones;
        public FileStream archivoArbol;
        public const int TAMANIO_BLOQUE = 2048;
        public const int NREGISTROS_SENCILLOS = (TAMANIO_BLOQUE - 8) / 8;
        public ArbolSecundario(List<Nodo> nodos,int entidad,int atributo, List<Atributo> listAtributo)
        {
            InitializeComponent();
            this.nodos = nodos;
            this.entidad = entidad;
            this.atributo_id = atributo;
            this.listAtributo = listAtributo;
            imprimeArbol();
        }

        public void imprimeArbol()
        {
            archivo_idx_secu_ab.Rows.Clear();

            string[] filas = new string[11];
            foreach (Nodo nodo in nodos)
            {
                filas[0] = nodo.tipo.ToString();
                filas[1] = nodo.direccion.ToString();
                for (int i = 0; i < 4; i++)
                {
                    filas[2 * (i + 1)] = nodo.apuntadores[i].ToString();
                    filas[2 * (i + 1) + 1] = nodo.claves[i].ToString();
                }

                filas[10] = nodo.apuntadores[Nodo.CAP - 1].ToString();
                archivo_idx_secu_ab.Rows.Add(filas);
            }
        }

        private void Archivo_idx_secu_ab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (archivo_idx_secu_ab.Rows[e.RowIndex].Cells[0].Value + "" == "H")
                {
                    RellenaClaveHojas(Convert.ToInt64(archivo_idx_secu_ab.Rows[e.RowIndex].Cells[1].Value));
                }
            }
            catch { };
        }

        public void RellenaClaveHojas(long direccion)
        {
            int idx_entidad = entidad;
            List<Atributo> atributos = listAtributo;

            int idx_atributo = atributo_id;
            Arbol arbol = new Arbol(nodos, atributos[idx_atributo]);

            Nodo nodo = arbol.GetNodo(direccion);

            List<string[]> filas = new List<string[]>();
            for (int i = 0; i < Nodo.CAP - 1; i++)
            {
                if (nodo.apuntadores[i] != -1)
                {
                    string[] temp = new string[2];
                    temp[0] = nodo.claves[i].ToString();
                    temp[1] = nodo.apuntadores[i].ToString();
                    filas.Add(temp);
                }
                else
                    break;
            }

            arbol2_claves.Rows.Clear();
            foreach (var item in filas)
            {
                arbol2_claves.Rows.Add(item);
            }
        }

        private void Arbol2_claves_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RellenaBloqueArbolSecu(Convert.ToInt64(arbol2_claves.Rows[e.RowIndex].Cells[1].Value));
            }
            catch { };
        }

        public void RellenaBloqueArbolSecu(long direccion)
        {
            int idx_entidad = entidad;
            List<Atributo> atributos = listAtributo;

            int idx_atributo = atributo_id;
            Atributo atributo = atributos[idx_atributo];
            List<long> direcciones = GetBloqueDenso(atributo, direccion);

            List<string> filas = new List<string>();
            foreach (var item in direcciones)
            {
                filas.Add(item.ToString());
            }

            arbol2_bloque.Rows.Clear();
            foreach (var item in filas)
            {
                arbol2_bloque.Rows.Add(item);
            }
        }

        public List<long> GetBloqueDenso(Atributo atributo, long cabecera)
        {
            List<long> res = new List<long>();
            AbrirArchivoArbol(atributo);
            BinaryReader bn = new BinaryReader(archivoArbol);
            bn.BaseStream.Position = cabecera;
            for (int i = 0; i < NREGISTROS_SENCILLOS; i++)
            {
                long temp = bn.ReadInt64();
                if (temp != -1)
                    res.Add(temp);
            }
            CerrarArchivoArbol();
            return res;
        }

        public void CerrarArchivoArbol()
        {
            archivoArbol.Close();
        }

        public void AbrirArchivoArbol(Atributo atributo)
        {
            string file_name = atributo.id + ".idx";
            try
            {
                archivoArbol = new FileStream(file_name, FileMode.Open, FileAccess.ReadWrite);
            }
            catch (Exception)
            {
                archivoArbol.Close();
                archivoArbol = new FileStream(file_name, FileMode.Open, FileAccess.ReadWrite);
            }
        }
    }
}
