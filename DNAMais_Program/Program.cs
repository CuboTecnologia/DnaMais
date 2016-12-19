using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DNAMais.Domain;
using DNAMais.Domain.Services;
using DNAMais.Framework;

namespace DNAMais_Program
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = Security.Encryption("admin1234");

            UsuarioBackOfficeService teste = new UsuarioBackOfficeService();

            Console.Write("Teste: " + teste.ConsultarPorId(1));
            Console.ReadKey();

            //BackOfficeUser user = new BackOfficeUser();

            //Console.WriteLine("ID: {0}", user.Id);
            //Console.WriteLine("Nome: {0}", user.Name);
            //Console.ReadKey();
        }
    }
}
