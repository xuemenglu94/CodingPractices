using System;
using System.Collections.Generic;
using System.Text;
using CodingPractices.String;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.String
{
    [TestFixture]
    public class ExcelTableTitleTest
    {
        private ExcelTableTitle _excelTableTitle = new ExcelTableTitle();
        [Test]
        [TestCase(1, "a")]
        [TestCase(28, "ab")]
        [TestCase(-1, null)]
        [TestCase(0, null)]
        [TestCase(704, "aab")]
        public void Should_Return_Correct_Table_Title(int input, string title)
        {
            _excelTableTitle.Get(input).Should().Be(title);
        }
    }
}
