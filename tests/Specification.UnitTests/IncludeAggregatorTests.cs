using Specification.Builder;
using Specification.UnitTests.Entities;
using Xunit;

namespace Specification.UnitTests
{
    public class IncludeAggregatorTests
    {
        [Fact]
        public void IncludeAggregator_AddPropertyNameInConstructor_ReturnsCorrectIncludedString()
        {
            //Arrange
            var expectedString = nameof(Document);

            //Act
            var includeAggregator = new IncludeAggregator(expectedString);

            //Assert
            Assert.Equal(expectedString, includeAggregator.IncludeString);
        }

        [Fact]
        public void IncludeAggregator_AddNullInConstructor_ReturnsStringEmpty()
        {
            //Arrange
            var expectedString = string.Empty;

            //Act
            var includeAggregator = new IncludeAggregator(null);

            //Assert
            Assert.Equal(expectedString, includeAggregator.IncludeString);
        }

        [Fact]
        public void IncludeAggregator_AddEmptyStringInConstructor_ReturnsStringEmpty()
        {
            //Arrange
            var expectedString = string.Empty;

            //Act
            var includeAggregator = new IncludeAggregator("");

            //Assert
            Assert.Equal(expectedString, includeAggregator.IncludeString);
        }

        [Fact]
        public void IncludeAggregator_AddNavigationPropertyName_ReturnsCorrectIncludeString()
        {
            //Arrange
            var expectedString = $"{nameof(Document)}.{nameof(Document.Owner)}.{nameof(Document.Tags)}";

            //Act
            var includeAggregator = new IncludeAggregator(nameof(Document));
            includeAggregator.AddNavigationPropertyName(nameof(Document.Owner));
            includeAggregator.AddNavigationPropertyName(nameof(Document.Tags));

            //Assert
            Assert.Equal(expectedString, includeAggregator.IncludeString);
        }

        [Fact]
        public void IncludeAggregator_AddNavigationPropertyNameAndNullConstructor_ReturnsCorrectIncludeString()
        {
            //Arrange
            var expectedString = $"{nameof(Document)}.{nameof(Document.Owner)}.{nameof(Document.Tags)}";

            //Act
            var includeAggregator = new IncludeAggregator(null);
            includeAggregator.AddNavigationPropertyName(nameof(Document));
            includeAggregator.AddNavigationPropertyName(nameof(Document.Owner));
            includeAggregator.AddNavigationPropertyName(nameof(Document.Tags));

            //Assert
            Assert.Equal(expectedString, includeAggregator.IncludeString);
        }

        [Fact]
        public void IncludeAggregator_AddNavigationPropertyNameAndEmptyConstructor_ReturnsCorrectIncludeString()
        {
            //Arrange
            var expectedString = $"{nameof(Document)}.{nameof(Document.Owner)}.{nameof(Document.Tags)}";

            //Act
            var includeAggregator = new IncludeAggregator(string.Empty);
            includeAggregator.AddNavigationPropertyName(nameof(Document));
            includeAggregator.AddNavigationPropertyName(nameof(Document.Owner));
            includeAggregator.AddNavigationPropertyName(nameof(Document.Tags));

            //Assert
            Assert.Equal(expectedString, includeAggregator.IncludeString);
        }

        [Fact]
        public void IncludeAggregator_AddNullNavigationPropertyName_ReturnsCorrectIncludeString()
        {
            //Arrange
            var expectedString = $"{nameof(Document)}.{nameof(Document.Owner)}.{nameof(Document.Tags)}";

            //Act
            var includeAggregator = new IncludeAggregator(string.Empty);
            includeAggregator.AddNavigationPropertyName(nameof(Document));
            includeAggregator.AddNavigationPropertyName(null);
            includeAggregator.AddNavigationPropertyName(nameof(Document.Owner));
            includeAggregator.AddNavigationPropertyName(nameof(Document.Tags));

            //Assert
            Assert.Equal(expectedString, includeAggregator.IncludeString);
        }

        [Fact]
        public void IncludeAggregator_AddNavigationPropertyNameWithoutSomeProperty_ReturnsInCorrectIncludeString()
        {
            //Arrange
            var expectedString = $"{nameof(Document)}.{nameof(Document.Owner)}.{nameof(Document.Tags)}";

            //Act
            var includeAggregator = new IncludeAggregator(string.Empty);
            includeAggregator.AddNavigationPropertyName(nameof(Document));
            includeAggregator.AddNavigationPropertyName(null);
            includeAggregator.AddNavigationPropertyName(nameof(Document.Owner));

            //Assert
            Assert.NotEqual(expectedString, includeAggregator.IncludeString);
        }
    }
}
