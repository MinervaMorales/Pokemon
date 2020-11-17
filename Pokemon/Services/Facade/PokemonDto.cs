using Pokemon.Common.Entities;
using System.Collections.Generic;

namespace Pokemon.Services.Facade
{
    public class PokemonDto
    {
        public long IdPokemon { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public List<Poder> Poderes{ get; set; }

    }
}
