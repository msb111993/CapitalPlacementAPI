using CapitalPlacementAPI.Data;
using CapitalPlacementAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacementAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class CandidateController : ControllerBase
    {
        CandidateService objCandidate = new CandidateService();

        [HttpGet("all")]
        public IEnumerable<CandidateModel> Index()
        {
            return objCandidate.GetAllCandidates();
        }

        [HttpGet("pagination")]
        public CandidatePagination GetFiterCandidates(string? txtsearch = null, int pagenumber = 1, int limit = 20)
        {
            CandidatePagination upData = new CandidatePagination();
            upData = objCandidate.GetCandidatesWithFilter(txtsearch, pagenumber, limit);
            return upData;
        }

        [HttpPost("create")]
        public void Create([FromBody] CandidateModel candidate)
        {
            objCandidate.AddCandidate(candidate);
        }

        [HttpGet("details/{id}")]
        public CandidateModel Details(string id)
        {
            return objCandidate.GetCandidateData(id);
        }

        [HttpPut("candidate/")]
        public void Edit([FromBody] CandidateModel candidate)
        {
            objCandidate.UpdateCandidate(candidate);
        }

        [HttpDelete("candidate/{id}")]
        public void Delete(string id)
        {
            objCandidate.DeleteCandidate(id);
        }

        [HttpPost("validation")]
        public string CandidateValidation([FromBody] CandidateModel candidate)
        {
            return objCandidate.ValidateCandidateModel(candidate);
        }

        [HttpPost("duplicatecheck")]
        public bool CheckDuplicate([FromBody] CandidateModel candidate)
        {
            try
            {
                var urData = objCandidate.GetCandidateByEmail(candidate.Email);
                if (urData != null)
                {
                    return true;
                }
               

                return false;
            }
            catch
            {
                return false;
            }
        }


        [HttpPost("add")]
        public string AddCandidate([FromBody] CandidateModel candidate)
        {
            try
            {
                var vData = objCandidate.ValidateCandidateModel(candidate);
                if (vData != "OK")
                {
                    return vData;
                }

                var urData = objCandidate.GetCandidateByEmail(candidate.Email);
                if (urData != null)
                {
                    return "Candidate Email Already Exists";
                }
              
            

                objCandidate.AddCandidate(candidate);

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
