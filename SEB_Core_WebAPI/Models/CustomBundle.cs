﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Models
{
    public class CustomBundle
    {
        public int CustomBundleId { get; set; }
        public int BundleId { get; set; }
        public int ProductId { get; set; }
        public int QuestionId { get; set; }
    }
}
