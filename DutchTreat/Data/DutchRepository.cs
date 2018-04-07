using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext _ctx;
        private readonly ILogger<DutchRepository> _logger;

        public DutchRepository(DutchContext ctx, ILogger<DutchRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders
                    .Include(x => x.Items)
                    .ThenInclude(i => i.Product)
                    .ToList();
            }
            else
            {
                return _ctx.Orders
                    .ToList();
            }
        }

        //Insert try/catch for all the methods so that error shows for all//

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called");
                return _ctx.Products
                           .OrderBy(p => p.Title)
                           .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products:{ex}");
                return null;
            }
        }

        public Order GetOrderById(int id)
        {
            return _ctx.Orders
                .Include(x => x.Items)
                .ThenInclude(i => i.Product)
                .Where(x => x.Id ==id)
                .FirstOrDefault();
        }

        public IEnumerable<Product> GetProductsByCatagory(string category)
        {
            return _ctx.Products
                       .Where(p => p.Category == category)
                       .ToList();
        }

        public bool SaveAll()
        {
           return _ctx.SaveChanges() > 0;
        }
    }
}
