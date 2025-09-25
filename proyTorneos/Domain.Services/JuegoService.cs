using Data;
using Domain.Model;
using DTOs;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Identity.Client;
using System.Security.Cryptography;

namespace Domain.Services
{
    public class JuegoService
    {

        public JuegoDTO Add(JuegoDTO dto)
        {
            var juegoRepository = new JuegoRepository();
            var juego = new Juego (0, dto.Nombre, dto.Descripcion);

            juegoRepository.Add(juego);

            dto.Id = juego.Id;

            return dto; 

        }

        public bool Delete(int id)
        {
            var juegoRepository = new JuegoRepository();
            return juegoRepository.Delete(id);
        }


        public bool Update(JuegoDTO dto)
        {
            var juegoRepository = new JuegoRepository();
            var juego = new Juego(0, dto.Nombre, dto.Descripcion);
            juegoRepository.Add(juego);
            return juegoRepository.Update(juego);
        }

        public JuegoDTO GetOne(int id)
        {
            var juegoRepository = new JuegoRepository();
            var dto = juegoRepository.GetOne(id);
            return new JuegoDTO
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
            };
        }

        public IEnumerable<JuegoDTO> GetAll()
        {
            var juegoRepository = new JuegoRepository();
            var juegos = juegoRepository.GetAll();

            return (from dto in juegos
                    select new JuegoDTO{
                        Id = dto.Id,
                        Nombre = dto.Nombre,
                        Descripcion = dto.Descripcion,
                    }).ToList(); 

        }
    }
}
