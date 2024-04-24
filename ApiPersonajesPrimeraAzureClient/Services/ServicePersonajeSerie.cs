using ApiPersonajesAzureClient.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiPersonajesPrimeraAzureClient.Services
{
    public class ServicePersonajeSerie
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue header;
        public ServicePersonajeSerie(IConfiguration configuration)
        {
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
            this.UrlApi = configuration.GetValue<string>("ApiUrls:ApiPersonajesSerie");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<PersonajeSerie>> GetPersonajesAsync()
        {
            string request = "api/personajesseries/personajes";
            List<PersonajeSerie> data = await CallApiAsync<List<PersonajeSerie>>(request);
            return data;
        }

        public async Task<List<PersonajeSerie>> GetPersonajeSeriesAsync(string serie)
        {
            string request = "api/personajesseries/personajesseries/"+serie;
            List<PersonajeSerie> data = await CallApiAsync<List<PersonajeSerie>>(request);
            return data;
        }

        public async Task<List<string>> GetSeriesAsync()
        {
            string request = "api/personajesseries/series";
            List<string> data = await CallApiAsync<List<string>>(request);
            return data;
        }

        //Metodos de accion
        public async Task InsertPersonajeAsync(int idpersonaje, string nombre, string imagen, string serie)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/personajesseries/insertpersonaje";
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                PersonajeSerie pj= new PersonajeSerie();
                pj.IdPersonaje = idpersonaje;
                pj.Nombre = nombre;
                pj.Imagen = imagen;
                pj.Serie = serie;
                string json = JsonConvert.SerializeObject(pj);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage reponse = await client.PostAsync(request, content);
            }
        }

        public async Task UpdatePersonajeAsync(int idpersonaje, string nombre, string imagen, string serie)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/personajesseries/insertpersonaje";
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                PersonajeSerie pj = new PersonajeSerie();
                pj.IdPersonaje = idpersonaje;
                pj.Nombre = nombre;
                pj.Imagen = imagen;
                pj.Serie = serie;
                string json = JsonConvert.SerializeObject(pj);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage reponse = await client.PostAsync(request, content);
            }
        }

        public async Task DeletePersonajeAsync(int idpersonaje)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/personajesseries/deletepersonaje/" + idpersonaje;
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage response = await client.DeleteAsync(request);
            }
        }
    }
}
