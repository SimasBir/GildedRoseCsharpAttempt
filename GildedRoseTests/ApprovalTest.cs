
using FluentAssertions;
using GildedRoseKata;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using VerifyXunit;

using Xunit;

namespace GildedRoseTests
{
    [UsesVerify]
    public class ApprovalTest
    {
        [Fact]
        public void ThirtyDays()
        {
            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            var output = fakeoutput.ToString();
            File.WriteAllText("Output.txt", output);

            var processedTransactions = File.ReadAllLines("VerifiedContent.txt");
            var sampleTransactions = File.ReadAllLines("Output.txt");

            for (int i = 0; i < processedTransactions.Length; i++)
            {
                processedTransactions[i].Should().Be(sampleTransactions[i]);
            }

            //return Verifier.Verify(output);
        }
    }
}