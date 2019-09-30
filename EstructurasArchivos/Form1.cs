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
        FileStream dataFile;
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
                textCab.Text = cab_aux.ToString();
                if (file.Length > 8)
                {
                    guardarDatos();
                }
            }



        }
        private void CloseFile_Click(object sender, EventArgs e)
        {
            file.Close();
        }

        private void guardarDatos()
        {
            listEntidades.Clear();
            BinaryReader binaryReader = new BinaryReader(file);
            file.Seek(0, SeekOrigin.Begin);
            long cab = binaryReader.ReadInt64();
            textCab.Text = cab.ToString();
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

                    string id = BitConverter.ToString(binaryReader.ReadBytes(5));
                    string nombre = binaryReader.ReadString();
                    long direccion = binaryReader.ReadInt64();
                    long direccion_atributos = binaryReader.ReadInt64();
                    long dir_data = binaryReader.ReadInt64();
                    direccion_sig = binaryReader.ReadInt64();


                    Entidad e = new Entidad(id, nombre, direccion, direccion_atributos, dir_data, direccion_sig);
                    listEntidades.Add(e);



                    if (direccion_sig != -1)
                    {
                        file.Position = direccion_sig;
                    }

                } while (direccion_sig != -1);

                selectEntidad.Items.Clear();
                cargarEntidades.Items.Clear();
                elimEntidadAtributo.Items.Clear();
                elimEntidad.Items.Clear();
                editarEntidad.Items.Clear();
                editarEntAtri.Items.Clear();
                entidadInsertarEntidad.Items.Clear();

                for (int i = 0; i < listEntidades.Count; i++)
                {
                    selectEntidad.Items.Add(listEntidades[i].nombre);
                    cargarEntidades.Items.Add(listEntidades[i].nombre);
                    elimEntidadAtributo.Items.Add(listEntidades[i].nombre);
                    elimEntidad.Items.Add(listEntidades[i].nombre);
                    editarEntidad.Items.Add(listEntidades[i].nombre);
                    editarEntAtri.Items.Add(listEntidades[i].nombre);
                    entidadInsertarEntidad.Items.Add(listEntidades[i].nombre);
                }


                entidades.Rows.Clear();
                atributos.Rows.Clear();
                guardarAtributos(cargarEntidades.Text);


                for (int j = 0; j < listEntidades.Count; j++)
                {
                    string[] entidad = new string[6];
                    entidad[0] = 
                        
                        listEntidades[j].id;
                    entidad[1] = listEntidades[j].nombre;
                    entidad[2] = listEntidades[j].direccion.ToString();
                    entidad[3] = listEntidades[j].direccion_atributos.ToString();
                    entidad[4] = listEntidades[j].dir_data.ToString();
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
                            //string id = Encoding.ASCII.GetString();
                            string id = BitConverter.ToString(binaryReader.ReadBytes(5));
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
        private void AgregarAtributo_Click(object sender, EventArgs e)
        {
            listAtributos.Clear();
            BinaryWriter binaryWriter = new BinaryWriter(file);
            BinaryReader binaryReader = new BinaryReader(file);
            file.Position = file.Length;

            //char[] id_entidad = new char[5];

            string nombre = nombreAtributo.Text.PadRight(34);


            char tipo = char.Parse(tipoAtributo.Text);
            int longitud = Int32.Parse(longitudAtributo.Text);
            long direccion_atributo = file.Length;
            int tipo_indice = tipoIndiceAtributo.Items.IndexOf(tipoIndiceAtributo.Text);
            //int tipo_indice = Int32.Parse(tipoIndiceAtributo.SelectedItem.ToString());
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
            guardarDatos();

            MessageBox.Show("Atributo Agregada");
            nombreAtributo.Clear();
            tipoAtributo.SelectedItem = null;
            tipoIndiceAtributo.SelectedItem = null;
            longitudAtributo.Clear();
        }

        public byte[] generarId()
        {
            byte[] buffer = new byte[5];
            new Random().NextBytes(buffer);
            return buffer;
        }
        private void CargarDatos_Click(object sender, EventArgs e)
        {
            guardarDatos();
            guardarAtributos(cargarEntidades.Text);
        }

        private void EntidadEditar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Modificacion");
            string nombre_nuevo = nombreEntidadNuevo.Text;
            int indice_modificar = editarEntidad.Items.IndexOf(editarEntidad.Text);
            BinaryWriter binaryWriter = new BinaryWriter(file);
            BinaryReader binaryReader = new BinaryReader(file);
            file.Position = 0;
            long cab = binaryReader.ReadInt64();

            if (listEntidades[indice_modificar].nombre != nombre_nuevo)
            {
                if (listEntidades[indice_modificar].direccion == cab)
                {
                    if (listEntidades[indice_modificar].direccion_sig != -1)
                    {
                        file.Position = 0;
                        binaryWriter.Write(listEntidades[indice_modificar].direccion_sig);
                    }
                    else
                    {
                        /*file.Position = 0;
                        binaryWriter.Write((long)-1);*/
                    }
                }
                else
                {
                    if (listEntidades[indice_modificar].direccion_sig != -1)
                    {
                        for (int i = 0; i < listEntidades.Count; i++)
                        {
                            if (listEntidades[i].direccion_sig == listEntidades[indice_modificar].direccion)
                            {
                                file.Position = listEntidades[i].direccion + 64;
                                binaryWriter.Write(listEntidades[indice_modificar].direccion_sig);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listEntidades.Count; i++)
                        {
                            if (listEntidades[i].direccion_sig == listEntidades[indice_modificar].direccion)
                            {
                                file.Position = listEntidades[i].direccion + 64;
                                binaryWriter.Write((long)-1);
                            }
                        }
                    }
                }

                long apunta;


                long aux_dir_anterior;

                aux_dir_anterior = cab;

                file.Position = cab + 5;
                string aux = binaryReader.ReadString(); //Recupera el nombre de la primera entidad a partir de la cabecera

                if (string.Compare(nombre_nuevo, aux) == -1)  
                {
                    file.Position = 0;
                    long modifucarCab = listEntidades[indice_modificar].direccion;
                    binaryWriter.Write(modifucarCab);
                    file.Position = listEntidades[indice_modificar].direccion + 64;    //Esta parte del codigo funciona cuando es insertar en la primera pocision
                    binaryWriter.Write(aux_dir_anterior);
                }
                else
                {
                    do
                    {
                        file.Position = aux_dir_anterior + 64;
                        apunta = binaryReader.ReadInt64();
                        if (apunta == (long)-1)
                        {
                            file.Position = aux_dir_anterior + 64;
                            long nuevo_siguiente = binaryReader.ReadInt64();
                            file.Position = aux_dir_anterior + 64;
                            binaryWriter.Write(listEntidades[indice_modificar].direccion);   //Este es el caso en el que va despues del utlimo ya funciona
                            file.Position = listEntidades[indice_modificar].direccion + 64;
                            binaryWriter.Write(nuevo_siguiente);
                            break;
                        }
                        else
                        {
                            file.Position = apunta + 5;
                            aux = binaryReader.ReadString();
                            if (string.Compare(nombre_nuevo, aux) == -1)
                            {
                                file.Position = aux_dir_anterior + 64;
                                binaryWriter.Write(listEntidades[indice_modificar].direccion);

                                file.Position = listEntidades[indice_modificar].direccion + 64;
                                binaryWriter.Write(apunta);
                                break;
                            }
                        }
                        file.Position = aux_dir_anterior + 64;                        
                        aux_dir_anterior = binaryReader.ReadInt64();

                    } while (apunta != (long)-1);
                }
                string nombre = nombre_nuevo.PadRight(34);
                file.Position = listEntidades[indice_modificar].direccion + 5;
                binaryWriter.Write(nombre);

                guardarDatos();
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
        private void EliminaCargarEntidades_Click(object sender, EventArgs e)
        {
            eliminarAtributo.Items.Clear();
            guardarAtributos(elimEntidadAtributo.Text);
            for (int i = 0; i < listAtributos.Count; i++)
            {
                eliminarAtributo.Items.Add(listAtributos[i].nombre);
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
                            file.Position = file.Position + 8;
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
            guardarDatos();
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
            guardarDatos();
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
            guardarDatos();
        }

        private void InsertarRegistroBoton_Click(object sender, EventArgs e)
        {
            if (entidadInsertarEntidad.Text != "")
            {
                int id = entidadInsertarEntidad.Items.IndexOf(entidadInsertarEntidad.Text);
                guardarAtributos(entidadInsertarEntidad.Text);

                for (int i = 0; i < listAtributos.Count; i++)
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.Name = listAtributos[i].nombre;
                    tablaInsertarRegistro.Columns.Add(column);
                }

            }
        }

        private void GuardarRegistroBoton_Click(object sender, EventArgs e)
        {
            int contIndices=0;
            int cve_busqueda=0;
            int clave_entidad = entidadInsertarEntidad.Items.IndexOf(entidadInsertarEntidad.Text);
            for (int i = 0; i < listAtributos.Count; i++)
            {
                if (listAtributos[i].tipoId == 2)
                {
                    contIndices++;
                }
                if (listAtributos[i].tipoId == 1)
                {
                    cve_busqueda++;
                }
            }

            if (contIndices == 1)
            {
                if (cve_busqueda == 1)
                {

                }
                else
                {

                }
            }
            else
            {
                if (cve_busqueda == 1)
                {

                }
                else
                {
                    if (listEntidades[clave_entidad].dir_data == -1)
                    {
                        string nombre_archivo = listEntidades[clave_entidad].id + ".dat";
                        dataFile = new FileStream(nombre_archivo, FileMode.Create);
                        dataFile.Close();
                        dataFile = new FileStream(nombre_archivo, FileMode.Open, FileAccess.ReadWrite);
                        BinaryWriter binaryWriter = new BinaryWriter(file);
                        BinaryWriter dbw = new BinaryWriter(dataFile);
                        file.Position = listEntidades[clave_entidad].direccion + 56;
                        binaryWriter.Write((long)0);

                        dataFile.Position = 0;
                        dbw.Write((long)0);
                        for (int i = 0; i < tablaInsertarRegistro.SelectedCells.Count; i++)
                        {
                            if (listAtributos[i].tipo == 'E')
                            {
                                int dataInsertar = Convert.ToInt32(tablaInsertarRegistro.SelectedCells[i].Value); 
                                dbw.Write(dataInsertar);
                            }
                            else if (listAtributos[i].tipo == 'C')
                            {
                                string dataInsertar = (string)tablaInsertarRegistro.SelectedCells[i].Value;
                                dataInsertar = dataInsertar.PadRight(listAtributos[i].longitud);
                                dbw.Write(dataInsertar);
                            }
                        }
                        dbw.Write((long)(file.Length + 8));
                        dataFile.Close();
                    }
                    else
                    {
                        string nombre_archivo = listEntidades[clave_entidad].id + ".dat";
                        dataFile = new FileStream(nombre_archivo, FileMode.Open, FileAccess.ReadWrite);
                    }
                }
            }

            /*for (int i = 0; i < tablaInsertarRegistro.SelectedCells.Count; i++)
            {
                var a = tablaInsertarRegistro.SelectedCells[i].Value;
            }*/
            
        }
    }
}
