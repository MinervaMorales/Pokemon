

namespace Pokemon.Common.Entities
{
    public class Categoria: Entity
    {
        public string Descripcion { get; set; }


        public Categoria()
        {

        }
        public Categoria( int id,  string descripcion )
        {
            Id = id;
            Descripcion = descripcion;
        }
    }

}
