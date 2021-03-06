using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JeanetteDemoApp.Models
{
    /// <summary>
    /// Represents a category
    /// </summary>
    public class Category
    {
        /// <summary>
        /// CategoryId
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Category title
        /// </summary>
        public string CategoryTitle { get; set; }
        /// <summary>
        /// Is category active
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// Clips in the category
        /// </summary>
        public List<Clip> Clip { get; set; }
    }
}