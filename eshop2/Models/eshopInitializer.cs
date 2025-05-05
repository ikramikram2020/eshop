using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Web;

namespace eshop2.Models
{
    public class eshopInitializer : DropCreateDatabaseIfModelChanges<eshopContext>
    {
        protected override void Seed(eshopContext context)
        {
            var products = new List<product>
            {
            new product
                {
                    Id = 1,
                    Product_name = "Laptop",
                    product_description = "Core i7, 16GB RAM",
                    Quantite = 10,
                    produitImage = getFileBytes("~/Images/Mac.jpg"),
                    produitImageType = "image/jpeg"
                },
                new product
                {
                    Id = 2,
                    Product_name = "Smartphone",
                    product_description = "Android 12",
                    Quantite = 25,
                    produitImage = getFileBytes("~/Images/Iphone.jpg"),
                    produitImageType = "image/jpeg"
                },
                new product
                {
                    Id = 3,
                    Product_name = "Keyboard",
                    product_description = "Mechanical keyboard",
                    Quantite = 50,
                    produitImage = getFileBytes("~/Images/keyboard.jpg"),
                    produitImageType = "image/jpeg"
                }
            };


            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
        }

        private byte[] getFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }
    }
}
