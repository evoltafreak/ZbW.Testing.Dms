using System.Collections.Generic;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Repositories;
using ZbW.Testing.Dms.Client.ViewModels;
using ZbW.Testing.Dms.Client.Views;

namespace ZbW.Testing.Dms.Client.UnitTests.Views
{
    [TestFixture, RequiresSTA]
    public class SearchViewTest
    {

        [Test]
        public void TestSearchView()
        {
            SearchView searchView = new SearchView();
            Assert.IsNotNull(searchView);

            SearchViewModel searchViewModel = new SearchViewModel();
            MetadataItem item = new MetadataItem();
            item.FilePath = @"..\..\DMSTest\1cbed3d2-0d08-49ad-bd5d-0a1dfb57d499_Content.txt";
            searchViewModel.SelectedTypItem = "Quittungen";
            searchViewModel.Suchbegriff = "Quittungen";
            searchViewModel.TypItems = ComboBoxItems.Typ;
            searchViewModel.SelectedMetadataItem = item;
            Assert.IsNotNull(searchViewModel);

            searchViewModel.OnCmdOeffnen();

            searchViewModel.OnCmdReset();
            Assert.AreEqual(0, searchViewModel.FilteredMetadataItems.Count);
            Assert.IsNull(searchViewModel.SelectedTypItem);
            Assert.IsEmpty(searchViewModel.Suchbegriff);

            searchViewModel.Suchbegriff = "test";
            searchViewModel.OnCmdSuchen();
            Assert.IsTrue(searchViewModel.FilteredMetadataItems.Count > 0);

        }

    }
}
