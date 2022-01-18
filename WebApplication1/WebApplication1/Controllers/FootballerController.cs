using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class FootballerController : Controller
    {

        public IActionResult Listele()
        {
            return View(Models.FootballerData.Footballers);
            
        }

        public IActionResult Ekle()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Ekle(Models.Footballer newFootballer)
        {
            Models.FootballerData.Footballers.Add(newFootballer);
            return RedirectToAction("Listele"); 
        }


        public IActionResult Guncelle(int id)
        {
            var guncelle = Models.FootballerData.Footballers.FirstOrDefault(b => b.Id == id);
            return View(guncelle);
        }

        [HttpPost]
        public IActionResult Guncelle(Models.Footballer footballer)
        {

            var guncelleOrj = Models.FootballerData.Footballers.FirstOrDefault(b => b.Id == footballer.Id);

            var guncelle = Models.FootballerData.Footballers.FirstOrDefault(b => b.Id == footballer.Id);

            guncelle.Ad = footballer.Ad;
            guncelle.Takim = footballer.Takim;
            guncelle.Pozisyon = footballer.Pozisyon;
            guncelle.Yas = footballer.Yas;


            Models.FootballerData.Footballers.Remove(guncelleOrj);
            Models.FootballerData.Footballers.Add(guncelle); 

            return RedirectToAction("Listele");
           
        }



        public IActionResult Detaylar(int id)//Parametre degeri girdim
        {
            var detay = Models.FootballerData.Footballers.FirstOrDefault(b => b.Id == id);
            return View(detay); 

        }


        public IActionResult Sil(int id)
        {
            var sil = Models.FootballerData.Footballers.FirstOrDefault(b => b.Id == id);
            return View(sil); 
        }


        [HttpPost]
        public IActionResult Sil(Models.Footballer footballer)
        {
            var sil = Models.FootballerData.Footballers.FirstOrDefault(b => b.Id == footballer.Id);
            Models.FootballerData.Footballers.Remove(sil);
            return RedirectToAction("Listele"); 
        }


    }
}
