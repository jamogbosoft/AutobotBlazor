using System.Text.Json;

namespace AutobotBlazor.Server.Service.CandidateService
{
    public class CandidateService : ICandidateService
    {
        private readonly DataContext _context;

        public CandidateService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<CandidateResponse>>> GetCandidateResponses()
        {
            var candidates = await _context.CandidateResponses.ToListAsync();

            var response = new ServiceResponse<List<CandidateResponse>>
            {
                Data = candidates
            };

            return response;
        }
        public async Task<ServiceResponse<List<CandidateResponse>>> GetCandidateResponses(string sessionRef)
        {
            var candidates = await _context.CandidateResponses
                .Where(c => c.SessionRef == sessionRef)
                .ToListAsync();

            var response = new ServiceResponse<List<CandidateResponse>>
            {
                Data = candidates
            };

            return response;
        }

        public async Task<ServiceResponse<CandidateResponse>> GetCandidateResponse(string regNumber)
        {
            var candidate = await _context.CandidateResponses
               .FirstOrDefaultAsync(c => c.RegistrationNumber == regNumber);

            var response = new ServiceResponse<CandidateResponse>
            {
                Data = candidate
            };

            return response;
        }

        public async Task<ServiceResponse<List<CandidateResponse>>> GetMultipleLoginIssues()
        {
            var candidates = await _context.CandidateResponses.ToListAsync();
            candidates.ForEach(c => c.HostIPs = JsonSerializer.Deserialize<List<HostIP>>(c.PreviousHostIps)!);
            candidates = candidates.Where(c => c.HostIPs.Count > 1).ToList();

            var response = new ServiceResponse<List<CandidateResponse>>
            {
                Data = candidates
            };

            return response;
        }

        public async Task<ServiceResponse<List<CentreAnalysisResponse>>> GetMultipleLoginAnalysis()
        {
            CentreAnalysisResponse multipleLogin = null!;
            List<CentreAnalysisResponse> multipleLogins = new();

            var candidates = await _context.CandidateResponses.ToListAsync();

            candidates.ForEach(c => c.HostIPs = JsonSerializer.Deserialize<List<HostIP>>(c.PreviousHostIps)!);
            var candidateGroups = candidates.GroupBy(c => c.SessionRef).ToList();


            foreach (var group in candidateGroups)
            {
                var categoryM = group.Count(g => g.HostIPs.Count() > 1);

                if (categoryM > 0)
                {
                    var numberOfCandidates = group.Count();
                    var centreId = group.FirstOrDefault()?.CentreId;
                    var sessionRef = group.FirstOrDefault()?.SessionRef;
                    var examDate = group.FirstOrDefault()?.ExamDate;

                    var categoryA = group.Count(g => g.HostIPs.Count() == 0);
                    var categoryB = group.Count(g => g.HostIPs.Count() == 1);
                    var categoryC = group.Count(g => g.HostIPs.Count() >= 2 && g.HostIPs.Count() <= 3);
                    var categoryD = group.Count(g => g.HostIPs.Count() >= 4 && g.HostIPs.Count() <= 5);
                    var categoryE = group.Count(g => g.HostIPs.Count() >= 6);

                    multipleLogin = new()
                    {
                        CentreId = centreId!,
                        SessionRef = sessionRef!,
                        ExamDate = examDate!,
                        NumberOfCandidates = numberOfCandidates,
                        Category_A_Count = categoryA,
                        Category_B_Count = categoryB,
                        Category_C_Count = categoryC,
                        Category_D_Count = categoryD,
                        Category_E_Count = categoryE
                    };

                    multipleLogins.Add(multipleLogin);
                }
            }

            var result = multipleLogins.OrderBy(x => x.SessionRef).ToList();
            return new ServiceResponse<List<CentreAnalysisResponse>>()
            {
                Data = result
            };
        }

        public async Task<ServiceResponse<List<CentreAnalysisResponse>>> GetResponseCountAnalysis()
        {

            CentreAnalysisResponse responseCount = null!;
            List<CentreAnalysisResponse> responseCounts = new();

            //var candidateGroups = await _context.CandidateResponses
            //                       .GroupBy(c => c.SessionRef)
            //                       .ToListAsync();

            var candidates = await _context.CandidateResponses.ToListAsync();
            var candidateGroups = candidates.GroupBy(c => c.SessionRef).ToList();

            foreach (var group in candidateGroups)
            {
                var numberOfCandidates = group.Count();
                var centreId = group.FirstOrDefault()?.CentreId;
                var sessionRef = group.FirstOrDefault()?.SessionRef;
                var examDate = group.FirstOrDefault()?.ExamDate;

                var categoryA = group.Count(g => g.TotalAttempted == 0);
                var categoryB = group.Count(g => g.TotalAttempted > 0 && g.TotalAttempted < 100);
                var categoryC = group.Count(g => g.TotalAttempted >= 100 && g.TotalAttempted < 160);
                var categoryD = group.Count(g => g.TotalAttempted >= 160 && g.TotalAttempted <= 180);
                var categoryE = group.Count(g => g.TotalAttempted > 180);

                responseCount = new()
                {
                    CentreId = centreId!,
                    SessionRef = sessionRef!,
                    ExamDate = examDate!,
                    NumberOfCandidates = numberOfCandidates,
                    Category_A_Count = categoryA,
                    Category_B_Count = categoryB,
                    Category_C_Count = categoryC,
                    Category_D_Count = categoryD,
                    Category_E_Count = categoryE
                };

                responseCounts.Add(responseCount);                
            }

            var result = responseCounts.OrderBy(x => x.SessionRef).ToList();
            return new ServiceResponse<List<CentreAnalysisResponse>>()
            {
                Data = result
            };
        }
    }
}
