using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServicesLogic.Helpers
{
    public class AddAccountGenerator
    {
        private static readonly Random random = new Random();
        private static string id = "CA";
        public static string GenerateRandomID()
        {
            var container = id += random.Next(0, 9).ToString();
            return container;
        }
    }
}
