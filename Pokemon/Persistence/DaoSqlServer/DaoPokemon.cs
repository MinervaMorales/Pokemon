using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Pokemon.Common.Entities;

namespace Pokemon.Persistence.DaoSqlServer
{
    public class DaoPokemon: Dao
    {

        /// <summary>
        /// Metodo para agregar un pokemon
        /// </summary>
        /// <param name="pokemon"></param>
        public void Add(Pokemones pokemon)
        {
            string query = @"INSERT INTO Pokemon (nombre, observaciones) VALUES (@Nombre,@Observaciones)";
            
            try
            {
                Connect();
                Execute(query, pokemon);
            }
            catch( Exception e )
            {
                throw e;
            }
            finally
            {
                Disconnect();
            }
         
        }


        /// <summary>
        /// Metodo para obtener todos los pokemones
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Pokemones> GetAll()
        {
     
           string query = @"Select * From Pokemon";

            try
            {
                return Connect().Query<Pokemones>(query);
            }
            catch( Exception e )
            {
                throw e;
            }
            finally
            {
                Disconnect();
            }
           
                 
        }


        /// <summary>
        /// Metodo para obtener un pokemon por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pokemones GetById(int id)
        {
            
           string query = @"Select * From Pokemon where PokemonId=@Id";

            try
            {
                return Connect().Query<Pokemones>(query, new { Id = id }).FirstOrDefault();
            }
            catch( Exception e )
            {
                throw e;
            }
            finally
            {
                Disconnect();
            }



        }


        /// <summary>
        /// Metodo para eliminar un pokemon segun su id
        /// </summary>
        /// <param name="id">id dek pokemon a eliminar</param>
        public void Delete( long id )
        {
 
           string sQuery = @"Delete * From Pokemon where PokemonId=@Id";
            try
            {
                Connect().Execute(sQuery, new { Id = id });
            }
            catch ( Exception e )
            {
                throw e;
            }
            finally
            {
                Disconnect();
            }
           
        }


        /// <summary>
        /// Metodo para actualizar la informacion de un pokemon
        /// </summary>
        /// <param name="pokemon"></param>
        public void Update( Pokemones pokemon )
        {
            
            string query = @"Update Pokemon Set Nombre=@Nombre, Observaciones=@Observaciones  where PokemonId=@Id";

            try
            {
                Connect().Query(query, pokemon);
            }
            catch( Exception e )
            {
                throw e;
            }
            finally
            {
                Disconnect();
            }


        }


    }
}
