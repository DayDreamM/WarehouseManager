using System;

namespace CheckOutApp.entity
{
    class CheckoutRecord
    {
        public int id { get; set; }
        public string company { get; set; }
        public string recordId { get; set; }
        public string carNumber { get; set; }
        public string totalSum { get; set;}
        public string totalNumber { get; set; }
        public string paymentMethod { get; set; }
        public string recordOperator { get; set; }
        public string inTime { get; set; }
        public string remark { get; set; }
    }
}
