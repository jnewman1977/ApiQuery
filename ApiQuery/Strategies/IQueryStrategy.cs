namespace ApiQuery.Strategies;

using ApiQuery.Model;

public interface IQueryStrategy
{
    string BuildQuery(List<Filter> filters, List<Sort> sorts);
}