using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGameATP
{
    internal class snake
    {
        public int[] corpoX = new int[600];
        public int[] corpoY = new int[600];
        public int tamanhoCobra = 5;
        public int x, y;
        public int direcaox, direcaoy;

        public int largura = 30;
        public int altura = 20;
        public bool gameOver = false;

        food food = new food();

        public void Resetar()
        {
            x = largura / 2;
            y = altura / 2;

            direcaox = 1;
            direcaoy = 0;
            for (int i = 0; i < tamanhoCobra; i++)
            {
                corpoX[i] = x - i;
                corpoY[i] = y;
            }
        }
        public void LerTecla()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo tecla = Console.ReadKey(true);

                if (tecla.Key == ConsoleKey.UpArrow)
                {
                    direcaox = 0; direcaoy = -1;
                }
                else if (tecla.Key == ConsoleKey.DownArrow)
                {
                    direcaox = 0; direcaoy = 1;
                }
                else if (tecla.Key == ConsoleKey.LeftArrow)
                {
                    direcaox = -1; direcaoy = 0;
                }
                else if (tecla.Key == ConsoleKey.RightArrow)
                {
                    direcaox = 1; direcaoy = 0;
                }
            }
        }
        public void Mover()
        {
            for (int i = tamanhoCobra - 1; i > 0; i--)
            {
                corpoX[i] = corpoX[i - 1];
                corpoY[i] = corpoY[i - 1];
            }

            corpoX[0] += direcaox;
            corpoY[0] += direcaoy;

            x = corpoX[0];
            y = corpoY[0];

            if (x < 0 || x >= largura || y < 0 || y >= altura)
            {
                gameOver = true;
            }
        }
        public void VerificarColisaoCorpo()
        {
            for (int i = 1; i < tamanhoCobra; i++)
            {
                if (corpoX[0] == corpoX[i] && corpoY[0] == corpoY[i])
                {
                    gameOver = true;
                    break;
                }
            }
        }
        public void VerificarComida(food food)
        {
            if (corpoX[0] == food.ComidaX && corpoY[0] == food.ComidaY)
            {
                tamanhoCobra++;
               
                food.CriarComida(corpoX, corpoY, tamanhoCobra, largura, altura);
            }
        }

    }
}