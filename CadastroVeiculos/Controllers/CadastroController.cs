using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CadastroVeiculos.Models;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace CadastroVeiculos.Controllers
{
    public class CadastroController : Controller
    {
        private modeloBD db = new modeloBD();/*;*/
        public object GetExtension { get; private set; }
        public IEnumerable<object> ImagemFile { get; private set; }

        // GET: Cadastro
        public ActionResult Index()
        {
            using (modeloBD modeloBD = new modeloBD())
            {
                return View(db.TBLimagem.ToList());
            }
        }

        // GET: Cadastro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLimagem tBLimagem = db.TBLimagem.Find(id);
            if (tBLimagem == null)
            {
                return HttpNotFound();
            }
            return View(tBLimagem);
        }

        // GET: Cadastro/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TBLimagem tblimagem)
        {
            string fileName = Path.GetFileNameWithoutExtension(tblimagem.ImagemFile.FileName);
            string extension = Path.GetExtension(tblimagem.ImagemFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            tblimagem.imagem = "C:/Users/brenn/source/repos/CadastroVeiculos/CadastroVeiculos/imagem" + fileName;
            fileName = Path.Combine(Server.MapPath("C:/Users/brenn/source/repos/CadastroVeiculos/CadastroVeiculos/imagem"), fileName);
            tblimagem.ImagemFile.SaveAs(fileName);
            using (modeloBD modeloBD = new modeloBD())
            {
                db.TBLimagem.Add(tblimagem);
                db.SaveChanges();
            }
            ModelState.Clear();
            return View();
        }

        // GET: Cadastro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLimagem tBLimagem = db.TBLimagem.Find(id);
            if (tBLimagem == null)
            {
                return HttpNotFound();
            }
            return View(tBLimagem);
        }

        // POST: Cadastro/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Placa,Renavan,Nome,CPF,imagem")] TBLimagem tBLimagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBLimagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBLimagem);
        }

        // GET: Cadastro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLimagem tBLimagem = db.TBLimagem.Find(id);
            if (tBLimagem == null)
            {
                return HttpNotFound();
            }
            return View(tBLimagem);
        }

        // POST: Cadastro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBLimagem tBLimagem = db.TBLimagem.Find(id);
            db.TBLimagem.Remove(tBLimagem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
