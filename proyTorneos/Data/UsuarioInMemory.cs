using Domain.Model;

namespace Data
{
    public class UsuarioInMemory
    {
        public static List<Usuario> Usuarios;

        static UsuarioInMemory()
        {
            Usuarios = new List<Usuario>()
            {
                new Usuario(1, "Luke", "Skywalker", "luke.skywalker@tatooine.sw", "Tatooine", "JediFarmBoy", "admin"),
                new Usuario(2, "Leia", "Organa", "leia.organa@alderaan.sw", "Alderaan", "RebelPrincess", "admin"),
                new Usuario(3, "Han", "Solo", "han.solo@falcon.sw", "Espacio", "ShotFirst", "usuario"),
                new Usuario(4, "Obi-Wan", "Kenobi", "obiwan@jedicouncil.sw", "Tatooine", "HelloThere", "admin"),
                new Usuario(5, "Anakin", "Skywalker", "anakin@coruscant.sw", "Coruscant", "ChosenOne", "usuario"),
                new Usuario(6, "Rey", "Palpatine", "rey@jakku.sw", "Jakku", "Scavenger", "usuario"),
                new Usuario(7, "C-3PO", "Droid", "c3po@protocol.sw", "Coruscant", "GoldenDroid", "usuario"),
                new Usuario(8, "Padmé", "Amidala", "padme@naboo.sw", "Naboo", "QueenAmidala", "admin"),
                new Usuario(9, "R2-D2", "Droid", "r2d2@astromech.sw", "Naboo", "BeepBoop", "usuario"),
                new Usuario(10, "Yoda", "Master", "yoda@dagobah.sw", "Dagobah", "GreenSage", "admin"),
                new Usuario(11, "Chewbacca", "Wookiee", "chewie@kashyyyk.sw", "Kashyyyk", "Aaaaarrrgh", "usuario")
            };
        }
    }
}
