using System.Xml.Linq;
using NUnit.Framework.Constraints;

namespace Fail.Better.CustomAsserts
{
    public sealed class XElementEquivalentToConstraintResult : ConstraintResult
    {
        private readonly XElement _expectedElement;

        internal XElementEquivalentToConstraintResult(IConstraint constraint,
            XElement expectedElement,
            XElement actualElement,
            bool isSuccess)
            : base(constraint, actualElement, isSuccess)
        {
            _expectedElement = expectedElement;
        }

        public override void WriteMessageTo(MessageWriter writer)
        {
            const string header = "Xml documents are not equivalent";
            var line = new string('-', header.Length);

            writer.WriteMessageLine(header);
            writer.WriteLine();
            
            writer.WriteMessageLine("Expected:");
            writer.WriteMessageLine(line);
            Write(_expectedElement, writer);
            writer.WriteMessageLine(line);
            writer.WriteLine();

            writer.WriteMessageLine("Actual:");
            writer.WriteMessageLine(line);
            Write(ActualValue as XElement, writer);
            writer.WriteMessageLine(line);
            writer.WriteLine();

            writer.Flush();
        }

        public override void WriteActualValueTo(MessageWriter writer) { }

        private static void Write(XElement element, MessageWriter writer)
        {
            writer.WriteLine(null == element ? "null" : element.ToString());
        }
    }
}