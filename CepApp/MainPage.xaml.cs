using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using CepApp.Model;


namespace CepApp
{
    public partial class MainPage : ContentPage
    {
        async void Handle_Completed(object sender, System.EventArgs e)
        {
            var client = new HttpClient();
            string cep = txtCEP.Text;
            var json = await client.GetStringAsync($"https://viacep.com.br/ws/{cep}/json/");
            var dados = JsonConvert.DeserializeObject<Endereco>(json);

            lblLogradouro.Text = dados.logradouro;
            lblComplemento.Text = dados.complemento;
            lblBairro.Text = dados.bairro;
            lblLocalidade.Text = dados.localidade;
            lblUF.Text = dados.uf;
            lblUnidade.Text = dados.unidade;
            lblIBGE.Text = dados.ibge;
            lblGIA.Text = dados.gia;

        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
