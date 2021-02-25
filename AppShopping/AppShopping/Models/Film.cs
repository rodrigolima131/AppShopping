﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.Models
{
 public   class Film
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public List<SessionGroup> SessionGroups { get; set; }
    }
}
