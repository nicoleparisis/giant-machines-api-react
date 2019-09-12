using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace models
{
    public class TimeSheetEntry
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Client { get; set; }
        public string Project { get; set; }
        public string ProjectCode { get; set; }
        public Decimal Hours { get; set; }
        public Decimal HoursRounded { get; set; }
        public bool Billable { get; set; }
        [NotMapped]
        public Decimal BillableHours
        {
            get
            {
                if (Billable)
                {
                    return HoursRounded;
                }

                return Decimal.Zero;
            }
            set{}
        }
        [NotMapped]
        public Decimal BillableAmount
        {
            get
            {
                if (Billable)
                {
                    return (Hours * BillableRate);
                }

                return Decimal.Zero;
            }
            set{}
        }
        [NotMapped]
        public string BillableAmountFormatted
        {
            get
            {
                if (Billable)
                {
                    return "$" + BillableAmount.ToString("F");
                }

                return "-";
            }
            set { }
        }

        public bool Invoiced { get; set; }
        public bool Approved { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public bool Employee { get; set; }
        public int BillableRate { get; set; }
        public int CostRate { get; set; }
        public int CostAmount { get; set; }
        public string Currency { get; set; }
        public string ExternalReferenceURL { get; set; }
    }
}
