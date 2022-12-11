using JobApplication.Data;
using JobApplication.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace JobApplication.Service
{
    public class CandidateService : ICandidateService
    {
        private readonly JobApplicationContext _dbContext;
        public CandidateService(JobApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseModel> AddCandidate(CandidateRequestModel model)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                var candidate = await _dbContext.Candidate.Where(x=>x.email == model.email).FirstOrDefaultAsync();
                if (candidate != null)
                {
                    result.IsSuccess = false;
                    result.Message = "Candidates email already exist";
                }
                else
                {
                    Candidate c = new Candidate();
                    c.Name = model.Name;c.email = model.email;c.Date = model.Date;
                    c.JobType = model.JobType;
                    c.PlaceOfBirth = model.PlaceOfBirth;
                    if(model.Cv!=null)
                    {

                        //Getting FileName
                        var fileName = Path.GetFileName(model.Cv.FileName);
                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);
                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                        string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Cv", newFileName);

                        var stream = new FileStream(uploadpath, FileMode.Create);

                        model.Cv.CopyToAsync(stream);
                        c.Cv = newFileName;
                    }
                    await _dbContext.Candidate.AddAsync(c);
                    await _dbContext.SaveChangesAsync();
                    result.IsSuccess = true;
                    result.Message = "Candidate save sucessfully";
                }
                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<ResponseModel> GetCandidatesByJob(string job)
        {
            try
            {
                var result = new ResponseModel();
                result.Result = await _dbContext.Candidate.Where(x=>x.JobType == job).ToListAsync();
                result.IsSuccess = true; 
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
