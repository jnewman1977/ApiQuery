using ApiQuery;

string input = "name LIKE \"John\", age >= 30 SORT BY name ASC, age DESC";
Console.WriteLine("Parser Input:");
Console.WriteLine($"\"{input}\"" + Environment.NewLine);

var noSqlQuery = QueryParser.ParseNoSqlQuery(input);
Console.WriteLine("Mongo Query:");
Console.WriteLine($"\"{noSqlQuery}\"" + Environment.NewLine);
