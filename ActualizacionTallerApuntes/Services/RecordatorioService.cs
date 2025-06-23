using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ActualizacionTallerApuntes.Models;

namespace ActualizacionTallerApuntes.Services
{
    public class RecordatorioService
    {
        private static string filePath = Path.Combine(FileSystem.AppDataDirectory, "recordatorios.json");

        public static async Task<List<Recordatorio>> LoadAsync()
        {
            if (!File.Exists(filePath)) return new List<Recordatorio>();
            var json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<List<Recordatorio>>(json) ?? new List<Recordatorio>();
        }

        public static async Task SaveAsync(List<Recordatorio> recordatorios)
        {
            var json = JsonSerializer.Serialize(recordatorios, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}
