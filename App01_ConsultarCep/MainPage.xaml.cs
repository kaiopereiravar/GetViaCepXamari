using App01_ConsultarCep.Services;
using App01_ConsultarCep.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01_ConsultarCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP; //+= para concatenar e atribuir
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();
            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCepService.BuscarEnderecoViaCep(cep);
                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {2} de {3}, {0}, {1} ", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    }
                    
                }
                catch(Exception e)
                {
                    DisplayAlert("ERRO CRITICO", e.Message, "OK");
                }
            }
        }

        private bool isValidCEP(string cep)
        {
            bool valid = true;

            if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");//esse OK é o nome do botão
                valid = false;
            }

            int NovoCEP = 0;
            if(!int.TryParse(cep,out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve ser composto apenas por números", "OK");
                valid = false;
            }

            return valid;
        }
    }
}
