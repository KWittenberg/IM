﻿namespace IM.Models.ViewModel;

public class ShoppingCartViewModel : ShoppingCartBase
{
    public int Id { get; set; }
    public List<ShoppingCartItemViewModel> ShoppingCartItems { get; set; }

    public ApplicationUserViewModel ApplicationUser { get; set; }
    public decimal GetTotalPrice()
    {
        decimal totalPrice = 0;

        if (ShoppingCartItems.Any())
        {
            foreach (var item in ShoppingCartItems)
            {
                totalPrice += item.Price * item.Quantity;
            }

        }

        return totalPrice;
    }

    public decimal GetTotalPriceWithVAT()
    {
        decimal totalPrice = GetTotalPrice();
        totalPrice = totalPrice * 1.25M;
        return totalPrice;
    }

    public ShoppingCartStatus ShoppingCartStatus { get; set; }
    public DateTime Created { get; set; }
}