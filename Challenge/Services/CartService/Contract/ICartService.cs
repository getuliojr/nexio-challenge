using Challenge.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Services.CartService.Contract
{
    public interface ICartService
    {
        CartModel GetCartByUserId(string userId);
        void AddProductToCart(string cartId, string productId);
        void RemoveProductFromCart(string cartId, string productId);
    }
}
