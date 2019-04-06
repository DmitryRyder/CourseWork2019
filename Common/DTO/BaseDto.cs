using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Common.DTO
{
    public class BaseDto : IComparable
    {
        [DisplayName("Id")]
        public virtual int Id { get; set; }

        [JsonIgnore]
        public virtual string Text =>
           GetType()
              .GetProperty("Name")
             ?.GetValue(this, null)
             ?.ToString();

        [JsonIgnore]
        [DisplayName("Id")]
        public string IdToString => Id.ToString();

        public override string ToString() => $"{Id} - {GetType().FullName}";

        public Dictionary<string, string> ServerValidationErrors { get; set; } = new Dictionary<string, string>();

        public string EntityLink { get; set; }

        public string EntityUrl { get; set; }

        public virtual Dictionary<string, string> Validate() => null;

        protected void AssertNotNull(string fieldName, string exString, Dictionary<string, string> result)
        {
            var obj = GetType()
                     .GetProperty(fieldName)
                    ?.GetValue(this, null);
            if (result.ContainsKey(fieldName))
                return;
            switch (obj)
            {
                case string sObj:
                    if (string.IsNullOrEmpty(sObj))
                        result.Add(fieldName, exString);
                    break;
                case BaseDto dtoObj:
                    if (dtoObj.Id <= 0)
                        result.Add(fieldName, exString);
                    break;
                case DateTime dateObj:
                    if (dateObj.Year <= 1)
                        result.Add(fieldName, exString);
                    break;
                case null:
                    result.Add(fieldName, exString);
                    break;
            }
        }

        protected void AssertNumeric(string fieldName, string exString, Dictionary<string, string> result, Func<decimal, bool> func)
        {
            AssertNotNull(fieldName, exString, result);
            var obj = GetType()
                     .GetProperty(fieldName)
                    ?.GetValue(this, null);
            switch (obj)
            {
                case decimal dObj:
                    if (!func(dObj) && !result.ContainsKey(fieldName))
                        result.Add(fieldName, exString);
                    break;
                case double doubleObj:
                    if (!func((decimal)doubleObj) && !result.ContainsKey(fieldName))
                        result.Add(fieldName, exString);
                    break;
                case int iObj:
                    if (!func(iObj) && !result.ContainsKey(fieldName))
                        result.Add(fieldName, exString);
                    break;
            }
        }

        public virtual int CompareTo(object obj)
        {
            if (obj is BaseDto otherDto)
                return string.Compare(Id.ToString(), otherDto.Id.ToString(), StringComparison.CurrentCulture);
            throw new ArgumentException("Object is not a BaseDto");
        }

        [JsonIgnore]
        public bool IsNew => Id == 0;
    }
}
