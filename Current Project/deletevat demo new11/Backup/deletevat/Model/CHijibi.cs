using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using ETL.Model;

namespace Model
{
    public class CHijibi 
    {
        public string BranchID { get; set; }
        public float Chrom { get; set; }

            public CHijibi()
            {
                this.BranchID = string.Empty;
                this.Chrom = 0;
                
            }
    }
}
