using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSLite_Portal.Shared.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please Enter an User Name.")]
        public string UserName { get; set; }    //usr
        [Required]
        public string Password { get; set; }
    }
}
