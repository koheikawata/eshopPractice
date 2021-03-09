using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eshopPractice.ApplicationCore.Exceptions;
using eshopPractice.ApplicationCore.Interfaces;
using eshopPractice.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eshopPractice.Pages.Basket
{
    public class CheckoutModel : PageModel
    {
        private readonly IBasketService _basketService;
        private string _username = null;
        private readonly IBasketViewModelService _basketViewModelService;
        private readonly IAppLogger<CheckoutModel> _logger;

        public CheckoutModel(IBasketService basketService, IBasketViewModelService basketViewModelService, IAppLogger<CheckoutModel> logger)
        {
            _basketService = basketService;
            _basketViewModelService = basketViewModelService;
            _logger = logger;
        }

        public BasketViewModel BasketModel { get; set; } = new BasketViewModel();

        public async Task OnGet()
        {
            await SetBasketModelAsync();
        }

        public async Task<IActionResult> OnPost(IEnumerable<BasketItemViewModel> items)
        {
            try
            {
                await SetBasketModelAsync();

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var updateModel = items.ToDictionary(b => b.Id.ToString(), b => b.Quantity);
                await _basketService.SetQuantities(BasketModel.Id, updateModel);
                await _basketService.DeleteBasketAsync(BasketModel.Id);
            }
            catch (EmptyBasketOnCheckoutException emptyBasketOnCheckoutException)
            {
                _logger.LogWarning(emptyBasketOnCheckoutException.Message);
                return RedirectToPage("/Basket/Index");
            }

            return RedirectToPage("Success");
        }

        private async Task SetBasketModelAsync()
        {
            GetOrSetBasketCookieAndUserName();
            BasketModel = await _basketViewModelService.GetOrCreateBasketForUser(_username);
        }

        private void GetOrSetBasketCookieAndUserName()
        {
            if (Request.Cookies.ContainsKey(Constants.BASKET_COOKIENAME))
            {
                _username = Request.Cookies[Constants.BASKET_COOKIENAME];
            }
            if (_username != null) return;

            _username = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Today.AddYears(10);
            Response.Cookies.Append(Constants.BASKET_COOKIENAME, _username, cookieOptions);
        }

        
    }
}
