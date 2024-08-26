using LoginAPIDotNet7_2.Data;
using LoginAPIDotNet7_2.Interfaces;
using LoginAPIDotNet7_2.Models;

namespace LoginAPIDotNet7_2.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ApplicationDbContext _context;
        private static int _CurrentOrderId = 1000;

        public InvoiceService(ApplicationDbContext context)
        {
            _context = context;
        }

        private int GenerateOrderId()
        {
            var lastOrderId = _context.Headers
                .OrderByDescending(h => h.OrderId)
                .Select(h => h.OrderId)
                .FirstOrDefault();

            // If the last OrderId is greater than or equal to 1000, use it as the base
            if (lastOrderId != 1000)
            {
                Interlocked.Exchange(ref _CurrentOrderId, lastOrderId);
            }
            return Interlocked.Increment(ref _CurrentOrderId);
        }

        public async Task<ApiResponse<bool>> CreateInvoiceAsync(HeaderDto headerDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {

                var header = new Header
                {
                    OrderId = GenerateOrderId(),
                    InvoiceNumber = headerDto.InvoiceNumber,
                    InvoiceDate = headerDto.InvoiceDate,
                    DueDate = headerDto.DueDate,
                    From = headerDto.From,
                    BillTo = headerDto.BillTo,
                    Subtotal = headerDto.Subtotal,
                    Tax = headerDto.Tax,
                    Discount = headerDto.Discount,
                    Total = headerDto.Total,
                    AmountPaid = headerDto.AmountPaid,
                    BalanceDue = headerDto.BalanceDue,
                    Notes = headerDto.Notes,
                    Terms = headerDto.Terms,
                };
                await _context.Headers.AddAsync(header);
                await _context.SaveChangesAsync();
                var orderItem = headerDto.OrderItems.Select(li => new OrderItem
                {

                    HeaderId = header.HeaderId,
                    ProductName = li.ProductName,
                    Quantity = li.Quantity,
                    Rate = li.Rate,
                    Discount = li.Discount,
                    Amount = li.Amount
                }).ToList();
                await _context.OrderItems.AddRangeAsync(orderItem);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return new ApiResponse<bool>
                {
                    Success = true,
                    Message = "Invoice created successfully",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = $"Inner exception: {ex.InnerException}",
                    Data = false
                };
            }
        }

        //public async Task<ApiResponse<bool>> CreateInvoiceAsync(HeaderDto headerDto)
        //{
        //    using var transaction = await _context.Database.BeginTransactionAsync();
        //    try
        //    {

        //        var header = new Header
        //        {
        //            OrderId = GenerateOrderId(),
        //            InvoiceNumber = headerDto.InvoiceNumber,
        //            InvoiceDate = headerDto.InvoiceDate,
        //            DueDate = headerDto.DueDate,
        //            From = headerDto.From,
        //            BillTo = headerDto.BillTo,
        //            Subtotal = headerDto.Subtotal,
        //            Tax = headerDto.Tax,
        //            Discount = headerDto.Discount,
        //            Total = headerDto.Total,
        //            AmountPaid = headerDto.AmountPaid,
        //            BalanceDue = headerDto.BalanceDue,
        //            Notes = headerDto.Notes,
        //            Terms = headerDto.Terms,
        //        };
        //        await _context.Headers.AddAsync(header);
        //        await _context.SaveChangesAsync();
        //        if (headerDto.OrderItems is null) 
        //        {
        //            await transaction.RollbackAsync();

        //            return new ApiResponse<bool>
        //            {
        //                Success = false,
        //                Message = "Invalid model state",
        //                Data = false
        //            };
        //        }
        //        var orderItem = headerDto.OrderItems.Select(li => new OrderItem
        //        {

        //            HeaderId = header.HeaderId,
        //            ProductName = li.ProductName,
        //            Quantity = li.Quantity,
        //            Rate = li.Rate,
        //            Discount = li.Discount,
        //            Amount = li.Amount
        //        }).ToList();
        //        await _context.OrderItems.AddRangeAsync(orderItem);
        //        await _context.SaveChangesAsync();

        //        await transaction.CommitAsync();
        //        return new ApiResponse<bool>
        //        {
        //            Success = true,
        //            Message = "Invoice created successfully",
        //            Data = true
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        await transaction.RollbackAsync();
        //        return new ApiResponse<bool>
        //        {
        //            Success = false,
        //            Message = $"Failed to create invoice: {ex.Message}",
        //            Data = false
        //        };
        //    }
        //}
    }
}
