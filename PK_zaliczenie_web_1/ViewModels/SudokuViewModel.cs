using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PK_zaliczenie_web_1.ViewModels
{
    public class SudokuViewModel
    {
        public int[,] sudoku = new int[9, 9];

        public List<int> zakres_liczb = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, };

       
    }
}
