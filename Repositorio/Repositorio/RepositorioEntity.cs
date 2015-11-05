using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Repositorio.ViewModel;

namespace Repositorio.Repositorio
{
    public class RepositorioEntity<TModelo, TViewModel> : IRepositorio<TModelo, TViewModel>
        where TModelo : class
        where TViewModel : IViewModel<TModelo>, new()

    {
        private DbContext context;

        //Se define protected para que no se pueda acceder desde fuera
        //pero si tiene hijos, puedan acceder a él
        protected DbSet<TModelo> DbSet
        {
            get { return context.Set<TModelo>(); }
            
        }

        

        public RepositorioEntity(DbContext context)
        {
            this.context = context;
        }


        public TViewModel Add(TViewModel model)
        {
            var modelo = model.ToBaseDatos();
            DbSet.Add(modelo);

            try
            {
                context.SaveChanges();
                model.FromBaseDatos(modelo);
                return model;
            }
            catch (Exception e)
            {
                return default(TViewModel);
            }
        }

        public int Borrar(TViewModel model)
        {
            var objeto = DbSet.Find(model.Getkeys());
            DbSet.Remove(objeto);

            try
            {
                return context.SaveChanges();
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int Borrar(Expression<Func<TModelo, bool>> consultaExpression)
        {
            var data = DbSet.Where(consultaExpression);
            DbSet.RemoveRange(data);

            try
            {
                return context.SaveChanges();
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int Actualizar(TViewModel model)
        {
            var data = DbSet.Find(model.Getkeys());
            model.UpdateBaseDatos(data);

            try
            {
                return context.SaveChanges();
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public ICollection<TViewModel> Get()
        {
            var data=new List<TViewModel>();

            foreach (var modelo in DbSet)
            {
                TViewModel objeto=new TViewModel();
                objeto.FromBaseDatos(modelo);

                data.Add(objeto);
            }
            return data;
        }

        public TViewModel Get(params object[] keys)
        {
            var datoUnico = DbSet.Find(keys);
            var retorno=new TViewModel();
            retorno.FromBaseDatos(datoUnico);
            return retorno;
        }

        public ICollection<TViewModel> Get(Expression<Func<TModelo, bool>> consultaExpression)
        {
            var datosFiltrados = DbSet.Where(consultaExpression);
            var data = new List<TViewModel>();

            foreach (var modelo in datosFiltrados)
            {
                TViewModel objeto =new TViewModel();
                objeto.FromBaseDatos(modelo);
                data.Add(objeto);
            }
            return data;
        }
    }
}
