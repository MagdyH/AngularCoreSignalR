using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalDiaryToDo.Models
{
    public class UserDiary
    {
        [Key]
        public int UserDiaryId { get; set; }
        [StringLength(150)]
        public string DiaryTitle { get; set; }
        //[StringLength(500)]
        public string DiaryContent { get; set; }
        public DateTime DiaryDataTime { get; set; }
        //public string DiaryImage { get; set; }
        public DateTime InsertionDate { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
