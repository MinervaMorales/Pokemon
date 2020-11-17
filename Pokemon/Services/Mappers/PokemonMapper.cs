using Pokemon.Common.Entities;
using Pokemon.Services.Facade;


namespace Pokemon.Services.Mappers
{
    public class PokemonMapper
    {
        public static Pokemones MapDtoToEntity( PokemonDto dto )
        {
            Pokemones entity = new Pokemones();

            entity.Id = dto.IdPokemon;
            entity.Nombre = dto.Nombre;
            entity.Poderes = dto.Poderes;

            return entity;
        }

        public static PokemonDto MapEntityToDto(Pokemones entity)
        {
            PokemonDto dto = new PokemonDto();

            dto.IdPokemon = entity.Id;
            dto.Nombre = entity.Nombre;
           // dto.Poderes = entity.Poderes;

            return dto;
        }
    }
}
