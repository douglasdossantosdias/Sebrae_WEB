using Newtonsoft.Json;
using RestSharp;
using Sebrae_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sebrae_WEB.Services
{
    public class Authentication
    {



        public IRestResponse Token(LoginViewModel usr)
        {


            var client = new RestClient("http://localhost:29587");
            var request = new RestRequest("/v1/account/login", Method.POST);
            request.RequestFormat = DataFormat.Json;
            string user = "{\"username\":\""+usr.NomeUsuario+"\", \"password\":\""+usr.SenhaUsuario+"\" }";
            request.AddParameter("application/json; charset=utf-8", user, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);


            return response;
        }

        public IRestResponse Get(string json)
        {
            var result = JsonConvert.DeserializeObject(json);
            json = result.ToString();


            var client = new RestClient("http://localhost:29587");
            var request = new RestRequest("/v1/account/authenticated", Method.GET);
            request.AddHeader("authorization", "bearer " + json);
            request.RequestFormat = DataFormat.Json;
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}