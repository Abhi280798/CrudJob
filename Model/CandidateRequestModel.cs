using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplication.Model
{
    public class CandidateRequestModel
    {
     
        public string Name { get; set; }

        public string email { get; set; }

        public DateTime Date { get; set; }

        public string PlaceOfBirth { get; set; }

        public string JobType { get; set; }
        public IFormFile? Cv { get; set; }
    }
}
