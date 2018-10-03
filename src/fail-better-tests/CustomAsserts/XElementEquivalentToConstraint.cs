using Microsoft.XmlDiffPatch;
using NUnit.Framework.Constraints;
using System.Xml.Linq;

namespace Fail.Better.CustomAsserts
{
    public sealed class XElementEquivalentToConstraint : Constraint
    {
        private readonly XElement _expectedElement;
        private readonly XmlDiff _diff;

        internal XElementEquivalentToConstraint(XElement expectedElement)
        {
            _expectedElement = expectedElement;
            _diff = new XmlDiff(XmlDiffOptions.None);
        }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            var xml = actual as string;
            return null == xml
                ? ApplyTo(actual as XElement)
                : ApplyTo(XElement.Parse(xml));
        }

        private ConstraintResult ApplyTo(XElement actualElement)
        {
            bool isSuccess;

            using (var expected = _expectedElement.CreateReader())
            using (var actual = actualElement.CreateReader())
            {
                isSuccess = _diff.Compare(expected, actual);
            }

            return new XElementEquivalentToConstraintResult(this, _expectedElement, actualElement, isSuccess);
        }
    }
}