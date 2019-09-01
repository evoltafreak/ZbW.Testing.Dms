using System;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Repositories;
using ZbW.Testing.Dms.Client.ViewModels;
using ZbW.Testing.Dms.Client.Views;

namespace ZbW.Testing.Dms.Client.UnitTests.Views
{
    [TestFixture, RequiresSTA]
    public class MainViewTest
    {

        [Test]
        public void TestMainView()
        {
            MainView mainView = new MainView("Joshua");
            Assert.IsNotNull(mainView);

            MainViewModel mainViewModel = new MainViewModel("Joshua");
            Assert.IsNotNull(mainViewModel);

            mainViewModel.OnCmdNavigateToDocumentDetail();
            Assert.IsNotNull(mainViewModel.Content);

            mainViewModel.OnCmdNavigateToSearch();
            Assert.IsNotNull(mainViewModel.Content);
        }

    }
}
