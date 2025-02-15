using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Text.Json;
using System.Globalization;

namespace labs3
{
    public class Client_rep_json : Client_rep
    {

        private const string filePath = "C://Ycheba//C#//Panesh1//Panesh1//clients.json";

        // a. Чтение всех значений из файла
        public override void LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                clients = JsonConvert.DeserializeObject<List<Client>>(jsonData);
            }
        }

        // b. Запись всех значений в файл
        public override void SaveToFile()
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(clients, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
