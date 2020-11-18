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
            entity.Categoria = dto.Categoria;
            entity.Salud = dto.Salud;
            entity.Observaciones = dto.Observaciones;
            entity.Poderes = dto.Poderes;

            return entity;
        }

        public static PokemonDto MapEntityToDto(Pokemones entity)
        {
            PokemonDto dto = new PokemonDto();

            dto.IdPokemon = entity.Id;
            dto.Nombre = entity.Nombre;
            dto.Poderes = entity.Poderes;
            dto.Categoria = entity.Categoria;
            dto.Salud = entity.Salud;
            dto.Observaciones = entity.Observaciones;

            return dto;
        }
    }
}
