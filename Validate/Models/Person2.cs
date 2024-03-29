﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Validate.Filter;
using Validate.Properties;

namespace Validate.Models
{
    public class Person2
    {
        [DisplayName("姓名")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        public string Name { get; set; }

        [DisplayName("性别")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        [Domain("F", "f", "M", "m", ErrorMessageResourceName = "Domain", ErrorMessageResourceType = typeof(Resources))]
        public string Gender { get; set; }

        [DisplayName("年龄")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        [Range(18, 25, ErrorMessageResourceName = "Range", ErrorMessageResourceType = typeof(Resources))]
        public int? Age { get; set; }
    }
}