using NUnit.Framework;
using Pokemon.Common.Entities;
using Pokemon.Persistence.DaoMongoDB;
using System.Collections.Generic;
using Tests.Persistence.DaoTestMongo;

namespace Tests.Persistence.DaoTest.DaoTestMongo
{
    [TestFixture]
    public class DaoMongoPokemon: DaoMongoTest
    {
        DaoMongo _dao = new DaoMongo();
        Pokemones _pokemon;

        [Test]
        public void Add()
        {
            _dao.Connect(); 
            List<Poder> poderes = new List<Poder>();

            for (int i = 0; i < 5; i++)
            {
                Poder poder = new Poder(i + 1, "poder " + i);
                poderes.Add(poder);
            }
            Pokemones pokemon = new Pokemones("pokemon 1", poderes, new Categoria(1, "categoria 1"), 500, "observacion");

            Pokemones result = _dao.Add(pokemon);

            _pokemon = result;

            Assert.NotNull(result);

        }

        [Test]
        public void GetAll()
        {
            _dao.Connect();
            Assert.IsNotNull(_dao.GetAll());
        }

        [Test]
        public void GetById()
        {
            _dao.Connect();
            Assert.IsNotNull(_dao.GetById(1));

        }

    }
}
