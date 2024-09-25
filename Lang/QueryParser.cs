namespace ApiQuery.Lang;

using Antlr4.Runtime;

public partial class QueryParser
{
    public static string ParseQuery<T>(string input)
        where T : class, IQueryStrategy, new()
    {
        var inputStream = new AntlrInputStream(input);
        var lexer = new QueryLexer(inputStream);
        var commonTokenStream = new CommonTokenStream(lexer);
        var parser = new QueryParser(commonTokenStream);
        QueryContext? context = parser.query();

        var visitor = new QueryVisitor();
        visitor.Visit(context);

        var strategy = new T();
        return strategy.BuildQuery(visitor.Filters, visitor.Sorts);
    }
}
