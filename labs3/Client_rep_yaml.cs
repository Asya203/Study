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
    public class Client_rep_yaml
    {
        private List<Client> clients = new List<Client>();
        private const string filePath = "C:\\Ycheba\\C#\\Panesh1\\Panesh1\\clients.yaml";
        private int nextId = 1;

        public void LoadClients()
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

        public void SaveClients()
        {
            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            var yaml = serializer.Serialize(clients);
            File.WriteAllText(filePath, yaml);
        }

        public Client GetClientById(int id)
        {
            return clients.FirstOrDefault(c => c.getId() == id);
        }

        public List<Client> GetKNSortList(int n, int k)
        {
            return clients.Skip(n).Take(k).ToList();
        }

        public void GetInfolist(List<Client> clientsinfo)
        {
            for (int i = 0; i < clientsinfo.Count; i++)
            {
                Console.WriteLine(clientsinfo[i].toMyString());
            }
        }
        public void GetInfolist()
        {
            for (int i = 0; i < clients.Count; i++)
            {
                Console.WriteLine(clients[i].toMyString());
            }

        }

        public void SortByField(string fieldName)
        {
            switch (fieldName.ToLower())
            {
                case "lastname":
                    clients.Sort((x, y) => string.Compare(x.GetLastName(), y.GetLastName()));
                    break;
                case "firstname":
                    clients.Sort((x, y) => string.Compare(x.GetFirstName(), y.GetFirstName()));
                    break;
                case "passport":
                    clients.Sort((x, y) => string.Compare(x.GetPassport(), y.GetPassport()));
                    break;
                case "middlename":
                    clients.Sort((x, y) => string.Compare(x.GetMiddleName(), y.GetMiddleName()));
                    break;
                case "email":
                    clients.Sort((x, y) => string.Compare(x.GetEmail(), y.GetEmail()));
                    break;
                case "birthday":
                    clients.Sort((x, y) => string.Compare(x.GetBirthday(), y.GetBirthday()));
                    break;
                case "phone":
                    clients.Sort((x, y) => string.Compare(x.GetPhone(), y.GetPhone()));
                    break;

                default:
                    throw new ArgumentException("Неверное имя поля для сортировки.");
            }
        }

        public void AddClient(Client client)
        {
            client.SetId(nextId++);
            clients.Add(client);
            SaveClients();
        }

        public void UpdateClient(int id, Client updatedClient)
        {
            var index = clients.FindIndex(c => c.getId() == id);
            if (index != -1)
            {
                updatedClient.SetId(id);
                clients[index] = updatedClient;
                SaveClients();
            }
        }

        public void DeleteClient(int id)
        {
            var clientToRemove = clients.FirstOrDefault(c => c.getId() == id);
            if (clientToRemove != null)
            {
                clients.Remove(clientToRemove);
                SaveClients();
            }
        }

        public int GetCount()
        {
            return clients.Count;
        }
    }

}
