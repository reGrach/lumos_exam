using LumosService.API.Models;
using LumosService.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LumosService.API.Controllers
{
    public class ExamController : DefaultController
    {
        private const string errorFutureExams = "У Вас нет запланированных экзаменов";
        private const string errorPassedExams = "Вы еще не сдали ни одного экзамена";

        public ExamController(LumosContext context) : base(context) { }

        [HttpGet]
        public int Check()
        {
            return 1;
        }

        [HttpGet]
        public ActionResult<JsonResultResponse> GetFuture()
        {
            try
            {
                var res = ctx.Exam
                    .Include("Questions")
                    .Where(x => x.Mark == Mark.NotPassed)
                    .ToList();
                if (res.Any())
                    return JsonResultResponse.Ok(res);
                else
                    return JsonResultResponse.Bad(errorFutureExams);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<JsonResultResponse> GetPassed()
        {
            try
            {
                var res = ctx.Exams
                    .Where(x => x.Mark != Mark.NotPassed)
                    .ToList();
                if (res.Any())
                    return JsonResultResponse.Ok(res);
                else
                    return JsonResultResponse.Bad(errorPassedExams);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}