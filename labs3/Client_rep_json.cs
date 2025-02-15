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
    public class Client_rep_json
    {
        private List<Client> clients = new List<Client>();
        private const string filePath = "C://Ycheba//C#//Panesh1//Panesh1//clients.json";

        // a. Чтение всех значений из файла
        public void LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                clients = JsonConvert.DeserializeObject<List<Client>>(jsonData);
            }
        }

        // b. Запись всех значений в файл
        public void SaveToFile()
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(clients, Newtonsoft.Json.Formatting.Indented));
        }

        // c. Получить объект по ID
        public Client GetById(int id)
        {
            return clients.Find(client => client.getId() == id);
        }

        // d. Получить список k по счету n объектов класса short
        public List<Client> GetKShortList(int n, int k)
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

        // e. Сортировать элементы по выбранному полю
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

        // f. Добавить объект в список
        public void AddClient(Client client)
        {
            clients.Add(client);
        }

        // g. Заменить элемент списка по ID
        public void UpdateClient(Client updatedClient)
        {
            var index = clients.FindIndex(c => c.getId() == updatedClient.getId());
            if (index != -1)
            {
                clients[index] = updatedClient;
            }
            else
            {
                throw new ArgumentException("Клиент с указанным ID не найден.");
            }
        }

        // h. Удалить элемент списка по ID
        public void DeleteClient(int id)
        {
            var clientToRemove = clients.Find(c => c.getId() == id);
            if (clientToRemove != null)
            {
                clients.Remove(clientToRemove);
            }
            else
            {
                throw new ArgumentException("Клиент с указанным ID не найден.");
            }
        }

        // i. Получить количество элементов
        public int GetCount()
        {
            return clients.Count;
        }
        private int GenerateNewId()
        {
            return clients.Count > 0 ? clients.Max(c => c.getId()) + 1 : 1;
        }
    }
}
