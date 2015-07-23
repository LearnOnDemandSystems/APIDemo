using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;

namespace LODS.SharePoint.ContentManagement.WebParts.LabOnDemandLauncher {
    [ToolboxItem(false)]
    public class LabOnDemandLauncher : WebPart {
        [WebBrowsable(true)]
        [Category("LODS Integration Configuration")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDisplayName("Lab on Demand Endpoint Uri")]
        public string EndpointUri {
            get {
                return _endpointUri ?? "https://labondemand.com/api/v3/";
            }
            set {
                _endpointUri = value;
            }
        }
        private string _endpointUri;

        [WebBrowsable(true)]
        [Category("LODS Integration Configuration")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDisplayName("Lab on Demand API Key")]
        public string ApiKey {
            get {
                return _apiKey ?? string.Empty;
            }
            set {
                _apiKey = value;
            }
        }
        private string _apiKey;

        [WebBrowsable(true)]
        [Category("LODS Launch Configuration")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDisplayName("Allow Anonymous Launch")]
        public bool AllowAnonymousLaunch { get; set; }

        [WebBrowsable(true)]
        [Category("LODS Launch Configuration")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDisplayName("Lab Profile IDs")]
        public string LabProfileIds { get; set; }

        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/LODS.SharePoint.ContentManagement.WebParts/LabOnDemandLauncher/LabOnDemandLauncherUserControl.ascx";

        protected override void CreateChildControls() {
            var control = (LabOnDemandLauncherUserControl ) Page.LoadControl(_ascxPath);
            control.ParentWebPart = this;
            Controls.Add(control);
        }
    }
}
