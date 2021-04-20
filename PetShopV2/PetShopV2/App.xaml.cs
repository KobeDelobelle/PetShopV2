﻿using PetShopV2.Services;
using PetShopV2.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetShopV2
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<ProductExampleDB>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}