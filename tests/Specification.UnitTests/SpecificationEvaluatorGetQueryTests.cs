using Specification.Exceptions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Specification.UnitTests
{
    public class SpecificationEvaluatorGetQueryTests
    {
        private readonly int _testId = 125;

        private class TestItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Active { get; set; }
        }

        private class ItemWithIdSpecification : Specification<TestItem>
        {
            public ItemWithIdSpecification(int id)
            {
                Query.Where(x => x.Id == id);
            }
        }
        private class ItemWithIdSpecificationAndOrderBy : Specification<TestItem>
        {
            public ItemWithIdSpecificationAndOrderBy()
            {
                Query.OrderBy(x => x.Id);
            }
        }

        private class ItemWithIdSpecificationAndTwoOrderBy : Specification<TestItem>
        {
            public ItemWithIdSpecificationAndTwoOrderBy()
            {
                Query.OrderBy(x => x.Id);
                Query.OrderBy(x => x.Name);
            }
        }

        private class ItemWithIdSpecificationAndOrderByDescending : Specification<TestItem>
        {
            public ItemWithIdSpecificationAndOrderByDescending()
            {
                Query.OrderByDescending(x => x.Id);
            }
        }
        private class ItemWithIdSpecificationAndThenBy : Specification<TestItem>
        {
            public ItemWithIdSpecificationAndThenBy()
            {
                Query.OrderBy(x => x.Name).ThenBy(x => x.Id);
            }
        }

        private class ItemWithIdSpecificationAndThenByDescending : Specification<TestItem>
        {
            public ItemWithIdSpecificationAndThenByDescending()
            {
                Query.OrderBy(x => x.Active).ThenByDescending(x => x.Name);
            }
        }

        private class ItemWithIdSpecificationAndTakeSomeData : Specification<TestItem>
        {
            public ItemWithIdSpecificationAndTakeSomeData()
            {
                Query.Where(x => x.Active == false).Take(2);
            }
        }

        private class ItemWithIdSpecificationAndSkipSomeData : Specification<TestItem>
        {
            public ItemWithIdSpecificationAndSkipSomeData()
            {
                Query.Where(x => x.Active == true).Skip(2);

            }
        }


        [Fact]
        public void ReturnsEntityWithId()
        {
            //Arrange
            var specification = new ItemWithIdSpecification(_testId);
            var evaluator = new SpecificationEvaluator<TestItem>();

            //Act
            var result = evaluator.GetQuery(GetTestListOfItems().AsQueryable(), specification).FirstOrDefault();

            //Assert
            Assert.Equal(_testId, result?.Id);
        }

        [Fact]
        public void ReturnsEntityOrderById()
        {
            //Arrange 
            var specification = new ItemWithIdSpecificationAndOrderBy();
            var evaluator = new SpecificationEvaluator<TestItem>();

            //Act
            var result = evaluator.GetQuery(GetTestListOfItems().AsQueryable(), specification).FirstOrDefault();

            //Assert
            Assert.Equal(0, result.Id);
        }

        [Fact]
        public void ReturnsEntityOrderByDescending()
        {
            //Arrange 
            var specification = new ItemWithIdSpecificationAndOrderByDescending();
            var evaluator = new SpecificationEvaluator<TestItem>();

            //Act
            var result = evaluator.GetQuery(GetTestListOfItems().AsQueryable(), specification).FirstOrDefault();

            //Assert
            Assert.Equal(_testId, result.Id);
        }

        [Fact]
        public void ReturnsEntityThenBy()
        {
            //Arrange 
            var expected = new TestItem
            {
                Id = 10,
                Name = "Apple",
                Active = false
            };
            var specification = new ItemWithIdSpecificationAndThenBy();
            var evaluator = new SpecificationEvaluator<TestItem>();

            //Act
            var result = evaluator.GetQuery(GetTestListOfItems().AsQueryable(), specification).ToList();

            //Assert
            Assert.Equal(expected.Id, result.FirstOrDefault().Id);
            Assert.Equal(expected.Name, result.FirstOrDefault().Name);
            Assert.Equal(expected.Active, result.FirstOrDefault().Active);
        }

        [Fact]
        public void ReturnsEntityThenByDescending()
        {
            //Arrange 
            var specification = new ItemWithIdSpecificationAndThenByDescending();
            var evaluator = new SpecificationEvaluator<TestItem>();

            //Act
            var result = evaluator.GetQuery(GetTestListOfItems().AsQueryable(), specification).ToList();

            //Assert
            Assert.Equal("PassionFruit", result.FirstOrDefault().Name);
        }


        [Fact]
        public void ReturnsEntitiesTakingJustTwoElements()
        {
            //Arrange 
            var specification = new ItemWithIdSpecificationAndTakeSomeData();
            var evaluator = new SpecificationEvaluator<TestItem>();

            //Act
            var result = evaluator.GetQuery(GetTestListOfItems().AsQueryable(), specification).ToList();

            //Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void ReturnsEntitiesSkippingTwoElements()
        {
            //Arrange 
            var specification = new ItemWithIdSpecificationAndSkipSomeData();
            var evaluator = new SpecificationEvaluator<TestItem>();

            //Act
            var result = evaluator.GetQuery(GetTestListOfItems().AsQueryable(), specification).ToList();

            //Assert
            Assert.Single(result);
        }

        [Fact]
        public void ReturnDuplicationOrderChainExceptionWithTwoOrderBy()
        {
            //Arrange 
            var specification = new ItemWithIdSpecificationAndTwoOrderBy();
            var evaluator = new SpecificationEvaluator<TestItem>();

            //Act
            //var result = evaluator.GetQuery(GetTestListOfItems().AsQueryable(), specification).ToList();
            var exeption = Assert.Throws<DuplicateOrderChainException>(() =>
                evaluator.GetQuery(GetTestListOfItems().AsQueryable(), specification));

            //Assert
            //Assert.Single(result);
            Assert.Contains("The specification contains more than one Order chain!", exeption.Message);
        }

        private IEnumerable<TestItem> GetTestListOfItems()
        {
            return new List<TestItem>
            {
                new TestItem{ Id = 1, Name =  "Grape", Active = false},
                new TestItem{ Id = 2, Name =  "PassionFruit", Active = false},
                new TestItem{ Id = _testId, Name =  "Banana", Active = false},
                new TestItem{ Id = 8, Name =  "Mango", Active = true},
                new TestItem{ Id = 4, Name =  "Orange", Active = false},
                new TestItem{ Id = 0, Name =  "Banana", Active = true},
                new TestItem{ Id = 12, Name =  "Raspberry", Active = true},
                new TestItem{ Id = 10, Name =  "Apple", Active = false},
                new TestItem{ Id = 9, Name =  "Blueberry", Active = false}
            };
        }
    }
}
