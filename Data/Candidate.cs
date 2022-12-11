using System.ComponentModel.DataAnnotations;

namespace JobApplication.Data
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; } 
        public string? email { get; set; } 
        public DateTime? Date { get; set; } 
        public string? PlaceOfBirth { get; set; }
        public string? JobType { get; set; } 
        public string? Cv { get; set; } 
    }
}
