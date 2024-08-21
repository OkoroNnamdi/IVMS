using Inventory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Inventory.Utility.HelperClass;
using Microsoft.Extensions.Options;
using System.Net.WebSockets;
using System.Net.Mail;
using System.Net;
using Inventory.Repository;
using Inventory.Services;


namespace Inventory.Utility
{
    public  class DbInitializer:IDbIntializer
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _env;
        private SuperAdmin _superAdmin;
        private readonly ApplicationDbContext _context;
        private readonly IRoleInventory _roleInventory;

        public DbInitializer(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,
            IWebHostEnvironment env, IOptions<SuperAdmin> superAdmin,
            ApplicationDbContext context, IRoleInventory roleInventory )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _env = env;
            _superAdmin = superAdmin.Value;
            _context = context;
            _roleInventory = roleInventory;
        }

        public async Task CreateSuperAdmin()
        {
            var user = new AppUser();
            user.Email = "";
            user.UserName = "";
            user.EmailConfirmed = true ;
            var response = await _userManager.CreateAsync(user,_superAdmin.Password );
            if (response.Succeeded) {
                var userProfile = new UserProfile();
                userProfile.FirstName = "Admin";
                userProfile.LastName = "Admin";
                userProfile.Email =user.Email;
                userProfile.AppUserId = user.Id;
                await _context.userProfiles .AddAsync(userProfile);
                await _context.SaveChangesAsync();
                await _roleInventory.AddRoleAsync(user.Id);
            }
        }

        public async Task SendEmail(string fromEmail, string fromName, string message,
            string toEmail, string toName, string stmpUser, string stmpPassword,
            string smtpHost,string subject, string  smptPort, bool smptSSL)
        {
            var body = message;
            var messageRequest = new MailMessage();
            messageRequest.To.Add (new MailAddress(toEmail,toName));
            messageRequest.From = new MailAddress(fromEmail,fromName);
            messageRequest.Subject = subject;
            messageRequest.Body = body;
            messageRequest .IsBodyHtml = true;
            using (var stmp = new SmtpClient ())
            {
                var credential = new NetworkCredential
                {
                    UserName =stmpUser ,
                    Password =stmpPassword
                };
                stmp.Credentials = credential;
                stmp.Host = smtpHost;
                stmp.Port = Convert.ToInt32(smptPort);
                stmp.EnableSsl = smptSSL;
                await stmp.SendMailAsync (messageRequest);
            }

        }

        public async Task<string> UploadFile(List<IFormFile> files, string directory)
        {
            var response = string.Empty;
            var upLoad = Path.Combine(_env.WebRootPath, directory);
            var fileExtension = string.Empty;
            var filePath = string.Empty;
            var filename = string.Empty;
            foreach ( var file in files )
            {
                if (file.Length > 0)
                {
                    fileExtension = Path.GetExtension (file.FileName ).ToLower ();
                    filename = Guid.NewGuid ().ToString () + fileExtension;
                    filePath = Path.Combine (upLoad, filename);
                    using (var ms = new FileStream(filePath, FileMode.Create))
                    {
                        await file .CopyToAsync (ms);
                    }
                   response =filename;
                }
            }
            return response;
        }

        
    }
}
