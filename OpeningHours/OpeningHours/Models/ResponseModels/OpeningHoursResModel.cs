using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpeningHours.Models.ResponseModels
{
    public class Monday
    {
        public List<string> openingHours { get; set; }
    }
    public class Tuesday
    {
        public List<string> openingHours { get; set; }
    }

    public class Wednesday
    {
        public List<string> openingHours { get; set; }
    }

    public class Thursday
    {
        public List<string> openingHours { get; set; }
    }

    public class Friday
    {
        public List<string> openingHours { get; set; }
    }

    public class Saturday
    {
        public List<string> openingHours { get; set; }
    }

    public class Sunday
    {
        public List<string> openingHours { get; set; }
    }

    public class OpeningHoursResModel
    {
        public Monday monday { get; set; }
        public Tuesday tuesday { get; set; }
        public Wednesday wednesday { get; set; }
        public Thursday thursday { get; set; }
        public Friday friday { get; set; }
        public Saturday saturday { get; set; }
        public Sunday sunday { get; set; }

        public OpeningHoursResModel()
        {
            monday = new Models.ResponseModels.Monday() { openingHours = new List<string>() };
            tuesday = new Models.ResponseModels.Tuesday() { openingHours = new List<string>() };
            wednesday = new Models.ResponseModels.Wednesday() { openingHours = new List<string>() };
            thursday = new Models.ResponseModels.Thursday() { openingHours = new List<string>() };
            friday = new Models.ResponseModels.Friday() { openingHours = new List<string>() };
            saturday = new Models.ResponseModels.Saturday() { openingHours = new List<string>() };
            sunday = new Models.ResponseModels.Sunday() { openingHours = new List<string>() };
        }
    }
}
