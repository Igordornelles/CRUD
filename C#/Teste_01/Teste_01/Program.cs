using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Teste_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Console.WriteLine("Hello, World!");

             string nome = "";
             Console.WriteLine("Qual é seu nome ?");
             nome = Console.ReadLine();
             Console.WriteLine("Seu nome é : " + nome);  

             int numero;
             Console.WriteLine("Qual é seu número favorito ?");
             numero= int.Parse(Console.ReadLine());
             Console.WriteLine("Seu número favorito é : " + numero);*/

            array();
            switc();
            Enu();
            //Enu_Swit();
            LoopWhil();
            LoopDoWit();
            Forr();
            Fop();
            Esco();
            Console.ReadLine();

        }

        static void array()
        {
            string[] nomes = new string[5]
            {
                 "Lucas",
                 "João",
                 "Maria",
                 "Ana",
                 "Pedro",
            };
            Console.WriteLine(nomes[1]);

            // Outra formar de fazer um array 
            int[] valores = { 50, 56, 58, 59, 30, 31 };
            Console.WriteLine(valores[5]);
            Console.WriteLine("===========================================");

        }

        static void switc()
        {
            string cor = "Azul";
            switch (cor)
            {
                case "Amarelo":
                    Console.WriteLine("A cor é Amarelo");
                    break;
                case "Verde":
                    Console.WriteLine("A cor é verde");
                    break;
                case "Vermelho":
                    Console.WriteLine("A cor é vermelho");
                    break;
                default:
                    Console.WriteLine("Cor não encontrada");
                    break;
            }
            Console.WriteLine("===========================================");
        }
        enum Cor
        {
            Azul, Verde, Vermelho, Amarelo
        }

        static void Enu()
        {
            Cor corFavorita = Cor.Azul;
            Cor corFavorita2 = Cor.Vermelho;

            Console.WriteLine(corFavorita);
            Console.WriteLine(corFavorita2);
            Console.WriteLine("===========================================");
        }

        /* enum Opcao { Criar =1, Deletar , Editar, Listar, Atualizar}
         static void Enu_Swit()
         {
             Console.WriteLine("Selecione uma opção a baixo :");
             Console.WriteLine("1-Criar\n2-Deletar\n3-Editar\n4-Listar\n5-Atualizar");
             Console.WriteLine("Digite o número da opção desejada :");

             int index = int.Parse(Console.ReadLine());

             Opcao opcaoSelecionada = (Opcao)index;

             switch (opcaoSelecionada) 
             { 
                 case Opcao.Criar:
                     Console.WriteLine("Você escolheu a opção Criar");
                     break;
                 case Opcao.Deletar:
                     Console.WriteLine("Você escolheu a opção Deletar");
                     break;
                 case Opcao.Editar:
                     Console.WriteLine("Você escolheu a opção Editar");
                     break;
                 case Opcao.Listar:
                     Console.WriteLine("Você escolheu a opção Listar");
                     break;
                 case Opcao.Atualizar:
                     Console.WriteLine("Você escolheu a opção Atualizar");
                     break;
                 default:
                     Console.WriteLine("Opção inválida");
                     break;
             }
         }*/

        static void LoopWhil()
        {
            int contador = 0;
            while (contador < 1) // Enquando for verdade faça 
            {
                Console.WriteLine(contador + 1);
                //Console.WriteLine("Igor" );
                //contador = contador + 1; 
                // contador += 1;
                contador++;
            }
            Console.WriteLine("Fim da Linha ");
            Console.WriteLine("===========================================");
        }

        static void LoopDoWit()
        {

            int contador = 5;
            do 
            {
                Console.WriteLine("Do While");
                contador++;
            }while (contador < 5);
            Console.WriteLine("===========================================");
        }

        static void Forr() // Foreach
        {
            string[] nomes =
            {
                "Lucas","João","Maria","Ana","Pedro","Henrique",
            };

            foreach(string nome in nomes) // Para cada palavra na array repita esse bloco de código  
            {
                Console.WriteLine(nome);
            }
            Console.WriteLine("===========================================");

        }

        static void Fop() 
        {
            string[] nomes =
            {
            "Lucas","João","Maria","Ana","Pedro","Henrique",
            };
        
            for (int contador = 0;contador < nomes.Length ; contador ++ )
            Console.WriteLine(nomes[contador]);

            Console.WriteLine("===========================================");
           
            for (int contador1= nomes.Length-1; contador1 >=0; contador1--)
            {
                Console.WriteLine(nomes[contador1]);   
            }
            Console.WriteLine("===========================================");
        } 
    
        static void Esco() 
        {
            Console.WriteLine("Meu nome é Jonas");
            Console.ReadLine();    
        }
    }
}



