using Egarage.Shared.Enums;
using Egarage.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egarage.Shared.Services
{
    public interface IGarageService
    {
        Task Create(NewGarage data);
        Task CreateOrder(NewOrder order);
        Task Remove(Guid garageId);
        Task ChangeStatus(Guid garageId, string status);
        //Task ChangeOrder(Guid garageId, Guid orderId);
        Task<IEnumerable<GarageModel>> GetAll(Guid? withCategory);
        //Task<IEnumerable<GarageModel>> GetWithStatus(Status status);
        Task<IEnumerable<Order>> GetOrders();
        Task<Order?> GetOrder(Guid categoryId);
    }
}
