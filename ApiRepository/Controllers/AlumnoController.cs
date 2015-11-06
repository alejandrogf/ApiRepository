using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Practices.Unity;
using Repositorio.Model;
using Repositorio.Repositorio;
using Repositorio.ViewModel;

namespace ApiRepository.Controllers
{
    public class AlumnoController : ApiController
    {
        private CentroFormacionEntities context;
        //private IRepositorio<Alumno, ViewModelAlumno> repo;

        //public AlumnoController()
        //{
        //    context=new CentroFormacionEntities();
        //    repo=new RepositorioEntity<Alumno, ViewModelAlumno>(context);
        //}

            [Dependency]
            public IRepositorio<Alumno, ViewModelAlumno> Repo { get; set; }

        public ICollection<ViewModelAlumno> Get()
        {
            return Repo.Get();
        }

        [ResponseType(typeof (ViewModelAlumno))]

        public IHttpActionResult Get(int id)
        {
            var data = Repo.Get(id);
            if (data == null)
                return NotFound();

            return Ok(data);

        }
    }
}
