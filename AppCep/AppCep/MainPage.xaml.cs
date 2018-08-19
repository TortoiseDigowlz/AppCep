using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppCep.Servico;
using AppCep.Servico.Modelo;


namespace AppCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Btn_send.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs args)
        {
            //validate

            //logica

            //search
            string cep = InputCep.Text.Trim();
            cep = cep.Replace("-", "");

            if (IsValidCep(cep))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarCep(cep);
                    if (end != null)
                        lbl_result.Text = string.Format("Endereço: {2}, {3}, {0} , {1}, {2}", end.localidade, end.uf, end.logradouro, end.bairro);
                    else
                    DisplayAlert("ERRO", "CEP não encontrado, verifique o CEP e tente novamente", "OK");
                }
                catch (Exception ex)
                {

                    DisplayAlert("ERRO", "O serviço de busca está indisponível./nCódigo do Erro:"+ex.Message, "OK");
                }
            }
            else
            {

                lbl_result.Text = "O CEP digitado é inválido.";

            }

        }

        private bool IsValidCep(string cep)
        {
            int auxCep = 0;
            if (!int.TryParse(cep, out auxCep))
            {
                DisplayAlert("ERRO", "O cep digitado contém letras.", "OK");
                return false;
            }

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "O cep digitado está incompleto ou possui números a mais.", "OK");
                return false;
            }
           
                       
                return true;
            
        }

    }
}
