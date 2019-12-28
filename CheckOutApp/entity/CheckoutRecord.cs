using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutApp.entity
{
    class CheckoutRecord
    {
        public int id { get; set; }
        public int recordId { get; set; }
        public String carNumber { get; set; }
        public int totalSum { get; set;}
        public int totalNumber { get; set; }
        public String paymentMethod { get; set; }
        public String recordOperator { get; set; }
        public DateTime inTime { get; set; }
    }
}
