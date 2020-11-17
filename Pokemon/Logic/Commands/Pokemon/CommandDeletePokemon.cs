using Pokemon.Common.Entities;
using Pokemon.Persistence.DaoSqlServer;
using System;
using System.Collections.Generic;

namespace Pokemon.Logic.Commands.Pokemon
{
    public class CommandDeletePokemon: Command
    {
        private Pokemones _pokemon;
        private DaoPokemon _dao;

        public CommandDeletePokemon(Entity pokemon)
        {
            _pokemon = pokemon as Pokemones;
            _dao = new DaoPokemon();
        }

        /// <summary>
        /// Comando para agregar un nuevo pokemon
        /// </summary>
        public override void Execute()
        {

            _dao.Delete( _pokemon.Id );
        }

        public override Entity GetEntity()
        {
            return _pokemon;
        }

        public override List<Entity> GetEntities()
        {
            throw new NotImplementedException();
        }

    }
}
