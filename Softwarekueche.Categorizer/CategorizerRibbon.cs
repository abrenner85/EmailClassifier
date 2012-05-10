using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
