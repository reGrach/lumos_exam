namespace LumosService.API.Models
{
    public class StatusModel
    {
        public int QuestionId { get; set; }
        public bool Value { get; set; }
        public StatusQuestionEnum Status { get; set; }
    }

    public enum StatusQuestionEnum
    {
        IsWritten = 1,
        IsLearned,
        IsDeffered
    }
}
