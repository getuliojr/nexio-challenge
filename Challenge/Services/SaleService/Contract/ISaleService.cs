using Challenge.Models.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Services.SaleService.Contract
{
    public interface ISaleService
    {
        void AddProductOnSale(AddProductOnSaleModel model);
        IEnumerable<SaleProduct> GetProductsOnSale();
    }
}
