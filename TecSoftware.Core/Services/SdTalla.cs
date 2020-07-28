using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdTalla
    {
        private readonly TallaRepository _tallaRepository = new TallaRepository();

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Talla, UniversalExtend>> source)
        {
            return await _tallaRepository.SelectList(source);
        }

        public List<Talla> MostrarTallas()
        {
            return _tallaRepository.DetalleItemTemp;
        }

        public void Agregar(Talla entity)
        {
            _tallaRepository.Agregar(entity);
        }

        public void CleanTalla()
        {
            _tallaRepository.CleanTalla();
        }

        public async Task<Talla> Single(Expression<Func<Talla, bool>> predicate)
        {
            return await _tallaRepository.Single(predicate);
        }

        public async Task Create(Talla entity)
        {
            if (entity.TallaId != default(int))
                await _tallaRepository.Update(entity);
            else
            {
                var exist = await _tallaRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La talla que intenta registrar ya existe.");
                await _tallaRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<Talla, bool>> predicate)
        {
            await _tallaRepository.Delete(predicate);
        }
    }
}
