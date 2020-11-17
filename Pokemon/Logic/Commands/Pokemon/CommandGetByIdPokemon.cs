using Pokemon.Common.Entities;
using Pokemon.Persistence.DaoMongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Logic.Commands.Pokemon
{
    public class CommandGetByIdPokemon: Command
    {
        private Pokemones _pokemon;
        public List<Entity> _pokemones;
        private DaoMongo _dao;

        public CommandGetByIdPokemon()
        {
            _dao = new DaoMongo();
        }

        /// <summary>
        /// Comando para agregar un nuevo pokemon
        /// </summary>
        public override void Execute()
        {

            _pokemon = _dao.GetById(_pokemon.Id);
        }

        public override Entity GetEntity()
        {
            return _pokemon;
        }

        public override List<Entity> GetEntities()
        {
            return _pokemones;
        }
    }
}
