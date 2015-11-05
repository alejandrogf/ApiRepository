using System.Data.Entity;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Repositorio.Model;
using Repositorio.Repositorio;
using Repositorio.ViewModel;
using Unity.WebApi;

namespace ApiRepository
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            //Entity para todos los repositorios.
            container.RegisterType<DbContext, CentroFormacionEntities>();
            //Repositorio para Alumno.
            container.RegisterType<IRepositorio<Alumno, ViewModelAlumno>, RepositorioEntity<Alumno, ViewModelAlumno>>();
            //Repositorio para Curso.
            container.RegisterType<IRepositorio<Curso, ViewModelCurso>, RepositorioEntity<Curso, ViewModelCurso>>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}