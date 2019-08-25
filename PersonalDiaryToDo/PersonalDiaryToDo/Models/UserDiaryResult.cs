using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalDiaryToDo.Models
{
    public class UserDiaryResult
    {
        public int UserDiaryId { get; set; }
        public string DiaryTitle { get; set; }
        public string DiaryContent { get; set; }
        public string DiaryDate { get; set; }
        public string DiaryTime { get; set; }
        public string UserFullName { get; set; }
        public DateTime InsertionDate { get; set; }
    }
}
