using ApiQuery.Lang;
using ApiQuery.NoSql;

const string input = "name LIKE \"John\", age >= 30 SORT BY name ASC, age DESC";
Console.WriteLine("Parser Input:");
Console.WriteLine($"\"{input}\"" + Environment.NewLine);

string noSqlQuery = QueryParser.ParseQuery<NoSqlQueryStrategy>(input);
Console.WriteLine("Mongo Query:");
Console.WriteLine($"\"{noSqlQuery}\"" + Environment.NewLine);
