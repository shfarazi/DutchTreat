using System.Collections.Generic;
using DutchTreat.Data.Entities;

namespace DutchTreat.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCatagory(string category);

        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);

        bool SaveAll();
        void AddEntity(object model);
    }
}