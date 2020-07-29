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
    public class SdMoneda : ISdMoneda
    {
        private readonly MonedaRepository _monedaRepository = new MonedaRepository();

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Moneda, UniversalExtend>> source)
        {
            return await _monedaRepository.SelectList(source);
        }

        public Task<IEnumerable<UniversalExtend>> ListaMonedas(Expression<Func<Moneda, UniversalExtend>> source)
        {
            var listItem = Task.Run(() => SelectList(source)).Result;
            listItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<Seleccione>>" });
            return (Task<IEnumerable<UniversalExtend>>)listItem;
        }

        public async Task<Moneda> Single(Expression<Func<Moneda, bool>> predicate)
        {
            return await _monedaRepository.Single(predicate);
        }

        public async Task Create(Moneda entity)
        {
            if (entity.MonedaId != default(int))
                await _monedaRepository.Update(entity);
            else
            {
                bool exist = await _monedaRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La Moneda que intenta registrar ya existe.");
                await _monedaRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<Moneda, bool>> predicate)
        {
            await _monedaRepository.Delete(predicate);
        }
    }
}
