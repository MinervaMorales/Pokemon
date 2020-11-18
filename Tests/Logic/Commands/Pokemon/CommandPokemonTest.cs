using NUnit.Framework;
using Pokemon.Common.Entities;
using Pokemon.Logic.Commands;
using Pokemon.Logic.Commands.Pokemon;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Logic.Commands.Pokemon
{
    [TestFixture]
    public class CommandPokemonTest
    {
        Pokemones _pokemon;

        [Test]
        public void CommandAddPokemonTest()
        {
            List<Poder> poderes = new List<Poder>();

            for (int i = 0; i < 5; i++)
            {
                Poder poder = new Poder(i + 1, "poder comando " + i);
                poderes.Add(poder);
            }
            
            _pokemon = new Pokemones("comando 1", poderes, new Categoria(2, "categoria 2"), 600, "observaciones pokemon");

            CommandAddPokemon command = new CommandAddPokemon( _pokemon );
            
            command.Execute();

            _pokemon = command.GetEntity() as Pokemones;

            Assert.NotZero( _pokemon.Id );
            
        }

        [Test]
        public void CommandGetByIdTest() 
        {
            _pokemon.Id = 0;
            CommandGetByIdPokemon command = new CommandGetByIdPokemon( _pokemon );

            command.Execute();

            Pokemones result = command.GetEntity() as Pokemones;
            
            Assert.IsNotNull( result );
        }

        [Test]
        public void CommandUpdatePokemonTest()
        {
            _pokemon.Nombre = "Cambiar Pokemon";

            CommandUpdatePokemon command = new CommandUpdatePokemon( _pokemon );

            command.Execute();

            CommandGetByIdPokemon findCommand = new CommandGetByIdPokemon( _pokemon );

            findCommand.Execute();

            Pokemones result = findCommand.GetEntity() as Pokemones;

            Assert.AreEqual( result.Nombre, _pokemon.Nombre );
        }


        [Test]
        public void CommandDeletePokemonTest()
        {
            CommandDeletePokemon command = new CommandDeletePokemon( _pokemon );
            
            command.Execute();

            CommandGetByIdPokemon findCommand = new CommandGetByIdPokemon(_pokemon );

            findCommand.Execute();

            Pokemones result = findCommand.GetEntity() as Pokemones;

            Assert.IsNull( result );
        }


        
        [Test]
        public void CommandGetAllPokemonTest()
        {

            CommandGetAllPokemon command = new CommandGetAllPokemon();
            command.Execute();

            List<Pokemones> result = command.GetAll();

            Assert.IsNotNull(result);

        }
    }
}
