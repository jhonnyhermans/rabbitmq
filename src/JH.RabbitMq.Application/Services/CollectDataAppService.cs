using JH.RabbitMq.Application.DTOs;
using JH.RabbitMq.Application.Services.Interfaces;
using JH.RabbitMq.Application.Services.Result;
using JH.RabbitMq.Application.ViewModels;
using JH.RabbitMq.Domain;
using JH.RabbitMq.Domain.Services.Interfaces;
using JH.RabbitMq.Domain.UoW;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JH.RabbitMq.Application.Services
{
    public class CollectDataAppService
        : AppServiceBase, ICollectDataAppService
    {
        private readonly ITemperatureDataStorageService _historicService;
        public CollectDataAppService(IUnitOfWork uow,
            ITemperatureDataStorageService historicService) : base(uow)
        {
            _historicService = historicService;
        }

        public object Client { get; private set; }

        public async Task<IResult<Rootobject>> CollectData(CollectDataViewModel viewModel)
        {

   
            var client = new HttpClient
            {
                MaxResponseContentBufferSize = 999999999
            };


            //var url = string.Format("http://apiadvisor.climatempo.com.br/api/v1/history/locale/{0}?token={1}&from={2}", 
            //    viewModel.Locale, 
            //    viewModel.Token,
            //    viewModel.From);


            var url = string.Format("http://apiadvisor.climatempo.com.br/api/v1/forecast/locale/{0}/hours/72?token={1}",
                viewModel.Locale,
                viewModel.Token,
                viewModel.From);

            var uri = new Uri(url);
            try
            {
                var response = await client.GetAsync(uri);
                return new Sucess<Rootobject>(response);
            }
            catch (HttpRequestException ex)
            {
                return new Error<Rootobject>(ex);
                throw;
            }

        }
    }
}
