namespace CsvDataAccess.NewSolution;

public class Row
{
    private Dictionary<string, object> _data;

    public Row(Dictionary<string, object> data)
    {
        _data = data;
    }

    public object GetAtColumn(string columnName)
    {
        if (!_data.ContainsKey(columnName))
        {
            return null;
        }

        return _data[columnName];
    }
}