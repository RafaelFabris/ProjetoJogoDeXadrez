using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.Enums;
using xadrez_console.tabuleiro.Exceptions;

namespace xadrez_console.xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem , Posicao destino)
        {
            /*bool[,] mat = Tab.Peca(origem).MovimentosPossiveis();
            if (mat[destino.Linha, destino.Coluna] == false)
            {
                throw new TabuleiroExceptions("Esta peca não pode ir para esta possição!");
            }*/
            //else
            //{
                Peca p = Tab.RetirarPeca(origem);
                p.IncrementarQteMovimentos();
                Peca pecaCapturada = Tab.RetirarPeca(destino);
                Tab.ColocarPeca(p, destino);
            //}
        }

        public void RealizaJogada(Posicao origem , Posicao destino)
        {          
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
                JogadorAtual = Cor.Preta;
            else
                JogadorAtual = Cor.Branca;
        }

        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if(Tab.Peca(pos) == null)
            {
                throw new TabuleiroExceptions("Não existe peça na posição escolhida!");
            }
            if(JogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new TabuleiroExceptions("A peça de origem escolhida não é sua!");
            }
            if (!Tab.Peca(pos).ExisteMovimentoPossiveis())
            {
                throw new TabuleiroExceptions("Não há movimentos possiveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem , Posicao destino) 
        {
            if (!Tab.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroExceptions("Posição de destino iválida!");
            }
        }

        private void ColocarPecas()
        {
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c' , 1).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());

            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());


        }
    }
}
