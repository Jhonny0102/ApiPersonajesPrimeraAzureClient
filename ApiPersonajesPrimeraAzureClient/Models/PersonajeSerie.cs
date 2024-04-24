using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPersonajesAzureClient.Models
{
    public class PersonajeSerie
    {
        [JsonProperty("idPersonaje")]
        public int IdPersonaje { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("imagen")]
        public string Imagen { get; set; }
        [JsonProperty("serie")]
        public string Serie { get; set; }
    }
}
