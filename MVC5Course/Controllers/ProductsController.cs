using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class ProductsController : BaseController
    {
        //private FabricsEntities db = new FabricsEntities();

        //private ProductRepository Repo = RepositoryHelper.GetProductRepository();

        // GET: Products
        public ActionResult Index()
        {
            var data = Repo.All().Take(5);

            //傳統寫法
            //var data2 = db.Product.Where(p => p.IsDelete);

            //假設需要處理兩個以上的Model
            //把第一個宣告的Respository內的UnitIfWork帶入建構式的參數，可以讓兩個Repository共通
            var RepoOL = RepositoryHelper.GetOrderLineRepository(Repo.UnitOfWork);


            return View(data);
        }

        [HttpPost]
        public ActionResult Index(IList<ProductsSaveViewModel> data)
        {
            return View(Repo.All().Take(5));
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var product = Repo.Find(item.ProductId);
                    product.Stock = item.Stock;
                    product.Price = item.Price;
                }

                Repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }
            else
            {
                return View(Repo.All().Take(5));
            }
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Product product = db.Product.Find(id);
            Product product = Repo.Find(id.Value);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                Repo.Add(product);
                Repo.UnitOfWork.Commit();
                //db.Product.Add(product);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Product product = db.Product.Find(id);
            Product product = Repo.Find(id.Value);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                Product p = Repo.Find(product.ProductId);
                Repo.UnitOfWork.Commit();

                //var db = Repo.UnitOfWork.Context;
                //db.Entry(product).State = EntityState.Modified;
                //db.SaveChanges();

                TempData["EditDoneMessage"] = "新增成功!";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, FormCollection Form)
        //{
        //    Product p = Repo.Find(id);

        //    if (TryUpdateModel<Product>(p, new string[] { "ProductId", "ProductName", "Price", "Active", "Stock" }))
        //    {
        //        Repo.UnitOfWork.Commit();

        //        TempData["EditDoneMessage"] = "修改成功!";
        //        return RedirectToAction("Index");
        //    }

        //    return View(p);
        //}

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = Repo.Find(id.Value);
            //Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Product product = db.Product.Find(id);
            Product product = Repo.Find(id);
            product.IsDelete = true;
            Repo.UnitOfWork.Commit();

            //db.Product.Remove(product);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Repo.UnitOfWork.Context.Dispose();
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
