using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donate.Domain
{
    public class BaseEntity
    {
        public virtual int Id { get; set; }
        [NotMapped]
        public bool HasError { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }
        public void AddErrorMessage(string message)
        {
            ErrorMessage = message;
        }
    }
}
