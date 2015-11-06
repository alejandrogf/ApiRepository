using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio.Model;

namespace Repositorio.ViewModel
{
    public class ViewModelCurso:IViewModel<Curso>
    {

        public int idCurso { get; set; }
        public string Nombre { get; set; }
        public int Duracion { get; set; }
        public Nullable<System.DateTime> Inicio { get; set; }
        public Nullable<System.DateTime> Fin { get; set; }
        public Nullable<int> idAula { get; set; }


        public Curso ToBaseDatos()
        {
            var nuevoCurso = new Curso()
            {
                //idCurso =  idCurso,
                Nombre =   Nombre,
                Duracion = Duracion,
                Inicio =   Inicio,
                Fin =      Fin,
                idAula =   idAula
            };
            return nuevoCurso;
        }

        public void FromBaseDatos(Curso modelo)
        {

            idCurso = modelo.idCurso;
            Nombre = modelo.Nombre;
            Duracion = modelo.Duracion;
            Inicio = modelo.Inicio;
            Fin = modelo.Fin;
            idAula = modelo.idAula;
        }

        public void UpdateBaseDatos(Curso modelo)
        {
            modelo.idCurso = idCurso;
            modelo.Nombre = Nombre;
            modelo.Duracion = Duracion;
            modelo.Inicio = Inicio;
            modelo.Fin = Fin;
            modelo.idAula = idAula;
        }

        public object[] Getkeys()
        {
            return new[] {(object) idCurso};
        }
    }
}
