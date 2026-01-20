// SetsAndMaps.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    // Problem 1: FindPairs
    public static string[] FindPairs(string[] words)
    {
        var set = new HashSet<string>(words);
        var result = new List<string>();
        var seen = new HashSet<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1]) continue; // skip duplicates like "aa"
            var reversed = new string(new[] { word[1], word[0] });
            if (set.Contains(reversed) && !seen.Contains(word) && !seen.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
                seen.Add(word);
                seen.Add(reversed);
            }
        }

        return result.ToArray();
    }

    // Problem 2: SummarizeDegrees
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var summary = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var parts = line.Split(',');
            if (parts.Length < 5) continue;
            var degree = parts[3].Trim();
            if (string.IsNullOrEmpty(degree)) continue;

            if (summary.ContainsKey(degree))
                summary[degree]++;
            else
                summary[degree] = 1;
        }
        return summary;
    }

    // Problem 3: IsAnagram
    public static bool IsAnagram(string a, string b)
    {
        a = a.Replace(" ", "").ToLower();
        b = b.Replace(" ", "").ToLower();

        if (a.Length != b.Length) return false;

        var dict = new Dictionary<char, int>();
        foreach (var c in a)
        {
            if (dict.ContainsKey(c)) dict[c]++;
            else dict[c] = 1;
        }

        foreach (var c in b)
        {
            if (!dict.ContainsKey(c)) return false;
            dict[c]--;
            if (dict[c] < 0) return false;
        }

        return true;
    }

    // Problem 5: EarthquakeDailySummary
    public static string[] EarthquakeDailySummary()
    {
        var url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        var json = client.GetStringAsync(url).Result;

        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        if (!root.TryGetProperty("features", out var features))
            return Array.Empty<string>();

        var result = new List<string>();

        foreach (var feature in features.EnumerateArray())
        {
            if (!feature.TryGetProperty("properties", out var prop)) continue;
            var place = prop.GetProperty("place").GetString();
            var mag = prop.GetProperty("mag").GetDouble();
            result.Add($"{place} - Mag {mag}");
        }

        return result.ToArray();
    }
}
