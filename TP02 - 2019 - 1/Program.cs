using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP02___2019___1
{
    //PROGRAMADOR(A): Nayla Cristina Gomes Carvalho da Silva.
    //OBJETIVO: Jogo da forca entre dois jogadores, onde um insere uma palavra para o outro adivinhar.

    class Program
    {
        /*---------------------------------------------------------------------
            - Procedimento para exibir cabeçalho padrão;
         ---------------------------------------------------------------------*/
        static void cabecalho()
        {
            Console.Clear();
            Console.WriteLine("=======================================================\n");
            Console.WriteLine("==================== JOGO DA FORCA ====================\n");
            Console.WriteLine("=======================================================\n");
        }

        /*---------------------------------------------------------------------
            - Procedimento para limpar a tela e exibir um cabeçalho padrão 
                com placar;
         ---------------------------------------------------------------------*/

        static void cabecalhoTentativas(int tentativas, int acertos, string digitadas)
        {
            Console.Clear();
            Console.WriteLine("=======================================================\n");
            Console.WriteLine("==================== JOGO DA FORCA ====================\n");
            Console.WriteLine("=======================================================\n");
            Console.WriteLine("Tentativas: " + tentativas);
            Console.Write("\nLetras digitadas:");
            for (int i = 0; i < digitadas.Length; i++)
                Console.Write(" " + digitadas[i] + " ");
            Console.WriteLine("\n\n-------------------------------------------------------\n");
        }

        /*---------------------------------------------------------------------
            - Função para verificar se as palavras apresentam a mesma
                quantidade de letras;
         ---------------------------------------------------------------------*/

        static string tamanhoPalavras(string p1, string p2)
        {
            cabecalho();
            Console.WriteLine("Opaa! Você deve inserir uma palavra com " + p1.Length + " letras.");

            while (p2.Length != p1.Length)
            {

                Console.WriteLine("\nTente novamente:");
                Console.Write("JOGADOR 2 => ");
                p2 = Console.ReadLine();
            }
            return p2.ToUpper();
        }

        /*---------------------------------------------------------------------
            - Procedimento que preenche o vetor de acertos com asteriscos;
         ---------------------------------------------------------------------*/

        static void preencherAsterisco(char[] acertos)
        {
            for (int i = 0; i < acertos.Length; i++)
            {
                acertos[i] = '*';
            }
            Console.WriteLine("\n");
        }

        /*---------------------------------------------------------------------
            - Procedimento que mostra as casas das palavras e suas letras
                que foram acertadas;
         ---------------------------------------------------------------------*/

        static void mostrarCasas(string palavra, char[] acertos)
        {
            for (int i = 0; i < palavra.Length; i++)
            {
                Console.Write(" " + acertos[i] + " ");
            }
            Console.WriteLine("\n");
        }

        /*---------------------------------------------------------------------
            - Procedimento para conferir se a letra digitada não é repetida;
         ---------------------------------------------------------------------*/

        static bool repetida(string palavra, ref char letra, ref string digitadas, ref int tentativas)
        {
            bool repetida = false;

            for (int i = 0; i < digitadas.Length; i++)
            {
                if (letra == digitadas[i])
                    repetida = true;
            }

            if (repetida == true)
            {
                Console.Write("\n\nLetra já digitada, insira outra... ");
                Console.ReadKey();
            }
            else
            {
                digitadas += letra;
                tentativas++;
            }
            return repetida;
        }

        /*---------------------------------------------------------------------
            - Procedimento que verifica se a letra inserida existe
                em determinada palavra;
         ---------------------------------------------------------------------*/

        static void verificacao(string palavra, char letra, ref int acertos, ref bool ganhou, string digitadas, ref char[] acertadas, bool repetidas)
        {
            int encontradas = 0;

            for (int i = 0; i < palavra.Length; i++)
            {
                if (letra == palavra[i])
                {
                    encontradas++;
                    acertadas[i] = letra;
                }
            }

            if (encontradas > 0 && repetidas == false)
                acertou(encontradas, ref acertos, palavra, ref ganhou, digitadas);
            else
                if (repetidas == false)
            {
                Console.Write("\nLetra não encontrada...");
                Console.ReadKey();
            }
        }

        /*---------------------------------------------------------------------
            - Procedimento executado se a pessoa acertou uma letra;
         ---------------------------------------------------------------------*/

        static void acertou(int encontradas, ref int acertos, string palavra, ref bool ganhou, string digitadas)
        {
            Console.Write("\nLetra encontrada!");
            acertos += encontradas;
            Console.ReadKey();

            if (acertos == palavra.Length)
            {
                Console.Write("\n\nParabéns você acertou a palavra " + palavra.ToUpper() + "!");
                ganhou = true;
                Console.ReadKey();
            }

        }

        /*---------------------------------------------------------------------
            - Procedimento para determinar o ganhador;
         ---------------------------------------------------------------------*/

        static void gameOver(int t1, int t2)
        {
            if (t1 < t2)
                Console.WriteLine("\nParabéns JOGADOR 1, você venceu o jogou!");
            else
                if (t1 > t2)
                Console.WriteLine("\nParabéns JOGADOR 2, você venceu o jogou!");
            else
                if (t1 == t2)
                Console.WriteLine("\nOpa, tivemos um empate!");
        }


        /*---------------------------------------------------------------------
                                       MAIN
         ---------------------------------------------------------------------*/
        static void Main(string[] args)
        {
            string palavra1, palavra2, digitadas = "";
            char letra = ' ';
            int acertos = 0, tentativasJ1 = 0, tentativasJ2 = 0;
            bool acertou = false, repetidas = false;

            //Apresentação do jogo
            cabecalho();
            Console.Write("Bem vindos ao Jogo da Forca!");
            Console.ReadKey();
            Console.WriteLine("\n\nAs regras são bem simples: ");
            Console.WriteLine("\n* O jogo é jogado com 2 jogadores;");
            Console.WriteLine("\n* Os dois, no começo irão inserir uma palavra para o outro tentar acertar;");
            Console.WriteLine("\n* Aquele que acertar a palavra com o menor número de tentativas vence!");
            Console.Write("\n\nProntos?");
            Console.ReadKey();
            cabecalho();
            Console.WriteLine("Ok! Insiram as palavras um para o outro, mas não deixem \nque o inimigo veja!");
            Console.WriteLine("\nIMPORTANTE => As palavras devem conter a mesma quantidade de letras \npara ser justo! Então combinem antes...");
            Console.Write("\nAgora sim! Prontos?");
            Console.ReadKey();
            cabecalho();

            //Requerindo a palavra do JOGADOR 1
            Console.Write("Insira a palavra, JOGADOR 1 => ");
            palavra1 = Console.ReadLine().ToUpper();

            cabecalho();

            /*Requerindo a palavra do JOGADOR 2 e chamando a função que verificará a quantidade de letras
            das duas palavras*/
            Console.WriteLine("A palavra inserida pelo JOGADOR 1 contém " + palavra1.Length + " letras");
            Console.Write("\nInsira a palavra, JOGADOR 2 => ");
            palavra2 = tamanhoPalavras(palavra1, Console.ReadLine());

            //Vetor que armazena as letras acertadas pelo J1 e pelo J2
            char[] acertadasJ1 = new char[palavra1.Length];
            char[] acertadasJ2 = new char[palavra2.Length];
            //Preenchendo os vetores com asteriscos
            preencherAsterisco(acertadasJ1);
            preencherAsterisco(acertadasJ2);

            //Dando inicío ao jogo
            cabecalho();
            Console.WriteLine("Palavras inseridas, vamos começar!");
            Console.Write("\nPrimeiro você JOGADOR 1, tente adivinhar a palavra que o \nJOGADOR 2 escolheu para você!");
            Console.ReadKey();

            //Ciclo do JOGADOR 1
            while (acertou == false)
            {
                cabecalhoTentativas(tentativasJ1, acertos, digitadas);
                mostrarCasas(palavra2, acertadasJ1);

                Console.WriteLine("\n* JOGADOR 1 *");
                Console.Write("\nLetra => ");
                letra = char.Parse(Console.ReadLine().ToUpper());

                repetidas = repetida(palavra2, ref letra, ref digitadas, ref tentativasJ1);
                if (repetidas == false)
                {
                    verificacao(palavra2, letra, ref acertos, ref acertou, digitadas, ref acertadasJ1, repetidas);
                }
            }

            //Fim do ciclo do JOGADOR 1 e chamada para o JOGADOR 2
            Console.Clear();
            cabecalho();
            Console.Write("\nSua vez JOGADOR 2, tente adivinhar a palavra que o \nJOGADOR 1 escolheu para você!");
            Console.ReadKey();

            //Zerando variaveis para reaproveitar
            digitadas = "";
            acertos = 0;
            acertou = false;
            repetidas = false;

            //Ciclo do JOGADOR 2
            while (acertou == false)
            {
                cabecalhoTentativas(tentativasJ2, acertos, digitadas);
                mostrarCasas(palavra1, acertadasJ2);

                Console.WriteLine("\n* JOGADOR 2 *");
                Console.Write("\nLetra => ");
                letra = char.Parse(Console.ReadLine().ToUpper());

                repetidas = repetida(palavra1, ref letra, ref digitadas, ref tentativasJ2);
                if (repetidas == false)
                {
                    verificacao(palavra1, letra, ref acertos, ref acertou, digitadas, ref acertadasJ2, repetidas);
                }
            }
            //Fim do ciclo do JOGADOR 2

            cabecalho();
            Console.WriteLine("\nTentativas JOGADOR 1: " + tentativasJ1);
            Console.Write("Tentativas JOGADOR 2: " + tentativasJ2 + "\n");

            gameOver(tentativasJ1, tentativasJ2);

            Console.Write("\n\nFim do jogo...");
            Console.ReadKey();
        }
    }
}
