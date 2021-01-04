using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using InterviewApplication.Core.Entities;
using InterviewApplication.Core.Specifications;
using Xunit;

namespace InterviewApplication.Tests
{
    public class FilterPaginationSpecificationUnitTests
    {
        [Theory]
        [InlineData(0, 3, "December's auditing", 1)]
        [InlineData(0, 3, "user10@gmail.com", 1)]
        [InlineData(0, 3, "State Report", 1)]
        [InlineData(0, 3, "Audit Report", 1)]
        [InlineData(0, 3, "12/13", 1)]
        [InlineData(0, 3, "12/2019", 2)]
        [InlineData(0, 3, "12/13/2019", 1)]
        public void Should_ReturnExpectNumberOfValues_When_SpecificFilterPassedIn(int skip, int take, string searchText, int expectedCount)
        {
            //Arrange
            var spec = new FilterPaginationSpecification(skip, take, searchText);

            //Act
            var result = GetTestItemCollection()
                .AsQueryable()
                .Where(spec.WhereExpressions.FirstOrDefault());

            //Assert
            result.Should().HaveCount(expectedCount);
        }

        public List<Dashboard> GetTestItemCollection()
        {
            return new List<Dashboard>
            {
                new Dashboard{DateCreated = DateTime.Parse("2019-12-13 03:49:55.210"), UserName = "user10@gmail.com", Id = Guid.Parse("1C1BFB09-F68B-4CBE-846D-000330A3266B"), Status = (Status)2, Type = (Core.Entities.Type)3, Title = "December's auditing"},
                new Dashboard{DateCreated = DateTime.Parse("2019-12-08 16:45:45.453"), UserName = "user7@gmail.com", Id = Guid.Parse("E40C8CF0-7BEC-4B11-89E6-000638F138BD"), Status = (Status)3, Type = (Core.Entities.Type)1, Title = "May's info add"},
                new Dashboard{DateCreated = DateTime.Parse("2020-02-11 05:50:58.443"), UserName = "user12@gmail.com", Id = Guid.Parse("77326DC4-5115-4E7B-A58C-0014034D2816"), Status = (Status)1, Type = (Core.Entities.Type)2, Title = "February's monthly output"},
            };
        }
    }
}
