using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.Atributos
{
    public class AtributosPersona
    {
        private int Id;
        private string nombre;
        private string apellido;
        private string direccion;
        private DateTime fecha_nacimiento;
        private string celular;

        public int Id1 { get => Id; set => Id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public DateTime Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
        public string Celular { get => celular; set => celular = value; }
    }
}
