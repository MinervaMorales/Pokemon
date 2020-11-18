using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokemon.Services.Mappers;
using Pokemon.Common.Entities;
using Pokemon.Services.Facade;
using Pokemon.Logic.Commands;
using Pokemon.Logic.Commands.Pokemon;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Pokemon.Controllers
{
    [ApiController]
    [Route("pokemon")]
    public class PokemonesController : ControllerBase
    {
        private readonly ILogger<Common.Entities.Pokemones> _logger;

        public PokemonesController()
        {
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody]PokemonDto dto)
        {
            try
            {
                if (ModelState.IsValid && dto != null )
                {
                    Pokemones pokemon = PokemonMapper.MapDtoToEntity(dto);

                    Command comando;

                    comando = new CommandAddPokemon(pokemon);

                    comando.Execute();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
            return Ok();

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put([FromBody]PokemonDto dto)
        {
            try
            {
                if (ModelState.IsValid && dto != null)
                {
                    Entity pokemon = PokemonMapper.MapDtoToEntity(dto);

                    Command comando;

                    comando = new CommandUpdatePokemon(pokemon);

                    comando.Execute();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch( Exception e )
            {
                return StatusCode(500);
            }

            return Ok();
          
        }

        [HttpDelete]
        public ActionResult Delete( [FromBody]PokemonDto dto )
        {
            try
            {
                Entity pokemon = PokemonMapper.MapDtoToEntity(dto);

                Command comando;

                comando = new CommandDeletePokemon(pokemon);

                comando.Execute();
            }
            catch( Exception e )
            {
                return StatusCode(500);
            }
            return Ok();
            
        }

        [HttpGet("{id}")]
        public ActionResult<PokemonesController> GetById( int id )
        {
            PokemonDto dto = new PokemonDto();
            dto.IdPokemon = id;

            try
            {
                Pokemones pokemon = PokemonMapper.MapDtoToEntity( dto );

                Command comando;

                comando = new  CommandGetByIdPokemon( pokemon );

                comando.Execute();
                Pokemones result = comando.GetEntity() as Pokemones;
                if( result != null) 
                {
                    dto = PokemonMapper.MapEntityToDto(result);
                }
                else
                {
                    return Ok();
                }
              
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
            return Ok(dto);

        }

      
        [HttpGet]
        public ActionResult<Pokemones> GetAll()
        {

            List<Pokemones> pokemones;
            try
            {
                CommandGetAllPokemon comando;

                comando = new CommandGetAllPokemon();

                comando.Execute();

                pokemones = comando.GetAll();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
            return Ok(pokemones);

        }



    }
}
