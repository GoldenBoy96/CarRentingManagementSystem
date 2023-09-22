using MyUtils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AppSetting
{
    public class AppSettingManager
    {
        //Singleton
        public static AppSettingManager Instance { get; } = new();
        public AppSetting? AppSetting { get => _appSetting; set => _appSetting = value; }

        private AppSettingManager()
        {
        }

        AppSetting? _appSetting;
        

        public void ReadAppSettingFile()
        {
            _appSetting = JSONSerialize.ReadData<AppSetting>("appsettings.json");
        }
        public void GenerateDefaultAppSettingFile()
        {
            Account defaultAdmin = new("admin@FUCarRentingSystem.com", "@@admin@@", Role.Admin);
            AppSetting appSetting = new(defaultAdmin, "Server=MEOWMEOW\\SQLEXPRESS;Database=FUCarRentingManagement; TrustServerCertificate=true; Uid=sa; Pwd=1234567890");
            JSONSerialize.SaveData(appSetting, "appsettings.json");
        }
    }

    [Serializable]
    public class AppSetting
    {
        Account? _defaultAdmin;
        string? _connetionString;

        public AppSetting(Account? defaultAdmin, string? connetionString)
        {
            _defaultAdmin = defaultAdmin;
            _connetionString = connetionString;
        }

        [JsonProperty] public Account? DefaultAdmin { get => _defaultAdmin; set => _defaultAdmin = value; }
        [JsonProperty] public string? ConnetionString { get => _connetionString; set => _connetionString = value; }
    }

    public class Account
    {
        string? _email;
        string? _password;
        Role _role;

        public Account(string email, string password, Role role)
        {
            Email = email;
            Password = password;
            Role = role;
        }

        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public Role Role { get => _role; set => _role = value; }
    }

    public enum Role
    {
        Customer, Admin
    }
}
