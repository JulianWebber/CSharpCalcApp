using System;
using Microsoft.AspNetCore.Mvc;
using CalculatorWebApp.Models;

namespace CalculatorWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        private static Calculator _calculator = new Calculator();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(double num1, double num2, string operation)
        {
            try
            {
                double result = _calculator.Calculate(num1, num2, operation);
                return Json(new { success = true, result = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetHistory()
        {
            return Json(_calculator.GetHistory());
        }

        [HttpPost]
        public IActionResult ClearHistory()
        {
            _calculator.ClearHistory();
            return Json(new { success = true });
        }
    }
}
