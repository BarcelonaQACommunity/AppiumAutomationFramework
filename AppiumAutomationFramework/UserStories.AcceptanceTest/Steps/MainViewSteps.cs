using Autofac;
using CrossLayer.DI.Module;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pageobject.Factory.Contracts.Pages.Contracts;
using TechTalk.SpecFlow;
using TechTalk.SpecRun.Helper;
using UserStories.AcceptanceTest.Steps.Base;

namespace UserStories.AcceptanceTest.Steps
{
    /// <summary>
    /// Main View class, contains all related steps with this view.
    /// </summary>
    /// <seealso cref="UserStories.AcceptanceTest.Steps.Base.BaseStep" />
    [Binding]
    public class MainViewSteps : BaseStep
    {
        // Main View page.
        private readonly IMainViewPage _mainViewPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewSteps"/> class.
        /// </summary>
        public MainViewSteps()
        {
            this._mainViewPage = AppContainer.AndroidContainer.Resolve<IMainViewPage>();
        }

        /// <summary>
        /// Default configuration Step.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        [Given(@"The application is running with the '(.*)' configuration")]
        public void TheApplicationIsRunningWithTheDefaultConfiguration(string configuration)
        {
            this._mainViewPage.SetUpWithConfiguration(configuration);
        }

        /// <summary>
        /// The user goes to the add task view.
        /// </summary>
        [Given(@"The user goes to the add task view")]
        [When(@"The user goes to the add task view")]
        public void TheUserGoesToTheAddTaskView()
        {
            this._mainViewPage.AddNewTask();
        }

        /// <summary>
        /// Check that the list does not have tasks.
        /// </summary>
        [Given(@"The application does not have any tasks")]
        [When(@"The application does not have any tasks")]
        public void TheApplicationDoesNotHaveAnyTasks()
        {
            Assert.AreEqual(0, this._mainViewPage.TotalTasks);
        }

        [When(@"The user goes to the task '(.*)' edit view")]
        public void TheUserGoesToTheTaskEditView(int id)
        {
            this._mainViewPage.SelectTask(id);
        }

        /// <summary>
        /// Check that the user sees a proverb.
        /// </summary>
        [Then(@"The user sees a proverb")]
        public void TheUserSeesAProverb()
        {
            Assert.IsFalse(this._mainViewPage.Proverb.IsNullOrEmpty());
        }

        [Then(@"The application has '(.*)' task created")]
        public void TheApplicationHaveTaskCreated(int total)
        {
            Assert.AreEqual(total, this._mainViewPage.TotalTasks);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                this._mainViewPage.TakeScreenshot(ScenarioContext.Current.ScenarioInfo.Title);
            }

            this._mainViewPage.CloseAndroidDriver();
        }
    }
}
