﻿using Doctrina.ExperienceApi.Data.Json.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace Doctrina.ExperienceApi.Data.Json
{
    public struct JsonString
    {
        private readonly string _jsonString;

        public JsonString(string jsonString)
        {
            _jsonString = jsonString;
        }

        public JToken ToJToken()
        {
            return Deserialize<JToken>();
        }

        public JArray ToJArray()
        {
            return Deserialize<JArray>();
        }

        public T Deserialize<T>()
        {
            try
            {
                using (var stringReader = new StringReader(_jsonString))
                {
                    using (var jsonTextReader = new JsonTextReader(stringReader))
                    {
                        var jsonSerializer = new ApiJsonSerializer();
                        return jsonSerializer.Deserialize<T>(jsonTextReader);
                    }
                }
            }
            catch (JsonReaderException ex)
            {
                throw new JsonStringException(ex.Message, ex);
            }
        }

        public static implicit operator JsonString(string jsonString)
        {
            return new JsonString(jsonString);
        }

        public static implicit operator string(JsonString jsonString)
        {
            return jsonString.ToString();
        }

        public static bool operator ==(JsonString left, JsonString right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(JsonString left, JsonString right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return _jsonString;
        }

        public override bool Equals(object obj)
        {
            return obj is JsonString @string &&
                   _jsonString == @string._jsonString;
        }

        public override int GetHashCode()
        {
            return 632056553 + EqualityComparer<string>.Default.GetHashCode(_jsonString);
        }
    }
}
