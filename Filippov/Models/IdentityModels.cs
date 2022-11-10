using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Filippov.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {

        [Display(Name = "ФИО")]
        public string FIO { get; set; }
        [Display(Name = "Адрес")]
        public string Adres { get; set; }
        [Display(Name = "паспорт")]
        public string Pasport { get; set; }
        [Display(Name = "СНИЛС")]
        public string SNILS { get; set; }
        [Display(Name = "ИНН")]
        public string INN { get; set; }
        [Display(Name = "Должность")]
        public string Job_status { get; set; }
        [Display(Name = "Филиал")]
        public string Filial { get; set; }
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]        
        public string Date_start { get; set; }
        [Display(Name = "Зарплата")]
        public string Salary { get; set; }
        [Display(Name = "Фото профиля")]
        public byte[] Photo { get; set; }




        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}