using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Squad3.Core
{
    public class UsersFirstDetailsInfoCore :Entity
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UsersCore UsersCore { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public GenderEnum? Gender { get; set; }
        public DateTime DateTime { get; set; }
    }
}
