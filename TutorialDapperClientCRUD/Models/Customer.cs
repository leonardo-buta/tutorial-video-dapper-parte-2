using Dapper.Contrib.Extensions;
using System;

namespace TutorialDapperClientCRUD.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
