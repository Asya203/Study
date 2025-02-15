using labs3;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

namespace labs3
{
    internal static class Program
    {

        static void Main()
        {
            Client client1 = new Client(1, "Ivan", "Ivanov", "Ivanovich", "89185550633", "ivan@gmail.com", "08.11.96", "2441117777", "good");
            Client client3 = new Client(2, "Igor", "Igorov", "Igorovich", "89184555623", "igor@gmail.com", "18.05.66", "1111662738", " very good");
            Client client2 = new Client(3, "Oleg", "Olegov", "Olegovich", "89186655443", "oleg@gmail.com", "03.10.03", "4444220099", "bad");

            ShortClient shClient1 = new ShortClient(3, "Ivan", "Ivanov", "89185550633", "2441117777");

            //Console.WriteLine(client1.ClientEquals(shClient1));
            //if (shClient1.Equals(client1)) Console.WriteLine("Equal!!!");
            /*
            Console.WriteLine(client1.toMyString());
            Console.WriteLine(client1.toJson());
            Console.WriteLine(client1.shortInfo());
            Console.WriteLine(client1.shortInfoNew());
            
            //if (client3.ClientEquals(client1)) { Console.WriteLine("Equal!!!"); } else { Console.WriteLine("No");}

            Client_rep_json client_rep_json1=new Client_rep_json();
            client_rep_json1.AddClient(client1);
            client_rep_json1.AddClient(client3);
            client_rep_json1.AddClient(client2);
            client_rep_json1.GetInfolist(client_rep_json1.GetKShortList(1, 2));
            Console.WriteLine(client_rep_json1.GetById(2).toMyString());
            client_rep_json1.SaveToFile();
            client_rep_json1.LoadFromFile();
            client_rep_json1.GetInfolist();
            client_rep_json1.SortByField("passport");
            //Console.WriteLine(client_rep_json1);
            client_rep_json1.GetInfolist();

            */

            /*

            Client_rep_yaml client_rep_yaml1 = new Client_rep_yaml();
            //client_rep_yaml1.AddClient(client1);
            //client_rep_yaml1.AddClient(client2);
            //client_rep_yaml1.AddClient(client3);
            client_rep_yaml1.GetInfolist();
            //client_rep_yaml1.SaveClients();
            client_rep_yaml1.LoadClients();
            client_rep_yaml1.GetInfolist();
            Console.WriteLine(client_rep_yaml1.GetClientById(1).toMyString());
            client_rep_yaml1.GetInfolist(client_rep_yaml1.GetKNSortList(0, 2));
            client_rep_yaml1.SortByField("passport");
            client_rep_yaml1.GetInfolist();

            */

        }
    }
}