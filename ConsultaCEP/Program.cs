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
            Console.WriteLine("* CEP Correios *");
            Console.WriteLine("----------------");
            Console.WriteLine($"CEP: {cepCorreios.cep}");
            Console.WriteLine($"Endereco: {cepCorreios.logradouro}");
            Console.WriteLine($"Complemento: {cepCorreios.complemento}");
            Console.WriteLine($"Bairro: {cepCorreios.bairro}");
            Console.WriteLine($"Cidade: {cepCorreios.localidade}");
            Console.WriteLine($"UF: {cepCorreios.uf}");

            var client = new HttpClient();
            var resultViaCEP = client.GetAsync("https://viacep.com.br/ws/86300000/json").Result;
            var dadosViaCEP = resultViaCEP.Content.ReadAsStringAsync().Result;
            var cepVIACEP = JsonConvert.DeserializeObject<CEP>(dadosViaCEP);
            Console.WriteLine("\n* CEP VIACEP *");
            Console.WriteLine("--------------");
            Console.WriteLine($"CEP: {cepVIACEP.cep}");
            Console.WriteLine($"Endereco: {cepVIACEP.logradouro}");
            Console.WriteLine($"Complemento: {cepVIACEP.complemento}");
            Console.WriteLine($"Bairro: {cepVIACEP.bairro}");
            Console.WriteLine($"Cidade: {cepVIACEP.localidade}");
            Console.WriteLine($"UF: {cepVIACEP.uf}");
            Console.WriteLine($"Cod. IBGE: {cepVIACEP.ibge}");
            Console.WriteLine($"Cod. SIAFI: {cepVIACEP.siafi}");
            Console.WriteLine($"DDD: {cepVIACEP.ddd}");
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
