using System;
using System.Collections.Generic;

namespace Wholesale.Web.Models.Dto
{
    public class AdminHomePageViewModel
    {
        public AdminHomePageViewModel()
        {
            Charts = new List<ChartDash>();
        }
        public int TotalUsers { get; set; }
        public float SellMonth { get; set; }
        public float TotalSell { get; set; }
        public int TotalProducts { get; set; }
        public int TotalNews { get; set; }

        public List<ChartDash> Charts { get; set; }
    }
    public class ChartDash
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float FinalPrice { get; set; }
    }
}
