using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace ConsultaCEPCorreios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var correios = new wsCorreios.AtendeClienteClient();

            var dadosCorreios = correios.consultaCEPAsync("86300000").Result;
            var cepCorreios = new CEP
            {
                cep = dadosCorreios.@return.cep,
                logradouro = dadosCorreios.@return.end,
                complemento = dadosCorreios.@return.complemento2,
                bairro = dadosCorreios.@return.bairro,
                localidade = dadosCorreios.@return.cidade,
                uf = dadosCorreios.@return.uf
            };

            var client = new HttpClient();
            var resultViaCEP = client.GetAsync("https://viacep.com.br/ws/86300000/json").Result;
            var dadosViaCEP = resultViaCEP.Content.ReadAsStringAsync().Result;
            var cepVIACEP = JsonConvert.DeserializeObject<CEP>(dadosViaCEP);


        }
    }


    public class CEP
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }
    }

}
