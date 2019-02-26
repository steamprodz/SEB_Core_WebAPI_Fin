using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int Age { get; set; }
        public bool IsStudent { get; set; }
        public long Income { get; set; }
    }
}
