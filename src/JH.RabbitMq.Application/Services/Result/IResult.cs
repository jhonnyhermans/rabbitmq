using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace JH.RabbitMq.Application.Services.Result
{
    public interface IResult
    {
        string Content { get; set; }
        bool Success { get; set; }
        string[] Errors { get; set; }
    }

    public interface IResult<T> : IResult where T : class

    {
        T Response { get; set; }
    }

    public class Sucess
        : IResult
    {
        public Sucess()
        {
            Success = true;
        }
        public Sucess(HttpResponseMessage response)
        {

            if (response.IsSuccessStatusCode)
            {
                Success = true;
            }
            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Success = false;
                    Errors = new string[] { "Você precisa estar logado para fazer essa requisição." };
                    return;
                }

                if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    Success = false;
                    Errors = new string[] { "Acesso negado." };
                    return;
                }


                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Success = false;
                    Errors = new string[] { "Link não encontrado." };
                    return;
                }


                var content = response.Content.ReadAsStringAsync();
                Content = content.Result;
                var serverResult = JsonConvert.DeserializeObject<ServerResultInternals>(content.Result);
                this.Success = serverResult.Success;
                this.Errors = serverResult.Errors;
            }
        }

        public bool Success { get; set; }
        public string[] Errors { get; set; }
        public string Content { get; set; }

        private class ServerResultInternals
        {
            public bool Success { get; set; }
            public string[] Errors { get; set; }
        }
    }

    public class Sucess<T> : Sucess, IResult<T> where T : class
    {
        public Sucess(T response)
        {
            Success = true;
            Response = response;
        }

        public Sucess(HttpResponseMessage response) : base(response)
        {
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync();
                Content = content.Result;
                Response = JsonConvert.DeserializeObject<T>(content.Result);
            }
        }
        public T Response { get; set; }
    }

    public class Error
        : IResult
    {

        public Error(HttpRequestException ex)
        {
            Success = false;
            Errors = new string[] { "Não foi possível acessar o servidor" };

        }
        public bool Success { get; set; }
        public string[] Errors { get; set; }
        public string Content { get; set; }
    }

    public class Error<T> : Error, IResult<T> where T : class
    {
        public Error(HttpRequestException ex) : base(ex)
        {
            Response = null;
        }
        public T Response { get; set; }
    }

}
