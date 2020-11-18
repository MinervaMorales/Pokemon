using Pokemon.Common.Entities;
using Pokemon.Persistence.DaoSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Logic.Commands.Pokemon
{
    public class CommandAddPokemon: Command
    {
        private Pokemones _pokemon;
        private DaoPokemon _dao;

        public CommandAddPokemon( Entity pokemon )
        {
            _pokemon = pokemon as Pokemones;
            _dao = new DaoPokemon();
        }

        /// <summary>
        /// Comando para agregar un nuevo pokemon
        /// </summary>
        public override void Execute()
        {
            
            _pokemon = _dao.Add( _pokemon );
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
