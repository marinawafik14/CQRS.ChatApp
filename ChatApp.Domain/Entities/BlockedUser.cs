using ChatApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatApp.Domain.Entities
{
    public class BlockedUser : BaseEntity<int>
    {

        public int BlockerId { get; set; }

        [ForeignKey("BlockerId")]
        public virtual  User Blocker { get; set; }
        public int BlockedId { get; set; }

        [ForeignKey("BlockedId")]
        public virtual User? Blocked { get; set; }


     



    }
}
