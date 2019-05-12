#if NETFRAMEWORK
using System.Configuration;
#endif

namespace Common
{
    public static class Constants
    {
        #region Пути для Баз данных

        //public static string PlanetDatabse = "workstation id=PlanetsDatabaseContext.mssql.somee.com;packet size=4096;user id=Ryder_SQLLogin_1;pwd=tfah5u3xng;data source=PlanetsDatabaseContext.mssql.somee.com;persist security info=False;Initial Catalog=PlanetsDatabaseContext;";
        public static string PowerConsumptionDatabase = "Data Source=DESKTOP-UKB4KSV;Initial Catalog=AccountingForEnergy;Integrated Security=True";
        //public static string PowerConsumptionDatabase = "workstation id=AccountingForEnergy.mssql.somee.com;packet size=4096;user id=Hupz_SQLLogin_1;pwd=o54cioyju6;data source=AccountingForEnergy.mssql.somee.com;persist security info=False;initial catalog=AccountingForEnergy";
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
