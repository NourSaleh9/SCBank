using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SCBankGym.Data;
using SCBankGym.Models;
using System.Diagnostics;

namespace SCBankGym.Controllers
{
    public class HomeController : Controller 
    {
        private readonly ILogger<HomeController> _logger;
        GymDataBaseContext db= new GymDataBaseContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
           // var result = db.Trainers.ToList();      
            return View();
        }

        
//ContactUs
        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveContact(ContactUModel model)
        {
            try { 
            ContactU contact = new ContactU();
            //var x = db.Trainees.Where(a => a.Email == trainee.Email && a.Passwordd == trainee.Passwordd).ToList();
            //contact.TrineeId=x[0].TrineeId;
            contact.Message = model.Message;
            contact.Name = model.Name;
            contact.Phone = model.Phone;
            db.ContactUs.Add(contact);
            db.SaveChanges();

        }catch (Exception ex)
            {
               Console.WriteLine(ex.ToString());            
            }  
            return RedirectToAction("Index");
        }
          public JsonResult IsUserExists(string Email)
          {  
             return Json(!db.Trainees.Any(x => x.Email == Email), new Newtonsoft.Json.JsonSerializerSettings());
          }

        [HttpPost]
        public IActionResult TraineeRegister(TraineeModel trainee)
        {
            try
            {
                int Emailexist= db.Trainees.Where(a => a.Email == trainee.Email).Count();
                if(Emailexist>0)
                {
                    ViewBag.Error = "Email Exists";
                    return RedirectToAction("Index");
                }
                Trainee _trainee = new Trainee();
                _trainee.Email=trainee.Email;
                _trainee.Subscription= trainee.Subscription;
                _trainee.LastName=trainee.LastName;
                _trainee.Gender= trainee.Gender;
                _trainee.Class = trainee.Class;
                _trainee.City=trainee.City;
                _trainee.FirstName=trainee.FirstName;   
                _trainee.Age=trainee.Age;   
                _trainee.Phone=trainee.Phone;
                _trainee.Passwordd = trainee.Passwordd;
                //if(IsUserExists(trainee.Email) == null) { 
                db.Trainees.Add(_trainee);
                    db.SaveChanges();
                    
                //}
                //else
                //{
                    
                //}
                
           
            }catch (Exception ex)
            {
               Console.WriteLine(ex.ToString());            
            }
            var x = db.Trainees.Where(a => a.Email == trainee.Email && a.Passwordd == trainee.Passwordd).ToList();
            return View("Profile", x[0]); 
        }

        [HttpGet]
        public IActionResult TraineeLogin()
        {
            return View();
        }

      

        [HttpPost]
        public IActionResult TraineeLogin(TraineeModel trainee)
        {
            
            try
            {
              
              var x = db.Trainees.Where(a => a.Email == trainee.Email && a.Passwordd == trainee.Passwordd).ToList();
                   // HttpContext.Session.SetString[x];
                if(  x.Count > 0)
                {
                    ViewBag.Error = "";
                    //HttpContext.Session.SetString("ID", x[0].TraineeId.ToString());
                    //HttpContext.Session.SetString("UserName", x[0].FirstName.ToString());
                    return View("Profile",x[0]);
                }
                else
                {
                    ViewBag.Error = "Email or Password is wrong!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ViewBag.Error = ex.ToString();
                return View();
            }

           
        }
        [HttpPost]
        public IActionResult Profile(Trainee trainee)
        {
            return View(trainee);
        }

        public IActionResult Logout()
        {

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(TrainerModel trainer)
        {

            try
            {
                var x = db.Trainers.Where(a => a.Name == trainer.Name && a.Passwordd == trainer.Passwordd).ToList();
                if (x.Count > 0)
                {
                    // HttpContext.Current.Session["Email"] = trainee.Email;
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return View();
            }


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}