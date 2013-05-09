using System;
using System.IO;
using System.Text;
using GildedRose;
using NUnit.Framework;


namespace GildedRoseTests
{
	[TestFixture]
	public class ApprovalTest
	{
		[Test]
		public void ThirtyDays()
		{
            var outputLocation = @"C:\gildedrose\GildedRose-XPMan\Output";
            FileStream fs = new FileStream(string.Concat(outputLocation, @"\Output.txt"), FileMode.Create);
            TextWriter tmp = Console.Out;

            StreamWriter sw = new StreamWriter(fs);
            Console.SetOut(sw);

			Program.Main(new string[] { });

            sw.Close();

		    var output = File.ReadAllText(string.Concat(outputLocation, @"\Output.txt"));
            var goldenMasterOutput = File.ReadAllText(string.Concat(outputLocation, @"\GoldenMaster.txt")); ;
		    Assert.That(output, Is.EqualTo(goldenMasterOutput));
		}
	}
	
}