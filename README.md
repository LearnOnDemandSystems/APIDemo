# APIDemo

This project is demonstration code for the public Learn on Demand .NET API package,
available in [`nuget`](http://www.nuget.org/packages/LODS.LabClients.Integration/).

As of July 23, 2015, there are two sample projects in a single solution.

## MVCSample

The MVC Sample is a full ASP.NET MVC application that allows launching labs,
connecting to saved labs, and retrieving information about launched labs.
This includes a full exception hierarchy.  The authentication and
authorization components are stubbed for simplicity sake.

## WebParts

The WebParts project is a version of a production web part used by
LODS in our on-premises SharePoint 2013 installation for launching labs.
It is intended to be used in cases where SharePoint is acting as a
pseudo-learning-management-system front end for lab access.
It includes configuration fields for the API key, the endpoint
location, support of anonymous launches, and the list of lab profile
identifiers.

This project will not build unless you have the SharePoint
2013 development support installed for Visual Studio and you have a local
SharePoint installation (a requirement for SharePoint development.)  You will
also need to add your own `key.snk` file for .NET strong-named signing (a
standard SharePoint requirement.)

# Support and License Statement

This code is not supported in any way.  It is not presented as complete
production code but is instead meant to act as sample reference code only.
You should verify the code yourself including validating the security
of the code.  Code based on this code may be used in any project targeting
the LOD API, including commercial and closed-source projects.