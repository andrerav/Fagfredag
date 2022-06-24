using System.Reflection;
using Structurizr.Analysis;
using Structurizr;
using System.IO;
using Structurizr.IO.Json;
using Structurizr.IO.PlantUML;

#region Opprette workspace, elementer og containere
Workspace workspace = new Workspace("Structurizr for .NET Annotations", "This is a model of my software system.");
Model model = workspace.Model;

Person user = model.AddPerson("User", "A user of my software system.");
SoftwareSystem softwareSystem = model.AddSoftwareSystem("Software System", "My software system.");

Container webApplication = softwareSystem.AddContainer("Web Application", "Provides users with information.", "C#");
Container database = softwareSystem.AddContainer("Database", "Stores information.", "Relational database schema");
database.AddTags("Database");
#endregion

#region Finn annoterte komponenter
ComponentFinder componentFinder = new ComponentFinder(
   webApplication,
   "Lk.Fagfredag.Demo.App",
   new StructurizrAnnotationsComponentFinderStrategy()
);

componentFinder.FindComponents();
model.AddImplicitRelationships();
#endregion

#region Opprett views og print til stdout
ViewSet views = workspace.Views;
SystemContextView contextView = views.CreateSystemContextView(softwareSystem, "SystemContext", "An example of a System Context diagram.");
contextView.AddAllElements();

ContainerView containerView = views.CreateContainerView(softwareSystem, "Containers", "The container diagram from my software system.");
containerView.AddAllElements();

ComponentView componentView = views.CreateComponentView(webApplication, "Components", "The component diagram for the web application.");
componentView.AddAllElements();

Styles styles = views.Configuration.Styles;
styles.Add(new ElementStyle(Tags.Element) { Color = "#ffffff" });
styles.Add(new ElementStyle(Tags.SoftwareSystem) { Background = "#1168bd" });
styles.Add(new ElementStyle(Tags.Container) { Background = "#438dd5" });
styles.Add(new ElementStyle(Tags.Component) { Background = "#85bbf0", Color = "#000000" });
styles.Add(new ElementStyle(Tags.Person) { Background = "#08427b", Shape = Shape.Person });
styles.Add(new ElementStyle("Database") { Shape = Shape.Cylinder });

StringWriter stringWriter = new();
JsonWriter jsonWriter = new(indentOutput: true);
jsonWriter.Write(workspace, stringWriter);
Console.WriteLine(stringWriter.ToString());

//StringWriter stringWriter = new();
//PlantUMLWriter plantUMLWriter = new();
//plantUMLWriter.Write(workspace, stringWriter);
//Console.WriteLine(stringWriter.ToString());
#endregion 