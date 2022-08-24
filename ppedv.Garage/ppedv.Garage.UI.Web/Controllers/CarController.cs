using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.Garage.Logic.CarServices;
using ppedv.Garage.Model;

namespace ppedv.Garage.UI.Web.Controllers
{
    public class CarController : Controller
    {
        CarManager cm = new CarManager(new Data.EfCore.EfUnitOfWork());

        // GET: CarController
        public ActionResult Index()
        {
            return View(cm.UnitOfWork.CarRepository.Query().ToList());
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            return View(cm.UnitOfWork.CarRepository.GetById(id));
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
                cm.UnitOfWork.CarRepository.Add(car);
                cm.UnitOfWork.SaveAll();

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
            return View(cm.UnitOfWork.CarRepository.GetById(id));
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Car car)
        {
            try
            {
                cm.UnitOfWork.CarRepository.Update(car);
                cm.UnitOfWork.SaveAll();

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
            return View(cm.UnitOfWork.CarRepository.GetById(id));
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Car car)
        {
            try
            {
                cm.UnitOfWork.CarRepository.Delete(car);
                cm.UnitOfWork.SaveAll();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
