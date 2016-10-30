using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace VacationReservations.App_Code.DataAccess
{
    public static class VacationReservationsConfiguration
    {
        private static string dbConnectionString;
        private static string dbProviderName;

        static VacationReservationsConfiguration()
        {
            dbConnectionString = ConfigurationManager.ConnectionStrings["VacationReservationsConnection"].ConnectionString;
            dbProviderName = ConfigurationManager.ConnectionStrings["VacationReservationsConnection"].ProviderName;
        }

        public static string DbConnectionString
        {
            get
            {
                return dbConnectionString;
            }
        }

        public static string DbProviderName
        {
            get
            {
                return dbProviderName;
            }
        }
        
        public static string MailServer
        {
            get
            {
                return ConfigurationManager.AppSettings["MailServer"];
            }
        }

        public static string MailUsername
        {
            get
            {
                return ConfigurationManager.AppSettings["MailUsername"];
            }
        }

        public static string MailPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["MailPassword"];
            }
        }

        public static string MailFrom
        {
            get
            {
                return ConfigurationManager.AppSettings["MailFrom"];
            }
        }

        public static bool EnableErrorLogEmail
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings
                ["EnableErrorLogEmail"]);
            }
        }

        public static string ErrorLogEmail
        {
            get
            {
                return ConfigurationManager.AppSettings["ErrorLogEmail"];
            }
        }
    }
}
           