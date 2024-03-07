using System;

namespace my_portfolio_project.Models
{
    public class Usermodel
    {
        public required string userName { get; set; }
        public int userId { get; set; }
        public int customerId { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime stopDate { get; set; }
    }
}
