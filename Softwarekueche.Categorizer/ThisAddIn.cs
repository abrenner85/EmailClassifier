﻿using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using Softwarekueche.Categorizer.Persister;

// ReSharper disable InconsistentNaming
namespace Softwarekueche.Categorizer
{
    public partial class ThisAddIn
    {
        #region ServiceLocator

        internal static class ServiceLocator
        {
            public static ITopicPersister TopicPersister { get; internal set; }

            public static IConfigPersister ConfigPersister { get; internal set; }
        }

        #endregion

        private const string CategorizerDataStore = "Softwarekueche.Categorizer";

        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {
        }

        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            var folder = Application.Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
            var storage = folder.GetStorage(CategorizerDataStore, OlStorageIdentifierType.olIdentifyBySubject);

            // initialize topic persister with StorageItem 
            var configPersister = new OutlookPstConfigPersister(storage);
            ServiceLocator.ConfigPersister = configPersister;

            // initialize topic persister with StorageItem 
            var topicPersister = new OutlookPstTopicPersister(storage);
            ServiceLocator.TopicPersister = topicPersister;

            Application.ItemSend += Application_ItemSend;
        }

        #region ItemSent EventHandler

        void Application_ItemSend(object Item, ref bool Cancel)
        {
            var mail = Item as MailItem;
            if (mail == null) return;

            var cfg = ServiceLocator.ConfigPersister.GetConfig();
            var subject = new EnhancedSubject(mail.Subject, cfg);
            //var usedTopics = ServiceLocator.TopicPersister.GetTopics();

            var dlg = new MailModDialog(subject);
            var res = dlg.ShowDialog();

            switch (res)
            {
                case DialogResult.OK:
                    var newSub = subject.Subject;
                    if (subject.Topic != null && !string.IsNullOrWhiteSpace(subject.Topic.Title))
                        newSub = "[" + subject.Topic + "] " + subject.Subject;

                    mail.Subject = newSub;

                    // add new topic to store
                    ServiceLocator.TopicPersister.AddTopic(subject.Topic);
                    break;

                case DialogResult.Abort:
                    Cancel = true;
                    break;
            }
        }

        #endregion

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        // ReSharper disable RedundantDelegateCreation
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        // ReSharper restore RedundantDelegateCreation

        #endregion
    }
}
