﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM_System_UI.Models.Departaments
{
    public class IndexDepartamentViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Название")]
        public string Title { get; set; }
    }
}