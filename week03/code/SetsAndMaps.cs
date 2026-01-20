using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    // =========================
    // Problem 1: Find Pairs
    // =========================
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> seen = new HashSet<string>();
        List<string> output = new List<string>();

        foreach (string word in words)
        {
            // Ignore words like "aa"
            if (word[0] == word[1])
            {
                seen.Add(word);
                continue;
            }

            string reversed = $"{word[1]}{word[0]}";

            if (seen.Contains(reversed))
            {
                // IMPORTANT: format must match tests exactly
                output.Add($"{word} & {reversed}");
            }

            seen.Add(word);
        }

        return output.ToArray();
    }

    // =========================
    // Problem 2: Degree Summary
    // =========================
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        Dictionary<string, int> degrees = new Dictionary<string, int>();

        foreach (string line in File.ReadLines(filename))
        {
            string[] parts = line.Split(',');

            if (parts.Length < 4)
                continue;

            string degree = parts[3].Trim();

            if (!degrees.ContainsKey(degree))
            {
                degrees[degree] = 0;
            }

            degrees[degree]++;
        }

        return degrees;
    }

    // =========================
    // Problem 3: Anagrams
    // =========================
    public static bool IsAnagram(string word1, string word2)
    {
        string a = word1.Replace(" ", "").ToLower();
        string b = word2.Replace(" ", "").ToLower();

        if (a.Length != b.Length)
            return false;

        Dictionary<char, int> counts = new Dictionary<char, int>();

        foreach (char c in a)
        {
            if (!counts.ContainsKey(c))
                counts[c] = 0;

            counts[c]++;
        }

        foreach (char c in b)
        {
            if (!counts.ContainsKey(c))
                return false;

            counts[c]--;

            if (counts[c] < 0)
                return false;
        }

        return true;
    }

    // =========================
    // Problem 5: Earthquake JSON (Extra Credit)
    // =========================
    public static string[] EarthquakeDailySummary()
    {
        string url =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using HttpClient client = new HttpClient();
        string json = client.GetStringAsync(url).Result;

        EarthquakeRoot data =
            JsonSerializer.Deserialize<EarthquakeRoot>(json);

        List<string> results = new List<string>();

        foreach (var feature in data.features)
        {
            if (feature.properties.mag != null)
            {
                results.Add(
                    $"{feature.properties.place} - Mag {feature.properties.mag}"
                );
            }
        }

        return results.ToArray();
    }
}

// =========================
// JSON Helper Classes
// (Must be in this file)
// =========================
public class EarthquakeRoot
{
    public List<EarthquakeFeature> features { get; set; }
}

public class EarthquakeFeature
{
    public EarthquakeProperties properties { get; set; }
}

public class EarthquakeProperties
{
    public string place { get; set; }
    public double? mag { get; set; }
}
