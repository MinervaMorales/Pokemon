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
        public Pokemones Add(Pokemones pokemon)
        {
            string query = @"INSERT INTO pokem (nombre, categoria_id, salud, observaciones) OUTPUT INSERTED.poke_id VALUES (@Nombre,@Categoria, @Salud, @Observaciones)";
            
            var cnn = Connect();
            
            using (var trans = cnn.BeginTransaction())
            {
                try
                {

                   pokemon.Id =  cnn.QuerySingle<int>( query, new { Nombre = pokemon.Nombre, Categoria = pokemon.Categoria.Id, Salud = pokemon.Salud, Observaciones = pokemon.Observaciones }, trans );
                    
                    foreach ( Poder poder in pokemon.Poderes )
                    {
                        string processQuery = "INSERT INTO poke_poder (poke_id, poder_id) VALUES (@poke_id,@poder_id)";

                        cnn.Execute(processQuery, new { poke_id = pokemon.Id, poder_id = poder.Id }, transaction: trans);
                    }

                    trans.Commit();
                 

                }
                catch (Exception e)
                {
                    trans.Rollback();
                }
                finally
                {
                    Disconnect();
                }
            }

            return pokemon;
         
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
                    }, splitOn: "poder_id, categoria_id")
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
                      }, new { Id = id }, splitOn: "poder_id, categoria_id").FirstOrDefault();
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
 
           string sQuery = @"DELETE FROM Pokem WHERE poke_id=@Id";
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
            
            string updateQuery = @"UPDATE pokem SET nombre=@Nombre, categoria_id=@CategoriaId, salud=@Salud, Observaciones=@Observaciones  where poke_id=@Id";

            var cnn = Connect();

            using (var trans = cnn.BeginTransaction())
            {
                try
                {

                    cnn.Execute(updateQuery, new { Nombre = pokemon.Nombre, CategoriaId = pokemon.Categoria.Id, Salud = pokemon.Salud, Observaciones = pokemon.Observaciones, Id= pokemon.Id }, transaction: trans);

                    string deleteQuery = @"DELETE FROM poke_poder WHERE poke_id=@pokeId";

                    cnn.Execute(deleteQuery, new { pokeId = pokemon.Id }, transaction: trans);
                    
                    foreach (Poder poder in pokemon.Poderes)
                    {
                        string processQuery = "INSERT INTO poke_poder (poke_id, poder_id) VALUES (@poke_id,@poder_id)";

                        cnn.Execute(processQuery, new { poke_id = pokemon.Id, poder_id = poder.Id }, transaction: trans);
                    }
                    
                    trans.Commit();
                }
                catch (Exception e)
                {
                    trans.Rollback();
                }
                finally
                {
                    Disconnect();
                }
            }

        }


    }
}
