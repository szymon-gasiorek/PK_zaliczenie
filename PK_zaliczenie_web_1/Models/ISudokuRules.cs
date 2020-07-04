using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PK_zaliczenie_web_1.Models
{
    public interface ISudokuRules
    {
        

        bool spr_rzad(int y, int liczba);

        bool spr_kolumna(int x, int liczba);

        bool spr_blok(int y, int x, int liczba);

        bool spr_wszystko(int y, int x, int liczba);

        bool rozwiazanie_okienka(int y, int x);

        bool rozwiazanie_calosc();
        int[,] GetSudoku();

        void wczytaj_sudoku();
    }
}
