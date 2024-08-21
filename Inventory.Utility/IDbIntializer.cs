using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Inventory.Utility
{
    public  interface IDbIntializer
    {
       
        Task CreateSuperAdmin();
        Task SendEmail(string fromEmail,string fromName, string message,
            string toEmail,string toName,string stmpUser,string stmpPassword,
            string smtpHost, string subject,string smptPort,bool smptSSL);
        Task<string> UploadFile(List<IFormFile> files, string directory);
    }
}
