using System;
using System.Collections.Generic;

namespace LumosService.DAL
{
    public class Exam
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public Mark Mark { get; set; }
        public string Comment { get; set; }
        public List<Question> Questions { get; set; }
    }    
}
