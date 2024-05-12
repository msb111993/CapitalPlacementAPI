using CapitalPlacementAPI.Model;
using MongoDB.Driver;

namespace CapitalPlacementAPI.Data
{
    public class DBContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public DBContext()
        {
            var client = new MongoClient(GlobalModels.MonogoServer);
            _mongoDatabase = client.GetDatabase(GlobalModels.MonogoDB);
        }

        public IMongoCollection<ProgramModel> ProgramRecord
        {
            get
            {
                return _mongoDatabase.GetCollection<ProgramModel>("tbl_program");
            }
        }
        public IMongoCollection<CandidateModel> CandidateRecord
        {
            get
            {
                return _mongoDatabase.GetCollection<CandidateModel>("tbl_candidate");
            }
        }

    }
}
