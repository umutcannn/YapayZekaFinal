using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApplication1.MLModel;

namespace WebApplication1.Controllers
{
    public class Odev : Controller
    {
        public object ConsumeModel { get; private set; }

        [HttpGet]
        public IActionResult Predict()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Predict(ModelInput input)
        {
            var prediction = MLModel.Predict(input);
            ViewBag.Result = prediction;
            return View();
        }
    }
}
