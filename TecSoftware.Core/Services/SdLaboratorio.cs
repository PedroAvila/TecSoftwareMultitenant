using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdLaboratorio : ISdLaboratorio
    {
        private readonly LaboratorioRepository _laboratorioRepository = new LaboratorioRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Laboratorio, UniversalExtend>> source)
        {
            return await _laboratorioRepository.SelectList(source);
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Laboratorio, bool>> predicate,
            Expression<Func<Laboratorio, UniversalExtend>> source)
        {
            return await _laboratorioRepository.SelectList(predicate, source);
        }

        public async Task Create(Laboratorio entity)
        {
            if (entity.LaboratorioId != default(int))
                await _laboratorioRepository.Update(entity);
            else
            {
                var exist = await _laboratorioRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El laboratorio que intenta registrar ya existe.");
                await _laboratorioRepository.Create(entity);
            }
        }
    }
}
