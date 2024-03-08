using NUnit.Framework;
using NUnitAutomationFramework.Base;
using NUnitAutomationFramework.Pages;
using NUnitAutomationFramework.Utility;

namespace NUnitAutomationFramework.TestSuites
{
    [Parallelizable(ParallelScope.Children)]
    public class Regression : BaseSetup
    {
        [Test, Category("Regression")]
        public void TC001_ValidateTrustAppInTwitter_CNBC()
        {
            HomePage page = new(GetDriver(), extent_test.Value);
            page.NavigateToURL("CNBC");
            for (int i = 1; i <= 4; i++)
                page.ValidateTrustApp(i);
            extent_test.Value.Pass("TrustApp Icon Text Validation Is Passed");
        }

        [Test, Category("Regression")]
        public void TC002_ValidateTrustAppInTwitter_CNN()
        {            
            HomePage page = new(GetDriver(), extent_test.Value);
            page.NavigateToURL("CNN");
            for (int i = 1; i <= 4; i++)
                page.ValidateTrustApp(i);
            extent_test.Value.Pass("TrustApp Icon Text Validation Is Passed");
        }
    }
}