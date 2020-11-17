using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Pokemon.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Pokemon.Persistence.DaoMongoDB
{
    public class DaoMongo
    {

        private IMongoClient _connection;
        private IMongoCollection<Pokemones> _collection;
        private DataTable _dataTable;

        private string _connectionString { get; set; }
        private string _database { get; set;  }


        /// <summary>
        /// Metodo para obtener el string de conexion de la base de datos
        /// </summary>
        /// <param name="configuration"></param>
        public void getConnectionString(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("mongoDb");
            _database = configuration.GetValue<string>("mongo:database");
        }


        /// <summary>
        /// Metodo que crea la conexion con la base de datos
        /// </summary>
        /// <returns></returns>
        public IMongoClient Connect()
        {
            try
            {
                if (_connection == null)
                {
                    _connection = new MongoClient(_connectionString);
                    _connection.StartSession();
                }
            }
            catch ( MongoException e )
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            return _connection;
        }


        /// <summary>
        /// Metodo que busca todos los pokemones
        /// </summary>
        /// <param name="query">Query a ejecutar</param>
        /// <param name="entity"></param>
        public void GetAll()
        {
            IMongoDatabase database = _connection.GetDatabase( _database );
            _collection = database.GetCollection<Pokemones>( "Pokemon" );

            //return _collection;
            
        }

        /// <summary>
        /// Metodo que busca un pokemon por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pokemones GetById( long id )
        {
           return _collection.Find(sub => sub.Id == id).SingleOrDefault();

        }

    }
}
