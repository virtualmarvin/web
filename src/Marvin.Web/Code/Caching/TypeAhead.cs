using System.Text.Json;

namespace Marvin.Web
{
    // Provides search controls with a dropdown typeahead feature

    #region Interface

    public interface ITypeahead
    {
        string ThingsA { get; }
        string ThingsB { get; }
        string ThingsC { get; }
        string ThingsD { get; }
        string ThingsE { get; }

        string Owners { get; }
    }
    #endregion

    public class Typeahead : ITypeahead
    {
        #region Dependency Injection

        private readonly ICache _cache;

        public Typeahead(ICache cache)
        {
            _cache = cache;
        }

        #endregion

        #region Typeaheads

        public string ThingsA
        {
            get
            {
                var list = new List<TypeaheadItem>();

                foreach (var thingA in _cache.ThingsA.Values)
                    list.Add(new() { id = thingA.Id, name = thingA.Name, icon = _cache.ThingAIcon, type = "ThingA" });

                return JsonSerializer.Serialize(list);
            }
        }

        public string ThingsB
        {
            get
            {
                var list = new List<TypeaheadItem>();

                foreach (var thingB in _cache.ThingsB.Values)
                    list.Add(new() { id = thingB.Id, name = thingB.Name, icon = _cache.ThingBIcon, type = "ThingB" });

                return JsonSerializer.Serialize(list);
            }
        }

        public string ThingsC
        {
            get
            {
                var list = new List<TypeaheadItem>();

                foreach (var thingC in _cache.ThingsC.Values)
                    list.Add(new() { id = thingC.Id, name = thingC.Name, icon = _cache.ThingCIcon, type = "ThingC" });

                return JsonSerializer.Serialize(list);
            }
        }

        public string ThingsD
        {
            get
            {
                var list = new List<TypeaheadItem>();

                foreach (var thingD in _cache.ThingsD.Values)
                    list.Add(new() { id = thingD.Id, name = thingD.Name, icon = _cache.ThingDIcon, type = "ThingD" });

                return JsonSerializer.Serialize(list);
            }
        }

        public string ThingsE
        {
            get
            {
                var list = new List<TypeaheadItem>();

                foreach (var thingE in _cache.ThingsE.Values)
                    list.Add(new() { id = thingE.Id, name = thingE.Name, icon = _cache.ThingEIcon, type = "ThingE" });

                return JsonSerializer.Serialize(list);
            }
        }

        public string Owners
        {
            get
            {
                var list = new List<TypeaheadItem>();

                foreach (var user in _cache.Users.Values.Where(a => a.IsDeleted == false))
                    list.Add(new() { id = user.Id, name = user.Name, icon = _cache.UserIcon, type = "User" });

                return JsonSerializer.Serialize(list);
            }
        }

        private record TypeaheadItem
        {
            public int id { get; set; }
            public string? name { get; set; }
            public string? icon { get; set; }
            public string? type { get; set; }
        }

        #endregion
    }
}
