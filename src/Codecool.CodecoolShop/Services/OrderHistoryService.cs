using System;
using System.Collections.Generic;
using System.IO;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Models.Products;
using Codecool.CodecoolShop.Models.ViewModels;
using Newtonsoft.Json;
using static NuGet.Packaging.PackagingConstants;

namespace Codecool.CodecoolShop.Services
{
    public class OrderHistoryService
    {
        public List<OrderToFileModel> GetOrderHistoryForUser(string userId)
        {
            var ordersDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "orders");
            if (!Directory.Exists(ordersDirectory))
            {
                Directory.CreateDirectory(ordersDirectory);
            }

            var orderFiles = Directory.GetFiles(ordersDirectory, "*.json");

            var userOrders = new List<OrderToFileModel>();

            foreach (var orderFile in orderFiles)
            {
                var json = File.ReadAllText(orderFile);
                var order = JsonConvert.DeserializeObject<OrderToFileModel>(json);

                if (order.UserData.UserId == userId)
                {
                    userOrders.Add(order);
                }
            }

            return userOrders;
        }
    }
}
