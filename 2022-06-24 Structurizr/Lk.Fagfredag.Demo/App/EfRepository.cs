using Structurizr.Annotations;

namespace Lk.Fagfredag.Demo.App
{
    [CodeElement(nameof(IRepository), Description = "Implementation")]
    [UsesContainer("Database", Description = "Reads from", Technology = "Entity Framework")]
    public class EfRepository : IRepository
    {
        public string GetData(long id)
        {
            return "...";
        }
    }
}