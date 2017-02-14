using System.Linq;
using CleanTableByTag.DbModels;
using TechTalk.SpecFlow;

[Binding]
public sealed class Hooks
{
    [BeforeScenario()]
    public void CleanTable()
    {
        var tags = ScenarioContext.Current.ScenarioInfo.Tags
            .Where(x => x.StartsWith("Clean"))
            .Select(x => x.Replace("Clean", ""));

        if (!tags.Any())
        {
            return;
        }

        using (var dbcontext = new NorthwindEntitiesForTest())
        {
            foreach (var tag in tags)
            {
                dbcontext.Database.ExecuteSqlCommand($"TRUNCATE TABLE [{tag}]");
            }

            dbcontext.SaveChangesAsync();
        }
    }
}