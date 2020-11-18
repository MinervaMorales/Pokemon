using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Dapper;
using Microsoft.Extensions.Configuration;
using Pokemon.Common.Entities;

namespace Pokemon.Persistence
{
    public class Dao
    {

        private IDbConnection _connection;

        private string _connectionString { get; set; }

        private IConfiguration _configuration { get; }

        public Dao()
        {
            IConfigurationBuilder config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables();

            _configuration = config.Build();
        }
        /// <summary>
        /// Metodo para obtener el string de conexion de la base de datos
        /// </summary>
        /// <param name="configuration"></param>
        public void getConnectionString()
        {
            _connectionString = _configuration.GetConnectionString("sqlServer");
        }

        
        /// <summary>
        /// Metodo que crea la conexion con la base de datos
        /// </summary>
        /// <returns></returns>
        public IDbConnection Connect()
        {
            try
            {
                if( !IsConnected() )
                {
                    getConnectionString();
                    _connection = new SqlConnection( _connectionString );
                    _connection.Open();
                }
            }
            catch( SqlException e )
            {
                throw e;
            }
            catch( Exception e )
            {
                throw e;
            }
            
            return _connection;
        }

        /// <summary>
        /// Metodo que pregunta si esta abierta la conexion con la base de datos
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            if( _connection == null )
            {
                return false;
            }
            else
            {
                return _connection.State == System.Data.ConnectionState.Open;
            }    
    
        }

        /// <summary>
        /// Metodo que cierra la conexion con la base de datos
        /// </summary>
        public void Disconnect()
        {
            if ( _connection != null && IsConnected() )
                _connection.Close();
        }


        /// <summary>
        /// Metodo encargado de ejecutar un query 
        /// </summary>
        /// <param name="query">Query a ejecutar</param>
        /// <param name="entity"></param>
        public void Execute(string query, Entity entity)
        {
         
            _connection.Execute(query, entity);
           
        }



    }
}
