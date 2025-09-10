using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;
using CsvDataAccess.OldSolution;

namespace CsvDataAccess.NewSolution;

public class TableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var columns = csvData.Columns;
        var rows = csvData.Rows;

        

        if (string.IsNullOrEmpty(value))
        {
            return null;
        }
        if (value == "TRUE")
        {
            return true;
        }
        if (value == "FALSE")
        {
            return false;
        }
        if (value.Contains(".") && decimal.TryParse(value, out var valueAsDecimal))
        {
            return valueAsDecimal;
        }
        if (int.TryParse(value, out var valueAsInt))
        {
            return valueAsInt;
        }
        return value;


        return new TableData(csvData.Columns, resultRows);
    }
}

// public class CsvReader
// {
//     public CsvData Read(string filePath)
//     {
//         var streamReader = new StreamReader(filePath);

//         string Separator = ",";
//         var columns = streamReader.ReadLine().Split(Separator);

//         var rows = new List<string[]>();
//         while (!streamReader.EndOfStream)
//         {
//             var cellData = streamReader.ReadLine().Split(Separator);
//             rows.Add(cellData);
//         }

//         return new CsvData(columns, rows);
//     }
// }

// public class CsvData {
//     public string[] Columns { get; }
//     public IEnumerable<string[]> Rows { get; }
//     public CsvData(string[] columns, IEnumerable<string[]> rows)
//     {
//         Columns = columns;
//         Rows = rows;
//     }
// }