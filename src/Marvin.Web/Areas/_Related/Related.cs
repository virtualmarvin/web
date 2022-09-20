using Marvin.Web.Domain;

namespace Marvin.Web.Areas._Related
{
    // Prepares related entities for different detail pages

    public class Related : IRelated
    {
        public void Prepare(List<ThingA> thingsA, _ThingsA model, int totalThingsA, int parentId, string parentName)
        {
            model.TotalThingsA = totalThingsA;
            model.ParentId = parentId;
            model.ParentName = parentName;

            foreach (var thingA in thingsA)
            {
                var _thingA = new _ThingA { Id = thingA.Id, Name = thingA.Name, Lookup = thingA.Lookup, Status = thingA.Status, Integer = thingA.Integer, TotalThingsE  = thingA.TotalThingsE };
                model.ThingsA.Add(_thingA);
            }
        }

        public void Prepare(List<ThingB> thingsB, _ThingsB model, int totalThingsB, int parentId, string parentName)
        {
            model.TotalThingsB = totalThingsB;
            model.ParentId = parentId;
            model.ParentName = parentName;

            foreach (var thingB in thingsB)
            {
                var _thingB = new _ThingB { Id = thingB.Id, Name = thingB.Name, Lookup = thingB.Lookup, Money = thingB.Money.ToCurrency(), Status = thingB.Status, TotalThingsA = thingB.TotalThingsA };
                model.ThingsB.Add(_thingB);
            }
        }

        public void Prepare(List<ThingC> thingsC, _ThingsC model, int totalThingsC, int parentId, string parentName)
        {
            model.TotalThingsC = totalThingsC;
            model.ParentId = parentId;
            model.ParentName = parentName;

            foreach (var thingC in thingsC)
            {
                var _thingC = new _ThingC { Id = thingC.Id, Name = thingC.Name, Boolean = thingC.Boolean, Status = thingC.Status, Money = thingC.Money.ToCurrency() , TotalThingsA = thingC.TotalThingsA };
                model.ThingsC.Add(_thingC);
            }
        }

        public void Prepare(List<ThingD> thingsD, _ThingsD model, int totalThingsD, int parentId, string parentName)
        {
            model.TotalThingsD = totalThingsD;
            model.ParentId = parentId;
            model.ParentName = parentName;

            foreach (var thingD in thingsD)
            {
                var _thingD = new _ThingD { Id = thingD.Id, Name = thingD.Name, Integer = thingD.Integer, Status = thingD.Status, Lookup = thingD.Lookup, TotalThingsE = thingD.TotalThingsE };
                model.ThingsD.Add(_thingD);
            }
        }

        public void Prepare(List<ThingE> thingsE, _ThingsE model, int totalThingsE, int parentId, string parentName)
        {
            model.TotalThingsE = totalThingsE;
            model.ParentId = parentId;
            model.ParentName = parentName;

            foreach (var thingE in thingsE)
            {
                var _thingE = new _ThingE { Id = thingE.Id, Name = thingE.Name, Lookup = thingE.Lookup, Money = thingE.Money.ToCurrency(), Date = thingE.DateTime.ToDate() };
                model.ThingsE.Add(_thingE);
            }
        }

    }
}
