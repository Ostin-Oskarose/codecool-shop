using System;
using System.Collections.Generic;
using Codecool.CodecoolShop.Models.DTO;
using Codecool.CodecoolShop.Models.Payment;
using Codecool.CodecoolShop.Models.UserData;

namespace Codecool.CodecoolShop.Models
{
    public class OrderToFileModel
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<ProductDto> Products { get; set; }
        public UserDataModel UserData { get; set; }
        public PaymentModel Payment { get; set; }
    }
}
