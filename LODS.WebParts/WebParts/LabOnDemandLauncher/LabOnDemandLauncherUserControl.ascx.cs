using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LabOnDemand.ApiV3;
using Microsoft.IdentityModel.Claims;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace LODS.SharePoint.ContentManagement.WebParts.LabOnDemandLauncher {
    public partial class LabOnDemandLauncherUserControl : UserControl {
        public LabOnDemandLauncher ParentWebPart { get; set; }

        private readonly string _launchPageUrlBase = string.Format("{0}/_layouts/LODS.WebParts/LodLauncher.aspx?{1}=",
                SPContext.Current.Web.Url, Constants.QueryStringLabId);

        private bool IsEditing() {
            return SPContext.Current.FormContext.FormMode ==
                   SPControlMode.Edit;
        }

        private bool NeedsConfig() {
            return string.IsNullOrWhiteSpace(ParentWebPart.ApiKey) ||
                string.IsNullOrWhiteSpace(ParentWebPart.EndpointUri) ||
                string.IsNullOrWhiteSpace(ParentWebPart.LabProfileIds);
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (IsEditing()) {
                ReportEditing();
                return;
            }
            if (NeedsConfig()) {
                ReportNeedsConfiguration();
                return;
            }

            if ((!ParentWebPart.AllowAnonymousLaunch) && (!Request.IsAuthenticated)) {
                throw new HttpException(403, "You must be signed in to continue.");
            }

            var actingUserName = Request.IsAuthenticated ?
                IdentityHelpers.GetUsedEmail(Page.User as IClaimsPrincipal) : 
                "(anonymous)";
            SessionManager.SaveIntegrationSession(Session, 
                ParentWebPart.EndpointUri, ParentWebPart.ApiKey,
                string.Empty, actingUserName);

            try {
                var client = new LabOnDemandApiClient(ParentWebPart.EndpointUri, ParentWebPart.ApiKey);

                var labProfileIds = ParentWebPart.LabProfileIds.Split(',');

                var labTable = new Table {
                    CssClass = "labTable"
                };
                AddHeader(labTable);
                var count = 0;
                foreach (var labProfileIdString in labProfileIds) {
                    AddComment(labProfileIdString);
                    int labProfileId;
                    if (!int.TryParse(labProfileIdString, out labProfileId)) {
                        AddComment("(skipped)");
                        continue;
                    }
                    count++;
                    var alternate = (count % 2) == 0;
                    var labProfile = client.LabProfile(labProfileId);
                    labTable.Rows.Add(GetFirstRow(labProfile, alternate));
                    labTable.Rows.Add(GetSecondRow(labProfile, alternate));
                }
                Controls.Add(labTable);

                SessionManager.SessionAllowsAnonymous(Session, ParentWebPart.AllowAnonymousLaunch);
            }
            catch (Exception ex) {
                AddComment(ex.ToString());
                AddLiteral("An error occurred retrieving the requested lab information.");
            }
        }

        private void AddComment(string comment) {
            AddLiteral("<!--" + comment + "-->");
        }

        private void AddLiteral(string text) {
            Controls.Add(new Literal {
                Text = text
            });
        }

        private void ReportEditing() {
            AddLiteral("This web part does not display data in edit mode.");
        }

        private void ReportNeedsConfiguration() {
            AddLiteral("This web part needs to be configured.");
        }

        private void AddHeader(Table table) {
            var row = new TableHeaderRow {
                TableSection = TableRowSection.TableHeader
            };
            var cell1 = new TableHeaderCell {
                Text = "Code"
            };
            var cell2 = new TableHeaderCell {
                Text = "Title and Description"
            };
            var cell3 = new TableHeaderCell {
                Text = "&nbsp;"
            };
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
            table.Rows.Add(row);
        }

        private TableRow GetFirstRow(LabProfile labProfile, bool alternate) {
            var labRow = new TableRow();
            if (alternate) {
                labRow.CssClass = "alternate";
            }
            var codeCell = new TableCell {
                Text = labProfile.Number,
                CssClass = "labCode",
                RowSpan = 2,
            };
            labRow.Cells.Add(codeCell);
            var titleCell = new TableCell {
                Text = labProfile.Name,
                CssClass = "labTitle"
            };
            labRow.Cells.Add(titleCell);
            var launchLinkCell = new TableCell {
                CssClass = "labLaunchLink",
                RowSpan = 2
            };
            //var launchLink = new HyperLink {
            //    NavigateUrl =
            //        string.Format("{0}{1}", _launchPageUrlBase, labProfile.Id),
            //    Text = "Launch",
            //    Target = "_blank"
            //};
            //launchLinkCell.Controls.Add(launchLink);
            var launchLinkButton = new LinkButton {
                Text = "Launch",
                CommandName = "Launch",
                CommandArgument = labProfile.Id.ToString()
            };
            launchLinkButton.Click += LaunchClick;
            launchLinkCell.Controls.Add(launchLinkButton);

            labRow.Cells.Add(launchLinkCell);
            return labRow;
        }

        private static TableRow GetSecondRow(LabProfile labProfile, bool alternate) {
            var labRow = new TableRow();
            if (alternate) {
                labRow.CssClass = "alternate";
            }
            var descriptionCell = new TableCell {
                Text = labProfile.Description,
                CssClass = "labDescription"
            };
            labRow.Cells.Add(descriptionCell);
            return labRow;
        }

        protected void LaunchClick(object sender, EventArgs e) {
            var button = (LinkButton)sender;
            var labProfileIdString = button.CommandArgument;
            int labProfileId;
            if (!int.TryParse(labProfileIdString, out labProfileId)) {
                return;
            }
            if ((!Request.IsAuthenticated && ParentWebPart.AllowAnonymousLaunch) || (Request.IsAuthenticated)) {
                Response.Redirect(string.Format("{0}{1}", _launchPageUrlBase, labProfileIdString), true);
            }
            throw new HttpException(403, "Launch requires a valid sign-in session");
        }
    }
}
