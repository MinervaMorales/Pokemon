using Pokemon.Common.Entities;
using System.Collections.Generic;

namespace Pokemon.Services.Facade
{
    public class PokemonDto
    {
        public int IdPokemon { get; set; }
        public string Nombre { get; set; }
        public Categoria Categoria { get; set; }
        public int Salud { get; set; }
        public string Observaciones { get; set; }
        public List<Poder> Poderes{ get; set; }

    }
}
