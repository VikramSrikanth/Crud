using Crud.Data;
using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;

namespace Crud.Service
{
    public class Services : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly MainController _controller;
        private readonly AppDbContext _context;
        public Services(MainController controller, AppDbContext context)
        {
            _controller = controller;
            _context = context;
        }


        public string Create(user use)
        {
            if (ModelState.IsValid)
            {
                use.RegistrationDate = DateTime.Now;

                _context.Usertables.Add(use);
                _context.SaveChanges();
                //return RedirectToAction("Read");
                return "success";

            }
            //return View(use);
            return "failure";
        }
    }
}
