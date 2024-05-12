using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CapitalPlacementAPI.Model
{
    public class CandidateModel
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string PID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Nationality { get; set; }
        public string? CurrentResidence { get; set; }
        public string? IDNumber { get; set; }
        public string? DOB { get; set; } 
        public string? Gender { get; set; }
        public bool Active { get; set; } = true;
        public DateTime RegDate { get; set; } = DateTime.Now;

        public List<CandidateAnswer> Questions { get; set; }

    }

    public class CandidateAnswer
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }


    public class CandidatePagination
    {
        public int TotalPages { get; set; }
        public List<CandidateModel> CandidateList { get; set; }
    }
}
