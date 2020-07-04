using PK_zaliczenie_web_1.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PK_zaliczenie_web_1.Models
{
  

    public class SudokuRules : SudokuViewModel, ISudokuRules 
    {
        public int[,] GetSudoku()
        {
            return sudoku;
        }


        public bool rozwiazanie_calosc()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (sudoku[i, j] == 0)
                    {
                        return rozwiazanie_okienka(i, j);
                    }
                }
            }
            return true;
        }

        public bool rozwiazanie_okienka(int y, int x)
        {
            foreach (int n in zakres_liczb)
            {
                if (spr_wszystko(y, x, zakres_liczb[n - 1]) == true)
                {
                    sudoku[y, x] = n;
                    if (rozwiazanie_calosc())
                    {
                        return true;
                    }
                }
            }

            sudoku[y, x] = 0;
            return false;
        }

        public bool spr_blok(int y, int x, int liczba)
        {
            int blok_x = x / 3 * 3;
            int blok_y = y / 3 * 3;

            for (int i = blok_y; i < blok_y + 3; i++)
            {
                for (int j = blok_x; j < blok_x + 3; j++)
                {
                    if (sudoku[i, j] == liczba)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool spr_kolumna(int x, int liczba)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[i, x] == liczba)
                {
                    return false;
                }
            }
            return true;
        }

        public bool spr_rzad(int y, int liczba)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[y, i] == liczba)
                {
                    return false;
                }
            }
            return true;
        }

        public bool spr_wszystko(int y, int x, int liczba)
        {
            if (spr_rzad(y, liczba) == true && spr_kolumna(x, liczba) == true && spr_blok(y, x, liczba) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void wczytaj_sudoku()
        {
            try
            {
                using (StreamReader dane = new StreamReader("sudoku.txt"))
                {
                    for (int i = 0; i < 9; i++)
                    {
                        string[] liczby = dane.ReadLine().Split(' ');

                        for (int j = 0; j < 9; j++)
                        {
                            sudoku[i, j] = Convert.ToInt32(liczby[j]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Blad ! ");
                Console.WriteLine(e.Message);
            }
        }
    }
}
