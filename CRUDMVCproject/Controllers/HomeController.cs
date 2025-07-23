using CRUDMVCproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDMVCproject.Controllers
{
    public class HomeController : Controller
    {
        [Route("/dashboard")]
        public IActionResult home()
        {
            return View();
        }

        [HttpGet]
        [Route("/admin/employees")]

        public IActionResult Employees() 
        {
            //To show List of Employees
            Employees emp = new Employees();
            ViewBag.employeeList = emp.List();
            return View();
        }

        [HttpGet]
        [Route("employee/{id:int}")]
        public IActionResult Employee(int id)
        {
            //To get single value in form field
            Employees emp = new Employees();
            if(id> 0)
            {
                emp = new Employees();
                emp.GetSingleValue(id);
            }
            ViewBag.employeeList = emp.List();
            return View(emp);
        }

        [HttpPost]
        [Route("/admin/SaveEmployee")]

        public IActionResult SaveEmployee(Employees employees)
        {
            if(employees.id == 0)
            {
                employees.InsertUpdate("Insert");

            }
            else
            {
                employees.InsertUpdate("Update");
            }
                return RedirectToAction("Employees");
        }

        [HttpGet]
        [Route("/deleteemployee/{id:int}")]

        public IActionResult DeleteEmployee(int id)
        {
            Employees emp = new Employees();
            emp.Delete(id);
            return RedirectToAction("Employees");
        }


    }
}
