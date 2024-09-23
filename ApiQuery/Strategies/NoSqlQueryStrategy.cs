namespace ApiQuery.Strategies;

using ApiQuery.Model;
using MongoDB.Bson;
using MongoDB.Driver;

public class NoSqlQueryStrategy : IQueryStrategy
{
    public string BuildQuery(List<Filter> filters, List<Sort> sorts)
    {
        FilterDefinitionBuilder<BsonDocument>? filterBuilder = Builders<BsonDocument>.Filter;
        var filterConditions = new List<FilterDefinition<BsonDocument>>();

        foreach (var filterItem in filters)
        {
            FilterDefinition<BsonDocument>? condition = filterBuilder.Eq(filterItem.Field, filterItem.Value);
            filterConditions.Add(condition);
        }

        FilterDefinition<BsonDocument>? filter = filterBuilder.And(filterConditions);

        SortDefinitionBuilder<BsonDocument>? sortBuilder = Builders<BsonDocument>.Sort;
        var sortConditions = new List<SortDefinition<BsonDocument>>();

        foreach (Sort sortItem in sorts)
        {
            SortDefinition<BsonDocument>? sortCondition = sortBuilder.Combine(
                sortBuilder.MetaTextScore(sortItem.Field),
                sortItem.Direction == "DESC"
                    ? sortBuilder.MetaSearchScoreDescending()
                    : sortBuilder.MetaSearchScoreAscending());

            sortConditions.Add(sortCondition);
        }

        SortDefinition<BsonDocument>? sort = sortBuilder.Combine(sortConditions);

        // Here you would use the filter and sort with a MongoDB query
        // Example:
        // var collection = database.GetCollection<BsonDocument>("collectionName");
        // var result = collection.Find(filter).Sort(sort).ToList();

        // For demonstration purposes, returning the filter and sort as JSON
        return filter.ToJson() + ", " + sort.ToJson(); 
    }
}
