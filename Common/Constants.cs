#if NETFRAMEWORK
using System.Configuration;
#endif

namespace Common
{
    public static class Constants
    {
        #region Пути для Баз данных
        public static string ThermalNetworksDBContext = "ThermalNetworks.mssql.somee.com;packet size=4096;user id=NapiformGoose_SQLLogin_1;pwd=s5d8w2mf7y;data source=ThermalNetworks.mssql.somee.com;persist security info=False;initial catalog=ThermalNetworks";
        #endregion
#if NETFRAMEWORK
        public static readonly string ApiUrl = ConfigurationManager.AppSettings["API"];
#endif

        public const string DateTimeFullFormat = "dd.MM.yyyy HH:mm:ss";
        public const string DateFormat = "dd.MM.yyyy";
        public const string DateShort2YFormat = "ddMMyy";
        public const string DateShort4YFormat = "ddMMyyyy";
        public const string DateUSAFormat = "MM/dd/yyyy";
        public const string AttributeDateFormat = "{0:dd.MM.yyyy}";
        public const string AttributeDateWithoutDayFormat = "{0:MM.yyyy}";
        public const string AttibuteTimeFormat = "{0:HH:mm}";
    }
}
