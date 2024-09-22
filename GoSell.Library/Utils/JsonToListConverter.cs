using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoSell.Library.Utils;

public class JsonToListConverter<T> : CustomCreationConverter<IList<T>>
{
    public override IList<T> Create(Type objectType)
    {
        // Default value is an empty list.
        return new List<T>();
    }

    public override object ReadJson(JsonReader reader, Type objectType,
       object existingValue, JsonSerializer serializer)
    {
        if (serializer == null) throw new ArgumentNullException(nameof(serializer));
        if (reader == null) throw new ArgumentNullException(nameof(reader));
        if (objectType == null) throw new ArgumentNullException(nameof(objectType));

        if (reader.TokenType == JsonToken.StartArray)
        {
            // JSON object was already an array, so just deserialize it as usual.
            object result = serializer.Deserialize(reader, objectType);

            // Add a null check for the result variable
            if (result != null)
            {
                return result;
            }
            else
            {
                // Handle the case where result is null, 
                // perhaps by returning an empty list or a default value.
                return new List<T>();
            }
        }
        else
        {
            // JSON object was not an array, 
            // so deserialize the object and wrap it in a List.
            var resultObject = serializer.Deserialize<T>(reader);

            // Check if resultObject is null before adding to the list
            if (resultObject != null)
            {
                var correctedResult = new List<T>();
                correctedResult.Add(resultObject);
                return correctedResult;
            }
            else
            {
                // Handle the case where resultObject is null, 
                // perhaps by returning an empty list or a default value.
                return new List<T>();
            }
        }
    }
}
