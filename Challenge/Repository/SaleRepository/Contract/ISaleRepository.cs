using Challenge.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.SaleRepository.Contract
{
    public interface ISaleRepository
    {
        void AddSale(Sale sale);
        IEnumerable<Sale> GetSales(FilterDefinition<Sale> filter = null);
        void RemoveSale(string _id);
    }
}
