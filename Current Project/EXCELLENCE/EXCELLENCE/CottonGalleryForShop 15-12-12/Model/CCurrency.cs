using System;
namespace ETL
{
    namespace Model
    {
        [Serializable]
        public class CCurrency
        {
            public string Curr_OID { get; set; }
            public string Curr_Code { get; set; }
            public string Curr_Name { get; set; }
            public string Curr_Branch { get; set; }

            public CCurrency()
            {
                this.Curr_OID = string.Empty;
                this.Curr_Code = string.Empty;
                this.Curr_Name = string.Empty;
                this.Curr_Branch = string.Empty;
            }
        }
    }
}