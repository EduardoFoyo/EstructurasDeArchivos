using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EstructurasArchivos
{
    public partial class CrearTabla : Form
    {
        List<string> entidades;
        List<Atributo> atributoList;
        public CrearTabla()
        {
            InitializeComponent();
            entidades = new List<string>();
            atributoList = new List<Atributo>();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(nombreEntidad.Text!="")
            {
                entidadesBox.Items.Add(nombreEntidad.Text);
                nombreEntidad.Clear();
            }
        }

        private void AgregarAtributo_Click(object sender, EventArgs e)
        {
            Atributo atributo = new Atributo(nombreAtributo.Text, tipoAtributo.SelectedItem.ToString(), Int32.Parse(longitudAtributo.Text), Int32.Parse(tipoIndiceAtributo.SelectedItem.ToString()), "");
            atributoList.Add(atributo);
            nombreAtributo.Clear();
            tipoAtributo.SelectedItem = null;
            tipoIndiceAtributo.SelectedItem = null;
            longitudAtributo.Clear();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string nomArchivo;
            FileStream archivo;
            BinaryWriter bw;
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                nomArchivo = save.FileName;
                archivo = new FileStream(nomArchivo, FileMode.Create,FileAccess.ReadWrite);

                Random random = new Random();
               


                bw = new BinaryWriter(archivo);
                bw.Write(random.Next(0, 200));
                bw.Write(nombreEntidad.Text);
                bw.Write(8);
                bw.Write(80);
                bw.Write(-1);
                bw.Write(-1);
                foreach (Atributo a in atributoList)
                {
                    bw.Write(random.Next(0, 200));
                    bw.Write(a.GetNombre());
                    bw.Write(a.GetTipo());
                    bw.Write(a.GetLongitud());
                    bw.Write(80);
                    bw.Write(a.GetTipoIndice());
                    bw.Write(-1);
                    bw.Write(80);
                }

                archivo.Close();

                this.Close();
            }
        }
    }
}
