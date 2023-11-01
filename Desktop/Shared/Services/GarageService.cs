using Egarage.Shared.Models;
using Egarage.Shared.Services;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Egarage.Shared.Enums;

namespace Desktop.Shared.Services
{
    internal sealed class GarageService : IGarageService
    {
        private List<GarageModel> garages = new List<GarageModel>();
        private List<Order> orders = new List<Order>();
        private readonly IJSRuntime _jSRuntime;
        private readonly IFileSystem _fileSystem;

        public GarageService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }
        public async Task ChangeStatus(Guid garageId, Status status)
        {
            await LoadData();

            var garage = garages.FirstOrDefault(x => x.Id == garageId);

            if (garage == null)
                return;
            var index = garages.IndexOf(garage);
            garages[index] = garage;

            garage = garage with { Status = status };

            await SaveData();
        }

        public async Task Create(NewGarage data)
        {
           await LoadData();

            var order = orders.FirstOrDefault(x => x.Id == data.OrderId);

            var garage = new GarageModel(Guid.NewGuid(), data.Name,data.Description, Status.ToDO, order);

            garages.Add(garage);

            await SaveData();
        }

        public async Task CreateOrder(NewOrder data)
        {
            await LoadData();

            var order = new Order(Guid.NewGuid(), data.Name, data.Color);

            orders.Add(order);

            await SaveData();
        }

        public async Task<IEnumerable<GarageModel>> GetAll(Guid? withOrders)
        {
            await LoadData();
            return withOrders is null 
                ? garages 
                : garages.Where(x => x.Order is not null && x.Order.Id == withOrders);
        }

        public async Task<Order> GetOrder(Guid OrderId)
        {
            await LoadData();
            return orders.FirstOrDefault(x => x.Id == OrderId);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            await LoadData();
            return orders;
        }

        public async Task Remove(Guid garageId)
        {
            await LoadData();

            var garageToRemove = garages.FirstOrDefault(x =>x.Id == garageId);
            if (garageToRemove != null)
                return;
            garages.Remove(garageToRemove);
            await SaveData();
        }

        public async Task LoadData()
        {
            var loadedGarages = await _jSRuntime.InvokeAsync<string>("localStorage.getItem","garages");
            var loadedOrders = await _jSRuntime.InvokeAsync<string>("localStorage.getItem","orders");

            if (loadedGarages is not null)
            {
                garages = JsonSerializer.Deserialize<List<GarageModel>>(loadedGarages);
            }
            if (loadedOrders is not null)
            {
                orders = JsonSerializer.Deserialize<List<Order>>(loadedOrders);
            }
        }
        private async Task SaveData()
        {
            await _jSRuntime.InvokeVoidAsync("localStorage.setItem","garages", JsonSerializer.Serialize(garages));
            await _jSRuntime.InvokeVoidAsync("localStorage.setItem", "garages", JsonSerializer.Serialize(garages));
        }
    }
}
