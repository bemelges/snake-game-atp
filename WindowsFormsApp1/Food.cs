using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Food
    {
        public Point Location { get; private set; }
        private Random randomFood = new Random();
        public void CriacaoComida(List<Point> posicaoOcupada)
        {
            Point novaPosicao;
            do
            {
                novaPosicao = new Point(randomFood.Next(0, 20), randomFood.Next(0, 20));
            }
            while (corpoCobra.contains (novaPosicao) || posicaoOcupada.Contains(novaPosicao));
            Location = novaPosicao;
        }
    }
}
