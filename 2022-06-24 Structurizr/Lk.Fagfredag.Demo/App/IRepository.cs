using Structurizr.Annotations;

namespace Lk.Fagfredag.Demo.App
{
    [Component(Description = "Provides access to data stored in the database.", Technology = "C#")]
    public interface IRepository
    {
        string GetData(long id);
    }
}