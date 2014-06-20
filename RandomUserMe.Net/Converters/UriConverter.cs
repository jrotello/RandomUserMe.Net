using System;
using Newtonsoft.Json;

namespace RandomUserMe.Net.Converters
{
    public class UriConverter: JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string value = reader.Value.ToString();

            Uri uri;
            if (Uri.TryCreate(value, UriKind.Absolute, out uri))
            {
                return uri;
            }

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (Uri);
        }
    }
}