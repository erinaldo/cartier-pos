using System;
using System.Data;

namespace ETL
{
    namespace Common
    {
        public enum EDateType
        {
            CURRENT = 0,
            FROM = 1,
            TO = 2,
            MIN = 3
        }

        public static class CUtils
        {
            /// <summary>
            /// Return the desired Date time.
            /// </summary>
            /// <param name="sInputDate">Format : dd-mm-yyyy</param>
            /// <param name="sType">"",From,To and MIN</param>
            /// <returns></returns>
            public static DateTime GetDate(string sInputDate,EDateType eDateType)
            {
                DateTime oNow = DateTime.Now;
                DateTime oDateTime = DateTime.MinValue;

                string[] sDate = sInputDate.Trim().Split('-');

                string sHour = oNow.Hour.ToString();
                string sMinute = oNow.Minute.ToString();
                string sSecond = oNow.Second.ToString();

                if (eDateType==EDateType.FROM)
                {
                    sHour = "00";
                    sMinute = "00";
                    sSecond = "00";
                }
                else if (eDateType == EDateType.TO)
                {
                    sHour = "23";
                    sMinute = "59";
                    sSecond = "59";
                }

                if (eDateType == EDateType.MIN)
                {
                    oDateTime = new DateTime(1900, 01, 01, 00, 00, 00);
                }
                else
                {
                    try
                    {
                        oDateTime = new DateTime(int.Parse(sDate[2]), int.Parse(sDate[1]), int.Parse(sDate[0]), int.Parse(sHour), int.Parse(sMinute), int.Parse(sSecond));
                    }
                    catch (Exception)
                    {
                        oDateTime = DateTime.MinValue;
                    }
                }

                return oDateTime;
            }

            public static object GetDBValue(DataRow dr, int nColumnIndex, string sDefaultValue)
            {
                object oReturnObject = null;

                try
                {
                    if (dr[nColumnIndex].GetType().Equals(typeof(DBNull)))
                    {
                        oReturnObject = sDefaultValue;
                    }
                    else
                    {
                        oReturnObject = dr[nColumnIndex];
                    }
                }
                catch (Exception e)
                {
                    oReturnObject = sDefaultValue;
                }

                return oReturnObject;
            }

            public static string RemoveAPS(string sValue)
            {
                sValue = sValue.Replace("'", "''");
                return sValue;
            }

            public static string RestoreAPS(string sValue)
            {
                sValue = sValue.Replace("''", "'");
                return sValue;
            }
            
        }
    }
}
