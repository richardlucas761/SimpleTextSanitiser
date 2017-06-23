using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleTextSanitiser.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void SanitiseInputEmptyString()
        {
            // Act
            var result = Program.SanitiseInput(new StringBuilder(""));

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SanitiseInputNull()
        {
            // Act
            Program.SanitiseInput(null);
        }

        [TestMethod]
        public void SanitiseInputNormalScriptTags()
        {
            // Act
            var result = Program.SanitiseInput(new StringBuilder("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor <script>alert('Hello!');</script> incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."));

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor  incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", result);
        }

        [TestMethod]
        public void SanitiseInputScriptTagsSpecifyScriptLanguage()
        {
            // Act
            var result = Program.SanitiseInput(new StringBuilder("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor <script type='text/javascript'>alert('Hello again!');</script> incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."));

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor  incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", result);
        }
    }
}
