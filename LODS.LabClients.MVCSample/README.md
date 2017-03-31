# LODS MVC Sample ReadMe
_API v3 Release, March 6, 2015_

## Introduction
The Learn on Demand Systems (LODS) MVC Sample is intended to be a simple
demonstration project for the LODS Integration API as exposed through the .NET
helper assembly. The project does not demonstrate all functionality available
in the API. Instead, it shows what we believe will be the most common
integration points used. Full documentation on the API is always available
[here](https://labondemand.com/apidocumentation/v3).

The MVC sample assumes knowledge of the basics of ASP.NET MVC as well as
experience in developing projects in Visual Studio 2013 including package
management and management of assembly references.

The project includes demo credentials in the web.config file; in production
you will of course use your own integration information as supplied by Learn on
Demand Systems.

## Running the Sample
1. Open the .sln in Visual Studio 2017.
1. Launch the package manager GUI and ensure that all packages are restored
correctly.
1. Right-click the LODS.LabClients.MVCSample project and "Set as StartUp
Project."
1. Run the solution.
1. Sign in as any e-mail address/password combination. No validation is done on
the credentials; however, the e-mail address will be the one presented to the
Lab on Demand (LOD) system; thus, you will want to be consistent with what you
use if you intend to work with labs and reporting across sessions.
1. Navigate around. You can do the following actions:
    1. Launch a new instance of a lab from the Available view.
    1. Launch a saved instance from the Saved view. To create a saved instance,
	launch a new instance of a lab, then "Save and Close Lab" within that
	instance.
    1. Report on up to seven days of launch activity for the organization.

## Code Structure
The sample is a relatively simple ASP.NET MVC 5 application. It was created
using the Visual Studio .NET 2013 template for ASP.NET MVC 5 applications with
local accounts, and then had a substantial amount of code removed to focus
specifically on the task at hand. At the same time, as it was intended to show
some possible recommended practices, there are code files that you may find
useful to pick up as supplied and use as-is.

### Folder Structure
The following folders are present in the sample project.

|Folder|Purpose|
|---|---|
|App_Start|Standard ASP.NET startup class location. Handles routing, file bundling, etc.|
|Content|Standard ASP.NET folder for CSS, etc.|
|Controllers|MVC Controllers (more detail below)|
|Exceptions|Custom exceptions (more detail below)|
|Fonts|Glyph fonts used in the views|
|Models|MVC ViewModels - Basic authentication data structure; lab data structure|
|Scripts|Supporting JavaScript|
|Views|Standard MVC view folder|

### Controllers
The primary controller of interest is LabController. All interaction with Lab
on Demand (LOD) happens through this controller. This controller is very
heavily commented to help guide you in what is happening and hopefully explain
the actions being taken.

HomeController and AccountController are supporting controllers for the
application and are not critical to understanding the LOD integration. One
small interesting piece of code is the pseudo-sign-in code in
AccountController, which handles creating a claims-based sign in token for the
user; this is not critical to LOD integration but does demonstrate how to work
in the Owin/Claims authentication model.

### Exceptions
The sample has a multilayer exception hierarchy that represents various lab
launch/restore failures as exceptions, with heavy commenting and user-friendly
English (US) messages. The hierarchy is intended to help enforce the underlying
cause/recovery models to aid in you deciding how to handle each failure type in
your own code. For example, some failures can be corrected by the end user
without external assistance; those are grouped together under LabUserException.
You are of course free to handle the errors returned by the API in any way you
see fit; you do not need to use the provided exceptions. The .NET assembly
itself uses result code values for most failure modes and thus you can choose
to handle those codes in another way if desired.