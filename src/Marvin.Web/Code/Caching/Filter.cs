using Microsoft.AspNetCore.Mvc.Rendering;

namespace Marvin.Web
{
    // Filter items shown as dropdown options

    #region Interface

    public interface IFilter
    {
        List<SelectListItem> ThingAItems { get; }
        List<SelectListItem> ThingBItems { get; }
        List<SelectListItem> ThingCItems { get; }
        List<SelectListItem> ThingDItems { get; }
        List<SelectListItem> ThingEItems { get; }

        List<SelectListItem> PeopleItems { get; }
        List<SelectListItem> ErrorItems { get; }
    }
    #endregion

    public class Filter : IFilter
    {
        #region Filters

        public List<SelectListItem> ThingAItems =>
              new()
              {
                  new(value: "0", text: "All Things A", selected: true),
                  new(value: "1", text: "Recently Viewed"),
                  new(value: "2", text: "All My Things A")
              };

        public List<SelectListItem> ThingBItems =>
              new()
              {
                  new(value: "0", text: "All Things B", selected: true),
                  new(value: "1", text: "Recently Viewed"),
                  new(value: "2", text: "All My Things B")
              };

        public List<SelectListItem> ThingCItems =>
              new()
              {
                  new(value: "0", text: "All Things C", selected: true),
                  new(value: "1", text: "Recently Viewed"),
                  new(value: "2", text: "All My Things C")
              };

        public List<SelectListItem> ThingDItems =>
              new()
              {
                  new(value: "0", text: "All Things D", selected: true),
                  new(value: "1", text: "Recently Viewed"),
                  new(value: "2", text: "All My Things D")
              };

        public List<SelectListItem> ThingEItems =>
              new()
              {
                  new(value: "0", text: "All Things E", selected: true),
                  new(value: "1", text: "Recently Viewed"),
                  new(value: "2", text: "All My Things E")
              };

        public List<SelectListItem> PeopleItems =>
              new()
              {
                  new(value: "0", text: "All People", selected: true),
                  new(value: "1", text: "In My Department"),
                  new(value: "2", text: "All Admins"),
                  new(value: "3", text: "All Users")
              };

        public List<SelectListItem> ErrorItems =>
              new()
              {
                  new(value: "0", text: "-- Select --", selected: true),
                  new(value: "5", text: "Delete 5 errors"),
                  new(value: "10", text: "Delete 10 errors"),
                  new(value: "25", text: "Delete 25 errors"),
                  new(value: "100", text: "Delete 100 errors"),
                  new(value: "All", text: "Delete All errors")
              };

        #endregion
    }
}
