using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PersonalDiaryToDo.HubConfig;
using PersonalDiaryToDo.Models;

namespace PersonalDiaryToDo.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    public class UserDiaryController : Controller
    {
        private IHubContext<DiaryAlertHub> _hub;
        public UserDiaryContext _context;

        public UserDiaryController(IHubContext<DiaryAlertHub> hub, UserDiaryContext context)
        {
            _hub = hub;
            _context = context;
        }

        [HttpGet("[Action]")]
        public IEnumerable<UserDiaryResult> GetUserDiaries()
        {
            //var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));//var rng = new Random();
            return _context.UserDiary.Select(diary => new UserDiaryResult
            {
                UserDiaryId = diary.UserDiaryId,
                DiaryTitle = diary.DiaryTitle,
                DiaryContent = diary.DiaryContent,
                DiaryDate = diary.DiaryDataTime.ToString("YYYY-MM-DD"),
                DiaryTime = diary.DiaryDataTime.ToString("hh:mm:ss"),
                UserFullName = diary.User.FullName,
                InsertionDate = diary.InsertionDate
            }).OrderByDescending(diary=>diary.InsertionDate);
        }

        [HttpGet("[Action]/{id}")]
        public UserDiary GetUserDiary(int id)
        {
            //var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));//var rng = new Random();
            return _context.UserDiary.FirstOrDefault(diary=> diary.UserDiaryId == id);
        }

        //[EnableCors]
        [HttpPost("[Action]")]
        public IActionResult AddUserDiary([FromBody]UserDiary diary)
        {
            if (diary !=null)
            {
                _context.UserDiary.Add(diary);
                _context.SaveChanges();
                return Ok(new { Message = "Request Completed" });
            }
            return BadRequest(new { Message = "Invalid Request" });
        }

        [HttpPut("[Action]/{id}")]
        public IActionResult UpdateUserDiary(int id, [FromBody] UserDiary diary)
        {
            if (id > 0 && diary != null)
            {
                _context.UserDiary.Update(diary);
                _context.SaveChanges();
                return Ok(new { Message = "Request Completed" });
            }
            return BadRequest(new { Message = "Invalid Request" });
        }

        [HttpDelete("[Action]/{id}")]
        public IActionResult DeleteUserDiary(int id)
        {
            if (id > 0)
            {
                var diary = GetUserDiary(id);
                if (diary != null)
                {
                    _context.UserDiary.Remove(diary);
                    _context.SaveChanges();
                    return Ok(new { Message = "Request Completed" });
                }
            }
            return BadRequest(new { Message = "Invalid Request" });
        }
    }
}
