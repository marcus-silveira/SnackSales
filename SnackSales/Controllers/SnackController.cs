using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnackSales.Repositories.Interfaces;
using SnackSales.ViewModels;

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
            var snacksListViewModel = new SnackListViewModel
            {
                Snacks = _repository.GetAll().Include(c => c.Category).ToList(),
                CurrentCategory = "Categoria atual"
            };
            return View(snacksListViewModel);
        }
    }
}
