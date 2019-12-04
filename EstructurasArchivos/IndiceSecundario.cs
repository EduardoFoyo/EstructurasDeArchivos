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
    public partial class IndiceSecundario : Form
    {

        string id = "";
        char tipo;
        FileStream indexSecundarioFile;
        public IndiceSecundario(string id, char tipo)
        {
            this.tipo = tipo;
            this.id = id;
            InitializeComponent();
        }

        private void IndiceSecundario_Load(object sender, EventArgs e)
        {
            if (tipo == 'E')
            {
                indexSecundarioFile = new FileStream(this.id + ".idx", FileMode.Open, FileAccess.ReadWrite);
                BinaryReader idr = new BinaryReader(indexSecundarioFile);
                int actual = 0;
                long direccion = 0;
                indexSecundarioFile.Position = 0;
                while (direccion != -1)
                {
                    string[] data = new string[2];
                    actual = idr.ReadInt32();
                    direccion = idr.ReadInt64();
                    if (direccion != -1)
                    {
                        data[0] = actual.ToString();
                        data[1] = direccion.ToString();
                        tablaIndice.Rows.Add(data);
                    }
                }


                indexSecundarioFile.Close();
            }
            else
            {
                try
                {
                    indexSecundarioFile = new FileStream(this.id + ".idx", FileMode.Open, FileAccess.ReadWrite);
                }
                catch (Exception)
                {

                    indexSecundarioFile.Close();
                    indexSecundarioFile = new FileStream(this.id + ".idx", FileMode.Open, FileAccess.ReadWrite);
                }
                BinaryReader idr = new BinaryReader(indexSecundarioFile);

                string actual;
                long direccion = 0;
                indexSecundarioFile.Position = 0;

                while (direccion != -1)
                {
                    string[] data = new string[2];
                    actual = idr.ReadString();
                    direccion = idr.ReadInt64();
                    if (direccion != -1)
                    {
                        data[0] = actual.ToString();
                        data[1] = direccion.ToString();
                        tablaIndice.Rows.Add(data);
                    }
                }
            }
            indexSecundarioFile.Close();
        }

        private void TablaIndice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            indiceRegistro.Rows.Clear();
            long actual;
            long direccion = 0;

            try
            {
                indexSecundarioFile = new FileStream(this.id + ".idx", FileMode.Open, FileAccess.ReadWrite);
            }
            catch (Exception)
            {

                indexSecundarioFile.Close();
                indexSecundarioFile = new FileStream(this.id + ".idx", FileMode.Open, FileAccess.ReadWrite);
            }
            BinaryReader idr = new BinaryReader(indexSecundarioFile);

            indexSecundarioFile.Position = long.Parse(tablaIndice.SelectedCells[0].Value.ToString());

            while (direccion != -1)
            {
                string[] data = new string[1];
                direccion = idr.ReadInt64();
                if (direccion != -1 && direccion != -2)
                {
                    data[0] = direccion.ToString();
                    indiceRegistro.Rows.Add(data);
                }
            }
            indexSecundarioFile.Close();
        }
    }
}
