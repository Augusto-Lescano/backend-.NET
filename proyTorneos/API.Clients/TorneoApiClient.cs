using DTOs;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class TorneoApiClient
    {
        private static HttpClient client = new HttpClient();
        private static int usuarioId; //Guarda el ID del usuario conectado

        public static void SetUsuarioConectado(int usuario)
        {
            usuarioId = usuario;
        }

        static TorneoApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:3000");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<TorneoDTO> GetAsync(int id) {
            try
            {
                HttpResponseMessage response = await client.GetAsync("torneos/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<TorneoDTO>();
                }
                else {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener el torneo con el Id: {id}. Status: {response.StatusCode}. Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex) {
                throw new Exception($"Error de conexion al obtener el torneo con el Id: {id}. Mensaje: {ex.Message}",ex);
            }
            catch(TaskCanceledException ex) {
                throw new Exception($"Timeout al obtener el torneo con el Id: {id}. Mensaje: {ex.Message}", ex);
            }
        }

        public async static  Task<IEnumerable<TorneoDTO>> GetAllAsync() {
            try {
                HttpResponseMessage response = await client.GetAsync("torneos");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<TorneoDTO>>();
                }
                else {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener los torneos. Status: {response.StatusCode}. Detalle: {errorContent}");
                }
            }
            catch(HttpRequestException ex) {
                throw new Exception($"Error de conexion al obtener los torneos. Mensaje: {ex.Message}", ex);
            }
            catch(TaskCanceledException ex) {
                throw new Exception($"Timeout al obtener los torneos. Mensaje: {ex.Message}", ex);
            }
        }

        public static async Task AddAsync(TorneoDTO torneo) {
            try {
                client.DefaultRequestHeaders.Remove("X-Usuario-Id");
                client.DefaultRequestHeaders.Add("X-Usuario-Id", usuarioId.ToString());

                HttpResponseMessage response = await client.PostAsJsonAsync("torneos",torneo);

                if (!response.IsSuccessStatusCode) {
                    string errorContent = await response.Content.ReadAsStringAsync();

                    throw new Exception($"Error crear el torneo. Status: {response.StatusCode}. Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexion al crear el torneo. Mensaje: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear el torneo. Mensaje: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id) {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("torneos/" + id);
                if (!response.IsSuccessStatusCode) {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar un torneo. Status: {response.StatusCode}. Detalle: {errorContent}");
                }

            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexion al borrar el torneo con Id:{id}. Mensaje: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al borrar el torneo con Id:{id}. Mensaje: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(TorneoDTO torneo)
        {
            try {
                HttpResponseMessage response = await client.PutAsJsonAsync("torneos", torneo);
                if (!response.IsSuccessStatusCode) {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar el torneo con Id: {torneo.Id}. Status: {response.StatusCode}. Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexion al actualizar el torneo con Id:{torneo.Id}. Mensaje: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar el torneo con Id:{torneo.Id}. Mensaje: {ex.Message}", ex);
            }
        }

        //Solo actualiza fechas 
        public static async Task UpdateFechasInscripcionAsync(int torneoId, DateTime fechaInicio, DateTime fechaFin)
        {
            var dto = new
            {
                FechaInicio = fechaInicio,
                FechaFin = fechaFin
            };

            var response = await client.PutAsJsonAsync($"torneos/{torneoId}/fechas-inscripcion", dto);

            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar las fechas de inscripción. Status: {response.StatusCode}, Detalle: {error}");
            }
        }


    }
}
