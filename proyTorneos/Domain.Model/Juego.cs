using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Juego
    {

        public int Id { get; set;  }
        public string Nombre { get; set; }
        public string Descripcion { get; set;  }


        public Juego (int id, string nombre, string desc)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = desc; 
        }

    }
}
