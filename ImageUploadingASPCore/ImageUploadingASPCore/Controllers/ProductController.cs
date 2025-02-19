using ImageUploadingASPCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageUploadingASPCore.Controllers
{
    public class ProductController : Controller
    {
        ImageDbContext context;
        IWebHostEnvironment env;
        public ProductController(ImageDbContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }
        public IActionResult Index()
        {
            return View(context.Products.ToList());
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductViewModelcs prod)
        {
            string filename = "";
            if (prod.Photo != null)
            {
                var ext = Path.GetExtension(prod.Photo.FileName);
                var size = prod.Photo.Length;
                if (ext.Equals(".png") || ext.Equals(".jpg") || ext.Equals(".jpeg"))
                {

                    if (size <= 1000000)
                    {



                        string folder = Path.Combine(env.WebRootPath, "images");
                        filename = Guid.NewGuid().ToString() + "_" + prod.Photo.FileName;
                        string filepath = Path.Combine(folder, filename);
                        prod.Photo.CopyTo(new FileStream(filepath, FileMode.Create));

                        Product p = new Product()
                        {
                            Name = prod.Name,
                            Price = prod.Price,
                            ImagePath = filename
                        };
                        context.Products.Add(p);
                        context.SaveChanges();
                        TempData["Success"] = "Product Added...";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["size_error"] = "only less then 1mb size ...";
                    }
                }
                else
                {
                    TempData["ext_error"] = "only png , jpeg, jpg ...";
                }

            }
            return View();
        }
    }
}
