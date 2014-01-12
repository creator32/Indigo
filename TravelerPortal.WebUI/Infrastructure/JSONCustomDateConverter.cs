using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TravelerPortal.WebUI.Infrastructure
{
    public class JSONCustomDateConverter : DateTimeConverterBase
    {
        private int _timeZoneOffsetInMinutes;
        private string _dateFormat;

        public JSONCustomDateConverter(string dateFormat, int timeZoneOffsetInMinutes)
        {
            _dateFormat = dateFormat;
            _timeZoneOffsetInMinutes = timeZoneOffsetInMinutes;
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
            writer.WriteValue(Convert.ToDateTime(value).AddMinutes(_timeZoneOffsetInMinutes).ToString(_dateFormat));
            writer.Flush();
        }
    }
}