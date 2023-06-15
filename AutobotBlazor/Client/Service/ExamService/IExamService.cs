namespace AutobotBlazor.Client.Service.ExamService
{
    public interface IExamService
    {
        List<Exam> ExamsList { get; set; }
        Task GetExams();
    }
}
