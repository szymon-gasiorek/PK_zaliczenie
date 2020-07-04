using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PK_zaliczenie_web_1.Models;
using PK_zaliczenie_web_1.ViewModels;

namespace PK_zaliczenie_web_1.Constollers
{
    public class SudokuController : Controller
    {
        private readonly ISudokuRules sudokuRules;
        

        public SudokuController(ISudokuRules sr)
        {
            sudokuRules = sr;
        }


        [HttpGet]
        public ViewResult Sudoku()
        {
            sudokuRules.wczytaj_sudoku();
            SudokuViewModel svm = new SudokuViewModel();
            ViewBag.Title = "Sudoku Solver";
            //svm.sudoku = sudokuRules.GetSudoku();
            ViewBag.sudoku1 = svm.sudoku;

           
            return View();
        }

        [HttpPost]
        public IActionResult Sudoku(SudokuViewModel model)
        {
            if (ModelState.IsValid)
            {             
                //sudokuRules.wczytaj_sudoku();
                sudokuRules.rozwiazanie_calosc();

                model.sudoku = sudokuRules.GetSudoku();
                ViewBag.sudoku1 = model.sudoku;

            }

            return View(model);
        }

       
 

    }
}
