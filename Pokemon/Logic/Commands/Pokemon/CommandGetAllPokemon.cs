using Pokemon.Common.Entities;
using Pokemon.Persistence.DaoMongoDB;
using System;
using System.Collections.Generic;

namespace Pokemon.Logic.Commands.Pokemon
{
    public class CommandGetAllPokemon: Command
    {

        private Pokemones _pokemon;
        public List<Pokemones> _pokemones;
        private DaoMongo _dao;

        public CommandGetAllPokemon()
        {
            _dao = new DaoMongo();
        }

        /// <summary>
        /// Comando para agregar un nuevo pokemon
        /// </summary>
        public override void Execute()
        {

           //_pokemones = _dao.GetAll();
        }

        public override Entity GetEntity()
        {
            return _pokemon;
        }

        public override List<Entity> GetEntities()
        {
            throw new NotImplementedException();
        }


        public List<Pokemones> GetAll()
        {
            return _pokemones;
        }
    }
}
