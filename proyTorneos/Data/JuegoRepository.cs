using Domain.Model;

namespace Data
{
    public class JuegoRepository
    {

        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public Juego GetOne(int id)
        {
            using var context = CreateContext();
            return context.Juegos.Find(id); 
        }

        public IEnumerable<Juego> GetAll()
        {
            using var context = CreateContext();
            return context.Juegos.ToList();
        }

        public void Add(Juego juego)
        {
            using var context = CreateContext();
            context.Juegos.Add(juego);
            context.SaveChanges();
        }


        public bool Delete(int id)
        {
            using var context = CreateContext();
            var juego = context.Juegos.Find(id);

            if (juego != null)
            {
                context.Juegos.Remove(juego);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false; 
            }
        }

        public bool Update(Juego juego)
        {
            using var context = CreateContext();
            var JuegoUpdate = context.Juegos.Find(juego.Id);
            if (JuegoUpdate != null)
            {
                JuegoUpdate.Nombre = juego.Nombre;
                JuegoUpdate.Descripcion = juego.Descripcion;
                context.SaveChanges();
                return true; 
            }
            else
            {
                return false; 
            }
        }
    }

}
