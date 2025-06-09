using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace orientação_a_objeto
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            
                Pessoa pessoa = new Pessoa();
                pessoa.Nome = "João";
                pessoa.Idade = 10;

                pessoa.Apresentacao();
                Console.WriteLine(pessoa.VerificaIdade());
            
                Console.ReadLine();

        }
            class Pessoa 
            {
                public string Nome;
                public int Idade;

               public void Apresentacao()
                {
                Console.WriteLine($"Olá meu nome é {Nome}");        
                }

                public string VerificaIdade()
                 {
                    return Idade >= 18 ? "Maior de idade" : "Menor de idade";
                 }
            }
    }
}
