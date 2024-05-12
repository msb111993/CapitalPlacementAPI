using CapitalPlacementAPI.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CapitalPlacementAPI.Data
{
    public class CandidateService
    {
        DBContext db = new DBContext();

        // To Get all employees details
        public List<CandidateModel> GetAllCandidates()
        {
            try
            {
                return db.CandidateRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }

        public CandidatePagination GetCandidatesWithFilter(string? txtsearch = null, int pageno = 1, int limit = 20)
        {
            try
            {
                CandidatePagination upData = new CandidatePagination();


                var uData = db.CandidateRecord.Find(_ => true).ToList();

                if (!string.IsNullOrEmpty(txtsearch))
                {
                    uData = uData.Where(w => w.FirstName.Equals(txtsearch, StringComparison.OrdinalIgnoreCase) || w.LastName.Contains(txtsearch, StringComparison.OrdinalIgnoreCase) || w.Email.Contains(txtsearch, StringComparison.OrdinalIgnoreCase)).ToList();

                }
                upData.TotalPages = Convert.ToInt32(uData.Count() / 20) + 1;

                uData = uData.Skip((pageno - 1) * limit).ToList();
                uData = uData.Take(limit).ToList();
                upData.CandidateList = uData;

                return upData;
            }
            catch
            {
                throw;
            }
        }

        // To Add new employee record
        public void AddCandidate(CandidateModel Candidate)
        {
            try
            {
                db.CandidateRecord.InsertOne(Candidate);
            }
            catch
            {
                throw;
            }
        }

        // Get the details of a particular employee
        public CandidateModel GetCandidateData(string id)
        {
            try
            {
                FilterDefinition<CandidateModel> filterCandidateData = Builders<CandidateModel>.Filter.Eq("Id", id);

                return db.CandidateRecord.Find(filterCandidateData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public CandidateModel GetCandidateByMobile(string mobile)
        {
            try
            {
                FilterDefinition<CandidateModel> filterCandidateData = Builders<CandidateModel>.Filter.Eq("Mobile", mobile);

                return db.CandidateRecord.Find(filterCandidateData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public CandidateModel GetCandidateByCandidateName(string Candidatename)
        {
            try
            {
                FilterDefinition<CandidateModel> filterCandidateData = Builders<CandidateModel>.Filter.Eq("CandidateName", Candidatename);

                return db.CandidateRecord.Find(filterCandidateData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
        public CandidateModel GetCandidateByEmail(string email)
        {
            try
            {
                FilterDefinition<CandidateModel> filterCandidateData = Builders<CandidateModel>.Filter.Eq("Email", email);

                return db.CandidateRecord.Find(filterCandidateData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        // To Update the records of a particular employee
        public void UpdateCandidate(CandidateModel Candidate)
        {
            try
            {
                db.CandidateRecord.ReplaceOne(filter: g => g.Id == Candidate.Id, replacement: Candidate);

            }
            catch
            {
                throw;
            }
        }

        // To Delete the record of a particular employee
        public void DeleteCandidate(string id)
        {
            try
            {
                FilterDefinition<CandidateModel> CandidateData = Builders<CandidateModel>.Filter.Eq("Id", id);
                db.CandidateRecord.DeleteOne(CandidateData);
            }
            catch
            {
                throw;
            }
        }


    

        public string ValidateCandidateModel(CandidateModel uModel)
        {
            if (string.IsNullOrEmpty(uModel.FirstName))
            {
                return "First Name Required *";
            }
            if (string.IsNullOrEmpty(uModel.LastName))
            {
                return "Last Name Required *";
            }
            if (string.IsNullOrEmpty(uModel.Email))
            {
                return "Email Required *";
            }

            else
            {
                return "OK";
            }

        }

    }
}
