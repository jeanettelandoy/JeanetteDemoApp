namespace JeanetteDemoApp.Models
{
    /// <summary>
    /// Represents a clip
    /// </summary>
    public class Clip
    {
        /// <summary>
        /// ClipId
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Clip title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Is clip hidden
        /// </summary>
        public bool Hidden { get; set; }
        /// <summary>
        /// Belongs to CategoryId
        /// </summary>
        public int CategoryId { get; set; }
    }
}