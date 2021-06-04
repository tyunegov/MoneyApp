using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Models
{
    public class ReportPeriodDTOModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<AmountGroupTypeDTOModel> AmountGroupType { get; set; }
        public decimal Rest { 
            get {
                if(AmountGroupType!=null)
                {
                    return(getAmount(1) - getAmount(2));
                }
                return 0;
            } 
        }
        decimal getAmount(int id)
        {
            return AmountGroupType.Where(x => x.Type.Id == id).First().Amount;
        }
    }
}
