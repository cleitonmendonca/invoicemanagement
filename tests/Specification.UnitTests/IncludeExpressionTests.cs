using Specification.UnitTests.Entities;
using Specification.UnitTests.Specifications;
using System.Linq;
using Xunit;

namespace Specification.UnitTests
{
    public class IncludeExpressionTests
    {
        [Fact]
        public void ShouldGetCorrectPropertyName_ForExpressionWithSimpleType()
        {
            //Arrange
            var spec = new DocumentIncludeNameSpec();

            //Act
            var expected = nameof(Document.Name);
            var actual = spec.IncludeAggregators.FirstOrDefault()?.IncludeString;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldGetCorrectPropertyName_ForExpressionWithReferenceType()
        {
            //Arrange
            var spec = new DocumentIncludeOwnerSpec();

            //Act
            var expected = nameof(Document.Owner);
            var actual = spec.IncludeAggregators.FirstOrDefault()?.IncludeString;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldGetCorrectPropertyName_ForExpressionWithCollection()
        {
            //Arrange
            var spec = new DocumentIncludeTagsSpec();

            //Act
            var expected = nameof(Document.Tags);
            var actual = spec.IncludeAggregators.FirstOrDefault()?.IncludeString;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldGetEmptyString_ForExpressionWithDotAppendedNavigations()
        {
            //Arrange
            var spec = new DocumentIncludeMethodSpec();

            //Act
            var expected = string.Empty;
            var actual = spec.IncludeAggregators.FirstOrDefault().IncludeString;

            //Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void ShouldGetEmptyString_ForExpressionWithMethod()
        {
            var spec = new DocumentIncludeMethodSpec();

            var expeted = string.Empty;
            var actual = spec.IncludeAggregators.FirstOrDefault().IncludeString;

            Assert.Equal(expeted, actual);
        }

        [Fact]
        public void ShouldGetEmptyString_ForExpressionWithMethodOfNavigation()
        {
            var spec = new DocumentIncludeMethodOfNavigationSpec();

            var expeted = string.Empty;
            var actual = spec.IncludeAggregators.FirstOrDefault().IncludeString;

            Assert.Equal(expeted, actual);
        }

        [Fact]
        public void ShouldGetEmptyString_ForFaultyIncludeExpressions()
        {
            var spec = new DocumentWithFaultyIncludeSpec();

            var expeted = string.Empty;
            var actual = spec.IncludeAggregators.FirstOrDefault().IncludeString;

            Assert.Equal(expeted, actual);
        }
    }
}