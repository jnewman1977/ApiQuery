namespace ApiQuery;

using Antlr4.Runtime;
using ApiQuery.Strategies;
using ApiQuery.Visitors;

public partial class QueryParser
{
    public static string ParseNoSqlQuery(string input)
    {
        var inputStream = new AntlrInputStream(input);
        var lexer = new QueryLexer(inputStream);
        var commonTokenStream = new CommonTokenStream(lexer);
        var parser = new QueryParser(commonTokenStream);
        QueryContext? context = parser.query();

        var visitor = new QueryVisitor();
        visitor.Visit(context);

        var strategy = new NoSqlQueryStrategy();
        return strategy.BuildQuery(visitor.Filters, visitor.Sorts);
    }
}
