using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicApp.API.Helpers
{
    public static class OrderByQueryParser<TModel> where TModel : class
    {
        public static IEnumerable<TModel> Parse(string orderBy)
        {
            List<TModel> returnList = new List<TModel>();
            if (!string.IsNullOrEmpty(orderBy))
            {
                List<string> orderByFields = orderBy.Split(',').Select(p => p.Trim()).ToList();
                foreach (var orderByField in orderByFields)
                {
                    var field = "";
                    var sortType = "asc";

                    if (!string.IsNullOrWhiteSpace(orderByField))
                    {
                        if (orderByField.Length > 1 && ((orderByField[0] == '+') || (orderByField[0] == '-')))
                        {
                            field = orderByField.Substring(1);
                            if (orderByField[0] == '-')
                                sortType = "desc";
                        }
                        else
                            field = orderByField;

                        Type type = typeof(TModel);

                        var propertyOrderBy = type.GetProperty(field);
                        var propertyOrderType = type.GetProperty("OrderType");
                        if (propertyOrderBy != null && propertyOrderType != null)
                        {
                            var o = Activator.CreateInstance<TModel>();
                            propertyOrderBy.SetValue(o, true);
                            propertyOrderType.SetValue(o, sortType);
                            returnList.Add(o);
                        }
                    }
                }
            }
            return returnList;
        }
    }
}
