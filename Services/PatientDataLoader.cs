using FocalTest2.Model;
using System.Text.Json;
using System.IO;

namespace FocalTest2.Services
{
    internal class PatientDataLoader
    {
        public async Task<PatientData> LoadPatientDataAsync(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            var json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<PatientData>(json);
        }
    }
}
