using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace labs3
{
    public class Client_rep_yaml : Client_rep
    {
        private const string filePath = "C:\\Ycheba\\C#\\Panesh1\\Panesh1\\clients.yaml";
        private int nextId = 1;

        public override void LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                var yaml = File.ReadAllText(filePath);
                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();
                clients = deserializer.Deserialize<List<Client>>(yaml);
                nextId = clients.Count > 0 ? clients.Max(c => c.getId()) + 1 : 1;
            }
        }
        public override void SaveToFile()
        {
            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            var yaml = serializer.Serialize(clients);
            File.WriteAllText(filePath, yaml);
        }
    }
}
