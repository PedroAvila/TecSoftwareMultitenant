using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdAreaNegocio
    {
        private readonly AreaNegocioRepository _areaNegocioRepository = new AreaNegocioRepository();

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<AreaNegocio, UniversalExtend>> source)
        {
            return await _areaNegocioRepository.SelectList(source);
        }

        public Task<IEnumerable<UniversalExtend>> ListaAreaNegocio(Expression<Func<AreaNegocio, UniversalExtend>> source)
        {
            var listaItem = Task.Run(() => SelectList(source)).Result;
            listaItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return (Task<IEnumerable<UniversalExtend>>)listaItem;
        }

        public async Task<AreaNegocio> Single(Expression<Func<AreaNegocio, bool>> predicate)
        {
            return await _areaNegocioRepository.Single(predicate);
        }

        public async Task Create(AreaNegocio entity)
        {
            if (entity.AreaNegocioId != default)
                await _areaNegocioRepository.Update(entity);
            else
            {
                bool exist = await _areaNegocioRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El Área de negocio que intenta registrar ya existe.");
                await _areaNegocioRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<AreaNegocio, bool>> predicate)
        {
            await _areaNegocioRepository.Delete(predicate);
        }
    }
}
