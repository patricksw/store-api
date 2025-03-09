using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly DefaultContext _context;

        public CartRepository(DefaultContext context) => _context = context;

        public async Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default)
        {
            await _context.Carts.AddAsync(cart, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return cart;
        }

        public async Task<Cart> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Carts.Include(c => c.Products).FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Cart>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Carts.Include(c => c.Products).ToListAsync(cancellationToken);
        }

        public async Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(cart.Id, cancellationToken);
            if (entity is null)
                return null;

            _context.ItemCarts.RemoveRange(entity.Products);
            _context.Carts.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            await CreateAsync(cart, cancellationToken);
            return cart;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _context.ItemCarts.RemoveRange(entity.Products);
            _context.Carts.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}