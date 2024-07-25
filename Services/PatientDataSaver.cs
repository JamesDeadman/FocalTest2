using FocalTest2.Model;
using System.Text.Json;
using System.IO;

namespace FocalTest2.Services
{
    internal class PatientDataSaver
    {
        public async Task SavePatientDataAsync(PatientData patientData, string filePath)
        {
            var json = JsonSerializer.Serialize(patientData, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}
