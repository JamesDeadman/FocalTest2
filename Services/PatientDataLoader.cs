using FocalTest2.Model;
using System.Text.Json;
using System.IO;
using System.Reflection;

namespace FocalTest2.Services
{
    internal class PatientDataLoader
    {
        public async Task<PatientData> LoadPatientDataAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not exists");
            }
 

            var json = await File.ReadAllTextAsync(filePath);
            var data= JsonSerializer.Deserialize<PatientData>(json);
            
            // base on PatientData model every property must have value
            var deserializeResult = CheckIfAnyPropertyIsNull(data);
            if (!deserializeResult)
            {
                throw new Exception($"Can't deserialize file {filePath}");
            }

            return data;
        }

        //  Should be in separate class/project(Utility
        private static bool CheckIfAnyPropertyIsNull<T>(T obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {

                var value = property.GetValue(obj);

                if (value == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

