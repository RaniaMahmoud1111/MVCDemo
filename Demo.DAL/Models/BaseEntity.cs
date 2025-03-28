using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }//pk
        public int CreatedBy { get; set; }// user id

        public DateTime? CreatedOn { get; set; }// Time of creation 

        public int  LastModifiedBy { get; set; }//user id

        public DateTime? LastModifiedOn { get; set; } // time of last modification [Auto Calculated]

        public bool IsDeleted { get; set; }// soft Delete 


    }
}
