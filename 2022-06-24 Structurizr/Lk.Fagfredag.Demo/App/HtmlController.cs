using Structurizr.Annotations;

namespace Lk.Fagfredag.Demo.App
{
    [Component(Description = "Serves HTML pages to users.", Technology = "ASP.NET MVC")]
    [UsedByPerson("User", Description = "Uses", Technology = "HTTPS")]
    public class HtmlController
    {
        [UsesComponent("Gets data using")]
        private IRepository repository = new EfRepository();
    }
}