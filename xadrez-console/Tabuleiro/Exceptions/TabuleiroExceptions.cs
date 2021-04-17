using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace xadrez_console.tabuleiro.Exceptions
{
    class TabuleiroExceptions : Exception
    {
        public TabuleiroExceptions(string message) : base(message)
        {
        }
    }
}
