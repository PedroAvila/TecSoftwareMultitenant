using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdMarca
    {
        private readonly MarcaRepository _marcaRepository = new MarcaRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Marca, UniversalExtend>> source)
        {
            return await _marcaRepository.SelectList(source);
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Marca, bool>> predicate,
            Expression<Func<Marca, UniversalExtend>> source)
        {
            return await _marcaRepository.SelectList(predicate, source);
        }

        public async Task Create(Marca entity)
        {
            if (entity.MarcaId != default(int))
                await _marcaRepository.Update(entity);
            else
            {
                var exist = await _marcaRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La marca que intenta registrar ya existe.");
                await _marcaRepository.Create(entity);
            }
        }
    }
}
