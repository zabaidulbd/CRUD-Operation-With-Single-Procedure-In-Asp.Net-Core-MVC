using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SatyaMvc4Crud.DataAccess;
using SatyaMvc4Crud.Models;

namespace SatyaMvc4Crud.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly DataAccessLayer _dataAccessLayer;

        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
            _dataAccessLayer = new DataAccessLayer(_configuration);
        }

        // GET: /Customer/    
        [HttpGet]
        public ActionResult InsertCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertCustomer(Customer objCustomer)
        {
            objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            if (ModelState.IsValid)
            {
                string result = _dataAccessLayer.InsertData(objCustomer);
                TempData["result1"] = result;
                ModelState.Clear();
                return RedirectToAction("ShowAllCustomerDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult ShowAllCustomerDetails()
        {
            Customer objCustomer = new Customer();
            objCustomer.ShowallCustomer = _dataAccessLayer.Selectalldata();
            return View(objCustomer);
        }

        [HttpGet]
        public ActionResult Details(string ID)
        {
            return View(_dataAccessLayer.SelectDatabyID(ID));
        }

        [HttpGet]
        public ActionResult Edit(string ID)
        {
            return View(_dataAccessLayer.SelectDatabyID(ID));
        }

        [HttpPost]
        public ActionResult Edit(Customer objCustomer)
        {
            objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            if (ModelState.IsValid)
            {
                string result = _dataAccessLayer.UpdateData(objCustomer);
                TempData["result2"] = result;
                ModelState.Clear();
                return RedirectToAction("ShowAllCustomerDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(string ID)
        {
            int result = _dataAccessLayer.DeleteData(ID);
            TempData["result3"] = result;
            ModelState.Clear();
            return RedirectToAction("ShowAllCustomerDetails");
        }
    }
}
