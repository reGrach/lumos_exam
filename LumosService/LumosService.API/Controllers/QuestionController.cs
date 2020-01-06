using LumosService.API.Models;
using LumosService.DAL;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LumosService.API.Controllers
{
    public class QuestionController : DefaultController
    {
        private const string errorGetQuestion = "Фатальная ошибка, обратитесь к Гере. В системе не обнаружен вопрос с id: {0}";

        public QuestionController(LumosContext context) : base(context) { }

        [HttpPost("{id}")]
        public ActionResult<JsonResultResponse> UpdateStatus(StatusModel model)
        {
            try
            {
                if (ctx.Questions.Find(model.QuestionId) is Question quest)
                {
                    switch (model.Status)
                    {
                        case StatusQuestionEnum.IsClear:
                            quest.IsClear = model.Value;
                            break;
                        case StatusQuestionEnum.IsLearned:
                            quest.IsLearned = model.Value;
                            break;
                        case StatusQuestionEnum.IsWritten:
                            quest.IsWritten = model.Value;
                            break;
                    }
                    ctx.SaveChanges();
                    return Ok();
                }
                else
                    return JsonResultResponse.Bad(string.Format(errorGetQuestion, model.QuestionId));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}