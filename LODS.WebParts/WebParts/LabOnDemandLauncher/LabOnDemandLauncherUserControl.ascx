<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LabOnDemandLauncherUserControl.ascx.cs"
    Inherits="LODS.SharePoint.ContentManagement.WebParts.LabOnDemandLauncher.LabOnDemandLauncherUserControl" %>

<style>
    .labCode {
        font-weight: bold;
        text-align: center;
    }

    .labTitle {
        font-weight: bold;
    }

    .labDescription {
    }

    .labLaunchLink {
        text-align: center;
        padding-left: 8px !important;
        padding-right: 8px !important;
    }

    .labTable {
        border: 2px solid;
    }

        .labTable thead tr {
            background-color: lightgray;
        }

        .labTable tbody tr {
            vertical-align: middle;
        }

            .labTable tbody tr.alternate {
                background-color: #f0f0f0;
            }

        .labTable tbody td {
            padding: 2px;
            border: 1px solid;
        }

            .labTable tbody td.labTitle {
                border-bottom: 0;
            }

            .labTable tbody td.labDescription {
                border-top: 0;
            }
</style>

