using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineMobileRechargeSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMobileRechargeSystem.Models
{
    public class RechargeList
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Amount")]
        public int? Amount { get; set; }
        [Required(ErrorMessage ="Please Enter Plan Validity")]
        [Display(Name = "Plan Validity")]

        public int? validity { get; set; }
        [Required(ErrorMessage ="Please Enter Data Pack")]
        [Display(Name ="Data Pack")]
        public string Datapack { get; set; }
        [Required(ErrorMessage ="Please Enter SMS Limit of Plan")]
        [Display(Name = "SMS Limit")]

        public string SMSLimit { get; set; }
        [Required(ErrorMessage =" Please Enter Voice Calling Limit" )]
        public string Voice { get; set; }

        //Foreign key
        //[ForeignKey("Provider.Id")]
        public Provider Provider { get; set; }
        //[ForeignKey("TypeofRecharge.Id")]
        public  TypeofRecharge Type { get; set; }
    }
}
