using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class ClipModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Hidden { get; set; }
        public int CategoryId { get; set; }
    }
}
