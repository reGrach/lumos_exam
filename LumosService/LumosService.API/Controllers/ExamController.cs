using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LumosService.API.Models;
using LumosService.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LumosService.API.Controllers
{
    public class ExamController : DefaultController
    {
        private const string emptyExams = "В системе не обнаружено экзаменов";
        private const string errorGetExam = "В системе не обнаружен экзамен с id: {0}";

        public ExamController(LumosContext context) : base(context) { }

        [HttpGet]
        public int Check()
        {
            return 1;
        }

        [HttpGet]
        public ActionResult<JsonResultResponse> GetAll()
        {
            try
            {
                var res = ctx.Exams.Select(x => new ExamEasy { Id = x.Id, Title = x.Title }).ToList();
                if (res.Any())
                    return JsonResultResponse.Ok(res);
                else
                    return JsonResultResponse.Bad(emptyExams);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<JsonResultResponse> GetById(int id)
        {
            try
            {
                if (ctx.Exams.Find(id) is Exam exam)
                    return JsonResultResponse.Ok(exam);
                else
                    return JsonResultResponse.Bad(string.Format(errorGetExam, id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}