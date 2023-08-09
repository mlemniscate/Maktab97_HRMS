using Application;
using Application.Dtos;
using Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            var employeeDtos = employeeService.GetAll();
            return View(employeeDtos);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AddLeave(Guid id)
        {
            ViewData["ExceptionMessage"] = TempData["ExceptionMessage"];
            var employeeDto = employeeService.GetById(id);
            return View(employeeDto);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        public ActionResult Create(EmployeeCreateDto employeeCreateDto)
        {
            try
            {
                employeeService.Create(employeeCreateDto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ViewData["ExceptionMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddLeave(AddEmployeeLeaveDto addEmployeeLeaveDto)
        {
            try
            {
                employeeService.AddLeave(addEmployeeLeaveDto);
                return RedirectToAction(nameof(AddLeave), new {id = addEmployeeLeaveDto.EmployeeId});
            }
            catch (Exception ex)
            {
                TempData["ExceptionMessage"] = ex.Message;
                return RedirectToAction(nameof(AddLeave), new
                {
                    id = addEmployeeLeaveDto.EmployeeId
                }); 
            }
        }
        
    }
}
