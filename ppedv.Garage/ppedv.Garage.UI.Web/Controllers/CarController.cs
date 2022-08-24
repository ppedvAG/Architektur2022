using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.Garage.Logic.CarServices;
using ppedv.Garage.Model;
using ppedv.Garage.Model.Contracts.Infrastructure;

namespace ppedv.Garage.UI.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CarController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: CarController
        public ActionResult Index()
        {
            return View(unitOfWork.CarRepository.Query().ToList());
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            return View(unitOfWork.CarRepository.GetById(id));
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View(new Car() { Color = "Blau", Model = "NEU" });
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            try
            {
                unitOfWork.CarRepository.Add(car);
                unitOfWork.SaveAll();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(unitOfWork.CarRepository.GetById(id));
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Car car)
        {
            try
            {
                unitOfWork.CarRepository.Update(car);
                unitOfWork.SaveAll();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(unitOfWork.CarRepository.GetById(id));
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Car car)
        {
            try
            {
                unitOfWork.CarRepository.Delete(car);
                unitOfWork.SaveAll();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
