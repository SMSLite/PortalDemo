using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSLite_Portal.Shared.Models
{
    public class Mdl_Faculty
    {
        [Key]
        public int FID { get; set; }
        public string usr { get; set; }
        public string typ { get; set; }
        public string nme { get; set; }
        public string pass { get; set; }
        public string designation { get; set; }
        public string qualification { get; set; }
        public string DOJ { get; set; }
        public string phone { get; set; }
        public string Emailid { get; set; }
        public string Address { get; set; }
        public string pic { get; set; }
        public string Exp { get; set; }
        public string Category { get; set; }
        public string Lastlogin { get; set; }
    }
}
