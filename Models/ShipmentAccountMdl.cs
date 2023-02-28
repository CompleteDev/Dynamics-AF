using System.Collections.Generic;

namespace DynamicsInfo.Models
{
    public class ShipmentAccountMdl
    {
        public string name { get; set; }
        public string accountnumber { get; set; }
        public string telephone1 { get; set; }
        public string address1_line1 { get; set; }
        public string address1_line2 { get; set; }
        public string address1_city { get; set; }
        public string address1_stateorprovince { get; set; }
        public string address1_postalcode { get; set; }
        public string address1_country { get; set; }
        public string address2_line1 { get; set; }
        public string address2_line2 { get; set; }
        public string address2_city { get; set; }
        public string address2_stateorprovince { get; set; }
        public string address2_postalcode { get; set; }
        public string address2_country { get; set; }
        public int statecode { get; set; }
    }

    public class ShipmentAccountResponseMdl
    {
        public List<ShipmentAccountMdl> value { get; set; }
    }
}
