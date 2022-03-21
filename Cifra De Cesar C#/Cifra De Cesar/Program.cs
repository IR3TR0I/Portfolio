using System;

namespace Cifra_De_Cesar
{
    class Program
    {   
        //Criptografador & Descriptografador de Cifra de Cesar
        static void Main(string[] args)
        {
            Console.WriteLine("/////////////////////////////");
            Console.WriteLine("Bem vindo!\nEscolha no menu o que pretende fazer:\n1.-Criptografar\n2.-Descriptografar\n3.Pressione 3 para Fechar. ");
            Console.WriteLine("/////////////////////////////");
            //convertendo valor passado no menu para int usando switch case nele
            int valor = Convert.ToInt32(Console.ReadLine());

            switch (valor)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Por Favor Coloque uma mensagem ou texto para Criptografar: ");
                    string textoCript = Console.ReadLine();//Lendo
                    textoCript = textoCript.ToLower();//passando para minusculo
                    char[] textoSecreto = textoCript.ToCharArray();//passando texto criptografado para um array
                    Criptografar(textoSecreto, 3);//passando metodo de Criptográfia
                    string secreto = Criptografar(textoSecreto, 3);
                    Console.WriteLine(secreto);
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Por Favor Coloque uma mensagem ou texto para Descriptografar: ");
                    string textoDescrip = Console.ReadLine();//Lendo
                    textoDescrip = textoDescrip.ToUpper();//passando para minusculo
                    char[] Descripsecreto = textoDescrip.ToCharArray();//passando texto criptografado para um array
                    Descriptografar(Descripsecreto, 3);//passando metodo de Criptográfia
                    string secretodescrip = Descriptografar(Descripsecreto, 3);;
                    Console.WriteLine(secretodescrip);
                    break;
            }

        }

        //METODO PARA CRIPTOGRAFAR
        static string Criptografar(char[] textoSecreto, int key)
        {
            //Criando array alfabeto com todas as letra servindo como parametro
            char[] alfabeto = new char[27] {' ', 'a', 'b', 'c',  'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            int comprimento = textoSecreto.Length;
            char[] mensagemCriptografada = new char[comprimento];
            for (int i= 0; i< textoSecreto.Length; i++)
            {
                var letra = textoSecreto[i];
                int index = Array.IndexOf(alfabeto, letra);
                int novoIndex = (key + index) % 26;
                char novaLetra = alfabeto[novoIndex];
                mensagemCriptografada[i] = novaLetra;
            }

            string Criptomensagem = string.Join("", mensagemCriptografada);
            return Criptomensagem;
        }
        static string Descriptografar(char[] textoDescrip, int key)
        {
            char[] alfabeto = new char[27] {' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            int comprimento = textoDescrip.Length;
            char[] mensagemDescriptografada = new char[comprimento];
            for (int i = 0; i < textoDescrip.Length; i++)
            {
                var letra = textoDescrip[i];
                int index = Array.IndexOf(alfabeto, letra);
                int novoIndice = (index - key) % 26;
                char novaletra = alfabeto[novoIndice];
                mensagemDescriptografada[i] = novaletra;
            }

            string DescripMensagem = string.Join("", mensagemDescriptografada);
            return DescripMensagem;
            
        }
        
    }

}
