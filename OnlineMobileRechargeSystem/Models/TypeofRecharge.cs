using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineMobileRechargeSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMobileRechargeSystem.Models
{
    public class TypeofRecharge
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RechargeType { get; set; }
        //foreign key 

        public virtual Provider provider { get; set; }
        public virtual IEnumerable<RechargeList> Recharges { get; set; }
    }
}
