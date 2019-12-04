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
    public partial class Indice : Form
    {
        string id = "";
        char tipo;
        FileStream indexFile;
        public Indice(string id, char tipo)
        {
            this.tipo = tipo;
            this.id = id;
            InitializeComponent();
        }

        private void Indice_Load(object sender, EventArgs e)
        {
            if (tipo == 'E')
            {
                indexFile = new FileStream(this.id + ".idx", FileMode.Open, FileAccess.ReadWrite);
                BinaryReader idr = new BinaryReader(indexFile);
                int actual = 0;
                long direccion = 0;
                indexFile.Position = 0;
                while (direccion != -1)
                {
                    string[] data = new string[2];
                    actual = idr.ReadInt32();
                    direccion = idr.ReadInt64();
                    if (direccion != -1 && direccion != -2)
                    {
                        data[0] = actual.ToString();
                        data[1] = direccion.ToString();
                        tablaIndice.Rows.Add(data);
                    }
                }
                
                
                indexFile.Close();
            }
            else
            {
                indexFile = new FileStream(this.id + ".idx", FileMode.Open, FileAccess.ReadWrite);
                BinaryReader idr = new BinaryReader(indexFile);

                string actual;
                long direccion = 0;
                indexFile.Position = 0;

                while (direccion != -1)
                {
                    string[] data = new string[2];
                    actual = idr.ReadString();
                    direccion = idr.ReadInt64();
                    if (direccion != -1 && direccion != -2)
                    {
                        data[0] = actual.ToString();
                        data[1] = direccion.ToString();
                        tablaIndice.Rows.Add(data);
                    }
                }


                indexFile.Close();
            }
        }
    }
}
