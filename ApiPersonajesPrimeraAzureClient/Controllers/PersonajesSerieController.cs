using ApiPersonajesAzureClient.Models;
using ApiPersonajesPrimeraAzureClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesPrimeraAzureClient.Controllers
{
    public class PersonajesSerieController : Controller
    {
        private ServicePersonajeSerie service;
        public PersonajesSerieController(ServicePersonajeSerie service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<PersonajeSerie> pj = await this.service.GetPersonajesAsync();
            ViewData["SERIES"] = await this.service.GetSeriesAsync();
            return View(pj);
        }
        [HttpPost]
        public async Task<IActionResult> Index(string serie)
        {
            List<PersonajeSerie> pj = await this.service.GetPersonajeSeriesAsync(serie);
            ViewData["SERIES"] = await this.service.GetSeriesAsync();
            return View(pj);
        }

        
    }
}
