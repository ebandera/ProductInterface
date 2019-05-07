using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Net;

namespace ProductInterface
{
    class RegReader
    {
        string _mainKey = "";
        public RegReader(string mainKey)
        {
            _mainKey = mainKey;
        }
        public void Add(string key, string value)
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey(_mainKey);
            rk.SetValue(key, value);
            rk.Close();
        }
        public string Read(string key,string defaultValue="")
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(_mainKey, false);
            if (rk != null && rk.GetValue(key) != null)
            {
                return rk.GetValue(key).ToString();
            }
            else
            {
                return defaultValue;
            }
        }
        public bool Test(string key)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(_mainKey, false);
            if (rk != null && rk.GetValue(key) != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
