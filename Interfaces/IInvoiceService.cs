using LoginAPIDotNet7_2.Models;

namespace LoginAPIDotNet7_2.Interfaces
{
    public interface IInvoiceService
    {
        //Task<ApiResponse<bool>> CreateInvoiceAsync(HeaderDto headerDto);
        Task<ApiResponse<bool>> CreateInvoiceAsync(HeaderDto headerDto);
    }

}
