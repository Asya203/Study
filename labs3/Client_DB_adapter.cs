using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs3
{
    public class ClientAdapter : Client_rep
    {
        private readonly Client_rep_DB _clientRepDb;
        //public void LoadFromFile() => _clientRepDb.Load();
        //public void SaveToFile()=> _clientRepDb.Save();

        public ClientAdapter()
        {
            _clientRepDb = new Client_rep_DB();
        }


        public Client GetClientById(int id) => _clientRepDb.GetClientById(id);

        public List<Client> GetK_N_ShortList(int k, int n) => _clientRepDb.GetK_N_ShortList(k, n);

        public void AddClient(Client client) => _clientRepDb.AddClient(client);

        public void UpdateClient(Client client) => _clientRepDb.UpdateClient(client);

        public void DeleteClient(int id) => _clientRepDb.DeleteClient(id);

        public int GetCount() => _clientRepDb.GetCount();

        public override void LoadFromFile()
        {
            _clientRepDb.Load();
        }

        public override void SaveToFile()
        {
            _clientRepDb.Save();
        }
    }
}
