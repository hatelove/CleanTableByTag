using System;
using TechTalk.SpecFlow;

namespace CleanTableByTag.steps
{
    [Binding]
    public class BookControllerSteps
    {
        [Given(@"a book for registering")]
        public void GivenABookForRegistering(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Create")]
        public void WhenCreate()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Book table should exist a record")]
        public void ThenBookTableShouldExistARecord(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
