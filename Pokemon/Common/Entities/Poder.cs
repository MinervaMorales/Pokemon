

namespace Pokemon.Common.Entities
{
    public class Poder: Entity
    {
        public string Descripcion { get; set; }

        public Poder()
        {

        }
        public Poder( int id, string descripcion )
        {
            Id = id;
            Descripcion = descripcion;
        }

    }
}
