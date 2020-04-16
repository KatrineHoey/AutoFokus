using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspBilCrud.Services
{
    public class AboutInformations
    {
        public AboutInformations(string fileName)
        {
            GetInformationsFromFile(fileName);
        }
        public static string Name { get; set; }
        public static int copyRightYear { get; set; }

        private void GetInformationsFromFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            Name = lines[0];
            copyRightYear = Convert.ToInt32(lines[1]);

        }
    }
}
