namespace ApiQuery.Strategies;

using ApiQuery.Model;

public class NoSqlQueryStrategy : IQueryStrategy
{
    public string BuildQuery(List<Filter> filters, List<Sort> sorts)
    {
        var query = "{ $and: [";
        var conditions = new List<string>();

        foreach (var filter in filters)
        {
            conditions.Add($"{{ {filter.Field}: {{ {filter.Operator}: '{filter.Value}' }} }}");
        }

        query += string.Join(", ", conditions) + "] }";

        if (sorts.Any())
        {
            var sortConditions = new List<string>();
            foreach (var sort in sorts)
            {
                int direction = sort.Direction == "DESC" ? -1 : 1;
                sortConditions.Add($"{{ {sort.Field}: {direction} }}");
            }
            query += ", $sort: { " + string.Join(", ", sortConditions) + " }";
        }

        return query;
    }
}