using CountriesViewer.Models;
using CountriesViewer.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CountriesViewer.Helpers
{
    public class DataContext {

        private static string _dataSourcePath = Path.Combine(HttpRuntime.AppDomainAppPath, Settings.Default.DataSource);

        public static Countries LoadData()
        {
            var deserializer = new XmlSerializer(typeof(Countries));
            var reader = new StreamReader(_dataSourcePath);
            var countries = (Countries)deserializer.Deserialize(reader);
            reader.Close();
            return countries;
        }

        public static void SaveDatabase(Countries countries)
        {
            var serializer = new XmlSerializer(typeof(Countries));
            using (TextWriter writer = new StreamWriter(_dataSourcePath))
            {
                serializer.Serialize(writer, countries);
            }
        }
    }
}