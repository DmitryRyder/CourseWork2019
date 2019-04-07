#if NETFRAMEWORK
using System.Configuration;
#endif

namespace Common
{
    public static class Constants
    {
        #region Пути для Баз данных

        public static string PlanetDatabse = "workstation id=PlanetsDatabaseContext.mssql.somee.com;packet size=4096;user id=Ryder_SQLLogin_1;pwd=tfah5u3xng;data source=PlanetsDatabaseContext.mssql.somee.com;persist security info=False;Initial Catalog=PlanetsDatabaseContext;";
        public static string PowerConsumptionDatabase = "Data Source=DESKTOP-UKB4KSV;Initial Catalog=Accounting_for_energy;Integrated Security=True";

        #endregion
#if NETFRAMEWORK
        public static readonly string ApiUrl = ConfigurationManager.AppSettings["API"];
#endif

        public const string DateTimeFullFormat = "dd.MM.yyyy HH:mm:ss";
    }
}
