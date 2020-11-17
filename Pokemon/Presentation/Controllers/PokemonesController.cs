using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokemon.Services.Mappers;
using Pokemon.Common.Entities;
using Pokemon.Services.Facade;
using Pokemon.Logic.Commands;
using Pokemon.Logic.Commands.Pokemon;

namespace Pokemon.Controllers
{
    [ApiController]
    [Route("poke")]
    public class Pokemones : ControllerBase
    {
        private readonly ILogger<Common.Entities.Pokemones> _logger;

        public Pokemones(ILogger<Common.Entities.Pokemones> logger)
        {
            _logger = logger;
        }



        [Route("addPokemon")]
        [HttpPost]
        public void Post([FromBody]PokemonDto dto)
        {
            try
            {
                if( ModelState.IsValid )
                {
                    Entity pokemon = PokemonMapper.MapDtoToEntity(dto);

                    Command comando;

                    comando = new CommandAddPokemon(pokemon);

                    comando.Execute();
                }

            }
            catch (Exception exc)
            {

            }
            
        }

        [HttpPut("{id}")]
        public void Put( int id, [FromBody]PokemonDto dto)
        {
            if (ModelState.IsValid)
            {
                Entity pokemon = PokemonMapper.MapDtoToEntity(dto);

                Command comando;

                comando = new CommandUpdatePokemon(pokemon);

                comando.Execute();
            }
        }

        [HttpDelete]
        public void Delete( [FromBody]PokemonDto dto )
        {

            Entity pokemon = PokemonMapper.MapDtoToEntity(dto);

            Command comando;

            comando = new CommandUpdatePokemon(pokemon);

            comando.Execute();
        }

        [HttpGet("{id}")]
        public ActionResult<Pokemones> Get(int id)
        {
           
            return Ok();
            
        }



    }
}
