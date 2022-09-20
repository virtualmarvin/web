using Marvin.Web.Domain;
using Microsoft.Extensions.Caching.Memory;

namespace Marvin.Web
{
    #region Interface

    public interface ICache
    {
        Dictionary<string, MetaType> MetaTypes { get; }

        string ThingAIcon { get; }
        string ThingBIcon { get; }
        string ThingCIcon { get; }
        string ThingDIcon { get; }
        string ThingEIcon { get; }
        string AdminIcon { get; }
        string UserIcon { get; }
        string PeopleIcon { get; }

        Dictionary<int, ThingA> ThingsA { get; }
        Dictionary<int, ThingB> ThingsB { get; }
        Dictionary<int, ThingC> ThingsC { get; }
        Dictionary<int, ThingD> ThingsD { get; }
        Dictionary<int, ThingE> ThingsE { get; }
        Dictionary<int, User> Users { get; }

        void ClearThingsA();
        void MergeThingA(ThingA thingA);
        void DeleteThingA(ThingA thingA);

        void ClearThingsB();
        void MergeThingB(ThingB thingA);
        void DeleteThingB(ThingB thingA);

        void ClearThingsC();
        void MergeThingC(ThingC thingA);
        void DeleteThingC(ThingC thingA);

        void ClearThingsD();
        void MergeThingD(ThingD thingA);
        void DeleteThingD(ThingD thingA);

        void ClearThingsE();
        void MergeThingE(ThingE thingA);
        void DeleteThingE(ThingE thingA);

        void ClearUsers();
        void MergeUser(User user);
        void DeleteUser(User user);

        void Clear();
    }

    #endregion

    public class Cache : ICache
    {
        #region Dependency Injection

        private readonly ICurrentUser _currentUser;
        private readonly IMemoryCache _memoryCache;
        private readonly UltraContext _db;

        public Cache(ICurrentUser currentUser, IMemoryCache memoryCache, UltraContext db)
        {
            _currentUser = currentUser;
            _memoryCache = memoryCache;
            _db = db;
        }

        #endregion

        #region Cache management

        private const string ThingsAKey = nameof(ThingsAKey);
        private const string ThingsBKey = nameof(ThingsBKey);
        private const string ThingsCKey = nameof(ThingsCKey);
        private const string ThingsDKey = nameof(ThingsDKey);
        private const string ThingsEKey = nameof(ThingsEKey);
        private const string UsersKey = nameof(UsersKey);
        private const string MetaTypesKey = nameof(MetaTypesKey);

        // Keeps track of keys used
        private static readonly HashSet<string> UsedKeys = new();
        private static readonly object locker = new();
        private static readonly object mocker = new(); // modifying locker

        #endregion

        #region MetaTypes

        public Dictionary<string, MetaType> MetaTypes
        {
            get
            {
                // ** Lazy load pattern 

                if (_memoryCache.Get(MetaTypesKey) is not Dictionary<string, MetaType> dictionary)
                {
                    lock (locker)
                    {
                        dictionary = new()
                        {
                            ["ThingA"] = new(Name: "ThingA", Icon: "icon-star icon-square icon-thinga", Url: "/thingsa"),
                            ["ThingB"] = new(Name: "ThingB", Icon: "icon-user icon-square icon-thingb", Url: "/thingsb"),
                            ["ThingC"] = new(Name: "ThingC", Icon: "icon-calendar icon-square icon-thingc", Url: "/thingsc"),
                            ["ThingD"] = new(Name: "ThingD", Icon: "icon-globe icon-square icon-thingd", Url: "/thingsd"),
                            ["ThingE"] = new(Name: "ThingE", Icon: "icon-people icon-square icon-thinge", Url: "/thingse"),
                            ["People"] = new(Name: "People", Icon: "icon-emotsmile icon-square icon-persons", Url: "/people"),
                            ["Admin"] = new(Name: "Admin", Icon: "icon-settings icon-square icon-admin", Url: "/admin"),
                            ["Owner"] = new(Name: "Owner", Icon: "icon-user icon-square icon-owner", Url: "/people"),
                            ["User"] = new(Name: "User", Icon: "icon-user icon-square icon-owner", Url: "/admin/users")
                        };

                        Add(MetaTypesKey, dictionary, DateTime.Now.AddHours(24));
                    }
                }

                return dictionary;
            }
        }

        public string ThingAIcon { get => MetaTypes["ThingA"].Icon; }
        public string ThingBIcon { get => MetaTypes["ThingB"].Icon; }
        public string ThingCIcon { get => MetaTypes["ThingC"].Icon; }
        public string ThingDIcon { get => MetaTypes["ThingD"].Icon; }
        public string ThingEIcon { get => MetaTypes["ThingE"].Icon; }
        public string AdminIcon { get => MetaTypes["Admin"].Icon; }
        public string UserIcon { get => MetaTypes["User"].Icon; }
        public string PeopleIcon { get => MetaTypes["People"].Icon; }

        #endregion

        #region ThingAs

        public Dictionary<int, ThingA> ThingsA
        {
            get
            {
                // ** Lazy load pattern 

                if (_memoryCache.Get(ThingsAKey) is not Dictionary<int, ThingA> dictionary)
                {
                    lock (locker)
                    {
                        dictionary = _db.ThingAs.ToDictionary(c => c.Id);
                        Add(ThingsAKey, dictionary, DateTime.Now.AddHours(4));
                    }
                }

                return dictionary;
            }
        }

        // Clear thingA cache

        public void ClearThingsA()
        {
            lock (locker)
            {
                Clear(ThingsAKey);
            }
        }

        public void MergeThingA(ThingA thingA)
        {
            lock (mocker)
            {
                if (thingA != null)
                    ThingsA[thingA.Id] = thingA;
            }
        }

        public void DeleteThingA(ThingA thingA)
        {
            lock (mocker)
            {
                if (thingA != null)
                    ThingsA.Remove(thingA.Id);
            }
        }

        #endregion

        #region ThingBs

        public Dictionary<int, ThingB> ThingsB
        {
            get
            {
                // ** Lazy load pattern 

                if (_memoryCache.Get(ThingsBKey) is not Dictionary<int, ThingB> dictionary)
                {
                    lock (locker)
                    {
                        dictionary = _db.ThingBs.ToDictionary(c => c.Id);
                        Add(ThingsBKey, dictionary, DateTime.Now.AddHours(4));
                    }
                }

                return dictionary;
            }
        }

        // Clear ThingB cache

        public void ClearThingsB()
        {
            lock (locker)
            {
                Clear(ThingsBKey);
            }
        }

        public void MergeThingB(ThingB ThingB)
        {
            lock (mocker)
            {
                if (ThingB != null)
                    ThingsB[ThingB.Id] = ThingB;
            }
        }

        public void DeleteThingB(ThingB ThingB)
        {
            lock (mocker)
            {
                if (ThingB != null)
                    ThingsB.Remove(ThingB.Id);
            }
        }

        #endregion

        #region ThingCs

        public Dictionary<int, ThingC> ThingsC
        {
            get
            {
                // ** Lazy load pattern 

                if (_memoryCache.Get(ThingsCKey) is not Dictionary<int, ThingC> dictionary)
                {
                    lock (locker)
                    {
                        dictionary = _db.ThingCs.ToDictionary(c => c.Id);
                        Add(ThingsCKey, dictionary, DateTime.Now.AddHours(4));
                    }
                }

                return dictionary;
            }
        }

        // Clear ThingC cache

        public void ClearThingsC()
        {
            lock (locker)
            {
                Clear(ThingsCKey);
            }
        }

        public void MergeThingC(ThingC ThingC)
        {
            lock (mocker)
            {
                if (ThingC != null)
                    ThingsC[ThingC.Id] = ThingC;
            }
        }

        public void DeleteThingC(ThingC ThingC)
        {
            lock (mocker)
            {
                if (ThingC != null)
                    ThingsC.Remove(ThingC.Id);
            }
        }

        #endregion

        #region ThingDs

        public Dictionary<int, ThingD> ThingsD
        {
            get
            {
                // ** Lazy load pattern 

                if (_memoryCache.Get(ThingsDKey) is not Dictionary<int, ThingD> dictionary)
                {
                    lock (locker)
                    {
                        dictionary = _db.ThingDs.ToDictionary(c => c.Id);
                        Add(ThingsDKey, dictionary, DateTime.Now.AddHours(4));
                    }
                }

                return dictionary;
            }
        }

        // Clear ThingD cache

        public void ClearThingsD()
        {
            lock (locker)
            {
                Clear(ThingsDKey);
            }
        }

        public void MergeThingD(ThingD ThingD)
        {
            lock (mocker)
            {
                if (ThingD != null)
                    ThingsD[ThingD.Id] = ThingD;
            }
        }

        public void DeleteThingD(ThingD ThingD)
        {
            lock (mocker)
            {
                if (ThingD != null)
                    ThingsD.Remove(ThingD.Id);
            }
        }

        #endregion

        #region ThingEs

        public Dictionary<int, ThingE> ThingsE
        {
            get
            {
                // ** Lazy load pattern 

                if (_memoryCache.Get(ThingsEKey) is not Dictionary<int, ThingE> dictionary)
                {
                    lock (locker)
                    {
                        dictionary = _db.ThingEs.ToDictionary(c => c.Id);
                        Add(ThingsEKey, dictionary, DateTime.Now.AddHours(4));
                    }
                }

                return dictionary;
            }
        }

        // Clear ThingE cache

        public void ClearThingsE()
        {
            lock (locker)
            {
                Clear(ThingsEKey);
            }
        }

        public void MergeThingE(ThingE ThingE)
        {
            lock (mocker)
            {
                if (ThingE != null)
                    ThingsE[ThingE.Id] = ThingE;
            }
        }

        public void DeleteThingE(ThingE ThingE)
        {
            lock (mocker)
            {
                if (ThingE != null)
                    ThingsE.Remove(ThingE.Id);
            }
        }

        #endregion

        #region Users

        public Dictionary<int, User> Users
        {
            get
            {
                // ** Lazy load pattern 

                if (_memoryCache.Get(UsersKey) is not Dictionary<int, User> dictionary)
                {
                    lock (locker)
                    {
                        dictionary = _db.Users.OrderBy(u => u.LastName).ToDictionary(c => c.Id);
                        Add(UsersKey, dictionary, DateTime.Now.AddHours(4));
                    }
                }

                return dictionary;
            }
        }

        // Clear users cache

        public void ClearUsers()
        {
            lock (locker)
            {
                Clear(UsersKey);
            }
        }

        public void MergeUser(User user)
        {
            lock (mocker)
            {
                Users[user.Id] = user;
            }
        }

        public void DeleteUser(User user)
        {
            lock (mocker)
            {
                // No hard deletes
                Users[user.Id] = user;
            }
        }

        #endregion

        #region Cache Helpers

        // clears single cache entry

        private void Clear(string key)
        {
            lock (locker)
            {
                _memoryCache.Remove(key);

                UsedKeys.Remove(key);
            }
        }

        // clears entire cache

        public void Clear()
        {
            // only host is allowed to clear entire cache

            if (!_currentUser.IsAdmin) return;

            lock (locker)
            {
                foreach (var usedKey in UsedKeys)
                    _memoryCache.Remove(usedKey);

                UsedKeys.Clear();
            }
        }

        // add to cache 

        private void Add(string key, object value, DateTimeOffset expiration)
        {
            _memoryCache.Set(key, value,
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(expiration));

            UsedKeys.Add(key);
        }

        #endregion
    }

    public record MetaType(string Name, string Icon, string Url);
}
