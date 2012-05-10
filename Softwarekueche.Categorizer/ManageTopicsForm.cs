﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Softwarekueche.Categorizer.Persister;

// ReSharper disable InconsistentNaming
namespace Softwarekueche.Categorizer
{
    public partial class ManageTopicsForm : Form
    {
        private readonly IEnumerable<Topic> _topic;

        public ManageTopicsForm()
        {
            InitializeComponent();

            _topic = ThisAddIn.ServiceLocator.TopicPersister.GetTopics();
        }

        private void LoadTopics()
        {
            // add selected topic
            lstTopics.Items.Clear();
            lstTopics.Items.AddRange(_topic.ToArray());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) return;

            if (lstTopics.Items.Cast<Topic>().Any(item => string.Compare(item.Title, textBox1.Text, StringComparison.CurrentCultureIgnoreCase) == 0))
                return;

            lstTopics.Items.Add(new Topic() { Title = textBox1.Text });
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstTopics.SelectedIndex < 0) return;

            lstTopics.Items.Remove(lstTopics.SelectedItem);
        }

        private void ManageTopicsForm_Load(object sender, EventArgs e)
        {
            LoadTopics();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var newTopics = lstTopics.Items.Cast<Topic>();
            ThisAddIn.ServiceLocator.TopicPersister.SetTopics(newTopics);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
