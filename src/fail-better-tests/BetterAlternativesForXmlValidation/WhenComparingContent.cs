using System;
using System.Xml.Linq;
using Fail.Better.CustomAsserts;
using Microsoft.XmlDiffPatch;
using NUnit.Framework;

namespace Fail.Better.BetterAlternativesForXmlValidation
{
    [TestFixture]
    public sealed class WhenComparingContent
    {
        private const string XML = @"<?xml version='1.0'?>
<albums>
    <album title='Purple Rain' />
</albums>";

        [Test]
        public void Example_1()
        {
            /* We should know by now that Assert.True shouldn't be abused. */
            Assert.True(XML.Contains(@"<album title=""Purple Rain""/>"));
        }

        [Test]
        public void Example_2()
        {
            /*
             This isn't so good either because:
                1. We're comparing strings when we should be concerned with xml.
                2. What about the rest of the document? We don't event know it's valid xml.
             */
            Assert.That(XML, Does.Contain(@"<album title=""Purple Rain""/>"));
        }

        [Test]
        public void Example_3()
        {
            /*
             This also sucks because: 
                1. Both ' and "" around attribute values is valid xml.
                2. Did you notice the elusive line break at the end here?"
                3. Don't get me started on the console output :)
            */
            Assert.That(XML, Is.EqualTo(@"<?xml version='1.0'?>
<albums>
    <album title='Purple Rain' />
</albums>
"));
        }

        [Test]
        public void Example_4()
        {
            /*
             And what about this? It's valid xml too.
             We could go on an on :)
             */
            Assert.That(XML, Is.EqualTo(@"<?xml version='1.0'?><albums><album title='Purple Rain' /></albums>"));
        }

        [Test]
        public void Example_5()
        {
            /*
             Here's an example that uses XMLDiffPatch. 
             Now we're finally comparing xml :)
             but the readability is... <insert adjective here> :/
             And we're back to Assert.True :(
             */

            const string actualXml = @"<?xml version='1.0'?><albums><album title='Purple Train' /></albums>";
            var diff = new XmlDiff(XmlDiffOptions.None);
            using (var expected = XElement.Parse(XML).CreateReader())
            using (var actual = XElement.Parse(actualXml).CreateReader())
            {
                Assert.True(diff.Compare(expected, actual));
            }
        }

        [Test]
        public void Example_6()
        {
            /*
             Now we're getting somewhere.
             We have built a custom constraint.
             The test is readable and the custom constrains
             writes something that makes sense to the console.
             */

            const string actualXml = @"<?xml version='1.0'?><albums><album title='Purple Train' /></albums>";
            Assert.That(actualXml, Be.Xml.EquivalentTo(XML));
        }
    }
}
