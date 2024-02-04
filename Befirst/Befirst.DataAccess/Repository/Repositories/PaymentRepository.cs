using Befirst.DataAccess.DbConnection;
using Befirst.DataAccess.Models;
using Befirst.DataAccess.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Befirst.DataAccess.Repository.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly BefirstDbContext _paymentDbContext;

        public PaymentRepository(BefirstDbContext paymentDbContext)
        {
            _paymentDbContext = paymentDbContext;
        }

        public async Task<int> AddPaymentAsync(Payment payment)
        {
            try
            {
                _paymentDbContext.Payments.Add(payment);
                await _paymentDbContext.SaveChangesAsync();
                return payment.PaymentId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was adding changes");
            }
        }

        public async Task<int> DeletePaymentAsync(Payment payment)
        {
            try
            {
                _paymentDbContext.Payments.Remove(payment);
                await _paymentDbContext.SaveChangesAsync();
                return payment.PaymentId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was deleting changes");
            }
        }

        public async Task<List<Payment>> GetAllPaymentsAsync(string? searchWord)
        {
            try
            {
                var allPayments = await _paymentDbContext.Payments
                   .ToListAsync();
                if (!string.IsNullOrEmpty(searchWord))
                {
                    allPayments = allPayments.Where(n => n.ClientName.Contains(searchWord) || n.PaymentCategory.Contains(searchWord)).ToList();
                }
                return allPayments;
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving payments information");
            }
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            try
            {
                return await _paymentDbContext.Payments
                   .FirstOrDefaultAsync(u => u.PaymentId == id);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving PaymentById information");
            }
        }

        public async Task<int> UpdatePaymentAsync(Payment payment)
        {
            try
            {
                _paymentDbContext.Payments.Update(payment);
                await _paymentDbContext.SaveChangesAsync();
                return payment.PaymentId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it updating changes");
            }
        }
    }
}