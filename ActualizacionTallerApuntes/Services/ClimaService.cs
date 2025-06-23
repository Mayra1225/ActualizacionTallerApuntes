using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ActualizacionTallerApuntes.Models;

namespace ActualizacionTallerApuntes.Services
{
    public class ClimaService
    {
        private readonly HttpClient _http = new();

        public async Task<Clima?> ObtenerClimaAsync(double lat, double lon)
        {
            string url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current=temperature_2m,relative_humidity_2m,rain";
            try
            {
                var json = await _http.GetStringAsync(url);
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement.GetProperty("current");
                return new Clima
                {
                    Hora = root.GetProperty("time").GetString(),
                    Temperatura = root.GetProperty("temperature_2m").GetDouble(),
                    Humedad = root.GetProperty("relative_humidity_2m").GetDouble(),
                    Lluvia = root.GetProperty("rain").GetDouble()
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
