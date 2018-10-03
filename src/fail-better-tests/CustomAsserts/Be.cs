using System.Xml.Linq;
using NUnit.Framework.Constraints;

namespace Fail.Better.CustomAsserts
{
    public static class Be
    {
        public static class Xml
        {
            public static IResolveConstraint EquivalentTo(string expectedXml)
            {
                return new XElementEquivalentToConstraint(XElement.Parse(expectedXml));
            }
        }
    }
}
