using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab02.Models
{
    public class JsonDataProvider<T>
    {
        public JsonDataProvider(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", $"{typeof(T).Name}.json"); }
        }

        public IEnumerable<T> GetData()
        {
            try
            {
                using (var jsonFileReader = File.OpenText(JsonFileName))
                {
                    return JsonSerializer.Deserialize<T[]>(jsonFileReader.ReadToEnd(),
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                }
            }
            catch
            {
                return new T[0];
            }
        }

        public void AddData(T newData)
        {
            var oldData = GetData();
            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<T>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    oldData.Append(newData)
                );
            }
        }
    }
}
