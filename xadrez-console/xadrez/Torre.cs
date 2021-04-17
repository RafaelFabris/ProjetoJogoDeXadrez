using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.Enums;

namespace xadrez_console.xadrez
{
    class Torre : Peca
    {
        public Torre( Tabuleiro tab, Cor cor) : base(tab , cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
