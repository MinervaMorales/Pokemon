using NUnit.Framework;
using Pokemon.Persistence.DaoMongoDB;

namespace Tests.Persistence.DaoTestMongo
{
    [TestFixture]
    public class DaoMongoTest
    {
        public DaoMongo dao;

        [SetUp]
        public void SetUp()
        {
            dao = new DaoMongo();
            dao.Connect();
        }


      
    }
}
