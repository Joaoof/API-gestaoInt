using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoInt.Domain.Entities.ViewModels
{
    [Keyless]
    [Table("AuthLoginView")]
    public class AuthLoginView
    {
        public string UserId { get; set; } 
        public string UserEmail { get; set; }
        public string UserRole { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string PlanId { get; set; }
        public string PlanName { get; set; }
        public string Modules { get; set; }
    }
}
