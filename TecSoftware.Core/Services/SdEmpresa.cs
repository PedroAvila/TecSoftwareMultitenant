using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdEmpresa
    {
        private readonly EmpresaRepository _empresaRepository = new EmpresaRepository();
        private readonly EmpresaValidator _empresaValidator = new EmpresaValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Empresa, UniversalExtend>> source)
        {
            return _empresaRepository.SelectList(source).ToList();
        }

        public IEnumerable<UniversalExtend> ListaEmpresa(Expression<Func<Empresa, UniversalExtend>> source)
        {
            var listaItem = SelectList(source).ToList();
            listaItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return listaItem;
        }

        public Empresa Single(Expression<Func<Empresa, bool>> predicate)
        {
            return _empresaRepository.Single(predicate);
        }

        public void Create(Empresa entity)
        {
            var result = _empresaValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.EmpresaId != default(int))
                _empresaRepository.Update(entity);
            else
            {
                bool exist = _empresaRepository.Exist(x => x.RazonSocial == entity.RazonSocial);
                if (exist)
                    throw new CustomException("La Empresa que intenta registrar ya existe.");
                _empresaRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<Empresa, bool>> predicate)
        {
            _empresaRepository.Delete(predicate);
        }
    }
}
