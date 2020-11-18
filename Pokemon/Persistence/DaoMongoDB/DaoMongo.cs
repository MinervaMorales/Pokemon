using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Pokemon.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Pokemon.Persistence.DaoMongoDB
{
    public class DaoMongo
    {

        private IMongoClient _connection;
        private IMongoCollection<Pokemones> _collection;
        private IMongoDatabase _database;

        private string _connectionString { get; set; }
        private string _databaseName { get; set;  }
        
        private IConfiguration _configuration { get; }

        public DaoMongo()
        {
            IConfigurationBuilder config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables();

            _configuration = config.Build();

            Connect();
        }

        /// <summary>
        /// Metodo para obtener el string de conexion de la base de datos
        /// </summary>
        /// <param name="configuration"></param>
        public void getConnectionString()
        {
            _connectionString = _configuration.GetConnectionString("mongoDb");
            _databaseName = _configuration.GetValue<string>("mongo:database");
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
                    getConnectionString();
                    _connection = new MongoClient(_connectionString);
                    _database = _connection.GetDatabase(_databaseName);
                    _collection = _database.GetCollection<Pokemones>("Pokemones");

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
        /// Metodo que agrega un documento a la base de datos
        /// </summary>
        /// <param name="pokemon">nuevo pokemon a agregar</param>
        /// <returns></returns>
        public Pokemones Add(Pokemones pokemon)
        {
            
            _collection = _database.GetCollection<Pokemones>("Pokemones");
            _collection.InsertOne( pokemon );

            return pokemon;
        }

        /// <summary>
        /// Metodo que actualiza un documento en la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pokemon"></param>
        public void Update( int id, Pokemones pokemon)
        {
            _collection = _database.GetCollection<Pokemones>("Pokemones");
            _collection.ReplaceOne(poke => poke.Id == id, pokemon);
        }

        /// <summary>
        /// Metodo que busca todos los pokemones
        /// </summary>
        /// <param name="query">Query a ejecutar</param>
        /// <param name="entity"></param>
        public List<Pokemones> GetAll()
        {
            _collection = _database.GetCollection<Pokemones>("Pokemones");
            return _collection.Find(_=> true).ToList();

        }

        /// <summary>
        /// Metodo que busca un pokemon por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pokemones GetById( int id )
        {
            _collection = _database.GetCollection<Pokemones>("Pokemones");
            return _collection.Find(sub => sub.Id == id).SingleOrDefault();

        }

    }
}
