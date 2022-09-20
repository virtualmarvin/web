using Microsoft.AspNetCore.Mvc.Rendering;

namespace Marvin.Web
{
    // Lookup (dropdown) items. 

    #region Interface

    public interface ILookup
    {
        List<SelectListItem> ThingALookups { get; }
        List<SelectListItem> ThingBLookups { get; }
        List<SelectListItem> ThingCLookups { get; }
        List<SelectListItem> ThingDLookups { get; }
        List<SelectListItem> ThingELookups { get; }

        List<SelectListItem> ThingAStatuses { get; }
        List<SelectListItem> ThingBStatuses { get; }
        List<SelectListItem> ThingCStatuses { get; }
        List<SelectListItem> ThingDStatuses { get; }
        List<SelectListItem> ThingEStatuses { get; }

        List<SelectListItem> UserRoles { get; }

    }
    #endregion

    public class Lookup : ILookup
    {
        #region Lookups

        public List<SelectListItem> ThingALookups =>
              new()
              {
                  new(value: "", text: "-- None --", selected: true),
                  new(value: "High", text: "High"),
                  new(value: "Medium", text: "Medium"),
                  new(value: "Low", text: "Low")
              };


        public List<SelectListItem> ThingBLookups =>
              new()
              {
                  new(value: "", text: "-- None --", selected: true),
                  new(value: "Primary", text: "Primary"),
                  new(value: "Secondary", text: "Secondary"),
                  new(value: "Tertiary", text: "Tertiary")
              };

        public List<SelectListItem> ThingCLookups =>
              new()
              {
                  new(value: "", text: "-- None --", selected: true),
                  new(value: "Private", text: "Private"),
                  new(value: "Public", text: "Public"),
                  new(value: "Protected", text: "Protected")
              };

        public List<SelectListItem> ThingDLookups =>
              new()
              {
                  new(value: "", text: "-- None --", selected: true),
                  new(value: "Email", text: "Email"),
                  new(value: "Website", text: "Website"),
                  new(value: "Meeting", text: "Meeting"),
                  new(value: "Exhibit", text: "Exhibit"),
                  new(value: "Referral", text: "Referral")
              };

        public List<SelectListItem> ThingELookups =>
              new()
              {
                  new(value: "", text: "-- None --", selected: true),
                  new(value: "Installation", text: "Installation"),
                  new(value: "Compatibility", text: "Compatibility"),
                  new(value: "Bug/Defect", text: "Bug/Defect"),
                  new(value: "Data Issue", text: "Data Issue"),
                  new(value: "Change Request", text: "Change Request"),
                  new(value: "Other", text: "Other")
              };

        public List<SelectListItem> ThingAStatuses =>
              new()
              {
                  new(value: "", text: "-- None --", selected: true),
                  new(value: "Not Started", text: "Not Started"),
                  new(value: "In Progress", text: "In Progress"),
                  new(value: "Submitted", text: "Submitted"),
                  new(value: "Approved", text: "Approved"),
                  new(value: "Declined", text: "Declined")
              };

        public List<SelectListItem> ThingBStatuses =>
              new()
              {
                  new(value: "", text: "-- None --", selected: true),
                  new(value: "Bronze", text: "Bronze"),
                  new(value: "Silver", text: "Silver"),
                  new(value: "Gold", text: "Gold"),
                  new(value: "Platinum", text: "Platinum")
              };

        public List<SelectListItem> ThingCStatuses =>
              new()
              {
                  new(value: "", text: "-- None --", selected: true),
                  new(value: "In Review", text: "In Review"),
                  new(value: "Pending", text: "Pending"),
                  new(value: "Complete", text: "Complete")
              };

        public List<SelectListItem> ThingDStatuses =>
              new()
              {
                  new(value: "", text: "-- None --", selected: true),
                  new(value: "Junior", text: "Junior"),
                  new(value: "Senior", text: "Senior"),
                  new(value: "Architect", text: "Architect"),
                  new(value: "Manager", text: "Manager")
              };

        public List<SelectListItem> ThingEStatuses =>
              new()
              {
                  new(value: "", text: "-- None --", selected: true),
                  new(value: "Sent", text: "Sent"),
                  new(value: "Received", text: "Received"),
                  new(value: "Responded", text: "Responded")
              };

        public List<SelectListItem> UserRoles =>
              new()
              {
                  new(value: "", text: "-- None --", selected: true),
                  new(value: "User", text: "User"),
                  new(value: "Admin", text: "Admin")
              };

        #endregion
    }
}
