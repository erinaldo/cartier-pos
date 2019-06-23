using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using ETL.Model;
namespace ETL
{
    namespace Model
    {
        public class CSize : CBase
        {
            public string Size_OID { get; set; }
            public string Size_Code { get; set; }
            public string Size_Name { get; set; }
            public string Size_Branch { get; set; }



            public CSize()
            {
                Size_OID = string.Empty;
                Size_Code = string.Empty;
                Size_Name = string.Empty;
                Size_Branch = string.Empty;
            }

        }
    }
}
