using Marvin.Web.Domain;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web
{
    #region Interface

    public interface IRollup
    {
        void Startup();

        Task RollupAllAsync();

        Task RollupThingAAsync(int? id);
        Task RollupThingBAsync(int? id);
        Task RollupThingCAsync(int? id);
        Task RollupThingDAsync(int? id);
        Task RollupThingEAsync(int? id);
        Task RollupUserAsync(int? id);
    }

    #endregion

    public class Rollup : IRollup
    {
        #region Dependency Injection

        private readonly UltraContext _db;

        public Rollup(UltraContext db) { _db = db; }

        #endregion

        #region Global Rollups

        public void Startup()
        {
            Task.Run(RollupAllAsync).GetAwaiter().GetResult();
        }

        public async Task RollupAllAsync()
        {
            // Refresh denormalized columns

            await RollupThingsAAsync();
            await RollupThingsBAsync();
            await RollupThingsCAsync();
            await RollupThingsDAsync();
            await RollupThingsEAsync();
            await RollupUsersAsync();
        }

        #endregion

        #region Table Rollups

        private async Task RollupThingsAAsync()
        {
            string sql =
            @"UPDATE [ThingA] 
                 SET OwnerAlias = (SELECT Alias FROM [User] WHERE [User].Id = [ThingA].OwnerId),
                     ThingBName = (SELECT Name FROM [ThingB] WHERE [ThingB].Id = [ThingA].ThingBId),
                     ThingCName = (SELECT Name FROM [ThingC] WHERE [ThingC].Id = [ThingA].ThingCId),
                     TotalThingsE = (SELECT COUNT(ThingE.Id) FROM [ThingE] WHERE [ThingE].ThingAId = [ThingA].Id);";

            await _db.Database.ExecuteSqlRawAsync(sql);
        }

        private async Task RollupThingsBAsync()
        {
            string sql =
            @"UPDATE [ThingB] 
                 SET OwnerAlias = (SELECT Alias FROM [User] WHERE [User].Id = [ThingB].OwnerId),
                     TotalThingsA = (SELECT COUNT(ThingA.Id) FROM [ThingA] WHERE [ThingA].ThingBId = [ThingB].Id);";

            await _db.Database.ExecuteSqlRawAsync(sql);
        }

        private async Task RollupThingsCAsync()
        {
            string sql =
           @"UPDATE [ThingC] 
                SET OwnerAlias = (SELECT Alias FROM [User] WHERE [User].Id = [ThingC].OwnerId),
                    TotalThingsA = (SELECT COUNT(ThingA.Id) FROM [ThingA] WHERE [ThingA].ThingCId = [ThingC].Id);";

            await _db.Database.ExecuteSqlRawAsync(sql);
        }

        private async Task RollupThingsDAsync()
        {
            string sql =
             @"UPDATE [ThingD] 
                 SET OwnerAlias = (SELECT Alias FROM [User] WHERE [User].Id = [ThingD].OwnerId),
                     TotalThingsE = (SELECT COUNT(ThingE.Id) FROM [ThingE] WHERE [ThingE].ThingDId = [ThingD].Id);";

            await _db.Database.ExecuteSqlRawAsync(sql);
        }

        private async Task RollupThingsEAsync()
        {
            string sql =
             @"UPDATE [ThingE] 
                 SET OwnerAlias = (SELECT Alias FROM [User] WHERE [User].Id = [ThingE].OwnerId),
                     ThingAName = (SELECT Name FROM [ThingA] WHERE [ThingA].Id = [ThingE].ThingAId),
                     ThingDName = (SELECT Name FROM [ThingD] WHERE [ThingD].Id = [ThingE].ThingDId);";

            await _db.Database.ExecuteSqlRawAsync(sql);
        }

        private async Task RollupUsersAsync()
        {
            string sql =
           @"UPDATE [User] 
            SET TotalThingsA = (SELECT COUNT([ThingA].Id) FROM [ThingA] WHERE [ThingA].OwnerId = [User].Id),
                TotalThingsB = (SELECT COUNT([ThingB].Id) FROM [ThingB] WHERE [ThingB].OwnerId = [User].Id),
                TotalThingsC = (SELECT COUNT([ThingC].Id) FROM [ThingC] WHERE [ThingC].OwnerId = [User].Id),
                TotalThingsD = (SELECT COUNT([ThingD].Id) FROM [ThingD] WHERE [ThingD].OwnerId = [User].Id),
                TotalThingsE = (SELECT COUNT([ThingE].Id) FROM [ThingE] WHERE [ThingE].OwnerId = [User].Id);";

            await _db.Database.ExecuteSqlRawAsync(sql);
        }

        #endregion

        #region Record Rollups

        public async Task RollupThingAAsync(int? id)
        {
            if (id == null) return;

            await _db.Database.ExecuteSqlInterpolatedAsync(
                      $@"UPDATE [ThingA] 
                            SET OwnerAlias = (SELECT Alias FROM [User] WHERE [User].Id = [ThingA].OwnerId),
                                ThingBName = (SELECT Name FROM [ThingB] WHERE [ThingB].Id = [ThingA].ThingBId),
                                ThingCName = (SELECT Name FROM [ThingC] WHERE [ThingC].Id = [ThingA].ThingCId)
                          WHERE Id = {id};");
        }

        public async Task RollupThingBAsync(int? id)
        {
            if (id == null) return;

            await _db.Database.ExecuteSqlInterpolatedAsync(
                     $@"UPDATE [ThingB] 
                           SET OwnerAlias = (SELECT Alias FROM [User] WHERE [User].Id = [ThingB].OwnerId),
                               TotalThingsA = (SELECT COUNT(ThingA.Id) FROM [ThingA] WHERE [ThingA].ThingBId = [ThingB].Id)
                         WHERE Id = {id};");
        }

        public async Task RollupThingCAsync(int? id)
        {
            if (id == null) return;

            await _db.Database.ExecuteSqlInterpolatedAsync(
                      $@"UPDATE [ThingC] 
                            SET OwnerAlias = (SELECT Alias FROM [User] WHERE [User].Id = [ThingC].OwnerId),
                                TotalThingsA = (SELECT COUNT(ThingA.Id) FROM [ThingA] WHERE [ThingA].ThingCId = [ThingC].Id)
                          WHERE Id = {id};");
        }

        public async Task RollupThingDAsync(int? id)
        {
            if (id == null) return;

            await _db.Database.ExecuteSqlInterpolatedAsync(
                      $@"UPDATE [ThingD] 
                            SET OwnerAlias = (SELECT Alias FROM [User] WHERE [User].Id = [ThingD].OwnerId),
                                TotalThingsE = (SELECT COUNT(ThingE.Id) FROM [ThingE] WHERE [ThingE].ThingDId = [ThingD].Id)
                          WHERE Id = {id};");
        }

        public async Task RollupThingEAsync(int? id)
        {
            if (id == null) return;

            await _db.Database.ExecuteSqlInterpolatedAsync(
                    $@"UPDATE [ThingE] 
                          SET OwnerAlias = (SELECT Alias FROM [User] WHERE [User].Id = [ThingE].OwnerId),
                              ThingAName = (SELECT Name FROM [ThingA] WHERE [ThingA].Id = [ThingE].ThingAId),
                              ThingDName = (SELECT Name FROM [ThingD] WHERE [ThingD].Id = [ThingE].ThingDId)
                        WHERE Id = {id};");
        }

        public async Task RollupUserAsync(int? id)
        {
            if (id == null) return;

             await _db.Database.ExecuteSqlInterpolatedAsync(
                       $@"UPDATE [User] 
                             SET TotalThingsA = (SELECT COUNT([ThingA].Id) FROM [ThingA] WHERE [ThingA].OwnerId = [User].Id),
                                 TotalThingsB = (SELECT COUNT([ThingB].Id) FROM [ThingB] WHERE [ThingB].OwnerId = [User].Id),
                                 TotalThingsC = (SELECT COUNT([ThingC].Id) FROM [ThingC] WHERE [ThingC].OwnerId = [User].Id),
                                 TotalThingsD = (SELECT COUNT([ThingD].Id) FROM [ThingD] WHERE [ThingD].OwnerId = [User].Id),
                                 TotalThingsE = (SELECT COUNT([ThingE].Id) FROM [ThingE] WHERE [ThingE].OwnerId = [User].Id)
                           WHERE Id = {id ?? 0};");

        }

        #endregion
    }
}
