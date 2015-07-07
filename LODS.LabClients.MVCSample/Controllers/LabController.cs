using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;
using LabOnDemand.ApiV3;
using LODS.LabClients.MVCSample.Exceptions;
using LODS.LabClients.MVCSample.Models;

namespace LODS.LabClients.MVCSample.Controllers {
    [Authorize]
    public class LabController : Controller {
        // GET: Lab/id
        public ActionResult Index(int id) {
            var apiClient = GetLabOnDemandApiClient();
            var externalUserId = GetExternalUserId();
            // this is the minimum set of parameters plus one optional; most integration scenarios will not use "completion" status
            // but some will; discuss this with Support... completion status processing is not shown in the sample project.
            // There is also "LaunchAnonymous" for use cases where a user credential is not available, but we are not
            // exposing that here.
            var launchResponse = apiClient.Launch(id, externalUserId, "First Name", "Last Name", User.Identity.Name, false);
            switch (launchResponse.Result) {
                case LaunchResult.Success:
                    // This is the majority case
                    return new RedirectResult(launchResponse.Url);
                case LaunchResult.SavedInstanceExists:
                    // A saved instance exists for the user to resume, and they are not allowed to create a new one,
                    // so they can't launch a new instance.
                    // Here, we're just yelling at the user, but we could just find the saved instance for them and resume it without
                    // asking them.  It depends on what your goals are.  For a silent resume, you would have code like the following:
                    //   var savedSessionResponse = apiClient.UserRunningAndSavedLabs(externalUserId);
                    //   var savedSession = savedSessionResponse.SavedLabs.First(s => s.LabProfileId == labProfileId);
                    //   var resumeResponse = api.Resume(savedSession.LabInstanceId);
                    //   return new RedirectResult(resumeResponse.Url);
                    throw new LodUserSavedInstanceExistsException();
                case LaunchResult.InsufficientResources:
                    // On the hosting side, resources necessary to launch the lab were unavailable.  This generally means
                    // a configuration error in the lab.
                    throw new LodInsufficientResourcesException();
                case LaunchResult.ApiIntegrationMaxActiveLabInstancesReached:
                    // The maximum number of lab instances possible for the INTEGRATION (across all users and labs) has been reached.
                    throw new LodIntegrationMaxActiveLabInstancesReachedException();
                case LaunchResult.ApiIntegrationMaxRamUsageReached:
                    // The memory limit for all running instances across the INTEGRATION (across all users and labs) has been reached.
                    throw new LodIntegrationMaxRamUsageReachedException();
                case LaunchResult.UserMaxActiveLabInstancesReached:
                    // The maximum number of lab instances possible for the USER has been reached... note that as of when this code was
                    // written, users are only allowed to have one instance per user, so the error message in the exception assumes
                    // that is the case.  In production, you may want to be less specific about this as a futureproofing decision;
                    // however, you would also know what the maximum per user is allowed to be if it's not "one," so you can
                    // do the right thing.
                    throw new LodUserMaxActiveLabInstancesReachedException();
                case LaunchResult.UserMaxRamUsageReached:
                    // The memory limit for all running instances for the USER been reached
                    throw new LodUserMaxRamUsageReachedException();
                case LaunchResult.LabSeriesMaxActiveLabInstancesReached:
                    // The maximum number of lab instances possible for the LAB SERIES (across all users and integrations) has been reached.
                    throw new LodLabSeriesMaxActiveLabInstancesReachedException();
                case LaunchResult.LabSeriesMaxRamUsageReached:
                    // The memory limit for all running instances for the LAB SERIES (across all users and integrations) has been reached.
                    throw new LodLabSeriesMaxRamUsageReachedException();
                case LaunchResult.LabOrganizationMaxActiveLabInstancesReached:
                    // The maximum number of lab instances possible for the LAB OWNER ORGANIZATION (PUBLISHER) (across all users and integrations) has been reached.
                    throw new LodLabOrganizationMaxActiveLabInstancesReachedException();
                case LaunchResult.LabOrganizationMaxRamUsageReached:
                    // The memory limit for all running instances for the LAB OWNER ORGANIZATION (PUBLISHER) (across all users and integrations) has been reached.
                    throw new LodLabOrganizationMaxRamUsageReachedException();
                case LaunchResult.LabProfileMaxActiveLabInstancesReached:
                    // The maximum number of lab instances possible for the LAB PROFILE (across all users and integrations) has been reached.
                    throw new LodLabProfileMaxActiveLabInstancesReachedException();
                case LaunchResult.UserOrganizationMaxActiveLabInstancesReached:
                    // The maximum number of lab instances possible for the USER'S ORGANIZATION (across all users and integrations) has been reached.
                    throw new LodUserOrganizationMaxActiveLabInstancesReachedException();
                case LaunchResult.UserOrganizationMaxRamUsageReached:
                    // The memory limit for all running instances for the USER'S ORGANIZATION (across all users and integrations) has been reached.
                    throw new LodUserOrganizationMaxRamUsageReachedException();
                case LaunchResult.Error:
                    // A non-specific error occurred creating the lab instance.  This is not expected to be reported.
                    throw new LodLabLaunchErrorException();
                default:
                    // There are no other response codes.  This is here to keep the compiler happy, as well as making sure that
                    // we are somewhat future-proofed.  Perhaps throwing a generic launch exception would be better.
                    return HttpNotFound();
            }
        }

        // GET: Lab/Resume/id
        public ActionResult Resume(long id) {
            var apiClient = GetLabOnDemandApiClient();
            var resumeResponse = apiClient.Resume(id);
            switch (resumeResponse.Result) {
                case ResumeResult.Success:
                    // This is the majority case
                    return new RedirectResult(resumeResponse.Url);
                case ResumeResult.InsufficientResources:
                    // On the hosting side, resources necessary to launch the lab were unavailable.  This generally means
                    // a configuration error in the lab.
                    throw new LodInsufficientResourcesException();
                case ResumeResult.ApiIntegrationMaxActiveLabInstancesReached:
                    // The maximum number of lab instances possible for the INTEGRATION (across all users and labs) has been reached.
                    throw new LodIntegrationMaxActiveLabInstancesReachedException();
                case ResumeResult.ApiIntegrationMaxRamUsageReached:
                    // The memory limit for all running instances across the INTEGRATION (across all users and labs) has been reached.
                    throw new LodIntegrationMaxRamUsageReachedException();
                case ResumeResult.UserMaxActiveLabInstancesReached:
                    // The maximum number of lab instances possible for the USER has been reached... note that as of when this code was
                    // written, users are only allowed to have one instance per user, so the error message in the exception assumes
                    // that is the case.  In production, you may want to be less specific about this as a futureproofing decision;
                    // however, you would also know what the maximum per user is allowed to be if it's not "one," so you can
                    // do the right thing.
                    throw new LodUserMaxActiveLabInstancesReachedException();
                case ResumeResult.UserMaxRamUsageReached:
                    // The memory limit for all running instances for the USER been reached
                    throw new LodUserMaxRamUsageReachedException();
                case ResumeResult.LabSeriesMaxActiveLabInstancesReached:
                    // The maximum number of lab instances possible for the LAB SERIES (across all users and integrations) has been reached.
                    throw new LodLabSeriesMaxActiveLabInstancesReachedException();
                case ResumeResult.LabSeriesMaxRamUsageReached:
                    // The memory limit for all running instances for the LAB SERIES (across all users and integrations) has been reached.
                    throw new LodLabSeriesMaxRamUsageReachedException();
                case ResumeResult.LabOrganizationMaxActiveLabInstancesReached:
                    // The maximum number of lab instances possible for the LAB OWNER ORGANIZATION (PUBLISHER) (across all users and integrations) has been reached.
                    throw new LodLabOrganizationMaxActiveLabInstancesReachedException();
                case ResumeResult.LabOrganizationMaxRamUsageReached:
                    // The memory limit for all running instances for the LAB OWNER ORGANIZATION (PUBLISHER) (across all users and integrations) has been reached.
                    throw new LodLabOrganizationMaxRamUsageReachedException();
                case ResumeResult.LabProfileMaxActiveLabInstancesReached:
                    // The maximum number of lab instances possible for the LAB PROFILE (across all users and integrations) has been reached.
                    throw new LodLabProfileMaxActiveLabInstancesReachedException();
                case ResumeResult.UserOrganizationMaxActiveLabInstancesReached:
                    // The maximum number of lab instances possible for the USER'S ORGANIZATION (across all users and integrations) has been reached.
                    throw new LodUserOrganizationMaxActiveLabInstancesReachedException();
                case ResumeResult.UserOrganizationMaxRamUsageReached:
                    // The memory limit for all running instances for the USER'S ORGANIZATION (across all users and integrations) has been reached.
                    throw new LodUserOrganizationMaxRamUsageReachedException();
                case ResumeResult.Error:
                    // A non-specific error occurred creating the lab instance.  This is not expected to be reported.
                    throw new LodLabLaunchErrorException();
                default:
                    // There are no other response codes.  This is here to keep the compiler happy, as well as making sure that
                    // we are somewhat future-proofed.  Perhaps throwing a generic launch exception would be better.
                    return HttpNotFound();
            }
        }

        // GET: Lab/Available
        public ActionResult Available() {
            var apiClient = GetLabOnDemandApiClient();
            // get the lab catalog for the specific integration
            // note that by default, you only get published, enabled labs - if you would like all labs, enabled or not,
            // in all development states, then you can pass the optional includeAll parameter to indicate that
            // desire
            var labCatalog = apiClient.Catalog();
            // a lot of this is just translating the data structures now, to group by lab series for the view
            // ... a lot of integrations only have one series, so this would be unnecessarily complex
            var availableLabCollection = new AvailableLabViewModelCollection();
            foreach (var labSeries in labCatalog.LabSeries) {
                // note: the catalog is filtered to only send "enabled" labs so there's no need to filter on that here
                var availableLabs = labCatalog.LabProfiles.Where(l => l.SeriesId == labSeries.Id).Select(labInSeries => new AvailableLabViewModel {
                    Id = labInSeries.Id,
                    TitleString = GetLabTitleFromProfile(labInSeries),
                    Description = labInSeries.Description,
                }).ToList();
                availableLabCollection[labSeries] = availableLabs;
            }
            return View(availableLabCollection);
        }

        // GET: Lab/Saved
        public ActionResult Saved() {
            // get the user's running and saved instance list
            var apiClient = GetLabOnDemandApiClient();
            var savedAndRunningLabs = apiClient.UserRunningAndSavedLabs(GetExternalUserId());
            // Now get just the saved instances and map them to the viewmodel
            // in production, you might want to properly size this collection ahead of time, since
            // you know the size from the size of Results
            var savedLabCollection = new SavedLabViewModelCollection();
            foreach (var savedLab in savedAndRunningLabs.SavedLabs) {
                var labProfile = apiClient.LabProfile(savedLab.LabProfileId);
                savedLabCollection.Add(new SavedLabViewModel {
                    InstanceId = savedLab.LabInstanceId,
                    TitleString = GetLabTitleFromProfile(labProfile),
                    Description = labProfile.Description,
                    SavedUtc = savedLab.SavedTime,
                    ExpiresUtc = savedLab.ExpiresTime,
                    Available = !savedLab.SaveInProgress,
                    MinutesRemaining = savedLab.MinutesRemaining,
                });
            }
            return View(savedLabCollection);
        }

        // GET Lab/Report
        [HttpGet]
        public ActionResult Report() {
            return View(new HistoricalLabInstanceCollection());
        }

        // POST Lab/Report
        // we should use a viewmodel here to pass in the dates, but this is just a demo after all;
        // we also shouldn't really do a POST if we were being truly RESTful, but again - demo
        [HttpPost]
        public ActionResult Report(DateTime startDate, DateTime endDate) {
            // the date range is a maximum of 7 days
            if ((endDate - startDate > new TimeSpan(7, 0, 0, 0)) || (endDate < startDate)) {
                throw new ArgumentOutOfRangeException("endDate");
            }
            // get the instance list for the given date/time values
            var apiClient = GetLabOnDemandApiClient();
            var historicalResults = apiClient.Results(startDate, endDate);
            // Now get just the historical instances and map them to the viewmodel
            // in production, you might want to properly size this collection ahead of time, since
            // you know the size from the size of Results
            var historicalLabInstanceCollection = new HistoricalLabInstanceCollection();
            // we are caching some of the results to minimize round-tripping
            var profileCache = new Dictionary<int, string>();
            foreach (var historicalResult in historicalResults.Results) {
                var actingProfileId = historicalResult.LabProfileId;
                string labTitle;
                if (profileCache.ContainsKey(actingProfileId)) {
                    labTitle = profileCache[actingProfileId];
                } else {
                    labTitle = GetMinimumLabTitleFromProfile(apiClient.LabProfile(actingProfileId));
                    profileCache[actingProfileId] = labTitle;
                }
                var historicalLabInstance = new HistoricalLabInstance {
                    TitleString = labTitle,
                    UserId = historicalResult.UserId,
                    InstanceId = historicalResult.LabInstanceId,
                    StartUtc = historicalResult.StartTime,
                    EndUtc = historicalResult.EndTime ?? DateTime.MinValue,
                    CompletionStatus = historicalResult.CompletionStatus,
                };
                historicalLabInstanceCollection.Add(historicalLabInstance);
            }
            return View(historicalLabInstanceCollection);
        }

        private static LabOnDemandApiClient GetLabOnDemandApiClient() {
            return new LabOnDemandApiClient(WebConfigurationManager.AppSettings["integrationUrl"], WebConfigurationManager.AppSettings["integrationKey"]);
        }
        private string GetExternalUserId() {
            return string.Format("Demo: {0}", User.Identity.Name);
        }

        private static string GetLabTitleFromProfile(LabProfile labProfile) {
            return string.Format("{0}: {1} ({2} min.)", labProfile.Number, labProfile.Name, labProfile.DurationMinutes);
        }

        private static string GetMinimumLabTitleFromProfile(LabProfile labProfile) {
            var truncatedName = labProfile.Name;
            if (truncatedName.Length > 30) {
                truncatedName = truncatedName.Substring(0, 27) + "...";
            }
            return string.Format("{0}: {1}", labProfile.Number, truncatedName);
        }

    }
}