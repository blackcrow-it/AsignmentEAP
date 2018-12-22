using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;

namespace AsignmentEAP.Models
{
    public class Account
    {
        public Account()
        {
            this.CreateAt = DateTime.Now;
            this.UpdateAt = DateTime.Now;
            this.Status = AccountStatus.Active;
        }
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public AccountStatus Status { get; set; }
        public  StudentInformation StudentInformation { get; set; }
        public  List<Subject> Subjects { get; set; }
       
    }

    public enum AccountStatus
    {
        Active = 1,
        Deactive = 0
    }
}
