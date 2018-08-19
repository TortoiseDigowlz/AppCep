using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using AppCep.Servico.Modelo;
using Newtonsoft.Json;

namespace AppCep.Servico
{
    public class ViaCepServico
    {
        private static string cepUrl = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarCep(string cep)
        {
            string novaUrl = string.Format(cepUrl, cep);
            WebClient wc = new WebClient();
            string content = wc.DownloadString(novaUrl);
            Endereco end = JsonConvert.DeserializeObject<Endereco>(content);
            if (end.cep == null) return null;
            return end;            
        }
    }
}
