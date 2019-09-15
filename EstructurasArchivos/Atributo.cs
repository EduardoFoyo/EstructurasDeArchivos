using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasArchivos
{
    class Atributo
    {
        string nombre;
        string tipo;
        int longitud;
        int tipoIndice;
        string entidad;

        public Atributo(string text, string v1, int v2, int v3, string v4)
        {
            this.nombre = text;
            this.tipo = v1;
            this.longitud = v2;
            this.tipoIndice = v3;
            this.entidad = v4;
        }

        public string GetNombre()
        {
            return nombre;
        }
        public string GetTipo()
        {
            return tipo;
        }
        public int GetLongitud()
        {
            return longitud;
        }
        public int GetTipoIndice()
        {
            return tipoIndice;
        }
    }
}
