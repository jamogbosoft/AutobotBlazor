
namespace AutobotBlazor.Server.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<CandidateResponse> CandidateResponses { get; set; }
        public DbSet<HostIP> HostIPs { get; set; }
        public DbSet<ExamTime> ExamTimes { get; set; }
        public DbSet<ExamType> ExamTypes { get; set; }
       // public DbSet<ExternalCandidate> ExternalCandidates { get; set; }

    }
}
