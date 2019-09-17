using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasArchivos
{
    class Atributo
    {
        public string id;
        public string nombre;
        public char tipo;
        public int longitud;
        public long direccion;
        public int tipoId;
        public long dirDatos;
        public long dirSiguiente;

        public Atributo(string id, string nombre, char tipo, int longitud, long direccion, int tipoId, long dirDatos, long dirSiguiente)
        {
            this.id = id;
            this.nombre = nombre;
            this.tipo = tipo;
            this.longitud = longitud;
            this.direccion = direccion;
            this.tipoId = tipoId;
            this.dirDatos = dirDatos;
            this.dirSiguiente = dirSiguiente;
        }
    }
}
