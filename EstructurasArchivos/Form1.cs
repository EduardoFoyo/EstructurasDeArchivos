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
    public partial class cargarAtributos : Form
    {
        FileStream file;

        long cab_aux;
        List<Entidad> listEntidades;
        List<Atributo> listAtributos;

        public cargarAtributos()
        {
            InitializeComponent();
            listEntidades = new List<Entidad>();
            listAtributos = new List<Atributo>();
        }



        private void CreateFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = new FileStream(saveFileDialog.FileName, FileMode.Create);
                BinaryWriter binaryWriter = new BinaryWriter(file);
                binaryWriter.Write((long)-1);
                file.Close();
            }
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.ReadWrite);

                BinaryReader binaryReader = new BinaryReader(file);
                file.Seek(0, SeekOrigin.Begin);
                long aux = cab_aux;
                cab_aux = binaryReader.ReadInt64();
                if (file.Length > 8)
                {
                    guardarDatos();
                }
            }



        }

        private void guardarDatos()
        {
            listEntidades.Clear();
            BinaryReader binaryReader = new BinaryReader(file);
            file.Seek(0, SeekOrigin.Begin);
            long cab = binaryReader.ReadInt64();
            if (cab == -1)
            {

            }
            else
            {

                file.Position = cab;
                long direccion_sig;
                do
                {

                    string[] antributo = new string[6];

                    string id = Encoding.ASCII.GetString(binaryReader.ReadBytes(5));
                    string nombre = binaryReader.ReadString();
                    long direccion = binaryReader.ReadInt64();
                    long direccion_atributos = binaryReader.ReadInt64();
                    long dirNose = binaryReader.ReadInt64();
                    direccion_sig = binaryReader.ReadInt64();


                    Entidad e = new Entidad(id, nombre, direccion, direccion_atributos, dirNose, direccion_sig);
                    listEntidades.Add(e);



                    if (direccion_sig != -1)
                    {
                        file.Position = direccion_sig;
                    }

                } while (direccion_sig != -1);

                selectEntidad.Items.Clear();
                for (int i = 0; i < listEntidades.Count; i++)
                {
                    selectEntidad.Items.Add(listEntidades[i].nombre);
                }

                cargarEntidades.Items.Clear();
                for (int i = 0; i < listEntidades.Count; i++)
                {
                    cargarEntidades.Items.Add(listEntidades[i].nombre);
                }

                elimEntidadAtributo.Items.Clear();
                for (int i = 0; i < listEntidades.Count; i++)
                {
                    elimEntidadAtributo.Items.Add(listEntidades[i].nombre);
                }


                elimEntidad.Items.Clear();
                for (int i = 0; i < listEntidades.Count; i++)
                {
                    elimEntidad.Items.Add(listEntidades[i].nombre);
                }


                editarEntidad.Items.Clear();
                for (int i = 0; i < listEntidades.Count; i++)
                {
                    editarEntidad.Items.Add(listEntidades[i].nombre);
                }

                editarEntAtri.Items.Clear();
                for (int i = 0; i < listEntidades.Count; i++)
                {
                    editarEntAtri.Items.Add(listEntidades[i].nombre);
                }
            }

        }


        public void guardarAtributos(string seleccion)
        {
            listAtributos.Clear();
            BinaryReader binaryReader = new BinaryReader(file);

            for (int i = 0; i < listEntidades.Count; i++)
            {

                if (listEntidades[i].nombre == seleccion)
                {
                    if (listEntidades[i].direccion_atributos == -1)
                    {

                    }
                    else
                    {

                        file.Position = listEntidades[i].direccion_atributos;
                        do
                        {
                            //string id = new string(binaryReader.ReadChars(5));
                            string id = Encoding.ASCII.GetString(binaryReader.ReadBytes(5));
                            string nombre = binaryReader.ReadString();
                            char tipo = binaryReader.ReadChar();
                            int longitud = binaryReader.ReadInt32();
                            long direccion = binaryReader.ReadInt64();
                            int tipoId = binaryReader.ReadInt32();
                            long dirDatos = binaryReader.ReadInt64();
                            long dirSiguiente = binaryReader.ReadInt64();
                            if (dirSiguiente == -1)
                            {
                                Atributo a = new Atributo(id, nombre, tipo, longitud, direccion, tipoId, dirDatos, dirSiguiente);
                                listAtributos.Add(a);
                                break;
                            }
                            else
                            {
                                Atributo a = new Atributo(id, nombre, tipo, longitud, direccion, tipoId, dirDatos, dirSiguiente);
                                listAtributos.Add(a);
                                file.Position = dirSiguiente;
                            }

                        } while (true);
                    }
                }
            }

        }

        private void AddEntity_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Entidad Agregada");
            listEntidades.Clear();
            if (file.Length == 8)
            {
                BinaryWriter binaryWriter = new BinaryWriter(file);
                binaryWriter.Seek(0, SeekOrigin.Begin);
                binaryWriter.Write(file.Length);

                binaryWriter.Seek(0, SeekOrigin.End);

                char[] id_entidad = new char[5];
                string nombre = entityText.Text.PadRight(34);

                long direccion_entidad = file.Length;
                long dir_atributos = -1;
                long dir_datos = -1;
                long dir_siguiente_entidad = -1;

                binaryWriter.Write(generarId());
                binaryWriter.Write(nombre);
                binaryWriter.Write(direccion_entidad);
                binaryWriter.Write(dir_atributos);
                binaryWriter.Write(dir_datos);
                binaryWriter.Write(dir_siguiente_entidad);
            }
            else
            {
                long aux_anterior;
                //long aux_cab;
                bool bandera = false;
                BinaryWriter binaryWriter = new BinaryWriter(file);
                binaryWriter.Seek(0, SeekOrigin.End);

                char[] id_entidad = new char[5];
                string nombre = entityText.Text.PadRight(34);

                long direccion_entidad = file.Length;
                long dir_atributos = -1;
                long dir_datos = -1;
                long dir_siguiente_entidad = -1;

                binaryWriter.Write(generarId());
                binaryWriter.Write(nombre);
                binaryWriter.Write(direccion_entidad);
                binaryWriter.Write(dir_atributos);
                binaryWriter.Write(dir_datos);
                binaryWriter.Write(dir_siguiente_entidad);


                //file.Seek(0,SeekOrigin.Begin);
                file.Position = 0;
                BinaryReader br = new BinaryReader(file);
                long cab = br.ReadInt64();
                //file.Seek(cab, SeekOrigin.Current);
                file.Position = cab;
                aux_anterior = cab;
                //file.Seek(cab + 5, SeekOrigin.Current);
                file.Position = cab + 5;
                string aux = br.ReadString(); //Recupera el nombre de la primera entidad a partir de la cabecera

                if (string.Compare(entityText.Text, aux) == -1)
                {
                    file.Position = 0;
                    long modifucarCab = file.Length - 72;
                    binaryWriter.Write(modifucarCab);

                    file.Position = file.Length - 8;
                    binaryWriter.Write(aux_anterior);
                }
                else
                {
                    do
                    {
                        file.Position = aux_anterior + 64;
                        long apunta = br.ReadInt64();
                        if (apunta == -1)
                        {
                            file.Position = aux_anterior + 64;
                            binaryWriter.Write(file.Length - 72);
                            bandera = true;
                            break;
                        }
                        file.Position = apunta + 5;
                        aux = br.ReadString();
                        if (string.Compare(entityText.Text, aux) == -1)
                        {
                            file.Position = file.Length - 8;
                            binaryWriter.Write(apunta);
                            file.Position = aux_anterior + 64;
                            binaryWriter.Write(file.Length - 72);
                            break;
                        }
                        else
                        {
                            file.Position = aux_anterior + 64;
                            aux_anterior = br.ReadInt64();

                            if (aux_anterior == -1)
                            {
                                bandera = true;
                                break;
                            }
                        }

                    } while (true);

                    if (bandera == true)
                    {
                        file.Position = aux_anterior + 64;
                        binaryWriter.Write(file.Length - 72);
                    }
                }
            }
            guardarDatos();
        }

        public byte[] generarId()
        {
            byte[] buffer = new byte[5];
            new Random().NextBytes(buffer);
            return buffer;
        }

        private void AgregarAtributo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Atributo Agregada");
            listAtributos.Clear();
            BinaryWriter binaryWriter = new BinaryWriter(file);
            BinaryReader binaryReader = new BinaryReader(file);
            file.Position = file.Length;

            //char[] id_entidad = new char[5];

            string nombre = nombreAtributo.Text.PadRight(34);


            char tipo = char.Parse(tipoAtributo.Text);
            int longitud = Int32.Parse(longitudAtributo.Text);
            long direccion_atributo = file.Length;
            int tipo_indice = Int32.Parse(tipoIndiceAtributo.SelectedItem.ToString());
            long dir_datos = -1;
            long dir_siguiente_atributo = -1;
            string entidad = selectEntidad.Text.ToString();

            binaryWriter.Write(generarId());
            binaryWriter.Write(nombre);
            binaryWriter.Write(tipo);
            binaryWriter.Write(longitud);
            binaryWriter.Write(direccion_atributo);
            binaryWriter.Write(tipo_indice);
            binaryWriter.Write(dir_datos);
            binaryWriter.Write(dir_siguiente_atributo);

            for (int i = 0; i < listEntidades.Count; i++)
            {
                if (listEntidades[i].nombre == entidad)
                {
                    file.Position = listEntidades[i].direccion + 48;
                    long primerAtributo = binaryReader.ReadInt64();
                    if (primerAtributo == -1)
                    {
                        file.Position = listEntidades[i].direccion + 48;
                        binaryWriter.Write(file.Length - 73);
                    }
                    else
                    {
                        file.Position = listEntidades[i].direccion_atributos + 65;
                        do
                        {
                            long ultimoAtributo = binaryReader.ReadInt64();
                            if (ultimoAtributo == -1)
                            {
                                file.Position = file.Position - 8;
                                binaryWriter.Write(file.Length - 73);
                                break;
                            }
                            else
                            {
                                file.Position = ultimoAtributo + 65;
                            }
                        } while (true);
                    }

                }
            }

            nombreAtributo.Clear();
            tipoAtributo.SelectedItem = null;
            tipoIndiceAtributo.SelectedItem = null;
            longitudAtributo.Clear();
        }

        private void CloseFile_Click(object sender, EventArgs e)
        {
            file.Close();
        }

        private void CargarDatos_Click(object sender, EventArgs e)
        {
            entidades.Rows.Clear();
            atributos.Rows.Clear();
            guardarDatos();
            guardarAtributos(cargarEntidades.Text);


            for (int j = 0; j < listEntidades.Count; j++)
            {
                string[] entidad = new string[6];
                entidad[0] = listEntidades[j].id;
                entidad[1] = listEntidades[j].nombre;
                entidad[2] = listEntidades[j].direccion.ToString();
                entidad[3] = listEntidades[j].direccion_atributos.ToString();
                entidad[4] = listEntidades[j].dirNose.ToString();
                entidad[5] = listEntidades[j].direccion_sig.ToString();
                entidades.Rows.Add(entidad);
            }




            for (int j = 0; j < listAtributos.Count; j++)
            {
                string[] atributo = new string[8];
                atributo[0] = listAtributos[j].id;
                atributo[1] = listAtributos[j].nombre;
                atributo[2] = listAtributos[j].tipo.ToString();
                atributo[3] = listAtributos[j].longitud.ToString();
                atributo[4] = listAtributos[j].direccion.ToString();
                atributo[5] = listAtributos[j].tipoId.ToString();
                atributo[6] = listAtributos[j].dirDatos.ToString();
                atributo[7] = listAtributos[j].dirSiguiente.ToString();
                atributos.Rows.Add(atributo);
            }



        }

        private void EntidadEditar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listEntidades.Count; i++)
            {
                if (listEntidades[i].nombre == editarEntidad.Text)
                {
                    BinaryWriter binaryWriter = new BinaryWriter(file);
                    BinaryReader binaryReader = new BinaryReader(file);
                    file.Position = listEntidades[i].direccion + 5;
                    binaryWriter.Write(nombreEntidadNuevo.Text.PadRight(34));

                    nombreEntidadNuevo.Clear();
                    editarEntidad.SelectedItem = null;
                    break;
                }
            }
        }


        private void CargarAtrib_Click(object sender, EventArgs e)
        {
            editarAtributo.Items.Clear();
            guardarAtributos(editarEntAtri.Text);
            for (int i = 0; i < listAtributos.Count; i++)
            {
                editarAtributo.Items.Add(listAtributos[i].nombre);
            }
        }

        private void BEditarAtributo_Click(object sender, EventArgs e)
        {
            BinaryWriter binaryWriter = new BinaryWriter(file);
            BinaryReader binaryReader = new BinaryReader(file);
            for (int i = 0; i < listEntidades.Count; i++)
            {
                if (listEntidades[i].nombre == editarEntAtri.Text)
                {
                    for (int j = 0; j < listAtributos.Count; j++)
                    {
                        if (listAtributos[j].nombre == editarAtributo.Text)
                        {
                            file.Position = listAtributos[j].direccion + 5;
                            if (eNombreAtributo.Text != "")
                            {
                                binaryWriter.Write(eNombreAtributo.Text.PadRight(34));
                            }
                            else
                            {
                                file.Position = file.Position + 35;
                            }
                            if (eTipoAtributo.Text != "")
                            {
                                char tipo = char.Parse(eTipoAtributo.Text);
                                binaryWriter.Write(tipo);
                            }
                            else
                            {
                                file.Position = file.Position + 1;
                            }
                            if (eLongitudEntidad.Text != "")
                            {
                                int longitud = Int32.Parse(eLongitudEntidad.Text);
                                binaryWriter.Write(longitud);
                            }
                            else
                            {
                                file.Position = file.Position + 4;
                            }
                            if (eTipoIndiceAtributo.Text != "")
                            {
                                int indice = Int32.Parse(eTipoIndiceAtributo.Text);
                                binaryWriter.Write(indice);
                            }
                            else
                            {
                                file.Position = file.Position + 4;
                            }
                        }
                    }
                }
            }
            eNombreAtributo.Clear();
            eTipoAtributo.SelectedItem = null;
            eLongitudEntidad.Clear();
            eTipoIndiceAtributo.SelectedItem = null;
        }

        private void BotonEliminaEntidad_Click(object sender, EventArgs e)
        {
            BinaryWriter binaryWriter = new BinaryWriter(file);
            BinaryReader binaryReader = new BinaryReader(file);
            for (int i = 0; i < listEntidades.Count; i++)
            {
                if (listEntidades[i].nombre == elimEntidad.Text)
                {
                    file.Position = 0;
                    long cab = binaryReader.ReadInt64();
                    if (cab != listEntidades[i].direccion)
                    {
                        if (listEntidades[i].direccion_sig == -1)
                        {
                            file.Position = listEntidades[i - 1].direccion + 64;
                            binaryWriter.Write((long)-1);
                            break;
                        }
                        else
                        {
                            file.Position = listEntidades[i].direccion + 64;
                            long nuevaDireccion = binaryReader.ReadInt64();
                            file.Position = listEntidades[i - 1].direccion + 64;
                            binaryWriter.Write(nuevaDireccion);
                        }
                    }
                    else
                    {
                        if (listEntidades[i].direccion_sig != -1)
                        {
                            file.Position = 0;
                            binaryWriter.Write((long)listEntidades[i].direccion_sig);
                        }
                        else
                        {
                            file.Position = 0;
                            binaryWriter.Write((long)-1);
                        }


                    }
                
                }
            }
        }

        private void EliminaCargarEntidades_Click(object sender, EventArgs e)
        {
            eliminarAtributo.Items.Clear();
            guardarAtributos(elimEntidadAtributo.Text);
            for (int i = 0; i < listAtributos.Count; i++)
            {
                eliminarAtributo.Items.Add(listAtributos[i].nombre);
            }
        }

        private void ElimAtributo_Click(object sender, EventArgs e)
        {
            BinaryWriter binaryWriter = new BinaryWriter(file);
            BinaryReader binaryReader = new BinaryReader(file);
            for (int i = 0; i < listEntidades.Count; i++)
            {
                if (listEntidades[i].nombre == elimEntidadAtributo.Text)
                {
                    for (int j = 0; j < listAtributos.Count; j++)
                    {
                        if (listAtributos[j].nombre == eliminarAtributo.Text)
                        {
                            
                            if (listEntidades[i].direccion_atributos == listAtributos[j].direccion)
                            {
                                if (listAtributos[j].dirSiguiente == -1)
                                {
                                    file.Position = listEntidades[i].direccion + 48;
                                    binaryWriter.Write((long)-1);
                                }
                                else
                                {
                                    file.Position = listEntidades[i].direccion + 48;
                                    binaryWriter.Write(listAtributos[j].dirSiguiente);
                                }
                            }
                            else
                            {
                                
                                if (listAtributos[j].dirSiguiente == -1)
                                {
                                    file.Position = listAtributos[j - 1].direccion + 65;
                                    binaryWriter.Write((long)-1);
                                }
                                else
                                {
                                    file.Position = listAtributos[j - 1].direccion + 65;
                                    binaryWriter.Write(listAtributos[j].dirSiguiente);
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
