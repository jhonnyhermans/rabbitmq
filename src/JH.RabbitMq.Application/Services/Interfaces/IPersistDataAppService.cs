using JH.RabbitMq.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JH.RabbitMq.Application.Services.Interfaces
{

    public interface IPersistDataAppService : IAppService
    {
        void PersistData(PersistDataViewModel viewModel);
    }
}
