using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace PlayingWithTranslink.Gtfs.Services;

public static class GtfsCsv
{
	public static List<T> LoadSmall<T>(string path)
	{
		using var reader = new StreamReader(path);
		using var csv = Create(reader);
		return [.. csv.GetRecords<T>()];
	}

	public static IEnumerable<T> StreamBig<T>(string path)
	{
		using var reader = new StreamReader(path);
		using var csv = Create(reader);

		foreach (var row in csv.GetRecords<T>())
			yield return row;
	}

	private static CsvReader Create(TextReader reader)
	{
		var config = new CsvConfiguration(CultureInfo.InvariantCulture)
		{
			HasHeaderRecord = true,
			MissingFieldFound = null,
			BadDataFound = null,
			HeaderValidated = null,
		};

		return new CsvReader(reader, config);
	}
}
