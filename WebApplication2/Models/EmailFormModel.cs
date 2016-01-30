using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    /*clasa corespunzatoare formularului de mail*/
    public class EmailFormModel
    {
        [Required]
        public string FromName { get; set; }

        [Required, EmailAddress]
        public string FromEmail { get; set; }

        [Required, EmailAddress]
        public string ToEmail { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Message { get; set; }

        public HttpPostedFileBase File { get; set; }
    }
}