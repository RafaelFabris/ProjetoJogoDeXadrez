using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro.Exceptions;

namespace xadrez_console.tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }

        public int Colunas { get; set; }

        public Peca[,] Pecas { get; private set; }

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas , colunas];
        }

        public Peca Peca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return Peca(pos) != null;
        }
        public void ColocarPeca(Peca p , Posicao pos)
        {
            if (ExistePeca(pos))
                throw new TabuleiroExceptions("Já existe uma peça nesta posição");
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos)
        {
            if (Peca(pos)  == null)
            {
                return null;
            }
            Peca aux = Peca(pos);
            aux.Posicao = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }
        
        public bool PosicaValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
                return false;
            else
                return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaValida(pos))
                throw new TabuleiroExceptions("Posição Inválida!");
        }
    }
}
