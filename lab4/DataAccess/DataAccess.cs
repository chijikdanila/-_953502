using System;
using System.Collections.Generic;
using DataModel;

namespace DataAccess
{
    public class DataAccess
    {
        public void DbImport(out List<AirLinesEntity> airLinesList, TinyAirLinesEntities db)
        {
            airLinesList = new List<AirLinesEntity>();
            int k = 0;
            foreach (var obj in db.AirLines)
            {
                AirLinesEntity airLinesEntity = new AirLinesEntity();
                airLinesEntity.AirLines = obj;
                airLinesList.Add(airLinesEntity);
                k++;
            }

            for (int i = 0; i < k; i++)
            {
                foreach (var obj in db.Pilots)
                {
                    if (obj.Id == airLinesList[i].AirLines.PilotId)
                    {
                        airLinesList[i].Pilots = obj;
                        break;
                    }
                }

                foreach (var obj in db.Companies)
                {
                    if (obj.Id == airLinesList[i].AirLines.CompanyId)
                    {
                        airLinesList[i].Companies = obj;
                        break;
                    }
                }

                foreach (var obj in db.Planes)
                {
                    if (obj.Id == airLinesList[i].AirLines.PlaneId)
                    {
                        airLinesList[i].Planes = obj;
                        break;
                    }
                }

                foreach (var obj in db.ServiceStaff)
                {
                    if (obj.Id == airLinesList[i].AirLines.ServiceStaffId)
                    {
                        airLinesList[i].ServiceStaff = obj;
                        break;
                    }
                }
            }
        }

        public List<string> DbConvert(List<AirLinesEntity> airLinesList)
        {
            List<string> dataList = new List<string>();
            foreach (var obj in airLinesList)
            {
                dataList.Add(obj.Pilots.Name);
                dataList.Add(obj.Pilots.SurName);
                dataList.Add(obj.Pilots.Education);
                dataList.Add(obj.Pilots.Age.ToString());
                dataList.Add(obj.ServiceStaff.Name);
                dataList.Add(obj.ServiceStaff.SurName);
                dataList.Add(obj.ServiceStaff.Age.ToString());
                dataList.Add(obj.ServiceStaff.Sex);
                dataList.Add(obj.Planes.PlaneName);
                dataList.Add(obj.Planes.Series);
                dataList.Add(obj.Planes.YearOfCreation.ToString());
                dataList.Add(obj.Companies.CompanyName);
                dataList.Add(obj.Companies.Contacts);
                dataList.Add(obj.Companies.Email);
                dataList.Add(obj.Companies.Adress);
            }
            return dataList;
        }
        public DataAccess()
        {

        }
    }
}
