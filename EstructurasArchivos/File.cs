using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstructurasArchivos
{
    class File
    {
        public bool CrearArchivo()
        {
            FileStream archivo;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                archivo = new FileStream(saveFileDialog.FileName, FileMode.Create);
                BinaryWriter binaryWriter = new BinaryWriter(archivo);
                binaryWriter.Write((long)0);
                archivo.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public FileStream AbrirArchivo()
        {
            FileStream archivo;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                archivo = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.ReadWrite);
                return archivo;
            }
            else
                return null;
        }

        public void CerrarArchivo(FileStream archivo)
        {
            archivo.Close();
        }

        public void InsertaEntidad(FileStream archivo, string nombre)
        {
            if (archivo != null)
            {
                BinaryWriter binaryWriter = new BinaryWriter(archivo);
                binaryWriter.Seek(0, SeekOrigin.End);

                char[] id_entidad = new char[5];
                char[] nombre_entidad = new char[35];
                for (int i = 0; i < 35; i++)
                {
                    if (i < nombre.Length)
                        nombre_entidad[i] = nombre.ToCharArray()[i];
                    else
                        nombre_entidad[i] = ' ';
                }
                MessageBox.Show(nombre_entidad.Length + "");
                long direccion_entidad = archivo.Length;
                long dir_atributos = -1;
                long dir_datos = -1;
                long dir_siguiente_entidad = -1;

                binaryWriter.Write(id_entidad);
                binaryWriter.Write(nombre_entidad);
                binaryWriter.Write(direccion_entidad);
                binaryWriter.Write(dir_atributos);
                binaryWriter.Write(dir_datos);
                binaryWriter.Write(dir_siguiente_entidad);
            }
        }
    }
}
