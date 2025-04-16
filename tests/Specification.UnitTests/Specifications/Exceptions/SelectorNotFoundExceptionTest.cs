using System;
using Specification.Exceptions;
using Xunit;

namespace Specification.UnitTests.Specifications.Exceptions
{
    public class SelectorNotFoundExceptionTest
    {
        [Fact]
        public void Constructor_Default_ShouldSetMessage()
        {
            // Act
            var exception = new SelectorNotFoundException();

            // Assert
            Assert.Equal("The specification must have Selector defined.", exception.Message);
        }

        [Fact]
        public void Constructor_WithInnerException_ShouldSetMessageAndInnerException()
        {
            // Arrange
            var innerException = new Exception("Inner exception");

            // Act
            var exception = new SelectorNotFoundException(innerException);

            // Assert
            Assert.Equal("The specification must have Selector defined.", exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }

        [Fact]
        public void Constructor_WithSpecificationName_ShouldFormatMessage()
        {
            // Arrange
            var specificationName = "TestSpecification";

            // Act
            var exception = new SelectorNotFoundException(specificationName);

            // Assert
            Assert.Equal("The specification must have Selector defined. Specification: TestSpecification", exception.Message);
        }

        [Fact]
        public void Constructor_WithSpecificationNameAndInnerException_ShouldFormatMessageAndSetInnerException()
        {
            // Arrange
            var specificationName = "TestSpecification";
            var innerException = new Exception("Inner exception");

            // Act
            var exception = new SelectorNotFoundException(specificationName, innerException);

            // Assert
            Assert.Equal("The specification must have Selector defined. Specification: TestSpecification", exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }
    }
}