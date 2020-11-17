using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Persistence.Interfaces
{
    /// <summary>
    /// Intefaz para todos los DAOs
    /// </summary>
    public interface IBaseDao<T>
    {
        /// <summary>
        /// Metodo que agrega un nuevo objeto
        /// </summary>
        /// <param name="entity">Entidad que va a ser almacenada</param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// Metodo que edita una entidad
        /// </summary>
        /// <param name="entity">Nuevos datos de la entidad</param>
        /// <returns></returns>
        T Edit(T entity);

        /// <summary>
        /// Metodo que retorna todos los objetos
        /// </summary>
        /// <returns>Retorna todos los objetos de la clase</returns>
        IList<T> GetAll();

        /// <summary>
        /// Metodo que obtiene un objeto por id
        /// </summary>
        /// <param name="id">identificador unico del objeto</param>
        /// <returns>Retorna todos los datos asociados a al objeto</returns>
        T GetById(long id);

        /// <summary>
        /// Metodo que borra el objeto de la base de datos
        /// </summary>
        /// <param name="entity">Objeto a ser eliminado</param>
        /// <returns></returns>
        T Delete(T entity);
    }
}
