using DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class EquipoApiClient
    {
        private static readonly HttpClient client = new HttpClient();

        static EquipoApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:3000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<EquipoDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("equipos/" + id);

                if (response.IsSuccessStatusCode)
                {
                    var equipo = await response.Content.ReadFromJsonAsync<EquipoDTO>();
                    if (equipo == null)
                        throw new Exception($"El servidor devolvió una respuesta vacía para el equipo con Id {id}.");

                    return equipo;
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener el equipo con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener el equipo con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<EquipoDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("equipos");

                var equipos = await response.Content.ReadFromJsonAsync<IEnumerable<EquipoDTO>>();
                if (equipos == null)
                    throw new Exception("El servidor devolvió una respuesta vacía.");

                return equipos;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de equipos: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de equipos: {ex.Message}", ex);
            }
        }

        public static async Task AddAsync(EquipoDTO equipo)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("equipos", equipo);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear el equipo. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear el equipo: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear equipo: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("equipos/" + id);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar el equipo con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar el equipo con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar el equipo con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(EquipoDTO equipo)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("equipos", equipo);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar el equipo con Id: {equipo.Id}. Status: {response.StatusCode}. Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar el equipo con Id:{equipo.Id}. Mensaje: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar el equipo con Id:{equipo.Id}. Mensaje: {ex.Message}", ex);
            }
        }

        public static async Task<EquipoDTO?> GetEquipoDelUsuarioAsync(int usuarioId)
        {
            try
            {
                //API endpoint: "equipos/usuario/{usuarioId}"
                HttpResponseMessage response = await client.GetAsync($"equipos/usuario/{usuarioId}");

                if (response.IsSuccessStatusCode)
                {
                    var equipo = await response.Content.ReadFromJsonAsync<EquipoDTO>();
                    if (equipo == null)
                        throw new Exception($"El servidor devolvió una respuesta vacía para el equipo del usuario con Id {usuarioId}.");

                    return equipo;
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener el equipo del usuario con Id {usuarioId}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener el equipo del usuario con Id {usuarioId}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener el equipo del usuario con Id {usuarioId}: {ex.Message}", ex);
            }
        }
    }
}
