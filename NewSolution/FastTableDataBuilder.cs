using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;

namespace CsvDataAccess.OldSolution;

public class TableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var resultRows = new List<Dictionary<string, object>>(); // this is the /list that holds FastRow objects, a FastRow object is an object that contains a dictionary consisting of a string and an object to go with it.

        foreach (var row in csvData.Rows) // for each string array in the csvData.Rows IEnumerable
        {
            var newRowData = new Dictionary<string, object>(); // create a new dictionary that needs a string and an object

            for (int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex) // creating the looping indexer
            {
                var column = csvData.Columns[columnIndex]; // column represents each column in the csvData
                string valueAsString = row[columnIndex]; // valueAsString represents the string array data at the point of columnIndex

                newRowData[column] = valueAsString; // its adding/assigning the newRowData dictionary a key of the columnIndex and its attempting to convert the value of the cell into its proper value type.
            }

            resultRows.Add(newRowData);
        }

        return new FastTableData(csvData.Columns, resultRows);
    }

    private object ConvertValueToTargetType(string value)
    {
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
    }
}

public class FastRow
{
    private Dictionary<string, object> _data;

    public FastRow(Dictionary<string, object> data)
    {
        _data = data;
    }

    public object GetAtColumn(string columnName)
    {
        return _data[columnName];
    }
}

public class FastTableData : ITableData
{
    private readonly List<Dictionary<string, object>> _rows;
    public int RowCount => _rows.Count;
    public IEnumerable<string> Columns { get; }

    public FastTableData(IEnumerable<string> columns, List<Dictionary<string, object>> rows)
    {
        _rows = rows;
        Columns = columns;
    }

    public object GetValue(string columnName, int rowIndex)
    {
        return _rows[rowIndex][columnName];
    }
}