
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Pokemon.Common.Entities
{
    public class Pokemones: Entity
    {
    
        public string Nombre { get; set; }
        public List<Poder> Poderes { get; set; }
        public int Salud { get; set; }
        public Categoria Categoria { get; set; }
        public string Observaciones { get; set; }


        public Pokemones()
        {

        }
        public Pokemones( string nombre, List<Poder> poderes, Categoria categoria, int salud, string observaciones )
        {
            Nombre = nombre;
            Poderes = poderes;
            Categoria = categoria;
            Salud = salud;
            Observaciones = observaciones;

        }
    }
}
