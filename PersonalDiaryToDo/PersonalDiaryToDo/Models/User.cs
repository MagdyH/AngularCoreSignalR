using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalDiaryToDo.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [NotMapped]
        public virtual string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
