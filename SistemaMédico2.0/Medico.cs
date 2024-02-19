using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMédico2._0
{
    class Medico
    {
        private int id;
        private string nome;
        private string endereco;
        private string telefone;
        private string email;

        public int ID => id;

        public void Cadastrar()
        {
            Random rnd = new Random();
            id = rnd.Next(10000, 100000);
            Console.Write("\nDigite o nome do médico: ");
            nome = Console.ReadLine();
            Console.Write("Digite o endereço do médico: ");
            endereco = Console.ReadLine();
            Console.Write("Digite o telefone do médico: ");
            telefone = Console.ReadLine();
            Console.Write("Digite o e-mail do médico: ");
            email = Console.ReadLine();
        }

        public void ImprimirLista()
        {
            Console.WriteLine($"\nID: {id}\nNome: {nome}");
        }

        public void Imprimir()
        {
            Console.WriteLine($"\nID: {id}\nNome: {nome}\nEndereço: {endereco}\nTelefone: {telefone}\nE-mail: {email}");
        }
    }
}
