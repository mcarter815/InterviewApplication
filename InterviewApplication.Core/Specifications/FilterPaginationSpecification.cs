using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using Ardalis.Specification;
using InterviewApplication.Core.Entities;
using InterviewApplication.Core.ExtensionMethods;
using Type = InterviewApplication.Core.Entities.Type;

namespace InterviewApplication.Core.Specifications
{
    public sealed class FilterPaginationSpecification : Specification<Dashboard>
    {
        public FilterPaginationSpecification(int skip, int take, string searchText)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                var type = TypeParse(searchText, out var cleanedSearchText);
                var status = StatusParse(cleanedSearchText, out cleanedSearchText);
                var date = DateParse(cleanedSearchText, out cleanedSearchText);
                 

                if (type != 0)
                {
                    Query.Where(x => x.Type == type);
                }

                if (status != 0)
                {
                    Query.Where(x => x.Status == status);
                }

                if (date != null)
                {
                    if (date.Year == 0)
                        Query.Where(x => x.DateCreated.Month == date.Month && x.DateCreated.Day == date.Day);
                    else if (date.Day == 0)
                        Query.Where(x => x.DateCreated.Month == date.Month && x.DateCreated.Year == date.Year);
                    else
                        Query.Where(x =>
                            x.DateCreated.Month == date.Month && x.DateCreated.Day == date.Day &&
                            x.DateCreated.Year == date.Year);
                }

                if (!string.IsNullOrEmpty(cleanedSearchText))
                {
                    Query.Where(x => cleanedSearchText.Contains(x.UserName) || cleanedSearchText.Contains(x.Title));
                }
            }

            Query
                .Skip(skip).Take(take);
        }

        private Type TypeParse(string searchText, out string cleanedText)
        {
            foreach (var type in Enum.GetValues(typeof(Type)).Cast<Type>())
            {
                if (searchText.Contains(type.GetDescription()))
                {
                    cleanedText = searchText.Replace(type.GetDescription(), "");
                    return type;
                }
            }

            cleanedText = searchText;
            return 0;
        }

        private Status StatusParse(string searchText, out string cleanedText)
        {
            foreach (var status in Enum.GetValues(typeof(Status)).Cast<Status>())
            {
                if (searchText.Contains(status.GetDescription()))
                {
                    cleanedText = searchText.Replace(status.GetDescription(), "");
                    return status;
                }
            }

            cleanedText = searchText;
            return 0;
        }

        private BasicDate DateParse(string searchText, out string cleanedText)
        {
            var stringList = searchText.Split(" ").ToList();
            foreach (var elem in stringList)
            {
                var result = Regex.IsMatch(elem, "([0-9])*([0-9])+([/])([0-9])*([0-9])+([/)([0-9])*([0-9])*");
                if (result)
                {
                    cleanedText = searchText.Replace(elem, "");
                    var splitString = elem.Split('/');
                    if (splitString.Length == 3)
                        return new BasicDate(splitString[0], splitString[1], splitString[2]);
                    if (splitString.Length == 2) 
                        return new BasicDate(splitString[0], splitString[1]);
                }
            }

            cleanedText = searchText;
            return null;
        }
    }

    public class BasicDate
    {
        public int Month { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }

        public BasicDate(string month, string day, string year)
        {
            Month = Convert.ToInt32(month);
            Day = Convert.ToInt32(day);
            Year = Convert.ToInt32(year);
        }

        public BasicDate(string month, string dayOrYear)
        {
            Month = Convert.ToInt32(month);
            if (dayOrYear.Length == 4)
            {
                Year = Convert.ToInt32(dayOrYear);
                Day = 0;
            }
            else
            {
                Year = 0;
                Day = Convert.ToInt32(dayOrYear);
            }
        }
    }
}
