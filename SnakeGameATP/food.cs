using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameATP
{
    internal class food
    {
        public Random randomFood = new Random();
        public int comidaX, comidaY;
        public int ComidaX { get; private set; }
        public int ComidaY { get; private set; }

        public void CriarComida(int[] corpoX, int[] corpoY, int tamanhoCobra, int largura, int altura)
        {
            bool posicaoInvalida;
            int novoX = 0;
            int novoY = 0;

            do
            {
                novoX = randomFood.Next(0, largura);
                novoY = randomFood.Next(0, altura);
                posicaoInvalida = false;
                for (int i = 0; i < tamanhoCobra; i++)
                {
                    if (corpoX[i] == novoX && corpoY[i] == novoY)
                    {
                        posicaoInvalida = true;
                        break;
                    }
                }

            } while (posicaoInvalida);

            comidaX = novoX;
            comidaY = novoY;
            ComidaX= novoX;
            ComidaY= novoY;
        }
        public void Desenhar()
        {
            Console.SetCursorPosition(comidaX, comidaY);
            Console.Write("@");
        }
    }
}

