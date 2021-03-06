﻿using Windows.Data.Json;

namespace ResultsTracker
{
    public static class JsonObjectExtender
    {
        // extension method that adds a primitive value...
        public static void Add(this JsonObject json, string key, string value)
        {
            json.Add(key, JsonValue.CreateStringValue(value));
        }

        public static void Add(this JsonObject json, string key, bool value)
        {
            json.Add(key, JsonValue.CreateBooleanValue(value));
        }

        public static void Add(this JsonObject json, string key, double value)
        {
            json.Add(key, JsonValue.CreateNumberValue(value));
        }

        public static void AddArray(this JsonObject json, string key, string value)
        {
            json.Add(key, JsonArray.Parse(value));
        }
    }
}
