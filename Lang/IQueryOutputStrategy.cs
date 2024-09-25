namespace ApiQuery.Lang;

using ApiQuery.Model;

public interface IQueryOutputStrategy
{
    string BuildQuery(List<Filter> filters, List<Sort> sorts);
}