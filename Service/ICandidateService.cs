using JobApplication.Model;

namespace JobApplication.Service
{
    public interface ICandidateService
    {
        Task<ResponseModel> AddCandidate(CandidateRequestModel model);
        Task<ResponseModel> GetCandidatesByJob(string job);
    }
}
