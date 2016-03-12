using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity.Validation;
using System.Data.Entity;

namespace MVC5Course.Controllers
{
    public class EFController : BaseController
    {
        private FabricsEntities db = new FabricsEntities();
        // GET: EF
        public ActionResult Index(bool? IsActive, string Key)
        {
            Product _Product = new Product()
            {
                ProductName = "BCK",
                Price = 5,
                Stock = 1,
                Active = true
            };

            db.Product.Add(_Product);

            //SaveChanges();

            var Data = db.Product.OrderByDescending(p => p.ProductId).AsQueryable();

            if (IsActive.HasValue)
            {
                Data = Data.Where(p => p.Active == IsActive);
            }
            if (!string.IsNullOrWhiteSpace(Key))
            {
                Data = Data.Where(p => p.ProductName.Contains(Key));
            }


            return View(Data);
        }

        private void SaveChanges()
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                #region MyRegion
                List<string> ErrorMessage = new List<string>();
                foreach (var item in ex.EntityValidationErrors)
                {
                    foreach (var item2 in item.ValidationErrors)
                    {
                        ErrorMessage.Add(item2.ErrorMessage);
                    }
                }

                throw new Exception(String.Join(",", ErrorMessage.ToArray()));
                #endregion
            }
        }

        public ActionResult Details(int Id)
        {
            var data = db.Product.FirstOrDefault(p => p.ProductId == Id);
            //var data2 = db.Product.First(p => p.ProductId == Id);
            var data3 = db.Product.Where(p => p.ProductId == Id).ToList();

            return View(data);
        }

        public ActionResult Delete(int Id)
        {
            Product p = db.Product.Find(Id);

            db.OrderLine.RemoveRange(p.OrderLine);
            db.Product.Remove(p);
            SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult QueryPlan()
        {
            var data = db.Product.Include(t => t.OrderLine);

            var data2 = db.Database.SqlQuery<Product>(@"

select a.*, b.OrderCount from Product a
join (select productid, count(*) as OrderCount from orderline group by productid) b on a.productid = b.productid

");

            return View(data2);

        }
    }
}