using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.WootzJs;
using System.Threading.Tasks;
using System.Linq;
using WootzJs.Web;

namespace WootzJs.Testing
{
    public class UnitTester
    {
        private List<UnitTest> unitTests = new List<UnitTest>();
        private HashSet<UnitTest> outstandingTests;
        private Element table;
        private Dictionary<Type, Element> fixtureRows = new Dictionary<Type, Element>();
        private Dictionary<MethodInfo, Element> testRows = new Dictionary<MethodInfo, Element>();
        private Element header;

        public UnitTester()
        {
            var nameHeader = CreateHeaderCell("Name");
            var passedHeader = CreateHeaderCell("Passed");
            var failedHeader = CreateHeaderCell("Failed");
            var erroredHeader = CreateHeaderCell("Errored");

            header = Browser.Document.CreateElement("tr");
            header.AppendChild(nameHeader);
            header.AppendChild(passedHeader);
            header.AppendChild(failedHeader);
            header.AppendChild(erroredHeader);

            table = Browser.Document.CreateElement("table");
            table.Style.Width = "100%";
            table.AppendChild(header);

            Browser.Document.Body.AppendChild(table);
        }

        private Element CreateHeaderCell(string text)
        {
            var div = Browser.Document.CreateElement("div");
            div.AppendChild(Browser.Document.CreateTextNode(text));
            div.Style.Padding = "3px";

            var result = Browser.Document.CreateElement("th");
            result.AppendChild(div);
            result.Style.TextAlign = "left";
            result.Style.BackgroundColor = "#CCCCFF";
            return result;
        }

        private Element CreateDataCell(string text = null)
        {
            var div = Browser.Document.CreateElement("div");
            if (text != null)
                div.AppendChild(Browser.Document.CreateTextNode(text));
            div.Style.Padding = "3px";

            var result = Browser.Document.CreateElement("td");
            result.AppendChild(div);

            return result;
        }

        private Element CreateFixtureDataCell(string text = null)
        {
            var result = CreateDataCell(text);
            result.Style.BackgroundColor = "#DDDDFF";
            return result;
        }

        public void QueueTest(TestFixture instance, MethodInfo method)
        {
            var unitTest = new UnitTest
            {
                Instance = instance,
                Method = method
            };
            unitTests.Add(unitTest);
            instance.SetUnitTest(unitTest);

            Element fixtureRow;
            if (!fixtureRows.TryGetValue(instance.GetType(), out fixtureRow))
            {
                var nameCell = CreateFixtureDataCell(instance.GetType().FullName);

                var passedCell = CreateFixtureDataCell();
                var failedCell = CreateFixtureDataCell();
                var erroredCell = CreateFixtureDataCell();

                fixtureRow = Browser.Document.CreateElement("tr");
                fixtureRow.AppendChild(nameCell);
                fixtureRow.AppendChild(passedCell);
                fixtureRow.AppendChild(failedCell);
                fixtureRow.AppendChild(erroredCell);
                table.AppendChild(fixtureRow);

                fixtureRows[instance.GetType()] = fixtureRow;
            }

            var testNameCell = CreateDataCell(unitTest.Method.Name);

            var testPassedCell = CreateDataCell();
            var testFailedCell = CreateDataCell();
            var testErroredCell = CreateDataCell();

            var testRow = Browser.Document.CreateElement("tr");
            testRow.AppendChild(testNameCell);
            testRow.AppendChild(testPassedCell);
            testRow.AppendChild(testFailedCell);
            testRow.AppendChild(testErroredCell);
            testRows[unitTest.Method] = testRow;

            table.AppendChild(testRow);
        }

        public void RunTests()
        {
            outstandingTests = new HashSet<UnitTest>(unitTests);
            foreach (var test in unitTests)
            {
                RunTest(test);
            }
        }

        public async void RunTest(UnitTest test)
        {
            try
            {
                var result = test.Method.Invoke(test.Instance, new object[0]);
                if (test.Method.ReturnType != typeof(void) && typeof(Task).IsAssignableFrom(test.Method.ReturnType))
                {
                    var task = (Task)result;
                    await task;
                }                
            }
            catch (Exception e)
            {
//                Console.WriteLine(e);
            }

            ReportTest(test);
        } 

        private void ReportTest(UnitTest test)
        {
            Console.WriteLine(test.Method);
            var passed = test.Assertions.Where(x => x.Status == AssertionStatus.Passed).ToArray();
            var failed = test.Assertions.Where(x => x.Status == AssertionStatus.Failed).ToArray();
            var errored = test.Assertions.Where(x => x.Status == AssertionStatus.Errored).ToArray();
            Console.WriteLine("Passed: " + passed.Length + ", Failed: " + failed.Length + ", Errored: " + errored.Length);

            var testRow = testRows[test.Method];
            testRow.Children[1].Children[0].AppendChild(Browser.Document.CreateTextNode(passed.Length.ToString()));
            testRow.Children[2].Children[0].AppendChild(Browser.Document.CreateTextNode(failed.Length.ToString()));
            testRow.Children[3].Children[0].AppendChild(Browser.Document.CreateTextNode(errored.Length.ToString()));

            outstandingTests.Remove(test);

            if (failed.Any() || errored.Any())
            {
                for (var i = 0; i < testRow.Children.Length; i++)
                {
                    testRow.Children[i].Style.BackgroundColor = "red";
                }
            }
            if (!outstandingTests.Any(x => x.Instance.GetType().FullName == test.Instance.GetType().FullName))
            {
                var fixtureTestAssertions = unitTests.Where(x => x.Instance.GetType().FullName == test.Instance.GetType().FullName).SelectMany(x => x.Assertions).ToArray();
                var fixturePassedCount = fixtureTestAssertions.Count(x => x.Status == AssertionStatus.Passed);
                var fixtureFailedCount = fixtureTestAssertions.Count(x => x.Status == AssertionStatus.Failed);
                var fixtureErroredCount = fixtureTestAssertions.Count(x => x.Status == AssertionStatus.Errored);

                var fixtureRow = fixtureRows[test.Instance.GetType()];
                fixtureRow.Children[1].Children[0].AppendChild(Browser.Document.CreateTextNode(fixturePassedCount.ToString()));
                fixtureRow.Children[2].Children[0].AppendChild(Browser.Document.CreateTextNode(fixtureFailedCount.ToString()));
                fixtureRow.Children[3].Children[0].AppendChild(Browser.Document.CreateTextNode(fixtureErroredCount.ToString()));
            }

            if (!outstandingTests.Any())
                Finished();
        }

        private void Finished()
        {
            var passed = unitTests.Where(x => x.Assertions.All(y => y.Status == AssertionStatus.Passed) && x.Assertions.Any());
            var empty = unitTests.Where(x => !x.Assertions.Any());
            var failed = unitTests.Where(x => x.Assertions.Any(y => y.Status == AssertionStatus.Failed));
            var errored = unitTests.Where(x => x.Assertions.Any(y => y.Status == AssertionStatus.Errored));

            Console.WriteLine("Finished.");
            Console.WriteLine(passed.Count() + " passed.");
            Console.WriteLine(empty.Count() + " failed to make any assertions.");
            Console.WriteLine(failed.Count() + " had one or more assertions fail.");
            Console.WriteLine(errored.Count() + " threw an unhandled exception.");

            if (failed.Any() || errored.Any())
            {
                for (var i = 0; i < header.Children.Length; i++)
                {
                    header.Children[i].Style.BackgroundColor = "red";
                }
            }

            if (empty.Any())
            {
                Console.WriteLine("No Assertions:");
                foreach (var test in empty)
                {
                    Console.WriteLine(test.Method);
                }
            }
            if (failed.Any() || errored.Any())
            {
                Console.WriteLine("Failures:");
                foreach (var test in failed)
                {
                    Console.WriteLine(test.Method);
                    foreach (var assertion in test.Assertions.Where(x => x.Status == AssertionStatus.Failed || x.Status == AssertionStatus.Errored))
                    {
                        if (assertion.Status == AssertionStatus.Failed)
                        {
                            Console.WriteLine("Failed: " + assertion.Message);
                        }
                        else
                        {
                            Console.WriteLine("Error: " + assertion.Error);
                        }
                    }
                }
            }
        }
    }
}