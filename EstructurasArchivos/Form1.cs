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
        FileStream indexFile;
        FileStream indexSecundarioFile;
        FileStream archivoArbol;

        long modificar = -1;

        public const int TAMANIO_BLOQUE = 2048;

        public const int NREGISTROS_SENCILLOS = (TAMANIO_BLOQUE - 8) / 8;

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
            tablaInsertarRegistro.Rows.Clear();
            tablaInsertarRegistro.Columns.Clear();


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
            Atributo atributoArbolPrimario = null;
            Atributo atributoArbolSecundario = null;
            MessageBox.Show("Insertado");
            int num_atributo_ordenar = 0;
            int num_indice = 0;
            int num_indice_secundario = 0;
            int num_arbol_primario = 0;
            int num_arbol_secundario = 0;
            int ordenar_por = 0;
            string idAtributo = "";
            string idAtributoSecundario = "";
            string idAtributoArbolPrimario = "";
            string idAtributoArbolSecundario = "";
            string nombre_ordenado = "";
            int contIndices = 0;
            int contIndicesSecundario = 0;
            int contArbolPrimario = 0;
            int contArbolSecundario = 0;
            int cve_busqueda = 0;
            int tam_registro = 0;
            int tam_registro_secundario = 0;
            int tipo_registro = 0;
            int tipo_registro_secundario = 0;
            bool existe = false;
            long dir = 0;
            int clave_entidad = entidadInsertarEntidad.Items.IndexOf(entidadInsertarEntidad.Text);

            guardarAtributos(entidadInsertarEntidad.Text);

            BinaryWriter idw = null;
            BinaryReader idr = null;

            BinaryWriter isdw = null;
            BinaryReader isdr = null;


            for (int i = 0; i < listAtributos.Count; i++)
            {
                if (listAtributos[i].tipoId == 1)
                {
                    if (listAtributos[i].tipo == 'E')
                    {
                        ordenar_por = 0;
                    }
                    else if (listAtributos[i].tipo == 'C')
                    {
                        ordenar_por = 1;
                    }
                    num_atributo_ordenar = i;
                    cve_busqueda++;
                }
                else if (listAtributos[i].tipoId == 2)
                {
                    idAtributo = listAtributos[i].id;
                    num_indice = i;
                    contIndices++;
                }
                else if (listAtributos[i].tipoId == 3)
                {
                    idAtributoSecundario = listAtributos[i].id;
                    num_indice_secundario = i;
                    contIndicesSecundario++;
                }
                else if (listAtributos[i].tipoId == 4)
                {
                    atributoArbolPrimario = listAtributos[i];
                    idAtributoArbolPrimario = listAtributos[i].id;
                    num_arbol_primario = i;
                    contArbolPrimario++;
                }
                else if (listAtributos[i].tipoId == 5)
                {
                    atributoArbolSecundario = listAtributos[i];
                    idAtributoArbolSecundario = listAtributos[i].id;
                    num_arbol_secundario = i;
                    contArbolSecundario++;
                }
            }


            

                
            if (listEntidades[clave_entidad].dir_data == -1)//Caso insertar primer registro sin claves 
            {
                string nombre_archivo = listEntidades[clave_entidad].id + ".dat";
                try
                {
                    dataFile = new FileStream(nombre_archivo, FileMode.Create);
                }
                catch (Exception)
                {

                    dataFile.Close();
                    dataFile = new FileStream(nombre_archivo, FileMode.Create);

                }

                dataFile.Close();
                dataFile = new FileStream(nombre_archivo, FileMode.Open, FileAccess.ReadWrite);

                if (contIndices == 1)
                {
                    string nomArchivoIndex = idAtributo + ".idx";
                    indexFile = new FileStream(nomArchivoIndex, FileMode.Create);
                    indexFile.Close();
                    indexFile = new FileStream(nomArchivoIndex, FileMode.Open, FileAccess.ReadWrite);
                    idw = new BinaryWriter(indexFile);
                    idr = new BinaryReader(indexFile);
                }

                if (contIndicesSecundario == 1)
                {
                    //CAMBIOS QUE NO CHEQUE SI FUNCIONAN
                    string nomArchivoIndex = idAtributoSecundario + ".idx";
                    try
                    {
                        indexSecundarioFile = new FileStream(nomArchivoIndex, FileMode.Create);
                    }
                    catch (Exception)
                    {

                    }
                    indexSecundarioFile.Close();
                    indexSecundarioFile = new FileStream(nomArchivoIndex, FileMode.Open, FileAccess.ReadWrite);
                    isdw = new BinaryWriter(indexSecundarioFile);
                    isdr = new BinaryReader(indexSecundarioFile);
                }

                if (contArbolPrimario == 1)
                {
                    if (!CondicionesIndPrimarioArbol(atributoArbolPrimario, Convert.ToInt32(tablaInsertarRegistro.SelectedCells[num_arbol_primario].Value)))
                    {
                        return;
                    }
                    AccionesArbolPrimario(atributoArbolPrimario, Convert.ToInt32(tablaInsertarRegistro.SelectedCells[num_arbol_primario].Value), dataFile.Length);
                }

                if (contArbolSecundario == 1)
                {
                    Atributo atributo_secu_arbol = listAtributos[num_arbol_secundario];
                    AccionesArbolSecundario(atributoArbolSecundario, Convert.ToInt32(tablaInsertarRegistro.SelectedCells[num_arbol_secundario].Value), num_arbol_secundario);
                }


                BinaryWriter binaryWriter = new BinaryWriter(file);
                BinaryWriter dbw = new BinaryWriter(dataFile);

                BinaryReader binaryReader = new BinaryReader(file);
                BinaryReader dbr = new BinaryReader(dataFile);

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
                        if (contIndices == 1 && listAtributos[i].tipoId == 2)
                        {
                            file.Position = listAtributos[i].direccion + 57;
                            binaryWriter.Write((long)0);
                            int registrosIndice = 2040 / 12;
                            for (int j = 0; j < registrosIndice; j++)
                            {
                                idw.Write((int)0);
                                idw.Write((long)-1);
                            }
                            idw.Write((long)-1);
                            indexFile.Position = 0;
                            idw.Write(dataInsertar);
                            idw.Write((long)0);
                        }

                        if (contIndicesSecundario == 1 && listAtributos[i].tipoId == 3)
                        {
                            file.Position = listAtributos[i].direccion + 57;
                            binaryWriter.Write((long)0);
                            int registrosIndice = 2040 / 12;
                            for (int j = 0; j < registrosIndice; j++)
                            {
                                isdw.Write((int)0);
                                isdw.Write((long)-1);
                            }
                            isdw.Write((long)-1);
                            indexSecundarioFile.Position = 0;
                            isdw.Write(dataInsertar);
                            isdw.Write((long)2048);
                            int bloquesPequeños = 2040 / 8;
                            indexSecundarioFile.Position = 2048;
                            for (int j = 0; j < bloquesPequeños; j++)
                            {
                                isdw.Write((long)-1);
                            }
                            isdw.Write((long)-1);
                            indexSecundarioFile.Position = 2048;
                            isdw.Write((long)0);
                        }
                    }
                    else if (listAtributos[i].tipo == 'C')
                    {
                        string dataInsertar = (string)tablaInsertarRegistro.SelectedCells[i].Value;
                        dataInsertar = dataInsertar.PadRight(listAtributos[i].longitud - 1);
                        dbw.Write(dataInsertar);
                        if (contIndices == 1 && listAtributos[i].tipoId == 2)
                        {
                            file.Position = listAtributos[i].direccion + 57;
                            binaryWriter.Write((long)0);
                            int registrosIndice = 2040 / listAtributos[i].longitud;
                            for (int j = 0; j < registrosIndice; j++)
                            {
                                idw.Write(dataInsertar);
                                idw.Write((long)-1);
                            }
                            idw.Write((long)-1);

                            indexFile.Position = 0;
                            idw.Write(dataInsertar);
                            idw.Write((long)0);
                        }

                        if (contIndicesSecundario == 1 && listAtributos[i].tipoId == 3)
                        {
                            file.Position = listAtributos[i].direccion + 57;
                            binaryWriter.Write((long)0);
                            int registrosIndice = 2040 / listAtributos[i].longitud;
                            for (int j = 0; j < registrosIndice; j++)
                            {
                                isdw.Write(dataInsertar);
                                isdw.Write((long)-1);
                            }
                            isdw.Write((long)-1);
                            indexSecundarioFile.Position = 0;
                            isdw.Write(dataInsertar);
                            isdw.Write((long)2048);
                            int bloquesPequeños = 2040 / 8;
                            indexSecundarioFile.Position = 2048;
                            for (int j = 0; j < bloquesPequeños; j++)
                            {
                                isdw.Write((long)-1);
                            }
                            isdw.Write((long)-1);
                            indexSecundarioFile.Position = 2048;
                            isdw.Write((long)0);
                        }
                    }
                }
                dbw.Write((long)-1);
                dataFile.Close();
                if (contIndices == 1)
                {
                    indexFile.Close();
                }
                if (contIndicesSecundario == 1)
                {
                    indexSecundarioFile.Close();
                }
            }
            else
            {
                string nombre_archivo = listEntidades[clave_entidad].id + ".dat";
                try
                {
                    dataFile = new FileStream(nombre_archivo, FileMode.Open, FileAccess.ReadWrite);

                }
                catch (Exception)
                {
                    dataFile.Close();
                    dataFile = new FileStream(nombre_archivo, FileMode.Open, FileAccess.ReadWrite);
                }
                BinaryWriter binaryWriter = new BinaryWriter(file);
                BinaryReader binaryReader = new BinaryReader(file);
                BinaryReader dbr = new BinaryReader(dataFile);
                BinaryWriter dbw = new BinaryWriter(dataFile);

                if (contArbolPrimario == 1)
                {
                    if (!CondicionesIndPrimarioArbol(atributoArbolPrimario, Convert.ToInt32(tablaInsertarRegistro.SelectedCells[num_arbol_primario].Value)))
                    {
                        return;
                    }
                    AccionesArbolPrimario(atributoArbolPrimario, Convert.ToInt32(tablaInsertarRegistro.SelectedCells[num_arbol_primario].Value), dataFile.Length);
                }

                if (contArbolSecundario == 1)
                {
                    Atributo atributo_secu_arbol = listAtributos[num_arbol_secundario];
                    AccionesArbolSecundario(atributoArbolSecundario, Convert.ToInt32(tablaInsertarRegistro.SelectedCells[num_arbol_secundario].Value), num_arbol_secundario);
                }

                if (contIndices == 1)
                {
                    string nomArchivoIndex = idAtributo + ".idx";
                    indexFile = new FileStream(nomArchivoIndex, FileMode.Open, FileAccess.ReadWrite);
                    idw = new BinaryWriter(indexFile);
                    idr = new BinaryReader(indexFile);


                    for (int i = 0; i < tablaInsertarRegistro.SelectedCells.Count; i++)
                    {
                        if (listAtributos[i].tipoId == 2)
                        {
                            if (listAtributos[i].tipo == 'E')
                            {
                                tipo_registro = 0;
                                tam_registro += 4;
                            }
                            else if (listAtributos[i].tipo == 'C')
                            {
                                tipo_registro = 1;
                                tam_registro += listAtributos[i].longitud;
                            }
                        }
                    }

                    if (contArbolPrimario == 1)
                    {
                        if (!CondicionesIndPrimarioArbol(atributoArbolPrimario, Convert.ToInt32(tablaInsertarRegistro.SelectedCells[num_arbol_primario].Value)))
                        {
                            return;
                        }
                        AccionesArbolPrimario(atributoArbolPrimario, Convert.ToInt32(tablaInsertarRegistro.SelectedCells[num_arbol_primario].Value), dataFile.Length);
                    }

                    indexFile.Position = 0;
                    while (dir != -1)
                    {
                        if (tipo_registro == 0)
                        {
                            int nuevo_int = Convert.ToInt32(tablaInsertarRegistro.SelectedCells[num_indice].Value);
                            int datoInt = idr.ReadInt32();
                            dir = idr.ReadInt64();
                            if (datoInt == nuevo_int)
                            {
                                existe = true;
                                MessageBox.Show("No puedes utilizar 2 veces el mismo indice");
                            }
                        }
                        else
                        {
                            string nuevo_string = tablaInsertarRegistro.SelectedCells[num_indice].Value.ToString();
                            string datoString = idr.ReadString();
                            dir = idr.ReadInt64();
                            if (datoString == nuevo_string)
                            {
                                existe = true;
                                MessageBox.Show("No puedes utilizar 2 veces el mismo indice");
                            }
                        }
                    }
                }

                if (contIndicesSecundario == 1)
                {
                    bool existe_secundario = false;
                    string nomArchivoIndex = idAtributoSecundario + ".idx";
                    try
                    {
                        indexSecundarioFile = new FileStream(nomArchivoIndex, FileMode.Open, FileAccess.ReadWrite);
                    }
                    catch (Exception)
                    {
                        indexSecundarioFile.Close();
                        indexSecundarioFile = new FileStream(nomArchivoIndex, FileMode.Open, FileAccess.ReadWrite);
                    }

                    isdw = new BinaryWriter(indexSecundarioFile);
                    isdr = new BinaryReader(indexSecundarioFile);


                    for (int i = 0; i < tablaInsertarRegistro.SelectedCells.Count; i++)
                    {
                        if (listAtributos[i].tipoId == 3)
                        {
                            if (listAtributos[i].tipo == 'E')
                            {
                                tipo_registro_secundario = 0;
                                tam_registro_secundario += 4;
                            }
                            else if (listAtributos[i].tipo == 'C')
                            {
                                tipo_registro_secundario = 1;
                                tam_registro_secundario += listAtributos[i].longitud;
                            }
                        }
                    }

                    indexSecundarioFile.Position = 0;
                    if (tipo_registro_secundario == 0)
                    {
                        int nuevo_int = Int32.Parse(tablaInsertarRegistro.SelectedCells[num_indice_secundario].Value.ToString());
                        long dir_existe_guardar = 0;
                        long dir_actual_archivo = 0;
                        do
                        {

                            int actual_int = 0;

                            try
                            {
                                actual_int = isdr.ReadInt32();
                                dir_actual_archivo = isdr.ReadInt64();
                            }
                            catch (Exception)
                            {
                                break;
                            }

                            if (actual_int == nuevo_int && dir_actual_archivo != -1)
                            {
                                existe_secundario = true;
                                dir_existe_guardar = dir_actual_archivo;
                                break;
                            }

                        } while (dir_actual_archivo != (long)-1);



                        if (existe_secundario)
                        {
                            indexSecundarioFile.Position = dir_existe_guardar;
                            do
                            {
                                long actual = isdr.ReadInt64();
                                if (actual == -1)
                                {
                                    indexSecundarioFile.Position = indexSecundarioFile.Position - 8;
                                    isdw.Write(dataFile.Length);
                                    break;
                                }
                            } while (true);
                        }
                        else
                        {
                            dir_actual_archivo = 0;
                            long guarda_ultimo_bloque = 0;
                            indexSecundarioFile.Position = 0;
                            long dir_escribir = 0;
                            do
                            {
                                int actual_archivo = isdr.ReadInt32();
                                dir_actual_archivo = isdr.ReadInt64();

                                if (dir_actual_archivo != -1)
                                {
                                    guarda_ultimo_bloque = dir_actual_archivo;
                                }

                                if (dir_actual_archivo == -1)
                                {
                                    indexSecundarioFile.Position = dir_escribir;
                                    isdw.Write(nuevo_int);
                                    long nuevo_bloque = guarda_ultimo_bloque + 2048;
                                    isdw.Write(nuevo_bloque);
                                    indexSecundarioFile.Position = nuevo_bloque;
                                    int bloquesPequeños = 2040 / 8;
                                    for (int j = 0; j < bloquesPequeños; j++)
                                    {
                                        isdw.Write((long)-1);
                                    }
                                    isdw.Write((long)-1);
                                    indexSecundarioFile.Position = nuevo_bloque;
                                    isdw.Write(dataFile.Length);
                                }
                                dir_escribir = indexSecundarioFile.Position;
                            } while (dir_actual_archivo != (long)-1);
                        }
                    }
                    else
                    {
                        string nuevo_string = tablaInsertarRegistro.SelectedCells[num_indice_secundario].Value.ToString();
                        nuevo_string = nuevo_string.PadRight(listAtributos[num_indice_secundario].longitud - 1);
                        long dir_existe_guardar = 0;
                        long dir_actual_archivo = 0;
                        do
                        {

                            string actual_archivo = "";

                            try
                            {
                                actual_archivo = isdr.ReadString();
                                dir_actual_archivo = isdr.ReadInt64();
                            }
                            catch (Exception)
                            {
                                break;
                            }

                            if (actual_archivo.Contains(nuevo_string) && dir_actual_archivo != -1)
                            {
                                existe_secundario = true;
                                dir_existe_guardar = dir_actual_archivo;
                                break;
                            }

                        } while (dir_actual_archivo != (long)-1);



                        if (existe_secundario)
                        {
                            indexSecundarioFile.Position = dir_existe_guardar;
                            do
                            {
                                long actual = isdr.ReadInt64();
                                if (actual == -1)
                                {
                                    indexSecundarioFile.Position = indexSecundarioFile.Position - 8;
                                    isdw.Write(dataFile.Length);
                                    break;
                                }
                            } while (true);
                        }
                        else
                        {
                            dir_actual_archivo = 0;
                            long guarda_ultimo_bloque = 0;
                            indexSecundarioFile.Position = 0;
                            long dir_escribir = 0;
                            do
                            {
                                string actual_archivo = isdr.ReadString();
                                dir_actual_archivo = isdr.ReadInt64();

                                if (dir_actual_archivo != -1)
                                {
                                    guarda_ultimo_bloque = dir_actual_archivo;
                                }

                                if (dir_actual_archivo == -1)
                                {
                                    indexSecundarioFile.Position = dir_escribir;
                                    isdw.Write(nuevo_string);
                                    long nuevo_bloque = guarda_ultimo_bloque + 2048;
                                    isdw.Write(nuevo_bloque);
                                    indexSecundarioFile.Position = nuevo_bloque;
                                    int bloquesPequeños = 2040 / 8;
                                    for (int j = 0; j < bloquesPequeños; j++)
                                    {
                                        isdw.Write((long)-1);
                                    }
                                    isdw.Write((long)-1);
                                    indexSecundarioFile.Position = nuevo_bloque;
                                    MessageBox.Show(dataFile.Length.ToString());
                                    isdw.Write(dataFile.Length);
                                }
                                dir_escribir = indexSecundarioFile.Position;
                            } while (dir_actual_archivo != (long)-1);
                        }

                    }

                }

                if (cve_busqueda != 1)
                {
                    dataFile.Position = dataFile.Length - 8;
                    long dir_final = dbr.ReadInt64();
                    if (dir_final == -1)
                    {
                        dataFile.Position = dataFile.Length - 8;
                        dbw.Write(dataFile.Length);
                    }
                    else
                    {
                        long dir_guardar = 0;
                        do
                        {
                            dir_guardar = dir_final + tam_registro - 8;
                            dataFile.Position = dir_guardar;
                            dir_final = dbr.ReadInt64();

                        } while (dir_final == -1);
                        dataFile.Position = dir_guardar;
                        dbw.Write(dataFile.Length);
                    }

                }


                if (!existe)
                {
                    if (contIndices == 1)
                    {
                        while (true)
                        {
                            if (tipo_registro == 0)
                            {
                                int nuevo_int = Convert.ToInt32(tablaInsertarRegistro.SelectedCells[num_indice].Value);
                                indexFile.Position = indexFile.Position - 8 - 4;
                                idw.Write(nuevo_int);
                                idw.Write(dataFile.Length);
                                break;
                            }
                            else
                            {
                                string nuevo_string = tablaInsertarRegistro.SelectedCells[num_indice].Value.ToString();
                                indexFile.Position = indexFile.Position - 8 - tam_registro;
                                nuevo_string = nuevo_string.PadRight(tam_registro - 1);
                                idw.Write(nuevo_string);
                                idw.Write(dataFile.Length);
                                break;
                            }
                        }
                    }

                    dataFile.Position = dataFile.Length;
                    dbw.Write(dataFile.Length);
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
                            dataInsertar = dataInsertar.PadRight(listAtributos[i].longitud - 1);
                            dbw.Write(dataInsertar);
                        }
                    }
                    dbw.Write((long)-1);
                    //dataFile.Close();

                    if (cve_busqueda == 1)
                    {
                        for (int i = 0; i < listAtributos.Count; i++)
                        {
                            if (listAtributos[i].tipoId == 1)
                            {
                                if (listAtributos[i].tipo == 'E')
                                {
                                    ordenar_por = 0;
                                }
                                else if (listAtributos[i].tipo == 'C')
                                {
                                    ordenar_por = 1;
                                }
                                nombre_ordenado = listAtributos[i].nombre;
                                num_atributo_ordenar = i;
                            }
                        }

                        if (ordenar_por == 0) //Ordenar por enteros 
                        {
                            MessageBox.Show("Ordenado por enteros");
                            int nuevo_int = Convert.ToInt32(tablaInsertarRegistro.SelectedCells[num_atributo_ordenar].Value);
                            file.Position = listEntidades[clave_entidad].direccion + 56;
                            long cab = binaryReader.ReadInt64();
                            long apunta;
                            long aux_dir_anterior;

                            aux_dir_anterior = cab;

                            int tamaño_registro = CalculaTamRegistro;
                            int buscar_en = PosicionDeLaBusqueda;
                            dataFile.Position = aux_dir_anterior + buscar_en;
                            int int_anterior = dbr.ReadInt32();


                            if (nuevo_int < int_anterior)
                            {
                                MessageBox.Show("Entro uno nuevo a ordenar por encima");
                                file.Position = listEntidades[clave_entidad].direccion + 56;
                                binaryWriter.Write(dataFile.Length - tamaño_registro);
                                dataFile.Position = dataFile.Length - 8;
                                dbw.Write(aux_dir_anterior);
                            }
                            else
                            {
                                do
                                {
                                    dataFile.Position = aux_dir_anterior + (tamaño_registro - 8);
                                    apunta = dbr.ReadInt64();

                                    dataFile.Position = apunta + buscar_en;
                                    int_anterior = dbr.ReadInt32();

                                    if (apunta == (long)-1)
                                    {
                                        dataFile.Position = aux_dir_anterior + (tamaño_registro - 8);
                                        dbw.Write(dataFile.Length - tamaño_registro);
                                        break;
                                    }
                                    else
                                    {
                                        dataFile.Position = apunta + buscar_en;
                                        int_anterior = dbr.ReadInt32();

                                        if (nuevo_int < int_anterior)
                                        {
                                            dataFile.Position = aux_dir_anterior + tamaño_registro - 8;
                                            dbw.Write(dataFile.Length - tamaño_registro);

                                            dataFile.Position = dataFile.Length - 8;
                                            dbw.Write(apunta);
                                            break;
                                        }
                                        else
                                        {
                                            aux_dir_anterior = apunta;
                                        }
                                    }
                                } while (true);
                            }


                        }
                        else //Ordenar por cadenas
                        {
                            MessageBox.Show("Ordenado por Cadena");
                            string nuevo_string = tablaInsertarRegistro.SelectedCells[num_atributo_ordenar].Value.ToString();
                            file.Position = listEntidades[clave_entidad].direccion + 56;
                            long cab = binaryReader.ReadInt64();
                            long apunta;
                            long aux_dir_anterior;

                            aux_dir_anterior = cab;

                            int tamaño_registro = CalculaTamRegistro;
                            int buscar_en = PosicionDeLaBusqueda;
                            dataFile.Position = aux_dir_anterior + buscar_en;
                            string string_anterior = dbr.ReadString();


                            if (string.Compare(nuevo_string, string_anterior) == -1)
                            {
                                file.Position = listEntidades[clave_entidad].direccion + 56;
                                binaryWriter.Write(dataFile.Length - tamaño_registro);
                                dataFile.Position = dataFile.Length - 8;
                                dbw.Write(aux_dir_anterior);
                            }
                            else
                            {
                                do
                                {
                                    dataFile.Position = aux_dir_anterior + (tamaño_registro - 8);
                                    apunta = dbr.ReadInt64();

                                    dataFile.Position = apunta + buscar_en;
                                    string_anterior = dbr.ReadString();

                                    if (apunta == (long)-1)
                                    {
                                        dataFile.Position = aux_dir_anterior + (tamaño_registro - 8);
                                        dbw.Write(dataFile.Length - tamaño_registro);
                                        break;
                                    }
                                    else
                                    {
                                        dataFile.Position = apunta + buscar_en;
                                        string_anterior = dbr.ReadString();

                                        if (string.Compare(nuevo_string, string_anterior) == -1)
                                        {
                                            dataFile.Position = aux_dir_anterior + tamaño_registro - 8;
                                            dbw.Write(dataFile.Length - tamaño_registro);

                                            dataFile.Position = dataFile.Length - 8;
                                            dbw.Write(apunta);
                                            break;
                                        }
                                        else
                                        {
                                            aux_dir_anterior = apunta;
                                        }
                                    }
                                } while (true);
                            }
                        }
                    }

                    


                    dataFile.Close();
                    if (contIndices == 1)
                    {
                        indexFile.Close();
                    }
                    if (contIndicesSecundario == 1)
                    {
                        indexSecundarioFile.Close();
                    }
                }
            }
            guardarDatos();
            entidadInsertarEntidad.SelectedItem = null;
        }

        public void actualizaRegistro()
        {
            Atributo atributoArbolPrimario = null;
            Atributo atributoArbolSecundario = null;
            int num_atributo_ordenar = 0;
            int num_indice = 0;
            int num_indice_secundario = 0;
            int ordenar_por = 0;
            string idAtributo = "";
            string idAtributoSecundario = "";
            string nombre_ordenado = "";
            int contIndices = 0;
            int contIndicesSecundario = 0;
            int cve_busqueda = 0;
            int tam_registro = 0;
            int tam_registro_secundario = 0;
            int tipo_registro = 0;
            int tipo_registro_secundario = 0;
            bool existe = false;
            long dir = 0;
            int num_arbol_primario = 0;
            int num_arbol_secundario = 0;
            string idAtributoArbolPrimario = "";
            string idAtributoArbolSecundario = "";
            int contArbolPrimario = 0;
            int contArbolSecundario = 0;

            int clave_entidad = entidadInsertarEntidad.Items.IndexOf(entidadInsertarEntidad.Text);
            guardarAtributos(entidadInsertarEntidad.Text);

            BinaryWriter idw = null;
            BinaryReader idr = null;

            BinaryWriter isdw = null;
            BinaryReader isdr = null;


            for (int i = 0; i < listAtributos.Count; i++)
            {
                if (listAtributos[i].tipoId == 1)
                {
                    if (listAtributos[i].tipo == 'E')
                    {
                        ordenar_por = 0;
                    }
                    else if (listAtributos[i].tipo == 'C')
                    {
                        ordenar_por = 1;
                    }
                    num_atributo_ordenar = i;
                    cve_busqueda++;
                }
                else if (listAtributos[i].tipoId == 2)
                {
                    idAtributo = listAtributos[i].id;
                    num_indice = i;
                    contIndices++;
                }
                else if (listAtributos[i].tipoId == 3)
                {
                    idAtributoSecundario = listAtributos[i].id;
                    num_indice_secundario = i;
                    contIndicesSecundario++;
                }
                else if (listAtributos[i].tipoId == 4)
                {
                    atributoArbolPrimario = listAtributos[i];
                    idAtributoArbolPrimario = listAtributos[i].id;
                    num_arbol_primario = i;
                    contArbolPrimario++;
                }
                else if (listAtributos[i].tipoId == 5)
                {
                    atributoArbolSecundario = listAtributos[i];
                    idAtributoArbolSecundario = listAtributos[i].id;
                    num_arbol_secundario = i;
                    contArbolSecundario++;
                }
            }


            if (listEntidades[clave_entidad].dir_data == -1)//Caso insertar primer registro sin claves 
            {
                string nombre_archivo = listEntidades[clave_entidad].id + ".dat";
                try
                {
                    dataFile = new FileStream(nombre_archivo, FileMode.Create);
                }
                catch (Exception)
                {

                    dataFile.Close();
                    dataFile = new FileStream(nombre_archivo, FileMode.Create);

                }

                dataFile.Close();
                dataFile = new FileStream(nombre_archivo, FileMode.Open, FileAccess.ReadWrite);

                if (contIndices == 1)
                {
                    string nomArchivoIndex = idAtributo + ".idx";
                    indexFile = new FileStream(nomArchivoIndex, FileMode.Create);
                    indexFile.Close();
                    indexFile = new FileStream(nomArchivoIndex, FileMode.Open, FileAccess.ReadWrite);
                    idw = new BinaryWriter(indexFile);
                    idr = new BinaryReader(indexFile);
                }

                if (contIndicesSecundario == 1)
                {
                    //CAMBIOS QUE NO CHEQUE SI FUNCIONAN
                    string nomArchivoIndex = idAtributoSecundario + ".idx";
                    try
                    {
                        indexSecundarioFile = new FileStream(nomArchivoIndex, FileMode.Create);
                    }
                    catch (Exception)
                    {


                    }
                    indexSecundarioFile.Close();
                    indexSecundarioFile = new FileStream(nomArchivoIndex, FileMode.Open, FileAccess.ReadWrite);
                    isdw = new BinaryWriter(indexSecundarioFile);
                    isdr = new BinaryReader(indexSecundarioFile);
                }

                if (contArbolPrimario == 1)
                {
                    if (!CondicionesIndPrimarioArbol(atributoArbolPrimario, Convert.ToInt32(editaRegistro.SelectedCells[num_arbol_primario].Value)))
                    {
                        return;
                    }
                    AccionesArbolPrimario(atributoArbolPrimario, Convert.ToInt32(editaRegistro.SelectedCells[num_arbol_primario].Value), modificar);
                }

                if (contArbolSecundario == 1)
                {
                    AccionesArbolSecundario(atributoArbolSecundario, Convert.ToInt32(editaRegistro.SelectedCells[num_arbol_secundario].Value), num_arbol_secundario);
                }


                BinaryWriter binaryWriter = new BinaryWriter(file);
                BinaryWriter dbw = new BinaryWriter(dataFile);

                BinaryReader binaryReader = new BinaryReader(file);
                BinaryReader dbr = new BinaryReader(dataFile);

                file.Position = listEntidades[clave_entidad].direccion + 56;
                binaryWriter.Write((long)0);

                dataFile.Position = 0;
                dbw.Write((long)0);


                for (int i = 0; i < editaRegistro.SelectedCells.Count; i++)
                {
                    if (listAtributos[i].tipo == 'E')
                    {
                        int dataInsertar = Convert.ToInt32(editaRegistro.SelectedCells[i].Value);
                        dbw.Write(dataInsertar);
                        if (contIndices == 1 && listAtributos[i].tipoId == 2)
                        {
                            file.Position = listAtributos[i].direccion + 57;
                            binaryWriter.Write((long)0);
                            int registrosIndice = 2040 / 12;
                            for (int j = 0; j < registrosIndice; j++)
                            {
                                idw.Write((int)0);
                                idw.Write((long)-1);
                            }
                            idw.Write((long)-1);
                            indexFile.Position = 0;
                            idw.Write(dataInsertar);
                            idw.Write((long)0);
                        }

                        if (contIndicesSecundario == 1 && listAtributos[i].tipoId == 3)
                        {
                            file.Position = listAtributos[i].direccion + 57;
                            binaryWriter.Write((long)0);
                            int registrosIndice = 2040 / 12;
                            for (int j = 0; j < registrosIndice; j++)
                            {
                                isdw.Write((int)0);
                                isdw.Write((long)-1);
                            }
                            isdw.Write((long)-1);
                            indexSecundarioFile.Position = 0;
                            isdw.Write(dataInsertar);
                            isdw.Write((long)2048);
                            int bloquesPequeños = 2040 / 8;
                            indexSecundarioFile.Position = 2048;
                            for (int j = 0; j < bloquesPequeños; j++)
                            {
                                isdw.Write((long)-1);
                            }
                            isdw.Write((long)-1);
                            indexSecundarioFile.Position = 2048;
                            isdw.Write((long)0);
                        }
                    }
                    else if (listAtributos[i].tipo == 'C')
                    {
                        string dataInsertar = (string)editaRegistro.SelectedCells[i].Value;
                        dataInsertar = dataInsertar.PadRight(listAtributos[i].longitud - 1);
                        dbw.Write(dataInsertar);
                        if (contIndices == 1 && listAtributos[i].tipoId == 2)
                        {
                            file.Position = listAtributos[i].direccion + 57;
                            binaryWriter.Write((long)0);
                            int registrosIndice = 2040 / listAtributos[i].longitud;
                            for (int j = 0; j < registrosIndice; j++)
                            {
                                idw.Write(dataInsertar);
                                idw.Write((long)-1);
                            }
                            idw.Write((long)-1);

                            indexFile.Position = 0;
                            idw.Write(dataInsertar);
                            idw.Write((long)0);
                        }

                        if (contIndicesSecundario == 1 && listAtributos[i].tipoId == 3)
                        {
                            file.Position = listAtributos[i].direccion + 57;
                            binaryWriter.Write((long)0);
                            int registrosIndice = 2040 / listAtributos[i].longitud;
                            for (int j = 0; j < registrosIndice; j++)
                            {
                                isdw.Write(dataInsertar);
                                isdw.Write((long)-1);
                            }
                            isdw.Write((long)-1);
                            indexSecundarioFile.Position = 0;
                            isdw.Write(dataInsertar);
                            isdw.Write((long)2048);
                            int bloquesPequeños = 2040 / 8;
                            indexSecundarioFile.Position = 2048;
                            for (int j = 0; j < bloquesPequeños; j++)
                            {
                                isdw.Write((long)-1);
                            }
                            isdw.Write((long)-1);
                            indexSecundarioFile.Position = 2048;
                            isdw.Write((long)0);
                        }
                    }
                }
                dbw.Write((long)-1);
                dataFile.Close();
                if (contIndices == 1)
                {
                    indexFile.Close();
                }
                if (contIndicesSecundario == 1)
                {
                    indexSecundarioFile.Close();
                }
            }
            else
            {
                string nombre_archivo = listEntidades[clave_entidad].id + ".dat";
                dataFile = new FileStream(nombre_archivo, FileMode.Open, FileAccess.ReadWrite);
                BinaryWriter binaryWriter = new BinaryWriter(file);
                BinaryReader binaryReader = new BinaryReader(file);
                BinaryReader dbr = new BinaryReader(dataFile);
                BinaryWriter dbw = new BinaryWriter(dataFile);

                if (contIndices == 1)
                {
                    string nomArchivoIndex = idAtributo + ".idx";
                    indexFile = new FileStream(nomArchivoIndex, FileMode.Open, FileAccess.ReadWrite);
                    idw = new BinaryWriter(indexFile);
                    idr = new BinaryReader(indexFile);


                    for (int i = 0; i < editaRegistro.SelectedCells.Count; i++)
                    {
                        if (listAtributos[i].tipoId == 2)
                        {
                            if (listAtributos[i].tipo == 'E')
                            {
                                tipo_registro = 0;
                                tam_registro += 4;
                            }
                            else if (listAtributos[i].tipo == 'C')
                            {
                                tipo_registro = 1;
                                tam_registro += listAtributos[i].longitud;
                            }
                        }
                    }

                    indexFile.Position = 0;
                    while (dir != -1)
                    {
                        if (tipo_registro == 0)
                        {
                            int nuevo_int = Convert.ToInt32(editaRegistro.SelectedCells[num_indice].Value);
                            int datoInt = idr.ReadInt32();
                            dir = idr.ReadInt64();
                            if (datoInt == nuevo_int)
                            {
                                existe = true;
                                MessageBox.Show("No puedes utilizar 2 veces el mismo indice");
                            }
                        }
                        else
                        {
                            string nuevo_string = editaRegistro.SelectedCells[num_indice].Value.ToString();
                            string datoString = idr.ReadString();
                            dir = idr.ReadInt64();
                            if (datoString == nuevo_string)
                            {
                                existe = true;
                                MessageBox.Show("No puedes utilizar 2 veces el mismo indice");
                            }
                        }
                    }
                }

                if (contArbolPrimario == 1)
                {
                    if (!CondicionesIndPrimarioArbol(atributoArbolPrimario, Convert.ToInt32(editaRegistro.SelectedCells[num_arbol_primario].Value)))
                    {
                        return;
                    }
                    AccionesArbolPrimario(atributoArbolPrimario, Convert.ToInt32(editaRegistro.SelectedCells[num_arbol_primario].Value), modificar);
                }

                if (contArbolSecundario == 1)
                {
                    AccionesArbolSecundarioModificacion(atributoArbolSecundario, Convert.ToInt32(editaRegistro.SelectedCells[num_arbol_secundario].Value), num_arbol_secundario, modificar);
                }


                if (contIndicesSecundario == 1)
                {
                    bool existe_secundario = false;
                    string nomArchivoIndex = idAtributoSecundario + ".idx";
                    try
                    {
                        indexSecundarioFile = new FileStream(nomArchivoIndex, FileMode.Open, FileAccess.ReadWrite);
                    }
                    catch (Exception)
                    {
                        indexSecundarioFile.Close();
                        indexSecundarioFile = new FileStream(nomArchivoIndex, FileMode.Open, FileAccess.ReadWrite);
                    }

                    isdw = new BinaryWriter(indexSecundarioFile);
                    isdr = new BinaryReader(indexSecundarioFile);


                    for (int i = 0; i < editaRegistro.SelectedCells.Count; i++)
                    {
                        if (listAtributos[i].tipoId == 3)
                        {
                            if (listAtributos[i].tipo == 'E')
                            {
                                tipo_registro_secundario = 0;
                                tam_registro_secundario += 4;
                            }
                            else if (listAtributos[i].tipo == 'C')
                            {
                                tipo_registro_secundario = 1;
                                tam_registro_secundario += listAtributos[i].longitud;
                            }
                        }
                    }

                    indexSecundarioFile.Position = 0;
                    if (tipo_registro_secundario == 0)
                    {
                        int nuevo_int = Int32.Parse(editaRegistro.SelectedCells[num_indice_secundario].Value.ToString());
                        long dir_existe_guardar = 0;
                        long dir_actual_archivo = 0;
                        do
                        {

                            int actual_int = 0;

                            try
                            {
                                actual_int = isdr.ReadInt32();
                                dir_actual_archivo = isdr.ReadInt64();
                            }
                            catch (Exception)
                            {
                                break;
                            }

                            if (actual_int == nuevo_int && dir_actual_archivo != -1)
                            {
                                existe_secundario = true;
                                dir_existe_guardar = dir_actual_archivo;
                                break;
                            }

                        } while (dir_actual_archivo != (long)-1);



                        if (existe_secundario)
                        {
                            indexSecundarioFile.Position = dir_existe_guardar;
                            do
                            {
                                long actual = isdr.ReadInt64();
                                if (actual == -1)
                                {
                                    indexSecundarioFile.Position = indexSecundarioFile.Position - 8;
                                    isdw.Write(modificar);
                                    break;
                                }
                            } while (true);
                        }
                        else
                        {
                            dir_actual_archivo = 0;
                            long guarda_ultimo_bloque = 0;
                            indexSecundarioFile.Position = 0;
                            long dir_escribir = 0;
                            do
                            {
                                int actual_archivo = isdr.ReadInt32();
                                dir_actual_archivo = isdr.ReadInt64();

                                if (dir_actual_archivo != -1)
                                {
                                    guarda_ultimo_bloque = dir_actual_archivo;
                                }

                                if (dir_actual_archivo == -1)
                                {
                                    indexSecundarioFile.Position = dir_escribir;
                                    isdw.Write(nuevo_int);
                                    long nuevo_bloque = guarda_ultimo_bloque + 2048;
                                    isdw.Write(nuevo_bloque);
                                    indexSecundarioFile.Position = nuevo_bloque;
                                    int bloquesPequeños = 2040 / 8;
                                    for (int j = 0; j < bloquesPequeños; j++)
                                    {
                                        isdw.Write((long)-1);
                                    }
                                    isdw.Write((long)-1);
                                    indexSecundarioFile.Position = nuevo_bloque;
                                    isdw.Write(modificar);
                                }
                                dir_escribir = indexSecundarioFile.Position;
                            } while (dir_actual_archivo != (long)-1);
                        }
                    }
                    else
                    {
                        string nuevo_string = editaRegistro.SelectedCells[num_indice_secundario].Value.ToString();
                        nuevo_string = nuevo_string.PadRight(listAtributos[num_indice_secundario].longitud - 1);
                        long dir_existe_guardar = 0;
                        long dir_actual_archivo = 0;
                        do
                        {

                            string actual_archivo = "";

                            try
                            {
                                actual_archivo = isdr.ReadString();
                                dir_actual_archivo = isdr.ReadInt64();
                            }
                            catch (Exception)
                            {
                                break;
                            }

                            if (actual_archivo.Contains(nuevo_string) && dir_actual_archivo != -1)
                            {
                                existe_secundario = true;
                                dir_existe_guardar = dir_actual_archivo;
                                break;
                            }

                        } while (dir_actual_archivo != (long)-1);



                        if (existe_secundario)
                        {
                            indexSecundarioFile.Position = dir_existe_guardar;
                            do
                            {
                                long actual = isdr.ReadInt64();
                                if (actual == -1)
                                {
                                    indexSecundarioFile.Position = indexSecundarioFile.Position - 8;
                                    isdw.Write(modificar);
                                    break;
                                }
                            } while (true);
                        }
                        else
                        {
                            dir_actual_archivo = 0;
                            long guarda_ultimo_bloque = 0;
                            indexSecundarioFile.Position = 0;
                            long dir_escribir = 0;
                            do
                            {
                                string actual_archivo = isdr.ReadString();
                                dir_actual_archivo = isdr.ReadInt64();

                                if (dir_actual_archivo != -1)
                                {
                                    guarda_ultimo_bloque = dir_actual_archivo;
                                }

                                if (dir_actual_archivo == -1)
                                {
                                    indexSecundarioFile.Position = dir_escribir;
                                    isdw.Write(nuevo_string);
                                    long nuevo_bloque = guarda_ultimo_bloque + 2048;
                                    isdw.Write(nuevo_bloque);
                                    indexSecundarioFile.Position = nuevo_bloque;
                                    int bloquesPequeños = 2040 / 8;
                                    for (int j = 0; j < bloquesPequeños; j++)
                                    {
                                        isdw.Write((long)-1);
                                    }
                                    isdw.Write((long)-1);
                                    indexSecundarioFile.Position = nuevo_bloque;
                                    MessageBox.Show(dataFile.Length.ToString());
                                    isdw.Write(modificar);
                                }
                                dir_escribir = indexSecundarioFile.Position;
                            } while (dir_actual_archivo != (long)-1);
                        }

                    }

                }

                if (cve_busqueda != 1)
                {
                    dataFile.Position = dataFile.Length - 8;
                    long dir_final = dbr.ReadInt64();
                    if (dir_final == -1)
                    {
                        dataFile.Position = dataFile.Length - 8;
                        dbw.Write(dataFile.Length);
                    }
                    else
                    {
                        long dir_guardar = 0;
                        do
                        {
                            dir_guardar = dir_final + tam_registro - 8;
                            dataFile.Position = dir_guardar;
                            dir_final = dbr.ReadInt64();

                        } while (dir_final == -1);
                        dataFile.Position = dir_guardar;
                        dbw.Write(dataFile.Length);
                    }

                }


                if (!existe)
                {
                    if (contIndices == 1)
                    {
                        while (true)
                        {
                            if (tipo_registro == 0)
                            {
                                int nuevo_int = Convert.ToInt32(editaRegistro.SelectedCells[num_indice].Value);
                                indexFile.Position = indexFile.Position - 8 - 4;
                                idw.Write(nuevo_int);
                                idw.Write(modificar);
                                break;
                            }
                            else
                            {
                                string nuevo_string = editaRegistro.SelectedCells[num_indice].Value.ToString();
                                indexFile.Position = indexFile.Position - 8 - tam_registro;
                                nuevo_string = nuevo_string.PadRight(tam_registro - 1);
                                idw.Write(nuevo_string);
                                idw.Write(modificar);
                                break;
                            }
                        }
                    }

                    dataFile.Position = modificar;
                    dbw.Write(modificar);
                    for (int i = 0; i < editaRegistro.SelectedCells.Count; i++)
                    {
                        if (listAtributos[i].tipo == 'E')
                        {
                            int dataInsertar = Convert.ToInt32(editaRegistro.SelectedCells[i].Value);
                            dbw.Write(dataInsertar);
                        }
                        else if (listAtributos[i].tipo == 'C')
                        {
                            string dataInsertar = (string)editaRegistro.SelectedCells[i].Value;
                            dataInsertar = dataInsertar.PadRight(listAtributos[i].longitud - 1);
                            dbw.Write(dataInsertar);
                        }
                    }
                    dbw.Write((long)-1);
                    //dataFile.Close();

                    if (cve_busqueda == 1)
                    {
                        for (int i = 0; i < listAtributos.Count; i++)
                        {
                            if (listAtributos[i].tipoId == 1)
                            {
                                if (listAtributos[i].tipo == 'E')
                                {
                                    ordenar_por = 0;
                                }
                                else if (listAtributos[i].tipo == 'C')
                                {
                                    ordenar_por = 1;
                                }
                                nombre_ordenado = listAtributos[i].nombre;
                                num_atributo_ordenar = i;
                            }
                        }

                        if (ordenar_por == 0) //Ordenar por enteros 
                        {
                            MessageBox.Show("Ordenado por enteros");
                            int nuevo_int = Convert.ToInt32(editaRegistro.SelectedCells[num_atributo_ordenar].Value);
                            file.Position = listEntidades[clave_entidad].direccion + 56;
                            long cab = binaryReader.ReadInt64();
                            long apunta;
                            long aux_dir_anterior;

                            aux_dir_anterior = cab;

                            int tamaño_registro = CalculaTamRegistro;
                            int buscar_en = PosicionDeLaBusqueda;
                            dataFile.Position = aux_dir_anterior + buscar_en;
                            int int_anterior = dbr.ReadInt32();


                            if (nuevo_int < int_anterior)
                            {
                                MessageBox.Show("Entro uno nuevo a ordenar por encima");
                                file.Position = listEntidades[clave_entidad].direccion + 56;
                                binaryWriter.Write(modificar);
                                dataFile.Position = modificar + tamaño_registro - 8;
                                dbw.Write(aux_dir_anterior);
                            }
                            else
                            {
                                do
                                {
                                    dataFile.Position = aux_dir_anterior + (tamaño_registro - 8);
                                    apunta = dbr.ReadInt64();

                                    dataFile.Position = apunta + buscar_en;
                                    int_anterior = dbr.ReadInt32();

                                    if (apunta == (long)-1)
                                    {
                                        dataFile.Position = aux_dir_anterior + (tamaño_registro - 8);
                                        dbw.Write(modificar);
                                        break;
                                    }
                                    else
                                    {
                                        dataFile.Position = apunta + buscar_en;
                                        int_anterior = dbr.ReadInt32();

                                        if (nuevo_int < int_anterior)
                                        {
                                            dataFile.Position = aux_dir_anterior + tamaño_registro - 8;
                                            dbw.Write(modificar);

                                            dataFile.Position = modificar + tamaño_registro - 8;
                                            dbw.Write(apunta);
                                            break;
                                        }
                                        else
                                        {
                                            aux_dir_anterior = apunta;
                                        }
                                    }
                                } while (true);
                            }


                        }
                        else //Ordenar por cadenas
                        {
                            MessageBox.Show("Ordenado por Cadena");
                            string nuevo_string = editaRegistro.SelectedCells[num_atributo_ordenar].Value.ToString();
                            file.Position = listEntidades[clave_entidad].direccion + 56;
                            long cab = binaryReader.ReadInt64();
                            long apunta;
                            long aux_dir_anterior;

                            aux_dir_anterior = cab;

                            int tamaño_registro = CalculaTamRegistro;
                            int buscar_en = PosicionDeLaBusqueda;
                            dataFile.Position = aux_dir_anterior + buscar_en;
                            string string_anterior = dbr.ReadString();


                            if (string.Compare(nuevo_string, string_anterior) == -1)
                            {
                                file.Position = listEntidades[clave_entidad].direccion + 56;
                                binaryWriter.Write(modificar);
                                dataFile.Position = modificar + tamaño_registro - 8;
                                dbw.Write(aux_dir_anterior);
                            }
                            else
                            {
                                do
                                {
                                    dataFile.Position = aux_dir_anterior + (tamaño_registro - 8);
                                    apunta = dbr.ReadInt64();

                                    dataFile.Position = apunta + buscar_en;
                                    string_anterior = dbr.ReadString();

                                    if (apunta == (long)-1)
                                    {
                                        dataFile.Position = aux_dir_anterior + (tamaño_registro - 8);
                                        dbw.Write(modificar);
                                        break;
                                    }
                                    else
                                    {
                                        dataFile.Position = apunta + buscar_en;
                                        string_anterior = dbr.ReadString();

                                        if (string.Compare(nuevo_string, string_anterior) == -1)
                                        {
                                            dataFile.Position = aux_dir_anterior + tamaño_registro - 8;
                                            dbw.Write(modificar);

                                            dataFile.Position = modificar + tamaño_registro - 8;
                                            dbw.Write(apunta);
                                            break;
                                        }
                                        else
                                        {
                                            aux_dir_anterior = apunta;
                                        }
                                    }
                                } while (true);
                            }
                        }
                    }
                    dataFile.Close();
                    if (contIndices == 1)
                    {
                        indexFile.Close();
                    }
                    if (contIndicesSecundario == 1)
                    {
                        indexSecundarioFile.Close();
                    }
                }
            }
            guardarDatos();
            entidadInsertarEntidad.SelectedItem = null;
        }

        private int CalculaTamRegistro
        {
            get
            {
                int cont = 16;
                for (int i = 0; i < listAtributos.Count; i++)
                {
                    if (listAtributos[i].tipo == 'E')
                    {
                        cont += 4;
                    }
                    else
                    {
                        cont += listAtributos[i].longitud;
                    }
                }

                return cont;
            }
        }

        public int PosicionDeLaBusqueda
        {
            get
            {
                int cont = 8;
                for (int i = 0; i < listAtributos.Count; i++)
                {
                    if (listAtributos[i].tipoId == 1)
                    {
                        break;
                    }
                    else
                    {
                        if (listAtributos[i].tipo == 'E')
                        {
                            cont += 4;
                        }
                        else
                        {
                            cont += listAtributos[i].longitud;
                        }
                    }
                }
                return cont;
            }
        }

        private void MostrarRegistros_Click(object sender, EventArgs e)
        {
            tablaInsertarRegistro.Rows.Clear();
            tablaInsertarRegistro.Columns.Clear();
            BinaryReader binaryReader = new BinaryReader(file);


            if (entidadInsertarEntidad.Text != "")
            {
                //file.Close();
                int clave_entidad = entidadInsertarEntidad.Items.IndexOf(entidadInsertarEntidad.Text);
                string nombre_archivo = listEntidades[clave_entidad].id + ".dat";
                try
                {

                    dataFile = new FileStream(nombre_archivo, FileMode.Open, FileAccess.ReadWrite);
                }
                catch (Exception)
                {
                    dataFile.Close();
                    dataFile = new FileStream(nombre_archivo, FileMode.Open, FileAccess.ReadWrite);
                }

                BinaryReader br = new BinaryReader(dataFile);

                file.Position = listEntidades[clave_entidad].direccion + 56;
                long cab = binaryReader.ReadInt64();
                long direccion_anterior = cab;



                int id = entidadInsertarEntidad.Items.IndexOf(entidadInsertarEntidad.Text);
                guardarAtributos(entidadInsertarEntidad.Text);

                DataGridViewTextBoxColumn dirInicio = new DataGridViewTextBoxColumn();
                dirInicio.Name = "Direccion";
                tablaInsertarRegistro.Columns.Add(dirInicio);
                for (int i = 0; i < listAtributos.Count; i++)
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.Name = listAtributos[i].nombre;
                    tablaInsertarRegistro.Columns.Add(column);
                }
                DataGridViewTextBoxColumn dirFinal = new DataGridViewTextBoxColumn();
                dirFinal.Name = "Direccion siguiente";
                tablaInsertarRegistro.Columns.Add(dirFinal);



                long dir_siguiente;
                //int tama_registro = CalculaTamRegistro;

                //int contAtributo=0;
                if (direccion_anterior != -1)
                {
                    dataFile.Position = direccion_anterior;
                    do
                    {
                        int i = 0;
                        string[] data = new string[listAtributos.Count + 2];


                        data[i] = br.ReadInt64().ToString();
                        for (i = 0; i < listAtributos.Count; i++)
                        {
                            if (listAtributos[i].tipo == 'E')
                            {
                                int dato_int = br.ReadInt32();
                                data[i + 1] = dato_int.ToString();
                            }
                            else
                            {
                                string dato_string = br.ReadString();
                                data[i + 1] = dato_string;
                            }


                        }
                        dir_siguiente = br.ReadInt64();

                        data[i + 1] = dir_siguiente.ToString();
                        tablaInsertarRegistro.Rows.Add(data);
                        if (dir_siguiente == -1)
                        {
                            break;
                        }
                        dataFile.Position = dir_siguiente;


                    } while (dir_siguiente != -1);
                    dataFile.Close();
                }
            }
        }

        private void MuestraIndice_Click(object sender, EventArgs e)
        {
            if (entidadInsertarEntidad.Text != "")
            {
                string id_atributo;
                int id = entidadInsertarEntidad.Items.IndexOf(entidadInsertarEntidad.Text);
                guardarAtributos(entidadInsertarEntidad.Text);

                for (int i = 0; i < listAtributos.Count; i++)
                {
                    if (listAtributos[i].tipoId == 2)
                    {
                        id_atributo = listAtributos[i].id;
                        Indice indice = new Indice(id_atributo, listAtributos[i].tipo);
                        indice.Show();
                        break;
                    }
                }
            }
        }

        private void Elimina_registro_Click(object sender, EventArgs e)
        {
            eliminaRegistro();
        }

        public void eliminaRegistro()
        {
            Atributo atributo_primario = null;
            Atributo atributo_secundario = null;
            string idArbolPrimarioEliminar = "";
            string idArbolSecundarioEliminar = "";
            int contArbolPrimario = 0;
            int contArbolSecundario = 0;
            bool primero = false;
            string idAtributoEliminar = "";
            string idAtributoSecundarioEliminar = "";
            int contIndices = 0;
            int contIndicesSecundario = 0;
            long dir_borrar = long.Parse(tablaInsertarRegistro.SelectedCells[0].Value.ToString());
            long dir_editar = -1;

            BinaryReader binaryReader = new BinaryReader(file);
            BinaryWriter binaryWeader = new BinaryWriter(file);

            guardarAtributos(entidadInsertarEntidad.Text);

            if (entidadInsertarEntidad.Text != "")
            {
                //file.Close();
                int clave_entidad = entidadInsertarEntidad.Items.IndexOf(entidadInsertarEntidad.Text);
                string nombre_archivo = listEntidades[clave_entidad].id + ".dat";

                try
                {
                    dataFile = new FileStream(nombre_archivo, FileMode.Open, FileAccess.ReadWrite);

                }
                catch (Exception)
                {

                    dataFile.Close();
                    dataFile = new FileStream(nombre_archivo, FileMode.Open, FileAccess.ReadWrite);
                }

                BinaryReader br = new BinaryReader(dataFile);
                BinaryWriter bw = new BinaryWriter(dataFile);

                file.Position = listEntidades[clave_entidad].direccion + 56;
                long cab = binaryReader.ReadInt64();
                long direccion_anterior = cab;


                int id = entidadInsertarEntidad.Items.IndexOf(entidadInsertarEntidad.Text);
                guardarAtributos(entidadInsertarEntidad.Text);

                for (int i = 0; i < listAtributos.Count; i++)
                {
                    if (listAtributos[i].tipoId == 2)
                    {
                        idAtributoEliminar = listAtributos[i].
                            id;
                        contIndices++;
                    }
                    else if (listAtributos[i].tipoId == 3)
                    {
                        idAtributoSecundarioEliminar = listAtributos[i].id;
                        contIndicesSecundario++;
                    }
                    else if (listAtributos[i].tipoId == 4)
                    {
                        atributo_primario = listAtributos[i];
                        idArbolPrimarioEliminar = listAtributos[i].id;
                        contArbolPrimario++;
                    }
                    else if (listAtributos[i].tipoId == 5)
                    {
                        atributo_secundario = listAtributos[i];
                        idArbolSecundarioEliminar = listAtributos[i].id;
                        contArbolSecundario++;
                    }
                }

                

                long dir_siguiente;


                if (direccion_anterior != -1)
                {
                    dataFile.Position = direccion_anterior;

                    do
                    {
                        int i = 0;


                        long actual = br.ReadInt64();
                        for (i = 0; i < listAtributos.Count; i++)
                        {
                            if (listAtributos[i].tipo == 'E')
                            {
                                int dato_int = br.ReadInt32();
                            }
                            else
                            {
                                string dato_string = br.ReadString();
                            }
                        }


                        dir_siguiente = br.ReadInt64();
                        if (dir_editar != -1)
                        {
                            dataFile.Position = dir_editar;
                            bw.Write((long)dir_siguiente);

                            if (contIndices == 1)
                            {
                                indexFile = new FileStream(idAtributoEliminar + ".idx", FileMode.Open, FileAccess.ReadWrite);
                                BinaryReader idr = new BinaryReader(indexFile);
                                BinaryWriter idw = new BinaryWriter(indexFile);

                                int actual_indice = 0;
                                long direccion = 0;
                                indexFile.Position = 0;

                                while (direccion != -1)
                                {
                                    actual_indice = idr.ReadInt32();
                                    direccion = idr.ReadInt64();
                                    if (direccion == actual)
                                    {
                                        indexFile.Position = indexFile.Position - 8;
                                        idw.Write((long)-2);
                                    }
                                }
                                indexFile.Close();
                            }

                            if (contIndicesSecundario == 1)
                            {
                                indexSecundarioFile = new FileStream(idAtributoSecundarioEliminar + ".idx", FileMode.Open, FileAccess.ReadWrite);
                                BinaryReader isdr = new BinaryReader(indexSecundarioFile);
                                BinaryWriter isdw = new BinaryWriter(indexSecundarioFile);

                                long direccion = 0;
                                indexSecundarioFile.Position = 2048;

                                while (true)
                                {
                                    direccion = isdr.ReadInt64();
                                    if (direccion == actual)
                                    {
                                        indexSecundarioFile.Position = indexSecundarioFile.Position - 8;
                                        isdw.Write((long)-2);
                                        break;
                                    }
                                }


                                indexSecundarioFile.Close();
                            }

                            if (contArbolPrimario == 1)
                            {
                                archivoArbol = new FileStream(idArbolPrimarioEliminar + ".idx", FileMode.Open, FileAccess.ReadWrite);
                                BinaryReader abr = new BinaryReader(archivoArbol);
                                BinaryWriter abW = new BinaryWriter(archivoArbol);

                                EliminaDeArbolPrimario(atributo_primario, Convert.ToInt32(tablaInsertarRegistro.SelectedCells[1].Value));

                                archivoArbol.Close();
                            }

                            if (contArbolSecundario == 1)
                            {
                                archivoArbol = new FileStream(idArbolSecundarioEliminar + ".idx", FileMode.Open, FileAccess.ReadWrite);
                                BinaryReader abr = new BinaryReader(archivoArbol);
                                BinaryWriter abW = new BinaryWriter(archivoArbol);

                                EliminaDeArbolSecundario(atributo_secundario, Convert.ToInt32(tablaInsertarRegistro.SelectedCells[1].Value), Convert.ToInt64(tablaInsertarRegistro.SelectedCells[0].Value));

                                archivoArbol.Close();
                            }
                            break;
                        }

                        if (dir_siguiente == dir_borrar)
                        {
                            dir_editar = dataFile.Position - 8;
                        }


                        if (cab == dir_borrar && !primero)
                        {
                            file.Position = listEntidades[clave_entidad].direccion + 56;
                            binaryWeader.Write((long)dir_siguiente);

                            //dataFile.Position = dir_editar;
                            //bw.Write((long)dir_siguiente);

                            if (contIndices == 1)
                            {
                                indexFile = new FileStream(idAtributoEliminar + ".idx", FileMode.Open, FileAccess.ReadWrite);
                                BinaryReader idr = new BinaryReader(indexFile);
                                BinaryWriter idw = new BinaryWriter(indexFile);

                                int actual_indice = 0;
                                long direccion = 0;
                                indexFile.Position = 0;

                                while (direccion != -1)
                                {
                                    actual_indice = idr.ReadInt32();
                                    direccion = idr.ReadInt64();
                                    if (direccion == actual)
                                    {
                                        indexFile.Position = indexFile.Position - 8;
                                        idw.Write((long)-2);
                                    }
                                }


                                indexFile.Close();
                            }
                            

                            if (contIndicesSecundario == 1)
                            {
                                indexSecundarioFile = new FileStream(idAtributoSecundarioEliminar + ".idx", FileMode.Open, FileAccess.ReadWrite);
                                BinaryReader isdr = new BinaryReader(indexSecundarioFile);
                                BinaryWriter isdw = new BinaryWriter(indexSecundarioFile);

                                long direccion = 0;
                                indexSecundarioFile.Position = 2048;

                                while (true)
                                {
                                    direccion = isdr.ReadInt64();
                                    if (direccion == actual)
                                    {
                                        indexSecundarioFile.Position = indexSecundarioFile.Position - 8;
                                        isdw.Write((long)-2);
                                        break;
                                    }
                                }
                                indexSecundarioFile.Close();
                            }

                            if (contArbolPrimario == 1)
                            {
                                archivoArbol = new FileStream(idArbolPrimarioEliminar + ".idx", FileMode.Open, FileAccess.ReadWrite);
                                BinaryReader abr = new BinaryReader(archivoArbol);
                                BinaryWriter abW = new BinaryWriter(archivoArbol);

                                EliminaDeArbolPrimario(atributo_primario, Convert.ToInt32(tablaInsertarRegistro.SelectedCells[1].Value));

                                archivoArbol.Close();
                            }

                            if (contArbolSecundario == 1)
                            {
                                archivoArbol = new FileStream(idArbolSecundarioEliminar + ".idx", FileMode.Open, FileAccess.ReadWrite);
                                BinaryReader abr = new BinaryReader(archivoArbol);
                                BinaryWriter abW = new BinaryWriter(archivoArbol);

                                EliminaDeArbolSecundario(atributo_secundario, Convert.ToInt32(tablaInsertarRegistro.SelectedCells[1].Value), Convert.ToInt64(tablaInsertarRegistro.SelectedCells[0].Value));

                                archivoArbol.Close();
                            }


                            primero = true;
                            break;
                        }

                        if (dir_siguiente == -1)
                        {
                            break;
                        }
                        dataFile.Position = dir_siguiente;


                    } while (dir_siguiente != -1);
                    dataFile.Close();
                }
            }
            guardarDatos();
        }

        private void EditarRegistro_Click(object sender, EventArgs e)
        {
            editaRegistro.Rows.Clear();
            editaRegistro.Columns.Clear();
            string[] data = new string[tablaInsertarRegistro.SelectedCells.Count - 2];
            for (int i = 1; i < tablaInsertarRegistro.SelectedCells.Count - 1; i++)
            {
                editaRegistro.Columns.Add("...", "...");
                data[i - 1] = tablaInsertarRegistro.SelectedCells[i].Value.ToString();
            }
            editaRegistro.Rows.Add(data);

            this.modificar = Convert.ToInt64(tablaInsertarRegistro.SelectedCells[0].Value);


            guardarDatos();
        }

        private void TablaInsertarRegistro_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MuestraIndiceSecundario_Click(object sender, EventArgs e)
        {
            if (entidadInsertarEntidad.Text != "")
            {
                string id_atributo;
                int id = entidadInsertarEntidad.Items.IndexOf(entidadInsertarEntidad.Text);
                guardarAtributos(entidadInsertarEntidad.Text);

                for (int i = 0; i < listAtributos.Count; i++)
                {
                    if (listAtributos[i].tipoId == 3)
                    {
                        id_atributo = listAtributos[i].id;
                        IndiceSecundario indiceSecundario = new IndiceSecundario(id_atributo, listAtributos[i].tipo);
                        indiceSecundario.Show();
                        break;
                    }
                }
            }
        }



        private void EditRegisters_Click(object sender, EventArgs e)
        {
            eliminaRegistro();
            actualizaRegistro();
            guardarDatos();
        }

        private void EntidadInsertarEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void Arbol_primario_Click(object sender, EventArgs e)
        {
            Atributo atributo = null;

            int num_arbol_primario = 0;
            string idAtributoArbolPrimario = "";
            int contArbolPrimario = 0;
            int clave_entidad = entidadInsertarEntidad.Items.IndexOf(entidadInsertarEntidad.Text);

            BinaryWriter iapdw = null;
            BinaryReader iapdr = null;

            guardarAtributos(entidadInsertarEntidad.Text);

            for (int i = 0; i < listAtributos.Count; i++)
            {
                if (listAtributos[i].tipoId == 4)
                {
                    atributo = listAtributos[i];
                }
            }



            List<Nodo> nodos = GetNodos(atributo);
            MessageBox.Show(nodos.Count.ToString());
            ArbolPrimario arbol = new ArbolPrimario(nodos);
            arbol.Show();
        }



        private void Arbol_secundario_Click(object sender, EventArgs e)
        {
            Atributo atributo = null;
            int num_atributo = 0;

            int num_arbol_secundario = 0;
            string idAtributoArbolSecundario = "";
            int contArbolSecundario = 0;
            int clave_entidad = entidadInsertarEntidad.Items.IndexOf(entidadInsertarEntidad.Text);

            BinaryWriter iapdw = null;
            BinaryReader iapdr = null;

            guardarAtributos(entidadInsertarEntidad.Text);

            for (int i = 0; i < listAtributos.Count; i++)
            {
                if (listAtributos[i].tipoId == 5)
                {
                    atributo = listAtributos[i];
                    num_atributo = i;
                }
            }

            List<Nodo> nodos = GetNodos(atributo);

            ArbolSecundario arbol = new ArbolSecundario(nodos,clave_entidad,num_atributo,listAtributos);
            arbol.Show();

        }

        public void AbrirArchivoArbol(Atributo atributo)
        {
            string file_name = atributo.id + ".idx";
            try
            {
                archivoArbol = new FileStream(file_name, FileMode.Open,FileAccess.ReadWrite);
            }
            catch (Exception)
            {
                archivoArbol.Close();
                archivoArbol = new FileStream(file_name, FileMode.Open, FileAccess.ReadWrite);
            }
        }

        public void CerrarArchivoArbol()
        {
            archivoArbol.Close();
        }

        public List<Nodo> GetNodos(Atributo atributo)
        {
            List<Nodo> nodos = new List<Nodo>();
            long apuntador_archivo = atributo.dirDatos;

            if (apuntador_archivo != -1)
            {
                AbrirArchivoArbol(atributo);
                BinaryReader reader = new BinaryReader(archivoArbol);

                reader.BaseStream.Position = apuntador_archivo;
                Nodo nodo = new Nodo();
                nodo.tipo = System.Convert.ToChar(reader.ReadByte());
                nodo.direccion = reader.ReadInt64();
                nodo.claves = new List<int>();
                nodo.apuntadores = new List<long>();

                for (int i = 0; i < Nodo.CAP - 1; i++)
                {
                    nodo.apuntadores.Add(reader.ReadInt64());
                    nodo.claves.Add(reader.ReadInt32());
                }

                nodo.apuntadores.Add(reader.ReadInt64());
                nodos.Add(nodo);
                reader.Close();
                CerrarArchivoArbol();
            }
            else
            {
                return nodos;
            }


            if (nodos[0].tipo == 'H')
                return nodos;
            else
            {
                List<Nodo> temp = GetNodosFromDenso(atributo, nodos[0]);
                foreach (var item in temp)
                {
                    nodos.Add(item);
                }
            }

            return nodos;
        }
        public List<Nodo> GetNodosFromDenso(Atributo atributo, Nodo denso)
        {
            List<Nodo> nodos = new List<Nodo>();
            AbrirArchivoArbol(atributo);

            BinaryReader reader = new BinaryReader(archivoArbol);

            foreach (var item in denso.apuntadores)
            {
                if (item == -1) break;
                reader.BaseStream.Position = item;

                Nodo nodo = new Nodo();

                nodo.tipo = System.Convert.ToChar(reader.ReadByte());
                nodo.direccion = reader.ReadInt64();
                nodo.claves = new List<int>();
                nodo.apuntadores = new List<long>();

                for (int i = 0; i < Nodo.CAP - 1; i++)
                {
                    nodo.apuntadores.Add(reader.ReadInt64());
                    nodo.claves.Add(reader.ReadInt32());
                }

                nodo.apuntadores.Add(reader.ReadInt64());
                nodos.Add(nodo);
            }
            reader.Close();
            CerrarArchivoArbol();

            int tam_denso = nodos.Count;
            for (int i = 0; i < tam_denso; i++)
            {
                Nodo item = nodos[i];
                if (item.tipo != 'H')
                {
                    List<Nodo> temp;
                    temp = GetNodosFromDenso(atributo, item);
                    foreach (var item2 in temp)
                    {
                        nodos.Add(item2);
                    }
                }
            }

            return nodos;

        }

        public bool CondicionesIndPrimarioArbol(Atributo atributo_prim_arbol, int dato_indice)
        {
            //Si no tiene registros insertados, sólo creamos el archivo y nos regresamos
            if (atributo_prim_arbol.dirDatos == -1)
            {
                //Escribimos la cabecera del atributo en 0 para que apunte al primero
                CrearArchivoIndice(atributo_prim_arbol);
                EscribeCabeceraIndice(atributo_prim_arbol.direccion, 0);
                return true;
            }
            //Si sí hay datos la única condición que tiene que cumplir es que el arreglo no tenga el dato
            else
            {
                Arbol arbol = new Arbol(GetNodos(atributo_prim_arbol), atributo_prim_arbol);
                if (arbol.ContieneClave(dato_indice))
                {
                    return false;
                }
                return true;
            }
        }

        public void CrearArchivoIndice(Atributo atributo)
        {
            string file = atributo.id+".idx";
            archivoArbol = new FileStream(file, FileMode.Create);
            archivoArbol.Close();

        }

        public void EscribeCabeceraIndice(long direccion, long cabecera)
        {
            BinaryWriter bw = new BinaryWriter(file);
            file.Position = direccion + 57;
            bw.Write(cabecera);
        }

        public void AccionesArbolPrimario(Atributo atributo, int dato, long direccion)
        {
            Arbol arbol_primario = new Arbol(GetNodos(atributo), atributo);
            InsercionArbol(arbol_primario, dato, direccion);
        }


        public void InsercionArbol(Arbol arbol, int dato, long direccion)
        {
            // Si no existen nodos en el árbol, se crea la primera hoja y se le inserta la primera clave
            if (arbol.nodos.Count == 0)
            {
                Nodo nuevo = CreaNodo(arbol.atributo, 'H');
                nuevo.apuntadores[0] = direccion;
                nuevo.claves[0] = dato;
                EscribeNodoEnArchivo(arbol.atributo, nuevo);

                EscribeCabeceraIndice(arbol.atributo.direccion, nuevo.direccion);
            }
            // Si no contiene raíz se inserta en la única hoja que se tiene en el árbol
            else if (!arbol.ContieneRaiz())
            {
                Nodo hoja_unica = arbol.nodos[0];
                List<Nodo> nodos = InsertaDatoEnHoja(arbol.atributo, hoja_unica, dato, direccion);
                if (nodos.Count == 2)
                {
                    Nodo raiz = CreaNodo(arbol.atributo, 'R');
                    raiz.apuntadores[0] = nodos[0].direccion;
                    raiz.apuntadores[1] = nodos[1].direccion;
                    raiz.claves[0] = nodos[1].claves[0];
                    EscribeCabeceraIndice(arbol.atributo.direccion, raiz.direccion);
                    EscribeNodoEnArchivo(arbol.atributo, raiz);
                }
            }
            else
            {
                Nodo nodo_padre;
                Nodo nodo_hoja = arbol.GetRaiz();

                do
                {
                    nodo_padre = nodo_hoja;
                    int index = nodo_padre.DevuelvePosicion(dato);
                    nodo_hoja = arbol.GetNodo(nodo_padre.apuntadores[index]);
                } while (nodo_hoja.tipo != 'H');

                List<Nodo> nodos = InsertaDatoEnHoja(arbol.atributo, nodo_hoja, dato, direccion);
                if (nodos.Count == 2)
                {
                    ActualizaPadre(arbol, nodo_padre, nodos[1].claves[0], nodos[1].direccion);
                }
            }
        }

        public List<Nodo> InsertaDatoEnHoja(Atributo atributo, Nodo nodo, int dato, long direccion)
        {
            // Si no se pudo insertar significa que se tiene que dividir el nodo
            if (!nodo.InsertaEnHoja(dato, direccion))
            {
                List<Nodo> res = DivideHoja(nodo, CreaNodo(atributo, 'H'), dato, direccion);
                EscribeNodoEnArchivo(atributo, res[0]);
                EscribeNodoEnArchivo(atributo, res[1]);
                return res;
            }
            // Si sí se insertó simplemente se actualiza en el archivo
            else
            {
                EscribeNodoEnArchivo(atributo, nodo);
                List<Nodo> res = new List<Nodo> { nodo };
                return res;
            }
        }


        public List<Nodo> DivideHoja(Nodo nodo, Nodo nodo_nuevo2, int dato, long direccion)
        {
            int idx_medio = (Nodo.CAP - 1) / 2 - 1;

            // Se mueven los datos según si es derecha o izquierda
            List<long> apuntadores = new List<long>();
            List<int> claves = new List<int>();

            foreach (var item in nodo.apuntadores)
                apuntadores.Add(item);

            foreach (var item in nodo.claves)
                claves.Add(item);

            claves.Add(dato);
            claves.Sort();

            Nodo nodo_nuevo1 = new Nodo();
            nodo_nuevo1.tipo = nodo.tipo;
            nodo_nuevo1.direccion = nodo.direccion;
            nodo_nuevo1.apuntadores[Nodo.CAP - 1] = nodo.apuntadores[Nodo.CAP - 1];

            int idx_viejo = 0, idx_nuevo = 0, idx_temp = 0;
            for (int i = 0; i < Nodo.CAP; i++)
            {
                if (i <= idx_medio)
                {
                    if (claves[i] == dato)
                        nodo_nuevo1.apuntadores[idx_viejo] = direccion;
                    else
                        nodo_nuevo1.apuntadores[idx_viejo] = apuntadores[idx_temp++];
                    nodo_nuevo1.claves[idx_viejo++] = claves[i];
                }
                else
                {
                    if (claves[i] == dato)
                        nodo_nuevo2.apuntadores[idx_nuevo] = direccion;
                    else
                        nodo_nuevo2.apuntadores[idx_nuevo] = apuntadores[idx_temp++];
                    nodo_nuevo2.claves[idx_nuevo++] = claves[i];
                }
            }

            nodo_nuevo2.apuntadores[Nodo.CAP - 1] = nodo_nuevo1.apuntadores[Nodo.CAP - 1];
            nodo_nuevo1.apuntadores[Nodo.CAP - 1] = nodo_nuevo2.direccion;

            return new List<Nodo> { nodo_nuevo1, nodo_nuevo2 };
        }

        void ActualizaPadre(Arbol arbol, Nodo nodo_padre, int dato, long direccion)
        {
            if (nodo_padre.InsertaEnNodoDenso(dato, direccion))
                EscribeNodoEnArchivo(arbol.atributo, nodo_padre);
            else
            {
                int tipo = nodo_padre.tipo;
                if (tipo == 'R') nodo_padre.tipo = 'I';

                List<int> indices_ordenados = new List<int>();
                foreach (var item in nodo_padre.claves)
                    indices_ordenados.Add(item);

                indices_ordenados.Add(dato);
                indices_ordenados.Sort();
                int idx_mitad = (Nodo.CAP - 1) / 2;
                int clave_arriba = indices_ordenados[idx_mitad];


                List<Nodo> nodos_intermedios = DivideNodoDenso(indices_ordenados, nodo_padre, CreaNodo(arbol.atributo, 'I'), dato, direccion);

                EscribeNodoEnArchivo(arbol.atributo, nodos_intermedios[0]);
                EscribeNodoEnArchivo(arbol.atributo, nodos_intermedios[1]);

                if (tipo == 'R')
                {
                    Nodo nueva_raiz = CreaNodo(arbol.atributo, 'R');
                    nueva_raiz.apuntadores[0] = nodos_intermedios[0].direccion;
                    nueva_raiz.apuntadores[1] = nodos_intermedios[1].direccion;
                    nueva_raiz.claves[0] = clave_arriba;
                    EscribeCabeceraIndice(arbol.atributo.direccion, nueva_raiz.direccion);
                    EscribeNodoEnArchivo(arbol.atributo, nueva_raiz);
                }
                else
                {
                    Nodo nodo_padre_temp = arbol.GetPadre(nodos_intermedios[0]);
                    ActualizaPadre(new Arbol(GetNodos(arbol.atributo), arbol.atributo), nodo_padre_temp, clave_arriba, nodos_intermedios[1].direccion);
                }
            }
        }

        public List<Nodo> DivideNodoDenso(List<int> claves, Nodo nodo, Nodo nodo_nuevo2, int dato, long direccion)
        {
            int idx_medio = (Nodo.CAP - 1) / 2;

            List<long> apuntadores = new List<long>();

            foreach (var item in nodo.apuntadores)
                apuntadores.Add(item);

            Nodo nodo_nuevo1 = new Nodo();
            nodo_nuevo1.tipo = nodo.tipo;
            nodo_nuevo1.direccion = nodo.direccion;

            int idx_clave_medio = nodo.claves.IndexOf(claves[idx_medio]) + 1;
            nodo_nuevo1.apuntadores[0] = apuntadores[0];
            nodo_nuevo2.apuntadores[0] = apuntadores[idx_clave_medio];

            apuntadores.RemoveAt(idx_clave_medio);
            apuntadores.RemoveAt(0);


            int idx_viejo = 0, idx_nuevo = 0, idx_temp = 0;
            for (int i = 0; i < Nodo.CAP; i++)
            {
                if (i < idx_medio)
                {
                    if (claves[i] == dato)
                        nodo_nuevo1.apuntadores[idx_viejo + 1] = direccion;
                    else
                        nodo_nuevo1.apuntadores[idx_viejo + 1] = apuntadores[idx_temp++];
                    nodo_nuevo1.claves[idx_viejo++] = claves[i];
                }
                else if (i > idx_medio)
                {
                    if (claves[i] == dato)
                        nodo_nuevo2.apuntadores[idx_nuevo + 1] = direccion;
                    else
                        nodo_nuevo2.apuntadores[idx_nuevo + 1] = apuntadores[idx_temp++];
                    nodo_nuevo2.claves[idx_nuevo++] = claves[i];
                }
            }
            return new List<Nodo> { nodo_nuevo1, nodo_nuevo2 };
        }

        public void EscribeNodoEnArchivo(Atributo atributo, Nodo nodo)
        {
            AbrirArchivoArbol(atributo);
            BinaryWriter bn = new BinaryWriter(archivoArbol);
            bn.BaseStream.Position = nodo.direccion;
            bn.Write(nodo.tipo);
            bn.Write(nodo.direccion);
            for (int i = 0; i < Nodo.CAP; i++)
            {
                bn.Write(nodo.apuntadores[i]);
                if (i != Nodo.CAP - 1)
                    bn.Write(nodo.claves[i]);
            }
            CerrarArchivoArbol();
        }

        public Nodo CreaNodo(Atributo atributo, char tipo)
        {
            AbrirArchivoArbol(atributo);
            Nodo nodo = new Nodo();
            nodo.tipo = tipo;
            nodo.direccion = archivoArbol.Length;
            CerrarArchivoArbol();
            return nodo;
        }

        public void EliminaDeArbolPrimario(Atributo atributo, int dato)
        {
            Arbol arbol = new Arbol(GetNodos(atributo), atributo);
            Nodo nodo = arbol.GetNodoDeLlave(dato);
            long direccion = nodo.GetApuntadorHoja(dato);
            EliminaDeArbol(arbol, nodo, dato, direccion);
        }

        public void EliminaDeArbolSecundario(Atributo atributo, int dato, long direccion)
        {
            Arbol arbol = new Arbol(GetNodos(atributo), atributo);
            Nodo nodo = arbol.GetNodoDeLlave(dato);
            long dir = arbol.GetDireccion(dato);
            List<long> bloque_denso = GetBloqueDenso(atributo, dir);
            bloque_denso.Remove(direccion);

            if (bloque_denso.Count == 0)
            {
                EliminaDeArbol(arbol, nodo, dato, dir);
            }
            else
            {
                EscribeBloqueDenso(atributo, bloque_denso, dir);
            }
        }

        bool EliminaDeArbol(Arbol arbol, Nodo nodo, int dato, long direccion)
        {
            int tam_minimo = (Nodo.CAP - 1) / 2;
            char tipo = nodo.tipo;

            if (tipo == 'H')
            {
                if (!nodo.EliminaEnHoja(dato))
                    return false;
            }
            else
            {
                if (!nodo.EliminaEnNodoDenso(dato, direccion))
                    return false;
            }

            EscribeNodoEnArchivo(arbol.atributo, nodo);

            if (tipo != 'R')
            {
                if (nodo.CountClaves() < tam_minimo)
                {
                    Nodo padre = arbol.GetPadre(nodo);
                    Nodo vecino_der = arbol.GetVecinoDer(nodo);
                    Nodo vecino_izq = arbol.GetVecinoIzq(nodo);
                   

                    if (vecino_der != null && arbol.CheckMismoPadre(nodo, vecino_der) && vecino_der.CountClaves() - 1 >= tam_minimo)
                    {
                        if (tipo == 'H')
                        {
                            long prestado_dir = vecino_der.apuntadores[0];
                            int prestado_cve = vecino_der.claves[0];

                            if (!vecino_der.EliminaEnHoja(prestado_cve))
                                return false;
                            EscribeNodoEnArchivo(arbol.atributo, vecino_der);

                            nodo.InsertaEnHoja(prestado_cve, prestado_dir);
                            EscribeNodoEnArchivo(arbol.atributo, nodo);

                            int idx_actualizar_padre = padre.apuntadores.IndexOf(nodo.direccion);
                            padre.claves[idx_actualizar_padre] = vecino_der.claves[0];
                            EscribeNodoEnArchivo(arbol.atributo, padre);
                        }
                        else
                        {
                            long vecino_dir = vecino_der.apuntadores[0];
                            int vecino_cve = vecino_der.claves[0];
                            int idx_cve_padre = padre.apuntadores.IndexOf(nodo.direccion);
                            int padre_cve = padre.claves[idx_cve_padre];

                            if (!vecino_der.EliminaEnNodoDenso(vecino_cve, vecino_dir))
                                return false;
                            EscribeNodoEnArchivo(arbol.atributo, vecino_der);

                            padre.claves[idx_cve_padre] = vecino_cve;
                            EscribeNodoEnArchivo(arbol.atributo, padre);

                            nodo.InsertaEnNodoDenso(padre_cve, vecino_dir);
                            EscribeNodoEnArchivo(arbol.atributo, nodo);
                        }
                    }
                    else if (vecino_izq != null && arbol.CheckMismoPadre(nodo, vecino_izq) && vecino_izq.CountClaves() - 1 >= tam_minimo)
                    {
                        if (tipo == 'H')
                        {
                            long prestado_dir = vecino_izq.apuntadores[vecino_izq.CountClaves() - 1];
                            int prestado_cve = vecino_izq.claves[vecino_izq.CountClaves() - 1];

                            if (!vecino_izq.EliminaEnHoja(prestado_cve))
                                return false;
                            EscribeNodoEnArchivo(arbol.atributo, vecino_izq);

                            nodo.InsertaEnHoja(prestado_cve, prestado_dir);
                            EscribeNodoEnArchivo(arbol.atributo, nodo);

                            int idx_actualizar_padre = padre.apuntadores.IndexOf(vecino_izq.direccion);
                            padre.claves[idx_actualizar_padre] = prestado_cve;
                            EscribeNodoEnArchivo(arbol.atributo, padre);
                        }
                        else
                        {
                            long vecino_dir = vecino_izq.apuntadores[vecino_izq.CountClaves()];
                            int vecino_cve = vecino_izq.claves[vecino_izq.CountClaves() - 1];
                            int idx_cve_padre = padre.apuntadores.IndexOf(vecino_izq.direccion);
                            int padre_cve = padre.claves[idx_cve_padre];

                            if (!vecino_izq.EliminaEnNodoDenso(vecino_cve, vecino_dir))
                                return false;
                            EscribeNodoEnArchivo(arbol.atributo, vecino_izq);

                            padre.claves[idx_cve_padre] = vecino_cve;
                            EscribeNodoEnArchivo(arbol.atributo, padre);

                            nodo.InsertaEnNodoDenso(padre_cve, vecino_dir);
                            EscribeNodoEnArchivo(arbol.atributo, nodo);
                        }
                    }
                    else if (vecino_der != null && arbol.CheckMismoPadre(nodo, vecino_der))
                    {
                        if (tipo == 'H')
                        {
                            for (int i = 0; i < vecino_der.CountClaves(); i++)
                                nodo.InsertaEnHoja(vecino_der.claves[i], vecino_der.apuntadores[i]);
                            EscribeNodoEnArchivo(arbol.atributo, nodo);
                            if (padre.tipo == 'R' && padre.CountClaves() == 1)
                            {
                                EscribeCabeceraIndice(arbol.atributo.direccion, vecino_der.direccion);
                            }
                            else
                            {
                                int idx_eliminar_padre = padre.apuntadores.IndexOf(vecino_der.direccion);
                                int dato_nuevo = padre.claves[idx_eliminar_padre - 1];
                                long dir_nueva = padre.apuntadores[idx_eliminar_padre];

                                return EliminaDeArbol(arbol, padre, dato_nuevo, dir_nueva);
                            }
                        }
                        else
                        {
                            int cve_padre = padre.claves[padre.apuntadores.IndexOf(nodo.direccion)];
                            long dir0_vecino = vecino_der.apuntadores[0];

                            vecino_der.InsertaEnNodoDenso(cve_padre, dir0_vecino);

                            for (int i = 0; i < nodo.CountClaves(); i++)
                                vecino_der.InsertaEnNodoDenso(nodo.claves[i], nodo.apuntadores[i + 1]);
                            vecino_der.apuntadores[0] = nodo.apuntadores[0];

                            if (padre.tipo == 'R' && padre.CountClaves() == 1)
                            {
                                vecino_der.tipo = 'R';
                                EscribeNodoEnArchivo(arbol.atributo, vecino_der);
                                EscribeCabeceraIndice(arbol.atributo.direccion, vecino_der.direccion);
                            }
                            else
                            {
                                EscribeNodoEnArchivo(arbol.atributo, vecino_der);
                                return EliminaDeArbol(arbol, padre, cve_padre, nodo.direccion);
                            }
                        }
                    }
                    else if (vecino_izq != null && arbol.CheckMismoPadre(nodo, vecino_izq))
                    {
                        if (tipo == 'H')
                        {
                            for (int i = 0; i < nodo.CountClaves(); i++)
                                vecino_izq.InsertaEnHoja(nodo.claves[i], nodo.apuntadores[i]);
                            EscribeNodoEnArchivo(arbol.atributo, vecino_izq);
                            if (padre.tipo == 'R' && padre.CountClaves() == 1)
                            {
                                vecino_izq.tipo = 'R';
                                EscribeCabeceraIndice(arbol.atributo.direccion, vecino_izq.direccion);
                            }
                            else
                            {
                                int idx_eliminar_padre = padre.apuntadores.IndexOf(nodo.direccion);
                                int dato_nuevo = padre.claves[idx_eliminar_padre - 1];
                                long dir_nueva = padre.apuntadores[idx_eliminar_padre];

                                return EliminaDeArbol(arbol, padre, dato_nuevo, dir_nueva);
                            }
                        }
                        else
                        {
                            int cve_padre = padre.claves[padre.apuntadores.IndexOf(vecino_izq.direccion)];
                            long dir0_nodo = nodo.apuntadores[0];

                            vecino_izq.InsertaEnNodoDenso(cve_padre, dir0_nodo);

                            for (int i = 0; i < nodo.CountClaves(); i++)
                                vecino_izq.InsertaEnNodoDenso(nodo.claves[i], nodo.apuntadores[i + 1]);

                            if (padre.tipo == 'R' && padre.CountClaves() == 1)
                            {
                                vecino_izq.tipo = 'R';
                                EscribeNodoEnArchivo(arbol.atributo, vecino_izq);
                                EscribeCabeceraIndice(arbol.atributo.direccion, vecino_izq.direccion);
                            }
                            else
                            {
                                EscribeNodoEnArchivo(arbol.atributo, vecino_izq);
                                return EliminaDeArbol(arbol, padre, cve_padre, nodo.direccion);
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void AccionesArbolSecundarioModificacion(Atributo atributo, int dato, int index_atributo,long direccion)
        {
            // Si no hay archivo lo crea
            if (atributo.dirDatos == -1)
            {
                CrearArchivoIndice(atributo);
                EscribeCabeceraIndice(atributo.direccion, 0);
            }

            Arbol arbol = new Arbol(GetNodos(atributo), atributo);

            // Si ya contiene la clave, simplemente la inserta en su bloque
            if (arbol.ContieneClave(dato))
            {
                //Sólo inserta la dirección del registro en el bloque denso
                long dir = arbol.GetDireccion(dato);
                List<long> bloque_denso = GetBloqueDenso(atributo, dir);
                bloque_denso.Add(direccion);
                bloque_denso.Sort();
                EscribeBloqueDenso(atributo, bloque_denso, dir);
            }
            // Sino crea el nuevo bloque y la dirección del bloque se inserta en el árbol con la clave de búsqueda.
            else
            {
                //Crea nuevo bloque denso con la dirección del registro dentro
                long direccion_bloque = GetTamanioArchivoIndice(atributo);
                InicializaBloqueDensoSecundario(atributo, direccion_bloque);
                List<long> bloque_denso = GetBloqueDenso(atributo, direccion_bloque);
                bloque_denso.Add(direccion);
                EscribeBloqueDenso(atributo, bloque_denso, direccion_bloque);

                //Inserta en el árbol
                InsercionArbol(arbol, dato, direccion_bloque);
            }
        }

        public void AccionesArbolSecundario(Atributo atributo, int dato, int index_atributo)
        {
            // Si no hay archivo lo crea
            if (atributo.dirDatos == -1)
            {
                CrearArchivoIndice(atributo);
                EscribeCabeceraIndice(atributo.direccion, 0);
            }

            Arbol arbol = new Arbol(GetNodos(atributo), atributo);

            // Si ya contiene la clave, simplemente la inserta en su bloque
            if (arbol.ContieneClave(dato))
            {
                //Sólo inserta la dirección del registro en el bloque denso
                long dir = arbol.GetDireccion(dato);
                List<long> bloque_denso = GetBloqueDenso(atributo, dir);
                bloque_denso.Add(dataFile.Length);
                bloque_denso.Sort();
                EscribeBloqueDenso(atributo, bloque_denso, dir);
            }
            // Sino crea el nuevo bloque y la dirección del bloque se inserta en el árbol con la clave de búsqueda.
            else
            {
                //Crea nuevo bloque denso con la dirección del registro dentro
                long direccion_bloque = GetTamanioArchivoIndice(atributo);
                InicializaBloqueDensoSecundario(atributo, direccion_bloque);
                List<long> bloque_denso = GetBloqueDenso(atributo, direccion_bloque);
                bloque_denso.Add(dataFile.Length);
                EscribeBloqueDenso(atributo, bloque_denso, direccion_bloque);

                //Inserta en el árbol
                InsercionArbol(arbol, dato, direccion_bloque);
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

        public void EscribeBloqueDenso(Atributo atributo, List<long> direcciones, long cabecera)
        {
            InicializaBloqueDensoSecundario(atributo, cabecera);
            AbrirArchivoArbol(atributo);
            BinaryWriter bn = new BinaryWriter(archivoArbol);
            bn.BaseStream.Position = cabecera;
            foreach (var item in direcciones)
                bn.Write(item);
            CerrarArchivoArbol();
        }

        public long GetTamanioArchivoIndice(Atributo atributo)
        {
            AbrirArchivoArbol(atributo);
            long temp = archivoArbol.Length;
            CerrarArchivoArbol();
            return temp;
        }

        public void InicializaBloqueDensoSecundario(Atributo atributo, long direccion)
        {
            AbrirArchivoArbol(atributo);

            BinaryWriter bn = new BinaryWriter(archivoArbol);
            bn.BaseStream.Position = direccion;
            for (int i = 0; i < NREGISTROS_SENCILLOS; i++)
            {
                bn.Write((long)-1);
            }
            bn.BaseStream.Position = direccion + TAMANIO_BLOQUE - 8;
            bn.Write((long)-1);

            CerrarArchivoArbol();
        }

    }


}