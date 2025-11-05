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

        //Obtener una inscripción por Id
        public static async Task<InscripcionDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"inscripciones/{id}");

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
                    throw new Exception($"Error al obtener la inscripción con Id {id}. Status: {response.StatusCode}. Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener la inscripción con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener la inscripción con Id {id}: {ex.Message}", ex);
            }
        }

        //Obtener todas las inscripciones
        public static async Task<IEnumerable<InscripcionDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("inscripciones");

                if (response.IsSuccessStatusCode)
                {
                    var inscripciones = await response.Content.ReadFromJsonAsync<IEnumerable<InscripcionDTO>>();
                    if (inscripciones == null)
                        throw new Exception("El servidor devolvió una respuesta vacía.");

                    return inscripciones;
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener las inscripciones. Status: {response.StatusCode}. Detalle: {errorContent}");
                }
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

        //Crear nueva inscripción
        public static async Task AddAsync(InscripcionDTO inscripcion)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("inscripciones", inscripcion);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear la inscripción. Status: {response.StatusCode}. Detalle: {errorContent}");
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

        //Eliminar inscripción
        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"inscripciones/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar la inscripción con Id {id}. Status: {response.StatusCode}. Detalle: {errorContent}");
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

        //Actualizar inscripción
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
                throw new Exception($"Error de conexión al actualizar la inscripción con Id {inscripcion.Id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar la inscripción con Id {inscripcion.Id}: {ex.Message}", ex);
            }
        }

        //Inscribir usuario individual
        public static async Task InscribirUsuarioAsync(int inscripcionId, int usuarioId)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync(
                    $"inscripciones/{inscripcionId}/usuarios/{usuarioId}", null);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al inscribir usuario. Status: {response.StatusCode}. Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al inscribir usuario: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al inscribir usuario: {ex.Message}", ex);
            }
        }

        //Inscribir equipo (solo por líder)
        public static async Task InscribirEquipoAsync(int inscripcionId, int equipoId)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync(
                    $"inscripciones/{inscripcionId}/equipos/{equipoId}", null);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al inscribir equipo. Status: {response.StatusCode}. Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al inscribir equipo: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al inscribir equipo: {ex.Message}", ex);
            }
        }

        public static async Task EliminarUsuarioDeInscripcionAsync(int inscripcionId, int usuarioId)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(
                    $"inscripciones/{inscripcionId}/usuarios/{usuarioId}");

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar usuario: {response.StatusCode}. Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión: {ex.Message}", ex);
            }
        }

        public static async Task EliminarEquipoDeInscripcionAsync(int inscripcionId, int equipoId)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(
                    $"inscripciones/{inscripcionId}/equipos/{equipoId}");

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar equipo: {response.StatusCode}. Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión: {ex.Message}", ex);
            }
        }
    }
}
