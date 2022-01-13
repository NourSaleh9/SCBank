using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCBankGym.Data;
using SCBankGym.Models;

namespace SCBankGym.Controllers
{
    public class AdminController : Controller
    {
        GymDataBaseContext db = new GymDataBaseContext();
        // GET: AdminController
        public ActionResult Index()
        {
            List<TraineeModel> trineeModels = new List<TraineeModel>();
            var trainedb= db.Trainees.ToList();
            if(trainedb.Count>0)
            {
                foreach (var item in trainedb)
                {
                    trineeModels.Add(new TraineeModel
                    { Age = item.Age ,
                    City = item.City ,  
                    Class = item.Class ,    
                    Email = item.Email ,
                    FirstName= item.FirstName , 
                    LastName= item.LastName ,   
                    Phone   = item.Phone ,  
                    Gender = item.Gender ,
                    TraineeId = item.TraineeId ,
                    Subscription=item.Subscription ,
                    Photo = item.Photo ,


                    
                    });  
                }
            }
            return View(trineeModels);
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
