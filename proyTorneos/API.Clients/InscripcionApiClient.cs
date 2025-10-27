using DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class InscripcionApiClient
    {
        private static readonly HttpClient client = new HttpClient();

        static InscripcionApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:3000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<InscripcionDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("inscripciones/" + id);

                if (response.IsSuccessStatusCode)
                {
                    var inscripcion = await response.Content.ReadFromJsonAsync<InscripcionDTO>();
                    if (inscripcion == null)
                        throw new Exception($"El servidor devolvió una respuesta vacía para la inscripción con Id {id}.");

                    return inscripcion;
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener la inscripción con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener la inscripción con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<InscripcionDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("inscripciones");

                var inscripciones = await response.Content.ReadFromJsonAsync<IEnumerable<InscripcionDTO>>();
                if (inscripciones == null)
                    throw new Exception("El servidor devolvió una respuesta vacía.");

                return inscripciones;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de inscripciones: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de inscripciones: {ex.Message}", ex);
            }
        }

        public static async Task AddAsync(InscripcionDTO inscripcion)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("inscripciones", inscripcion);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear la inscripción. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear la inscripción: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear inscripción: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("inscripciones/" + id);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar la inscripción con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar la inscripción con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar la inscripción con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(InscripcionDTO inscripcion)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("inscripciones", inscripcion);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar la inscripción con Id: {inscripcion.Id}. Status: {response.StatusCode}. Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar la inscripción con Id:{inscripcion.Id}. Mensaje: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar la inscripción con Id:{inscripcion.Id}. Mensaje: {ex.Message}", ex);
            }
        }
    }
}
