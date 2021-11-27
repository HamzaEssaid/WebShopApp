using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using You.DTOs;
using You.UI.DataAccess;

namespace You.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDataAccess _dataAccess;

        [BindProperty]
        public string SearchTerm { get; set; }

        public IndexModel(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public List<ItemsDTO> Items1 { get; set; }
        public List<ItemsDTO> products { get; set; }
        public static CartDTO Cart { get; set; }
        public void OnGet()
        {

            if (products == null)
            {
                products = _dataAccess.GetAllitems().ToList();
                Cart = new CartDTO();
            }
        }

        public void/*IActionResult*/ OnPostCartAdd()
        {
            OnGet();
            //try
            //{
            //    //Hämta avädare från cookie
            //    int id = (int)HttpContext.Session.GetInt32("UserId");
            //    CustomerDTO customer = _dataAccess.GetCustomerById(id);
            //    ItemsDTO item = _dataAccess.GetItemsById(Convert.ToInt32(Request.Form["item_itemid"]));
            //    customer.Cart.Products.Add(item);
            //    return Page();

            //}
            //catch
            //{
            //    //Om användaren inte är inloggad: skicka dem till login istället
            //    return RedirectToPage("/Login");
            //}
            var item_url = Request.Form["item_url"];
            var item_name = Request.Form["item_name"];
            var item_price = Request.Form["item_price"];
            var item_itemid = Request.Form["item_itemid"];
            var MyObj = new ItemsDTO();
            MyObj.ImgUrl = item_url;
            MyObj.Name = item_name;
            MyObj.Price = Convert.ToInt32(item_price);
            MyObj.itemId = Convert.ToInt32(item_itemid);

            //Cart.Products.Add(MyObj);

            ShoppingCartModel.ShoppingCartItem.Add(MyObj);
            var MyObjTotalPrice = new ItemsDTO();
            MyObjTotalPrice.CheckOutPriceTotal += MyObj.Price;
        }
        //public IActionResult OnPostSave()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _dataAccess.SaveItem(Item);
        //        return Page();
        //    }
        //    return Page();
        //}
        public ActionResult OnPostSearch()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                products = _dataAccess.GetAllitems().Where(p => p.Name.ToLower().Contains(SearchTerm.ToLower())).ToList();
                return Page();
            }
            return RedirectToPage("/Index");
        }
    }
}
