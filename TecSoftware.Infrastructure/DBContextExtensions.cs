using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecSoftware.Infrastructure
{
    public static class DBContextExtensions
    {
        private static IHttpContextAccessor _httpContextAccessor;
        private const string customClaimName = "<CLAIM>";

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static HttpContext CurrentHttpContext => _httpContextAccessor.HttpContext;

        //Métodos de extensión

        public static IEnumerable<string> GetEntityKey<T>(this DbContext context, T entity) where T : class
        {
            return context.Model.FindEntityType(entity.GetType()).FindPrimaryKey().Properties.Select(x => x.Name);
        }

        //public static async Task<int> SaveChangesWithTrackerAsync<T>(this DbContext context) where T : class
        //{
        //    //En claim tengo el valor que venga desde la cabecera
        //    CurrentHttpContext.Request.Headers.TryGetValue(customClaimName, out StringValues claim);
        //    context.ChangeTracker.DetectChanges();
        //    var allEntries = context.ChangeTracker.Entries().ToList();
        //    var added = allEntries.Where(e => e.State == EntityState.Added);
        //    var deleted = allEntries.Where(e => e.State == EntityState.Deleted);
        //}
    }
}
