using System;
using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.Enums;
using xadrez_console.xadrez;
using xadrez_console.tabuleiro.Exceptions;




namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                    bool[,] possisoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab , possisoesPossiveis);

                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.ExecutaMovimento(origem, destino);

                }


            }
            catch (TabuleiroExceptions e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();

        }


    }
}
