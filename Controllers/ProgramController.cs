using CapitalPlacementAPI.Data;
using CapitalPlacementAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacementAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class ProgramController : ControllerBase
    {
        ProgramService objProgram = new ProgramService();

        [HttpGet("all")]
        public IEnumerable<ProgramModel> Index()
        {
            return objProgram.GetAllPrograms();
        }

        [HttpGet("pagination")]
        public ProgramPagination GetFiterPrograms(string? txtsearch = null, int pagenumber = 1, int limit = 20)
        {
            ProgramPagination upData = new ProgramPagination();
            upData = objProgram.GetProgramsWithFilter(txtsearch, pagenumber, limit);
            return upData;
        }

        [HttpGet("quetiontypes")]
        public IEnumerable<string> GetQuestionType()
        {
            List<string> qTypes = new List<string>();
            qTypes.Add("PARAGRAPH");
            qTypes.Add("YESNO");
            qTypes.Add("DROPDOWN");
            qTypes.Add("MULTIPLECHOICE");
            qTypes.Add("DATE");
            qTypes.Add("NUMBER");

            return qTypes;
        }


        [HttpPost("create")]
        public void Create([FromBody] ProgramModel program)
        {
            objProgram.AddProgram(program);
        }

        [HttpGet("details/{id}")]
        public ProgramModel Details(string id)
        {
            return objProgram.GetProgramData(id);
        }

        [HttpPut("program/")]
        public void Edit([FromBody] ProgramModel program)
        {
            objProgram.UpdateProgram(program);
        }

        [HttpDelete("program/{id}")]
        public void Delete(string id)
        {
            objProgram.DeleteProgram(id);
        }

        [HttpPost("validation")]
        public string ProgramValidation([FromBody] ProgramModel program)
        {
            return objProgram.ValidateProgramModel(program);
        }

        [HttpPost("duplicatecheck")]
        public bool CheckDuplicate([FromBody] ProgramModel program)
        {
            try
            {
                var urData = objProgram.GetProgramByProgramName(program.Title);
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
        public string AddProgram([FromBody] ProgramModel program)
        {
            try
            {
                var vData = objProgram.ValidateProgramModel(program);
                if (vData != "OK")
                {
                    return vData;
                }

                var urData = objProgram.GetProgramByProgramName(program.Title);
                if (urData != null)
                {
                    return "Program Name Already Exists";
                }
              
            

                objProgram.AddProgram(program);

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
