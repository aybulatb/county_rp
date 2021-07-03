using CountyRP.Gateways.AdminPanel.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountyRP.Gateways.AdminPanel.Infrastructure.Services.Interfaces
{
    public interface ISupportRequestMessageSiteService
    {
        Task<SupportRequestMessageDtoOut> Create(SupportRequestMessageDtoIn supportRequestMessageDtoIn);
    }
}
