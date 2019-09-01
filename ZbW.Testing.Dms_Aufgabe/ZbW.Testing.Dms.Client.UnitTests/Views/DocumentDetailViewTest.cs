using System;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Repositories;
using ZbW.Testing.Dms.Client.ViewModels;
using ZbW.Testing.Dms.Client.Views;

namespace ZbW.Testing.Dms.Client.UnitTests.Views
{
    [TestFixture, RequiresSTA]
    public class DocumentDetailViewTest
    {

        [Test]
        public void TestDocumentDetailView()
        {
            DocumentDetailView documentDetailView = new DocumentDetailView("Joshua", dummyMethod);
            Assert.IsNotNull(documentDetailView);

            DocumentDetailViewModel documentDetailViewModel = new DocumentDetailViewModel("Joshua", dummyMethod);
            documentDetailViewModel.ValutaDatum = DateTime.Now;
            documentDetailViewModel.Benutzer = "TestUser";
            documentDetailViewModel.Bezeichnung = "Test Quittungen";
            documentDetailViewModel.Erfassungsdatum = DateTime.Now;
            documentDetailViewModel.FilePath =
                @"..\..\DMSTest\test.txt";
            documentDetailViewModel.IsRemoveFileEnabled = false;
            documentDetailViewModel.SelectedTypItem = "Quittungen";
            documentDetailViewModel.Stichwoerter = "Test Quittungen";
            documentDetailViewModel.TypItems = ComboBoxItems.Typ;
            Assert.IsNotNull(documentDetailViewModel);

            documentDetailViewModel.OnCmdSpeichern();
        }


        public void dummyMethod()
        {

        }

    }
}
