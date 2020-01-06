namespace LumosService.DAL
{
    public class Question
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string Text { get; set; }
        public bool IsClear { get; set; }
        public bool IsWritten { get; set; }
        public bool IsLearned { get; set; }
        public bool IsDeferred { get; set; }
        public Exam Exam { get; set; }
    }
}
