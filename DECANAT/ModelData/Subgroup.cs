﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    public class Subgroup : Group
    {
        [Required]
        [Display(Name = "Подгруппа")]
        public int subgroup_number { get; set; }
        public int group_id { get; set; }
        public int peoples_count { get; set; }
    }
}