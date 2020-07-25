using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdListaPrecio
    {
        private readonly ListaPrecioRepository _listaPrecioRepository = new ListaPrecioRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<ListaPrecio, UniversalExtend>> source)
        {
            return await _listaPrecioRepository.SelectList(source);
        }


        public async Task<ListaPrecio> Single(Expression<Func<ListaPrecio, bool>> predicate)
        {
            return await _listaPrecioRepository.Single(predicate);
        }

        public async Task Create(ListaPrecio entity)
        {
            if (entity.ListaPrecioId != default(int))
                await _listaPrecioRepository.Update(entity);
            else
            {
                bool exist = await _listaPrecioRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La lista que intenta registrar ya existe.");
                await _listaPrecioRepository.Create(entity);
            }
        }
    }
}
