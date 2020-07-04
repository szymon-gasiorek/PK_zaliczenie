using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PK_zaliczenie_web_1.Models;
using PK_zaliczenie_web_1.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PK_zaliczenie_web_1.Constollers
{
    public class HomeController : Controller
    {
        private readonly IUnitsRepository unitRepository;
       

        public HomeController(IUnitsRepository unit_rep, IHostingEnvironment hosting)
        {
            unitRepository = unit_rep;
        }

        public ViewResult Index() 
        {           
            return View();
        }


        public ViewResult List()
        {
            var model = unitRepository.GetAllUnits();
            return View(model);
        }
      
        
        [HttpGet]
        [Authorize]     //tylko uzytkownik zalogowany bedzie mial uprawnienia
        public ViewResult Edit(int id)
        {
            Units unit = unitRepository.GetUnits(id);
            UnitEditViewModel unitEditViewModel = new UnitEditViewModel
            {

                Name = unit.Name,
                Attack = unit.Attack,
                Defense = unit.Defense,
                min_Damage = unit.min_Damage,
                max_Damage = unit.max_Damage,
                Health = unit.Health,
                Faction = unit.Faction,
                ExistingPhotoPath = unit.PhotoPath

            };
            return View(unitEditViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(UnitEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Units unit = unitRepository.GetUnits(model.Id);
                unit.Name = model.Name;
                unit.Attack = model.Attack;
                unit.Defense = model.Defense;
                unit.min_Damage = model.min_Damage;
                unit.max_Damage = model.max_Damage;
                unit.Health = model.Health;
                unit.Faction = model.Faction;

                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine("wwwroot/images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    unit.PhotoPath = ProcessUpload(model);
                }

                unitRepository.Update(unit);
                return RedirectToAction("list");
            }

            return View();
        }

        

        [HttpGet]
        [Authorize]
        public ViewResult Add_unit()
        {

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add_unit(UnitAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUpload(model);

                Units new_unit = new Units
                {
                    Name = model.Name,
                    Attack = model.Attack,
                    Defense = model.Defense,
                    min_Damage = model.min_Damage,
                    max_Damage = model.max_Damage,
                    Health = model.Health,
                    Faction = model.Faction,         
                    PhotoPath = uniqueFileName
                };

                unitRepository.Add_unit(new_unit);
                return RedirectToAction("details", new { id = new_unit.Id });
            }

            return View();
        }



        public ViewResult Details(int? id)
        {
          
            Units _unit = unitRepository.GetUnits(id.Value);

            if (_unit == null)
            {
                Response.StatusCode = 404;
                return View("UnitNotFound" , id.Value);
            }

            HomeDetailsViewModel hdvm = new HomeDetailsViewModel()
            {
                unit = _unit,
                PageTitile = "Units Details"
            };

            
            return  View(hdvm);
        }

        [HttpGet]
        [Authorize]
        public ViewResult Delete(int? id)
        {
            Units _unit = unitRepository.GetUnits(id.Value);

            if (_unit == null)
            {
                Response.StatusCode = 404;
                return View("UnitNotFound", id.Value);
            }

            DeleteViewModel dvm = new DeleteViewModel()
            {
                unit = _unit,
                PageTitile = "Units Details"
            };


            return View(dvm);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(DeleteViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
              
                unitRepository.Delete(id);
                return RedirectToAction("list");
            }


            return View();
        }

        private static string ProcessUpload(UnitAddViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {

                string uploadsFolder = Path.Combine("wwwroot/images/");

                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
                
            }

            return uniqueFileName;
        }

       
      

       

    }
}
