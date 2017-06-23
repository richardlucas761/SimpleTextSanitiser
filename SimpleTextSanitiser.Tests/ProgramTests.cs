using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleTextSanitiser.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void SanitiseInputEmptyString()
        {
            // Arrange
            var program = new Program();

            // Act
            var result = program.SanitiseInput("");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void SanitiseInputNull()
        {
            // Arrange
            var program = new Program();

            // Act
            var result = program.SanitiseInput(null);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void SanitiseInputNormalScriptTags()
        {
            // Arrange
            var program = new Program();

            // Act
            var result = program.SanitiseInput("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor <script>alert('Hello!');</script> incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", result);
        }

        [TestMethod]
        public void SanitiseInputScriptTagsSpecifyScriptLanguage()
        {
            // Arrange
            var program = new Program();

            // Act
            var result = program.SanitiseInput("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor <script type='text/javascript'>alert('Hello!');</script> incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", result);
        }
    }
}
