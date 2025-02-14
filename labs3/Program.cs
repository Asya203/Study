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

        }
    }
}