using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TravelerPortal.WebUI.Infrastructure
{
    public class JSONCustomDateConverter : DateTimeConverterBase
    {
        private int _timeZoneOffset;
        private string _dateFormat;

        public JSONCustomDateConverter(string dateFormat, int timeZoneOffset)
        {
            _dateFormat = dateFormat;
            _timeZoneOffset = timeZoneOffset;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(Convert.ToDateTime(value).AddMinutes(_timeZoneOffset).ToString(_dateFormat));
            writer.Flush();
        }
    }
}