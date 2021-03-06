using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public List<ClipModel> Clip { get; set; }
    }
}
