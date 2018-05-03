using JH.RabbitMq.Application.DTOs;
using JH.RabbitMq.Application.Services.Result;
using JH.RabbitMq.Application.ViewModels;
using System.Threading.Tasks;

namespace JH.RabbitMq.Application.Services.Interfaces
{
    public interface ICollectDataAppService: IAppService
    {
        Task<IResult<Rootobject>> CollectData(CollectDataViewModel viewModel);
    }
}
