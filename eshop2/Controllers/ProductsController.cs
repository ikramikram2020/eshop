using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web.Mvc;
using eshop2.Models;

namespace WebApplication3.Controllers
{
    public class produitsController : Controller
    {
        eshopContext context = new eshopContext();

        // GET: produits/ListeProduit
        public ActionResult ListeProduit()
        {
            return View("ListeProduit", context.Products.ToList());
        }

        // GET: produits/Afficherproduit/5  
        public ActionResult AfficherProduit(int id)
        {
            product P = new product();
            P = context.Products.Find(id);
            if (P != null)
                return View("AfficherProduit", P);
            else return HttpNotFound();

        }
        public ActionResult AjouterProduit()


        {
            product p = new product();
            return View("AjouterProduit", p);
        }
        [HttpPost]
        public ActionResult AjouterProduit(product p)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(p);
                context.SaveChanges();
                return RedirectToAction("ListeProduit");
            }
            else return View("AjouterProduit", p);
           
        }
        public ActionResult ListeSuppression ()
        {
            return View("ListeSuppression", context.Products.ToList());
        }

        public ActionResult Supprimer (int id)
        {
            product p = new product();
            p = context.Products.Find(id);
            if (p != null)
                return View("Supprimer", p);
            else return HttpNotFound();
            {
                
            }
        }
        [HttpPost, ActionName("Supprimer")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmerSuppression(int id)
        {
            product P = new product();
            P = context.Products.Find(id);
            if (P != null)
            {
                context.Products.Remove(P);
                context.SaveChanges();
            return RedirectToAction("ListeSuppression");
            }
            else return HttpNotFound();
        }




        public ActionResult ListeModification()
        {
            return View("ListeModification", context.Products.ToList());
        }
        public ActionResult Modifier(int id)
        {
            product P = new product();
            P = context.Products.Find(id);
            if (P != null)
            {
                return View("Modifier", P);
            }
            else return HttpNotFound();
        }
        [HttpPost, ActionName("Modifier")]
        [ValidateAntiForgeryToken]
        public ActionResult Modifier(product P)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(P).State = EntityState.Modified;
                    context.SaveChanges();
                    return View("ListeProduit", context.Products.ToList());
                }
                else return View("Modifier", P);
            }
            catch
            {
                return View("Modifier", P);
            }

        }

        public FileContentResult GetImage(int id)
        {
            var P = context.Products.Find(id);
            if (P != null && P.produitImage != null && !string.IsNullOrEmpty(P.produitImageType))
            {
                return File(P.produitImage, P.produitImageType);
            }
            else
            {
                return null;
            }
        }










    }
}
