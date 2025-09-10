namespace CsvDataAccess.NewSolution;

public class FastRow
{
    private Dictionary<string, string> _stringData = new();
    private Dictionary<string, int> _intData = new();
    private Dictionary<string, decimal> _decimalData = new();
    private Dictionary<string, bool> _boolData = new();

    public void AssignCell<T>(string columnName, T value)
{
    if (value is bool b)
        _boolData[columnName] = b;
    else if (value is int i)
        _intData[columnName] = i;
    else if (value is decimal d)
        _decimalData[columnName] = d;
    else if (value is string s)
        _stringData[columnName] = s;
    else
        throw new ArgumentException($"Unsupported type {typeof(T).Name}");
}

    public object GetAtColumn(string columnName)
    {
        if (_intData.ContainsKey(columnName))
        {
            return _intData[columnName];
        }
        if (_decimalData.ContainsKey(columnName))
        {
            return _decimalData[columnName];
        }
        if (_stringData.ContainsKey(columnName))
        {
            return _stringData[columnName];
        }
        if (_boolData.ContainsKey(columnName))
        {
            return _boolData[columnName];
        }
        return null;
    }
}
