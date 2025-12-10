using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnakeGameATP
{
    internal class game
    {
        int[,] mapa = new int[20, 30];
        snake snake = new snake();
        food food = new food();
        Tabuleiro tabuleiro = new Tabuleiro();

        public void Iniciar()
        {
            Console.CursorVisible = false;

            snake.Resetar();
            food.CriarComida(snake.corpoX, snake.corpoY, snake.tamanhoCobra, 30, 20);

            while (!snake.gameOver)
            {
                snake.LerTecla();
                snake.Mover();

                snake.VerificarColisaoCorpo();
                snake.VerificarComida(food);

                AtualizarMapa();
                DesenharMapa();

                Thread.Sleep(150);
            }

            Console.Clear();
            Console.WriteLine("GAME OVER!");
        }

        void AtualizarMapa()
        {
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 30; j++)
                    mapa[i, j] = 0;

            mapa[food.comidaY, food.comidaX] = 2;
            if (food.ComidaY >= 0 && food.ComidaY < 20 &&
            food.ComidaX >= 0 && food.ComidaX < 30)
            {
                mapa[food.ComidaY, food.ComidaX] = 2;
            }


            for (int i = 0; i < snake.tamanhoCobra; i++)
            {
                if (snake.corpoY[i] >= 0 && snake.corpoY[i] < 20 &&
            snake.corpoX[i] >= 0 && snake.corpoX[i] < 30)
                {
                    mapa[snake.corpoY[i], snake.corpoX[i]] = 1;
                }
            }
        }

        public void DesenharMapa()
        {
            Console.Clear();
            Console.WriteLine(new string('-', 32));

            for (int i = 0; i < 20; i++)
            {
                Console.Write("|");

                for (int j = 0; j < 30; j++)
                {
                    if (mapa[i, j] == 0) Console.Write(" ");
                    else if (mapa[i, j] == 1) Console.Write("o");
                    else if (mapa[i, j] == 2) Console.Write("@");
                }

                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 32));
        }
    }
}

