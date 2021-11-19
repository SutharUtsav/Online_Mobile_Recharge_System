using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineMobileRechargeSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMobileRechargeSystem.Models
{
    public class ActivePlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Phone Number")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Please enter 10 digit Mobile No.")]
        public string Phonenumber { get; set; }

        [Display(Name = "Active On")]
        public DateTime startdate { get; set; }

        [Display(Name = "Expire On")]
        public DateTime enddate { get; set; }

        [Display(Name = "User Name")]
        public string Uid { get; set; }
        public virtual RechargeList Recharge { get; set; }

    }
}
