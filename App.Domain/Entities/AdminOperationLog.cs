using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class AdminOperationLog
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int UserId { get; set; }
    }
}
