namespace ApiQuery.Lang;

using ApiQuery.Model;

public interface IQueryStrategy
{
    string BuildQuery(List<Filter> filters, List<Sort> sorts);
}