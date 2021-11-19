using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineMobileRechargeSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMobileRechargeSystem.Models
{
    public class Provider
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Provider Name")]
        [Display(Name ="Provider Name")]
        public string ProviderName { get; set; }

        public virtual IEnumerable<TypeofRecharge> Types { get; set; }
        public virtual IEnumerable<RechargeList> Recharges { get; set; }


    }
}