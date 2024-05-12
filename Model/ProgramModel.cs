using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CapitalPlacementAPI.Model
{
    public class ProgramModel
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string? Detail { get; set; }
        public bool ShowPhone { get; set; } = false;
        public bool ShowNationality { get; set; } = false;
        public bool ShowCurrentResidence { get; set; } = false;
        public bool ShowIdNumber { get; set; } = false;
        public bool ShowDOB{ get; set; } = false;
        public bool ShowGender { get; set; } = false;
        public bool Active { get; set; } = true;
        public DateTime? LastLogin { get; set; }
        public DateTime RegDate { get; set; } = DateTime.Now;

        public List<ProgramQuestion> Questions { get; set; }

    }

   
    public class ProgramQuestion
    {
        public string Question { get; set; }
        public string QuestionType { get; set; }
    }

   

    public class ProgramPagination
    {
        public int TotalPages { get; set; }
        public List<ProgramModel> ProgramList { get; set; }
    }
}
