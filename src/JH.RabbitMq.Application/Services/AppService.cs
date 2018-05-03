using JH.RabbitMq.Application.Services.Interfaces;
using JH.RabbitMq.Domain.UoW;


namespace JH.RabbitMq.Application.Services
{
    public class AppServiceBase
        : IAppService
    {

        private static IUnitOfWork _uow;
        public AppServiceBase(IUnitOfWork uow) => _uow = uow;

        public void Commit()
        {
            _uow.Commit();
        }
    }
}
