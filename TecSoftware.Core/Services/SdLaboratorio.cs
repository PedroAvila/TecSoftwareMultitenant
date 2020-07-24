using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdLaboratorio
    {
        private readonly LaboratorioRepository _laboratorioRepository = new LaboratorioRepository();
        private readonly LaboratorioValidator _laboratorioValidator = new LaboratorioValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Laboratorio, UniversalExtend>> source)
        {
            return _laboratorioRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Laboratorio, bool>> predicate,
            Expression<Func<Laboratorio, UniversalExtend>> source)
        {
            return _laboratorioRepository.SelectList(predicate, source);
        }

        public void Create(Laboratorio entity)
        {
            var result = _laboratorioValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.LaboratorioId != default(int))
                _laboratorioRepository.Update(entity);
            else
            {
                var exist = _laboratorioRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El laboratorio que intenta registrar ya existe.");
                _laboratorioRepository.Create(entity);
            }
        }
    }
}
