using CleanTableByTag.DbModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CleanTableByTag.steps
{
    [Binding]
    public class BookServiceSteps
    {
        private BookService _bookService;

        [BeforeScenario()]
        public void BeforeScenario()
        {
            this._bookService = new BookService();            
        }

        [Given(@"a book for registering")]
        public void GivenABookForRegistering(Table table)
        {
            var bookViewModel = table.CreateInstance<BookViewModel>();
            ScenarioContext.Current.Set<BookViewModel>(bookViewModel);
        }

        [When(@"Create")]
        public void WhenCreate()
        {
            var bookViewModel = ScenarioContext.Current.Get<BookViewModel>();
            this._bookService.Create(bookViewModel);
        }

        [Then(@"Book table should exist a record")]
        public void ThenBookTableShouldExistARecord(Table table)
        {
            using (var dbcontext = new NorthwindEntitiesForTest())
            {
                var book = dbcontext.Books.FirstOrDefault();
                Assert.IsNotNull(book);

                table.CompareToInstance(book);
            }
        }
    }

    internal class BookViewModel
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
    }

    internal class BookService
    {
        public void Create(BookViewModel bookViewModel)
        {
            var book = new Book { ISBN = bookViewModel.ISBN, Name = bookViewModel.Name };

            //production and testing project shouldn't use the same connection string
            //it is just for sample code
            using (var dbcontext = new NorthwindEntitiesForTest())
            {
                dbcontext.Books.Add(book);
                dbcontext.SaveChanges();
            }
        }
    }
}