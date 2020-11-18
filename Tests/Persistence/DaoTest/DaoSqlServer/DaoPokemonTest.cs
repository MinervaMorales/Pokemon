using NUnit.Framework;
using Pokemon.Common.Entities;
using Pokemon.Persistence.DaoSqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Persistence.DaoSqlServer.DaoTest
{
    [TestFixture]
    public class DaoPokemonTest: DaoTest
    {

        DaoPokemon _dao = new DaoPokemon();
        Pokemones _pokemon;

        [Test]
        public void Add()
        {
            List<Poder> poderes = new List<Poder>();

            for (int i = 0; i < 5; i++)
            {
                Poder poder = new Poder(i + 1, "poder " + i);
                poderes.Add(poder);
            }
            _pokemon = new Pokemones("pokemon 1", poderes, new Categoria(1, "categoria 1"), 500, "observacion");


            Pokemones result = _dao.Add( _pokemon );
            
            _pokemon = result;
            
            Assert.NotZero( result.Id );

        }

        [Test]
        public void GetAll()
        {
            Assert.IsNotNull(_dao.GetAll());
        }

        [Test]
        public void Update()
        {
            int cantidadPoderes = _pokemon.Poderes.Count;

            _pokemon.Nombre = "Pokemon Cambiado";
            _pokemon.Poderes.RemoveAt(0);

            _dao.Update(_pokemon);

           Pokemones result = _dao.GetById(_pokemon.Id);
            Assert.AreNotEqual(result.Poderes.Count, cantidadPoderes );
        }

      

        [Test]
        public void Delete()
        {
            int id = _pokemon.Id;
            
            _dao.Delete(_pokemon.Id);
           
            Assert.IsNull( _dao.GetById( id ) );

        }

    }
}
