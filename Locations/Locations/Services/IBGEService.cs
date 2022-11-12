using Locations.DTO;
using Locations.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Locations.Services
{
    public class IBGEService : IIBGEService
    {
        public string RequestAll()
        {
            WebRequest request = WebRequest.Create($"https://servicodados.ibge.gov.br/api/v1/localidades/estados");
            request.Method = "GET";
            request.ContentType = "application/json";

            return GetRequestResponse(request);
        }

        public string RequestOne(int id)
        {
            WebRequest request = WebRequest.Create($"https://servicodados.ibge.gov.br/api/v1/localidades/estados/");
            request.Method = "GET";
            request.ContentType = "application/json";

            return GetRequestResponse(request);
        }

        public string GetRequestResponse(WebRequest request)
        {
            try
            {
                using (var resposta = request.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    var objResponse = reader.ReadToEnd();
                    streamDados.Close();
                    resposta.Close();
                    return objResponse.ToString();
                }
            }
            catch (System.Net.WebException ex)
            {
                var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                return resp.ToString();
            }
        }
    }
}
