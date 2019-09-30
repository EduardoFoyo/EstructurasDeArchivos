using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasArchivos
{
    class Entidad
    {
        public string id;
        public string nombre;
        public long direccion;
        public long direccion_atributos;
        public long dir_data;
        public long direccion_sig;

        public Entidad(string id, string nombre, long direccion, long direccion_atributos, long dir_data, long direccion_sig)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.direccion_atributos = direccion_atributos;
            this.dir_data = dir_data;
            this.direccion_sig = direccion_sig;
        }

        public static implicit operator long(Entidad v)
        {
            throw new NotImplementedException();
        }
    }
}
