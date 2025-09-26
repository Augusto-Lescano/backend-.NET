using DTOs;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.TipoTorneo
{

    public class TipoTorneoApi
    {
        private static HttpClient client = new HttpClient();

        static TipoTorneoApi()
        {
            client.BaseAddress = new Uri("http://localhost:3000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<TipoTorneoDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("tipoTorneos/" + id);

                if (response.IsSuccessStatusCode)
                {
                    var torneo = await response.Content.ReadFromJsonAsync<TipoTorneoDTO>();
                    if (torneo == null)
                    {
                        throw new Exception($"El servidor devolvió una respuesta vacía para el tipo de torneo con Id {id}.");
                    }
                    return torneo;

                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener el tipo de torneo con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener el i con Id {id}: {ex.Message}", ex);
            }
        }

        public async static Task<IEnumerable<TipoTorneoDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("tipoTorneos");

                var torneos = await response.Content.ReadFromJsonAsync<IEnumerable<TipoTorneoDTO>>();
                if (torneos == null)
                {
                    throw new Exception($"El servidor devolvió una respuesta vacía.");
                }
                return torneos;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de tipo de torneos: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de tipo de torneos: {ex.Message}", ex);
            }
        }


        public async static Task AddAsync(TipoTorneoDTO tipoTorneo)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("tipoTorneos", tipoTorneo);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear el tipo de torneo. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexion al crear el tipo de torneo: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear tipo torneo: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("tipoTorneos/" + id);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar el tipo de torneo con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar el tipo de torneo con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar el tipo de torneo con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(TipoTorneoDTO tipoTorneo)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("tipoTorneos", tipoTorneo);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar el tipo de torneo con Id {tipoTorneo.Id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar el tipo de torneo con Id {tipoTorneo.Id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar el tipo de torneo con Id {tipoTorneo.Id}: {ex.Message}", ex);
            }
        }
    }

}