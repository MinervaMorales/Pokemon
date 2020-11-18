using Pokemon.Common.Entities;
using Pokemon.Persistence.DaoMongoDB;
using System.Collections.Generic;

namespace Pokemon.Logic.Commands.Pokemon
{
    public class CommandGetByIdPokemon: Command
    {
        private Pokemones _pokemon;
        public List<Entity> _pokemones;
        private DaoMongo _dao;

        public CommandGetByIdPokemon( Pokemones pokemon)
        {
            _dao = new DaoMongo();
            _pokemon = pokemon;
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
