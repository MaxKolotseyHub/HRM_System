using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models.Departaments
{
    public class IndexDepartamentViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Название")]
        public string Title { get; set; }
    }
}