using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnackSales.Repositories.Interfaces;

namespace SnackSales.Controllers
{
    public class SnackController : Controller
    {
        private readonly ISnackRepository _repository;

        public SnackController(ISnackRepository repository)
        {
            _repository = repository;
        }

        public IActionResult List()
        {
            var snacks = _repository.GetAll().Include(c=> c.Category).ToList();
            return View(snacks);
        }
    }
}
