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
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.Turno);
                        Console.WriteLine("Aguardando Jogada da: " + partida.JogadorAtual);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDeOrigem(origem);

                        bool[,] possisoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab, possisoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDeDestino(origem , destino);

                        partida.RealizaJogada(origem, destino);
                    }
                    catch(TabuleiroExceptions e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

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
