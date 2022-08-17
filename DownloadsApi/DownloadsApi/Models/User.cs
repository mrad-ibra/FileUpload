using System.ComponentModel.DataAnnotations;

namespace DownloadsApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Filename { get; set; }
    }
}
