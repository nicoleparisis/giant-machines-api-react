using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace models
{
    public class TimeSheetEntryDTO
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public Decimal? Hours { get; set; }
        public Decimal? HoursRounded { get; set; }
        public Decimal? BillableHours { get; set; }
        public bool Billable { get; set; }
        public Decimal? BillableAmount { get; set; }
        public string BillableAmountFormatted { get; set; }
        public string FullName { get; set; }
        public int BillableRate { get; set; }
        public int CostRate { get; set; }
        public int CostAmount { get; set; }
    }
}
