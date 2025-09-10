using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;
using CsvDataAccess.OldSolution;

namespace CsvDataAccess.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
   public ITableData Build(CsvData csvData)
    {
        

        return new TableData(csvData.Columns, resultRows);
    }
}
