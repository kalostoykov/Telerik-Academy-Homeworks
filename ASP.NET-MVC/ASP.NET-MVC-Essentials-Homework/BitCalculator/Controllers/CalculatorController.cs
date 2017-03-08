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
            decimal chosenValue = decimal.Parse(model.Type);
            decimal kilo = decimal.Parse(model.Kilo);
            int quantity = model.Quantity;

            foreach (StorageUnit unit in model.Units)
            {
                unit.RelativeValue = (chosenValue / unit.Value) * quantity;

                if (kilo == 1024)
                {
                    unit.RelativeValue *= 1024.0m / 1000;
                }
            }

            return this.View(model);
        }

        //[ChildActionOnly]
        //public ActionResult CalculatorPartial(CalculatorFormViewModel model)
        //{
        //    return this.PartialView("_CalculatorResult", model);
        //}
    }
}