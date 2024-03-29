﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Infrastructure
{
    public class TipoIdentificacionRepository : BaseBusinessRepository<TipoIdentificacion>,
        ITipoIdentificacion<TipoIdentificacion>
    {
        public async Task<IEnumerable<UniversalExtend>> ListaIdentificacionXCodigo()
        {
            using (var context = new BusinessContext())
            {

                var codigos = new List<string> { "04", "05", "06" };
                var list = from t in context.TipoIdentificaciones
                           where codigos.Contains(t.Codigo)
                           select new UniversalExtend() { Id = t.TipoIdentificacionId, Descripcion = t.Nombre };
                return await list.ToListAsync();
            }
        }

        public async Task<List<ICollection<TipoIdentificacion>>> IdentificacionXComprobante(int id)
        {
            //using (var context = new BusinessContext())
            //{
            //    var list = await context.Comprobantes
            //        .Where(x => x.ComprobanteId == id)
            //        .Select(c => c.TipoIdentificaciones).ToListAsync();

            //    return list;
            //}
            throw new NotImplementedException();
        }

        //public IQueryable<List<TipoIdentificacion>> xxxxx(int id)
        //{
        //    using (var context = new BusinessContext())
        //    {
        //        var list = from c in context.Comprobantes
        //            .Include("TipoIdentificaciones")
        //            .Where(x => x.ComprobanteId.Equals(id))
        //                   select (c.TipoIdentificaciones).ToList();

        //        return list;
        //    }
        //}

        /// <summary>
        /// No esta en uso.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TipoIdentificacionExtend>> ListaVinculacionDatos
            (Expression<Func<TipoIdentificacion, TipoIdentificacionExtend>> source)
        {
            using (var context = new BusinessContext())
            {
                var result = await context.Set<TipoIdentificacion>().AsNoTracking()
                    .Select(source).ToListAsync();
                return result;
            }
        }
    }
}
