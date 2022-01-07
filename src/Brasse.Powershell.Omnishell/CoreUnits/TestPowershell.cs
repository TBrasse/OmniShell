using NUnit.Framework;

namespace Omnishell.Core.Units
{
    public class TestPowershell
    {
        [Test]
        public void ShouldExecuteSingleExpression()
        {
            var powershell = new Powershell();

            var resultCollection = powershell.Execute("switch($true) { $true {'true'} default {'default'}}");

            var result = string.Join("", resultCollection);
            Assert.That(result, Is.EqualTo("true"));
        }

        [Test]
        public void ShouldExecuteMultipleExpressions()
        {
            var powershell = new Powershell();

            var resultCollection = powershell.Execute(new[]
            {
                @"$test = $true",
                @"$value = switch($test) { $true {'is'} default {'is not'}}",
                @"echo ""test $value true"""
            });

            var result = string.Join("", resultCollection);
            Assert.That(result, Is.EqualTo("test is true"));
        }

        [Test]
        public void ShouldReturnError()
        {
            var powershell = new Powershell();

            var resultCollection = powershell.Execute(new[]
            {
                @"throw TestError;echo Test"
            });

            var result = string.Join("", resultCollection);
            Assert.That(result, Is.Not.EqualTo("Test"));

            //Assert.Fail("Create test that check for error in Powershell.Execute");
        }
    }
}