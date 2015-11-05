using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio.Model;

namespace Repositorio.ViewModel
{
    public class ViewModelAlumno:IViewModel<Alumno>
    {
        public Int32 idAlumno { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }

        public List<string> cursos { get; set; }



        public Alumno ToBaseDatos()
        {
            var al = new Alumno()
            {
                DNI = DNI,
                Nombre = Nombre
            };
            return al;
        }

        public void FromBaseDatos(Alumno modelo)
        {
            DNI = modelo.DNI;
            Nombre = modelo.Nombre;
        }

        public void UpdateBaseDatos(Alumno modelo)
        {
            modelo.DNI = DNI;
            modelo.Nombre = Nombre;
        }

        public object[] Getkeys()
        {
            return new[] { (object)idAlumno };
        }
    }
}
