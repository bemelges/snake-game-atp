using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameATP
{
        internal class Tabuleiro
        {
            public int linhas = 20;
            public int colunas = 30;

            public int[,] matriz;

            public Tabuleiro()
            {
                matriz = new int[linhas, colunas];
            }

            public void Limpar()
            {
                for (int i = 0; i < linhas; i++)
                {
                    for (int j = 0; j < colunas; j++)
                    {
                        matriz[i, j] = 0;
                    }
                }
            }

            public void ColocarComida(int x, int y)
            {
                matriz[y, x] = 2; 
            }

            public void ColocarCobra(int[] corpoX, int[] corpoY, int tamanho)
            {
                for (int i = 0; i < tamanho; i++)
                {
                    matriz[corpoY[i], corpoX[i]] = 1;
                }
            }

            public void DesenharConsole()
            {
                Console.Clear();

                for (int i = 0; i < linhas; i++)
                {
                    for (int j = 0; j < colunas; j++)
                    {
                        switch (matriz[i, j])
                        {
                            case 0:
                                Console.Write(" ");
                                break;
                            case 1:
                                Console.Write("o");
                                break;
                            case 2:
                                Console.Write("@");
                                break;
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
