using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Repositorio.ViewModel;

namespace Repositorio.Repositorio
{
    public interface IRepositorio<TModelo, TViewModel> 
                                 where TModelo:class 
                                 where TViewModel:IViewModel<TModelo>
    {
        TViewModel Add(TViewModel model);
        //Para borrar un objeto concreto
        int Borrar(TViewModel model);
        //Para borrar toda la información que coincida con la expresión
        int Borrar(Expression<Func<TModelo, bool>> consultaExpression);

        int Actualizar(TViewModel model);

        //Para buscar todos los registro.
        ICollection<TViewModel> Get();

        //Para obtener un solo registro indicando la key/keys.
        //Con params Object[] recibes un array de objetos
        TViewModel Get(params Object[] keys);

        //Para obtener resultados a lrecibir una expresión lambda
        //Devuelve un icollection de tviewmodel, por si se reciben muchos.
        //La clase expression define expresiones lambda
        //Toda expresión lambda, realmente, lo que hace es encapsular una función 
        //(un trozo de código conm el que se busca o se hace cualquier otra cosa, 
        //aunque en este caso es para buscar) 
        //Por tanto recibe Func, que es una función (que no deja de ser un metodo)
        //Func a su vez recibe sobre qué buscar y devuelve un booleano según el resultado.
        ICollection<TViewModel> Get(Expression<Func<TModelo, bool>> consultaExpression);


    }
}
