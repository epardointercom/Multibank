using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Newtonsoft.Json;
using Multibank.Autorizador.Models;

namespace Multibank.Autorizador
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string ServiceBaseUrlKey = "serviceBaseUrl_key";
        private static readonly string ServiceBaseUrlDefault = "http://192.168.2.239:8046/ServiceRestMobileEnterprise/";

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        private const string IsLoggedInTokenKey = "isloggedid_key";
        private static readonly bool IsLoggedInTokenDefault = false;

        private const string CurrentSessionKey = "currentSession_Key";
        private static readonly Session CurrentSessionDefault = null;

        private const string CurrentUserKey = "currentUser_Key";
        private static readonly User CurrentUserDefault = null;

        #endregion


        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        public static bool IsLoggedIn
        {
            get
            {
                return AppSettings.GetValueOrDefault(IsLoggedInTokenKey, IsLoggedInTokenDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(IsLoggedInTokenKey, value);
            }
        }

        public static string ServiceBaseUrl
        {
            get
            {
                return AppSettings.GetValueOrDefault(ServiceBaseUrlKey, ServiceBaseUrlDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ServiceBaseUrlKey, value);
            }
        }

        public static Session CurrentSession
        {
            get
            {
                return JsonConvert.DeserializeObject<Session>(AppSettings.GetValueOrDefault(CurrentSessionKey, JsonConvert.SerializeObject(CurrentSessionDefault)));
            }
            set
            {
                AppSettings.AddOrUpdateValue(CurrentSessionKey, JsonConvert.SerializeObject(value));
            }
        }

        public static User CurrentUser
        {
            get
            {
                return JsonConvert.DeserializeObject<User>(AppSettings.GetValueOrDefault(CurrentUserKey, JsonConvert.SerializeObject(CurrentUserDefault)));
            }
            set
            {
                AppSettings.AddOrUpdateValue(CurrentUserKey, JsonConvert.SerializeObject(value));
            }
        }
    }
}