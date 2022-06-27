using Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product.Controllers
{
    public class ProController : Controller
    {
        productEntities db= new productEntities();
        [HttpGet]
        public ActionResult Add(int id=0)
        {
            ViewBag.BT = "Add";
            tblitem obj = new tblitem();
            if(id>0)
            {
                var data = db.tblitems.Where(x=>x.id==id).ToList();
                obj.id = data[0].id;
                obj.product_name = data[0].product_name;
                obj.product_model = data[0].product_model;
                obj.product_price = data[0].product_price;
                ViewBag.BT = "Update";
            }
            return View(obj);
        }
        [HttpPost]
        public ActionResult Add(tblitem item)
        {
            if(item.id>0)
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
            db.tblitems.Add(item);
            }
            db.SaveChanges();
            return RedirectToAction("Show");
        }

        public ActionResult Delete(int id=0)
        {
            var data = db.tblitems.Find(id);
            db.tblitems.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Show");
        }

        public ActionResult Show()
        {
           var data= db.tblitems.ToList();
            return View(data);
        }
    }
}