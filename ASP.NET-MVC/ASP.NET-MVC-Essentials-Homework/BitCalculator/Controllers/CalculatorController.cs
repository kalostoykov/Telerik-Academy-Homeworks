using BitCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public ActionResult Calculator()
        {
            var model = new CalculatorFormViewModel
            {
                Quantity = 1,
                Type = "1",
                Kilo = "1000"
            };

            foreach (StorageUnit unit in model.Units)
            {
                unit.RelativeValue = 1 / (unit.Value);
            }

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Calculator(CalculatorFormViewModel model)
        {
            return this.View(model);
        }
    }
}