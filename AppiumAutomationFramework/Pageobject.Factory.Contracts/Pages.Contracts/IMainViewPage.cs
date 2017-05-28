using Pageobject.Factory.Contracts.Base.Contracts;

namespace Pageobject.Factory.Contracts.Pages.Contracts
{
    /// <summary>
    /// The main view interface.
    /// </summary>
    /// <seealso cref="Pageobject.Factory.Contracts.Base.Contracts.IPageObjectBase" />
    public interface IMainViewPage : IPageObjectBase
    {
        /// <summary>
        /// Used for the feature to set the configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        void SetUpWithConfiguration(string configuration);

        /// <summary>
        /// Proverb appears when the application does not have tasks.
        /// </summary>
        string GetProverb();

        /// <summary>
        /// Gets the number of tasks from the list.
        /// </summary>
        int GetTotalTasks();
    }
}
