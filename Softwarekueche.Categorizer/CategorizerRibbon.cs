﻿using System.Diagnostics;
using Microsoft.Office.Tools.Ribbon;

namespace Softwarekueche.Categorizer
{
    public partial class CategorizerRibbon
    {
        private void CategorizerRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void btnEditTopics_Click(object sender, RibbonControlEventArgs e)
        {
            new ManageTopicsForm().ShowDialog();
        }

        private void btnDonate_Click(object sender, RibbonControlEventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=DTQGEK6NEXNBE");
        }
    }
}
