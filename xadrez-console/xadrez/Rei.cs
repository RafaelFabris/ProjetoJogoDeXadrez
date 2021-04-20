using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.Enums;

namespace xadrez_console.xadrez
{
    class Rei : Peca
    {
        public PartidaDeXadrez Partida { get; private set; }
        public Rei(Tabuleiro tab, Cor cor , PartidaDeXadrez partida) : base(tab, cor)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != Cor;
        }
        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p is Torre && p.Cor == Cor && QteMovimentos == 0;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tab.PosicaValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tab.PosicaValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Direita

            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tab.PosicaValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tab.PosicaValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tab.PosicaValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tab.PosicaValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tab.PosicaValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tab.PosicaValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Jogada especial: Roque 
            if(QteMovimentos == 0 && !Partida.Xeque)
            {
                // Roque Pequeno
                Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TesteTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna+1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if(Tab.Peca(p1) == null && Tab.Peca(p2) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }

                }

                // Roque Grande
                Posicao posT2 = new Posicao(Posicao.Linha, Posicao.Coluna -  4);
                if (TesteTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null && Tab.Peca(p3) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }

                }
            }
            return mat;
        }
    }
}
