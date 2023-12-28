using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLesson
{


    internal class CovidTest
    {
        private string name;
        private string id;
        private int cityCode;
        private bool isSick;

        public CovidTest(string name, string id, int cityCode,bool isSick)
        {
            this.name = name;
            this.id = id;
            this.cityCode = cityCode;
            this.isSick = isSick;
        }
        //add getters and setters
        public string GetName()
        {
            return name;
        }
        public string GetId()
        {
            return id;
        }
        public int GetCityCode()
        {
            return cityCode;
        }
        public bool GetIsSick()
        {
            return isSick;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetId(string id)
        {
            this.id = id;
        }
        public void SetCityCode(int cityCode)
        {
            this.cityCode = cityCode;
        }
        public void SetIsSick(bool isSick)
        {
            this.isSick = isSick;
        }
        public override string ToString()
        {
            return $"Name: {name}, Id: {id}, CityCode: {cityCode}, Sick: {isSick}";
        }
    }
}
