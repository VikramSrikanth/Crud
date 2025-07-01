using AspNetCoreGeneratedDocument;
using Crud.Data;
using Crud.Models;
using Crud.Service;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class MainController : Controller
    {
        private readonly AppDbContext _context;

        private readonly Services _service;

        //public MainController(AppDbContext con, Services service)
        //{
        //    _context = con;
        //    _service = service;
        //}
        public MainController(AppDbContext con)
        {
            _context = con;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind("UserId,Name,Email,Password,RollType")] user use)
        {
            if (ModelState.IsValid)
            {
                use.RegistrationDate = DateTime.Now;

                _context.Usertables.Add(use);
                _context.SaveChanges();
                return RedirectToAction("Read");

            }
            return View(use);
            //return _service.Create(use);
        }



        public async Task<IActionResult> Read(List<user> use)
        {
            var items = await _context.Usertables.ToListAsync();



            return View(items);
        }


        public async Task<IActionResult> Update(int id)
        {
                var item = await _context.Usertables.FirstOrDefaultAsync(x => x.UserId == id);
            
                return View(item);
            
          
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id,[Bind("UserId,Name,Email,Password,RollType,RegistrationDate")] user item)
        {
            if (ModelState.IsValid)
            {
               

                //_context.Usertables.Add(use);
                _context.Usertables.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Read");

            }
            return View(item);
            //return _service.Create(use);
        }
        
        public IActionResult Delete(int id)
        {
            var item = _context.Usertables.FirstOrDefault(x => x.UserId == id);
            return View(item);
          
        }

        [HttpPost, ActionName("Deleted")]
        public IActionResult Delete(user item)
        {   if (item != null)
            {
                _context.Usertables.Remove(item);
                _context.SaveChanges();
                return RedirectToAction("Read");
            }
        return View();
          //  return RedirectToAction("Read");
        }
    }
}
