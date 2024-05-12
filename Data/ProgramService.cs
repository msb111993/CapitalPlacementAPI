using CapitalPlacementAPI.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CapitalPlacementAPI.Data
{
    public class ProgramService
    {
        DBContext db = new DBContext();

        // To Get all employees details
        public List<ProgramModel> GetAllPrograms()
        {
            try
            {
                return db.ProgramRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }

        public ProgramPagination GetProgramsWithFilter(string? txtsearch = null, int pageno = 1, int limit = 20)
        {
            try
            {
                ProgramPagination upData = new ProgramPagination();


                var uData = db.ProgramRecord.Find(_ => true).ToList();

                if (!string.IsNullOrEmpty(txtsearch))
                {
                    uData = uData.Where(w => w.Title.Equals(txtsearch, StringComparison.OrdinalIgnoreCase) || w.Detail.Contains(txtsearch, StringComparison.OrdinalIgnoreCase)).ToList();

                }
                upData.TotalPages = Convert.ToInt32(uData.Count() / 20) + 1;

                uData = uData.Skip((pageno - 1) * limit).ToList();
                uData = uData.Take(limit).ToList();
                upData.ProgramList = uData;

                return upData;
            }
            catch
            {
                throw;
            }
        }

        // To Add new employee record
        public void AddProgram(ProgramModel Program)
        {
            try
            {
                db.ProgramRecord.InsertOne(Program);
            }
            catch
            {
                throw;
            }
        }

        // Get the details of a particular employee
        public ProgramModel GetProgramData(string id)
        {
            try
            {
                FilterDefinition<ProgramModel> filterProgramData = Builders<ProgramModel>.Filter.Eq("Id", id);

                return db.ProgramRecord.Find(filterProgramData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public ProgramModel GetProgramByMobile(string mobile)
        {
            try
            {
                FilterDefinition<ProgramModel> filterProgramData = Builders<ProgramModel>.Filter.Eq("Mobile", mobile);

                return db.ProgramRecord.Find(filterProgramData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public ProgramModel GetProgramByProgramName(string Programname)
        {
            try
            {
                FilterDefinition<ProgramModel> filterProgramData = Builders<ProgramModel>.Filter.Eq("ProgramName", Programname);

                return db.ProgramRecord.Find(filterProgramData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
        public ProgramModel GetProgramByEmail(string email)
        {
            try
            {
                FilterDefinition<ProgramModel> filterProgramData = Builders<ProgramModel>.Filter.Eq("Email", email);

                return db.ProgramRecord.Find(filterProgramData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        // To Update the records of a particular employee
        public void UpdateProgram(ProgramModel Program)
        {
            try
            {
                db.ProgramRecord.ReplaceOne(filter: g => g.Id == Program.Id, replacement: Program);

            }
            catch
            {
                throw;
            }
        }

        // To Delete the record of a particular employee
        public void DeleteProgram(string id)
        {
            try
            {
                FilterDefinition<ProgramModel> ProgramData = Builders<ProgramModel>.Filter.Eq("Id", id);
                db.ProgramRecord.DeleteOne(ProgramData);
            }
            catch
            {
                throw;
            }
        }


    

        public string ValidateProgramModel(ProgramModel uModel)
        {
            if (string.IsNullOrEmpty(uModel.Title))
            {
                return "Title Required *";
            }
            if (string.IsNullOrEmpty(uModel.Detail))
            {
                return "Detail Required *";
            }

            else
            {
                return "OK";
            }

        }

    }
}
