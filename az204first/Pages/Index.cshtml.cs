using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using az204first.models;
using az204first.Services;

namespace az204first.Pages
{
    public class IndexModel : PageModel
    {

        public List<Product> Products;

    

        public void OnGet()
        {
            ProductserviceSQL productservice = new ProductserviceSQL();
            Products = productservice.GetProducts();
        }
    }
}