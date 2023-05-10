using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;
using Microsoft.AspNetCore.Identity;

namespace Codecool.CodecoolShop.Models;

public class DatabaseCart
{
    [System.ComponentModel.DataAnnotations.Key]
    public string UserId { get; set; }

    //[ForeignKey("UserId")]
    //public IdentityUser User { get; set; }

    public string ShoppingCartData { get; set; }
}