using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPI.Helpers
{
    public static class RegisteredYearsAgo
    {
        public static string AddedBikeAgo(this DateTime dateTime)
        {
            var currentDate = DateTime.Now;
            int years = currentDate.Year - dateTime.Year;
            int month = currentDate.Month - dateTime.Month;
            int day = currentDate.Day- dateTime.Day;

            string dateAddedAgo = $"Added Bike: {years}.{month}.{day}";

            return string.Format(dateAddedAgo);
        }
    }
}
