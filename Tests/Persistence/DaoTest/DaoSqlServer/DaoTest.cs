using NUnit.Framework;
using Pokemon.Persistence;

namespace Tests.Persistence.DaoSqlServer.DaoTest
{
    [TestFixture]
    public class DaoTest
    {

        public Dao dao;

        [SetUp]
        public void SetUp()
        {
            dao = new Dao();
            dao.Connect();
        }


        [TearDown]
        public void CleanUp()
        {
            dao.Disconnect();
        }
    }
}
