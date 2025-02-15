using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs3
{
    public abstract class Client_rep
    {
        protected List<Client> clients = new List<Client>();

        public abstract void LoadFromFile();
        public abstract void SaveToFile();

        public Client GetById(int id)
        {
            return clients.Find(c => c.getId() == id);
        }

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
            int newId = clients.Count > 0 ? clients.Max(c => c.getId()) + 1 : 1;
            client.SetId(newId++);
            clients.Add(client);
        }

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

        public int GetCount()
        {
            return clients.Count;
        }
    }
}
