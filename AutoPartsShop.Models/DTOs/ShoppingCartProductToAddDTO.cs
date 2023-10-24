using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.DataAccess.DTOs
{
    public class ShoppingCartProductToAddDTO
    {
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
    }
}
