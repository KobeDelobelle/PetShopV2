﻿using PetShopV2.Models;
using PetShopV2.Services;
using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace PetShopV2.ViewModels
{
    [QueryProperty(nameof(FoodId), nameof(FoodId))]
    public class FoodDetailViewModel : BaseViewModel
    {
        private Food selectedFood;
        private int foodId;
        public Command AddProductCommand => new Command(OnAddProduct);

        public int FoodId
        {
            get { return foodId; }
            set
            {
                foodId = value;
                LoadProduct(value);
            }
        }

        public Food SelectedFood
        {
            get { return selectedFood; }
            set
            {
                selectedFood = value;
                OnPropertyChanged(nameof(SelectedFood));
            }
        }

        public async void LoadProduct(int productId)
        {
            try
            {
                SelectedFood = await DataStore.GetProductAsync(productId) as Food;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private void OnAddProduct()
        {
            CartItem cartItem = new CartItem()
            {
                Product = selectedFood,
                ID = selectedFood.ID,
            };

            var lijstje = CartSingleton.ShoppingCart.ItemsInCart;

            bool ziterin = false;

            foreach (var item in lijstje)
            {
                if (item.Product == selectedFood)
                {
                    ziterin = true;
                }
            }

            if (!ziterin)
            {
            CartSingleton.ShoppingCart.ItemsInCart.Add(cartItem);
            }

            lijstje.FirstOrDefault(x => x.Product == selectedFood).CartItemQuantity += 1;
        }
    }
}