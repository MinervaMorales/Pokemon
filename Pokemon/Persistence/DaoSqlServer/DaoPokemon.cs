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
            string query = @"INSERT INTO pokem (nombre, categoria_id, salud, observaciones) VALUES (@Nombre,@Categoria, @Salud, @Observaciones)";
            
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
            try
            {
                var query = Connect()
                .Query<Pokemones, Poder, Categoria, Pokemones>($@"
                    SELECT pk.poke_id, pk.nombre,  pk.salud, pk.observaciones, pk_pd.poder_id, pd.descripcion, 
                    pk.categoria_id, cat.descripcion FROM pokem AS pk  JOIN poke_poder as pk_pd 
                    ON pk.poke_id = pk_pd.poke_id INNER JOIN poderes AS pd ON pd.poder_id = pk_pd.poder_id 
                    INNER JOIN categoria AS cat ON cat.categoria_id = pk.categoria_id",
                    (pk, pd, cat) =>
                    {
                        pk.Poderes = pk.Poderes ?? new List<Poder>();
                        pk.Poderes.Add(pd);
                        pk.Categoria = cat;
                        return pk;
                    })//, splitOn: "poderes_id, categoria_id" 
                .AsQueryable();

                return query.ToList();
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
        public Pokemones GetById( int id )
        {
            Pokemones pokemon;
            try
            {
                pokemon  = Connect()
                  .Query<Pokemones, Poder, Categoria, Pokemones>($@"
                    SELECT pk.poke_id, pk.nombre,  pk.salud,  pk.observaciones, pk_pd.poder_id, pd.descripcion, 
                    pk.categoria_id, cat.descripcion FROM pokem AS pk  JOIN poke_poder as pk_pd 
                    ON pk.poke_id = pk_pd.poke_id INNER JOIN poderes AS pd ON pd.poder_id = pk_pd.poder_id 
                    INNER JOIN categoria AS cat ON cat.categoria_id = pk.categoria_id WHERE pk.poke_id=@Id",
                      (pk, pd, cat) =>
                      {
                          pk.Poderes = pk.Poderes ?? new List<Poder>();
                          pk.Poderes.Add(pd);
                          pk.Categoria = cat;
                          return pk;
                      }, new { Id = id }).FirstOrDefault();
            }
            catch( Exception e )
            {
                throw e;
            }
            finally
            {
                Disconnect();
              
            }

            return pokemon;
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


        public List<Pokemones> multipleQueries()
        {
         
                var query = Connect()
                    .Query<Pokemones, Poder, Categoria, Pokemones>($@"
                    SELECT pk.poke_id, pk.nombre,  pk.salud, pk_pd.poder_id, pd.descripcion, 
                    pk.categoria_id, cat.descripcion FROM pokem AS pk  JOIN poke_poder as pk_pd 
                    ON pk.poke_id = pk_pd.poke_id INNER JOIN poderes AS pd ON pd.poder_id = pk_pd.poder_id 
                    INNER JOIN categoria AS cat ON cat.categoria_id = pk.categoria_id",
                        (pk, pd, cat) =>
                        {
                            pk.Poderes = pk.Poderes ?? new List<Poder>();
                            pk.Poderes.Add( pd );
                            pk.Categoria = cat;
                            return pk;
                        })//, splitOn: "poderes_id, categoria_id" 
                    .AsQueryable();

                return query.ToList();
        
        }

    }
}
