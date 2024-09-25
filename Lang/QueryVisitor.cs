namespace ApiQuery.Lang;

using Antlr4.Runtime.Misc;
using ApiQuery.Model;

public class QueryVisitor : QueryBaseVisitor<object>
{
    public List<Filter> Filters { get; } = new List<Filter>();
    public List<Sort> Sorts { get; } = new List<Sort>();

    public override object VisitExpression([NotNull] QueryParser.ExpressionContext context)
    {
        string? field = context.field().GetText();
        string? op = context.@operator().GetText();
        string value = context.value().GetText().Trim('"');

        this.Filters.Add(new Filter { Field = field, Operator = op, Value = value });
        return base.VisitExpression(context);
    }

    public override object VisitSort([NotNull] QueryParser.SortContext context)
    {
        foreach (var sortFieldContext in context.sortField())
        {
            string field = sortFieldContext.field().GetText();
            string direction = sortFieldContext.GetText().Contains("DESC") ? "DESC" : "ASC";
            this.Sorts.Add(new Sort { Field = field, Direction = direction });
        }
        return base.VisitSort(context);
    }
}