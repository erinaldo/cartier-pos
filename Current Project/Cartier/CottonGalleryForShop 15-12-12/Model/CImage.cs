using System;
namespace ETL
{
    namespace Model
    {
        [Serializable]
        public class CImage : CBase
        {
            #region "Properties"

            public string Images_OId { get; set; }
            public byte[] Images_Data { get; set; }

            #endregion

            #region "constructor"

            /// <summary>
            /// Default constructor.
            /// </summary>
            public CImage()
            {
                this.Images_OId = string.Empty;
                this.Images_Data = null;
            }

            #endregion

        }
    }
}