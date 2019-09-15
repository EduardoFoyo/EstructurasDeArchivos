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
    public partial class Form1 : Form
    {
        FileStream file;
        
        long cab_aux;
        List<Entidad> listEntidades;
        List<Atributo> listAtributos;

        public Form1()
        {
            InitializeComponent();
            listEntidades = new List<Entidad>();
            listAtributos = new List<Atributo>();
        }

        private void CrearTabla_Click(object sender, EventArgs e)
        {
            CrearTabla ct = new CrearTabla();
            ct.Show();
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
                MessageBox.Show(file.Length.ToString());
                if (file.Length > 8)
                {
                    guardarDatos();
                }
            }
            


        }

        private void guardarDatos()
        {
            BinaryReader binaryReader = new BinaryReader(file);
            file.Seek(0, SeekOrigin.Begin);
            long cab = binaryReader.ReadInt64();
            file.Position = cab;
            long direccion_sig;
            do
            {

                string[] antributo = new string[6];

                string id = new string(binaryReader.ReadChars(5));
                string nombre = binaryReader.ReadString();
                long direccion = binaryReader.ReadInt64();
                long direccion_atributos = binaryReader.ReadInt64();
                long dirNose = binaryReader.ReadInt64();
                direccion_sig = binaryReader.ReadInt64();
   

                Entidad e = new Entidad(id,nombre,direccion,direccion_atributos,dirNose,direccion_sig);
                listEntidades.Add(e);

         

                if (direccion_sig != -1)
                {
                    file.Position = direccion_sig;
                }

            } while (direccion_sig != -1);
        }

        private void AddEntity_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se agrego la Entidad: " + entityText);
            if (file.Length == 8)
            {
                BinaryWriter binaryWriter = new BinaryWriter(file);
                binaryWriter.Seek(0, SeekOrigin.Begin);
                binaryWriter.Write(file.Length);

                /*BinaryReader binaryReader = new BinaryReader(file);
                file.Seek(0, SeekOrigin.Begin);
                long aux = cab_aux;
                cab_aux = binaryReader.ReadInt64();
                MessageBox.Show(cab_aux.ToString());*/

                binaryWriter.Seek(0, SeekOrigin.End);

                char[] id_entidad = new char[5];
                string nombre = entityText.Text.PadRight(34);

                long direccion_entidad = file.Length;
                long dir_atributos = -1;
                long dir_datos = -1;
                long dir_siguiente_entidad = -1;

                binaryWriter.Write(id_entidad);
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

                binaryWriter.Write(id_entidad);
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
                    //binaryWriter.Seek(0, SeekOrigin.Begin);
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
                        //file.Seek(aux_anterior+64, SeekOrigin.Current);
                        long apunta = br.ReadInt64();
                        if (apunta == -1)
                        {
                            file.Position = aux_anterior + 64;
                            binaryWriter.Write(file.Length-72);
                            bandera = true;
                            break;
                        }
                        file.Position = apunta + 5;
                        //file.Seek(apunta+5, SeekOrigin.Begin);
                        
                        aux = br.ReadString();
                        if (string.Compare(entityText.Text, aux) == -1)
                        {
                            file.Position = file.Length - 8;
                            binaryWriter.Write(apunta);
                            //file.Seek(file.Length - 8, SeekOrigin.End);
                            file.Position = aux_anterior +64;
                            binaryWriter.Write(file.Length - 72);
                            break;
                            //long aux_apuntador = br.ReadInt64();

                            //file.Seek(aux_anterior+64, SeekOrigin.Current);
                            //file.Position = aux_anterior + 64;

                            //binaryWriter.Write(aux_apuntador);
                        }
                        else
                        {
                            //file.Seek(aux_anterior + 64, SeekOrigin.Current);
                            file.Position = aux_anterior + 64;
                            aux_anterior = br.ReadInt64();

                            if(aux_anterior == -1)
                            {
                                bandera = true;
                                break;
                            }
                        }

                    } while (true);

                    if (bandera == true)
                    {
                       // file.Seek(aux_anterior + 64, SeekOrigin.Current);
                        file.Position = aux_anterior + 64;

                        binaryWriter.Write(file.Length-72);
                    }

                    

                }

                


                /* BinaryWriter binaryWriter = new BinaryWriter(file);
                 binaryWriter.Seek(0, SeekOrigin.End);

                 char[] id_entidad = new char[5];
                 string nombre = entityText.Text.PadRight(34);

                 long direccion_entidad = file.Length;
                 long dir_atributos = -1;
                 long dir_datos = -1;
                 long dir_siguiente_entidad = -1;

                 binaryWriter.Write(id_entidad);
                 binaryWriter.Write(nombre);
                 binaryWriter.Write(direccion_entidad);
                 binaryWriter.Write(dir_atributos);
                 binaryWriter.Write(dir_datos);
                 binaryWriter.Write(dir_siguiente_entidad);*/
            }
            
            //Invalidate();
        }

        private void AgregarAtributo_Click(object sender, EventArgs e)
        {

            BinaryWriter binaryWriter = new BinaryWriter(file);

            binaryWriter.Seek((int)file.Length, SeekOrigin.Begin);

            char[] id_entidad = new char[5];
            string nombre = nombreAtributo.Text.PadRight(34);


            char tipo = char.Parse(typeAtributo.Text);
            int longitud = Int32.Parse(longitudAtributo.Text);
            long direccion_atributo = file.Length;
            int tipo_indice = Int32.Parse(tipoIndiceAtributo.SelectedItem.ToString());
            long dir_datos = -1;
            long dir_siguiente_atributo = file.Length+73;

            binaryWriter.Write(id_entidad);
            binaryWriter.Write(nombre);
            binaryWriter.Write(tipo);
            binaryWriter.Write(longitud);
            binaryWriter.Write(direccion_atributo);
            binaryWriter.Write(tipo_indice);
            binaryWriter.Write(dir_datos);
            binaryWriter.Write(dir_siguiente_atributo);

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
            /*MessageBox.Show(cab_aux.ToString());
            BinaryReader binaryReader = new BinaryReader(file);
            file.Seek(cab_aux, SeekOrigin.Begin);
            //file.Seek(8, SeekOrigin.Begin);
            string[] entidad = new string[6];

            string hexa = new string(binaryReader.ReadChars(5));

            entidad[0] = hexa; 
            entidad[1] = binaryReader.ReadString(); 
            entidad[2] = binaryReader.ReadInt64().ToString();
            entidad[3] = binaryReader.ReadInt64().ToString();
            entidad[4] = binaryReader.ReadInt64().ToString();
            long salida = binaryReader.ReadInt64();
            entidad[5] = salida.ToString();
            entidades.Rows.Add(entidad);*/

            BinaryReader binaryReader = new BinaryReader(file);
            //file.Seek(0, SeekOrigin.Begin);
            file.Position = 0;
            long cab = binaryReader.ReadInt64();

            //long estado_actual = 80;
            //long pocision = 8;

            //do
            //{
            //file.Seek(pocision, SeekOrigin.Begin);
            //file.Position = pocision;
            file.Position = cab;
            long direccion_sig;
            int i = 0;
            do
            {
                string[] antributo = new string[6];

                string id = new string(binaryReader.ReadChars(5));

                antributo[0] = id;
                antributo[1] = binaryReader.ReadString();
                antributo[2] = binaryReader.ReadInt64().ToString();
                antributo[3] = binaryReader.ReadInt64().ToString();
                antributo[4] = binaryReader.ReadInt64().ToString();
                direccion_sig = binaryReader.ReadInt64();
                antributo[5] = direccion_sig.ToString();
                entidades.Rows.Add(antributo);
                if (direccion_sig != -1)
                {
                    MessageBox.Show(direccion_sig.ToString());
                    file.Position = direccion_sig;
                    MessageBox.Show(direccion_sig.ToString());
                }
            } while (direccion_sig != -1);

            


            /* id = new string(binaryReader.ReadChars(5));

            antributo[0] = id;
            antributo[1] = binaryReader.ReadString();
            antributo[2] = binaryReader.ReadInt64().ToString();
            antributo[3] = binaryReader.ReadInt64().ToString();
            antributo[4] = binaryReader.ReadInt64().ToString();
            antributo[5] = binaryReader.ReadInt64().ToString();
            entidades.Rows.Add(antributo);
            antributo = new string[6];


            id = new string(binaryReader.ReadChars(5));

            antributo[0] = id;
            antributo[1] = binaryReader.ReadString();
            antributo[2] = binaryReader.ReadInt64().ToString();
            antributo[3] = binaryReader.ReadInt64().ToString();
            antributo[4] = binaryReader.ReadInt64().ToString();
            antributo[5] = binaryReader.ReadInt64().ToString();
            entidades.Rows.Add(antributo); antributo = new string[6];

            id = new string(binaryReader.ReadChars(5));

            antributo[0] = id;
            antributo[1] = binaryReader.ReadString();
            antributo[2] = binaryReader.ReadInt64().ToString();
            antributo[3] = binaryReader.ReadInt64().ToString();
            antributo[4] = binaryReader.ReadInt64().ToString();
            antributo[5] = binaryReader.ReadInt64().ToString();
            entidades.Rows.Add(antributo); antributo = new string[6];

            id = new string(binaryReader.ReadChars(5));

            antributo[0] = id;
            antributo[1] = binaryReader.ReadString();
            antributo[2] = binaryReader.ReadInt64().ToString();
            antributo[3] = binaryReader.ReadInt64().ToString();
            antributo[4] = binaryReader.ReadInt64().ToString();
            antributo[5] = binaryReader.ReadInt64().ToString();
            entidades.Rows.Add(antributo); antributo = new string[6];*/



            // pocision += 72;
            // } while (file.Length != estado_actual);

            /*long estado_actual= 80;
            long pocision = 80;

            do 
            {
                file.Seek(pocision, SeekOrigin.Begin);

                string[] antributo = new string[8];

                string id = new string(binaryReader.ReadChars(5));

                antributo[0] = id;
                antributo[1] = binaryReader.ReadString();
                antributo[2] = binaryReader.ReadChar().ToString();
                antributo[3] = binaryReader.ReadInt32().ToString();
                antributo[4] = binaryReader.ReadInt64().ToString();
                antributo[5] = binaryReader.ReadInt32().ToString();
                antributo[6] = binaryReader.ReadInt64().ToString();
                antributo[7] = binaryReader.ReadInt64().ToString();
                estado_actual = Int32.Parse(antributo[7]);
                atributos.Rows.Add(antributo);
                pocision += 73;
            } while (file.Length != estado_actual) ;*/
        }
    }
}
