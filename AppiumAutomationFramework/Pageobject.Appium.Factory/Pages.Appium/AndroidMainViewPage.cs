using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Pageobject.Appium.Factory.Base.Appium;
using Pageobject.Factory.Contracts.Pages.Contracts;

namespace Pageobject.Appium.Factory.Pages.Appium
{
    public class AndroidMainViewPage : AndroidPageObjectBase, IMainViewPage
    {
        #region .: Android Elements :.

        /// <summary>
        /// // Central text that appears when the app does not have any list.
        /// </summary>
        [FindsBy(How = How.Id, Using = "douzifly.list:id/txt_empty")]
        private IWebElement _proverbText;
        
        [FindsBy(How = How.Id, Using = "douzifly.list:id/fab_add")]
        private IWebElement _addListButton;

        [FindsBy(How = How.Id, Using = "douzifly.list:id/content")]
        private IList<IWebElement> _taskList;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AndroidMainViewPage"/> class.
        /// </summary>
        public AndroidMainViewPage()
        {
            PageFactory.InitElements(this.AndroidDriver, this);
        }

        /// <summary>
        /// Used for the feature to set the configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <exception cref="NotFoundException"></exception>
        public void SetUpWithConfiguration(string configuration)
        {
            switch (configuration)
            {
                case "Default":
                    this.SetUpDefaultConfiguration();
                    break;

                default:
                    throw new NotFoundException($"{configuration} does not exist.");
            }
        }

        /// <summary>
        /// Proverb appears when the application does not have tasks.
        /// </summary>
        public string GetProverb()
        {
            return this._proverbText.Text;
        }

        /// <summary>
        /// Gets the number of tasks from the list.
        /// </summary>
        public int GetTotalTasks()
        {
            return _taskList?.Count ?? 0;
        }
    }
}
