using System;
using System.Collections.Generic;
using System.ServiceProcess;
using DataModel;
using DataManager;
using System.IO;

namespace ServiceLayer
{
    public partial class DataService : ServiceBase
    {
        public DataService()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                using (TinyAirLinesEntities db = new TinyAirLinesEntities())
                {
                    List<AirLinesEntity> airLinesList = new List<AirLinesEntity>();
                    DataAccess.DataAccess dataAccess = new DataAccess.DataAccess();
                    dataAccess.DbImport(out airLinesList, db);
                    List<string> data = dataAccess.DbConvert(airLinesList);
                    XmlDbSerializer xmlDbSerializer = new XmlDbSerializer();
                    xmlDbSerializer.XmlSerialize<List<string>>($"C:/TinyAirLines/AirLinesInfo.xml", data);
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter("Error_Log.txt"))
                {
                    sw.WriteLine(ex.Message);
                }
            }
        }

        protected override void OnStop()
        {
        }
    }
}
