﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ConsultarCep
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //App.Current.MainPage... Você consegue atribuir uma nova pagina
            MainPage = new MainPage();
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
