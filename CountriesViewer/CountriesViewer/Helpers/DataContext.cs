using CountriesViewer.Models;
using CountriesViewer.Properties;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Xml.Serialization;

namespace CountriesViewer.Helpers
{
    public class DataContext {

        private static string _dataSourcePath = Path.Combine(HttpRuntime.AppDomainAppPath, Settings.Default.DataSource);
        private static ReaderWriterLockSlim readWriteLock = new ReaderWriterLockSlim();
        private static readonly ILog log = LogManager.GetLogger(typeof(DataContext));

        public static Countries LoadData()
        {
            try
            {
                var deserializer = new XmlSerializer(typeof(Countries));
                var reader = new StreamReader(_dataSourcePath);
                var countries = (Countries)deserializer.Deserialize(reader);
                reader.Close();

                return countries;
            } catch (Exception e) {
                log.ErrorFormat("There was a problem while reading data from xml file, EXCEPTION: {0}", e.Message);

                return new Countries { CountriesList = new List<Country>() };
            }
        }

        public static void SaveDatabase(Countries countries)
        {
            var serializer = new XmlSerializer(typeof(Countries));
            Debug.WriteLine(String.Format("locking file on thread {0}", Thread.CurrentThread.ManagedThreadId));
            readWriteLock.EnterWriteLock();

            try
            {
                using (TextWriter writer = new StreamWriter(_dataSourcePath))
                {
                    Debug.WriteLine(String.Format("serializing file on thread {0}", Thread.CurrentThread.ManagedThreadId));
                    log.Info("Serializng file");
                    serializer.Serialize(writer, countries);
                } 
            } catch(IOException e) {
                log.ErrorFormat("There was a problem while writing data to xml file, EXCEPTION: {0}", e.Message);
            }
            finally
            {
                Debug.WriteLine(String.Format("unlocking file on thread {0}", Thread.CurrentThread.ManagedThreadId));
                readWriteLock.ExitWriteLock();
            }
        }
    }
}