using System.Collections.Generic;
using Common;
using Kendo.Mvc.UI;
using Kendo.Mvc.UI.Fluent;

namespace ProjectForCourseWork_ver_2._0.Extensions
{
    public static class DatePickerExtensions
    {
        public static DatePickerBuilder BackDatePicker(this DatePickerBuilder datePicker)
        {
            return datePicker
                   .Start(CalendarView.Month)
                   .Format(Constants.DateFormat)
                   .ParseFormats(new List<string>
                   {
                       Constants.DateFormat,
                       Constants.DateShort4YFormat,
                       Constants.DateShort2YFormat,
                       Constants.DateUSAFormat
                   });
        }
    }
}