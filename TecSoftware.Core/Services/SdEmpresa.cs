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
    public class SdEmpresa : ISdEmpresa
    {
        private readonly EmpresaRepository _empresaRepository = new EmpresaRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Empresa, UniversalExtend>> source)
        {
            return await _empresaRepository.SelectList(source);
        }

        public Task<IEnumerable<UniversalExtend>> ListaEmpresa(Expression<Func<Empresa, UniversalExtend>> source)
        {
            var listaItem = Task.Run(() => SelectList(source)).Result;
            listaItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return (Task<IEnumerable<UniversalExtend>>)listaItem;
        }

        public async Task<Empresa> Single(Expression<Func<Empresa, bool>> predicate)
        {
            return await _empresaRepository.Single(predicate);
        }

        public async Task Create(Empresa entity)
        {
            if (entity.EmpresaId != default(int))
                await _empresaRepository.Update(entity);
            else
            {
                bool exist = await _empresaRepository.Exist(x => x.RazonSocial == entity.RazonSocial);
                if (exist)
                    throw new CustomException("La Empresa que intenta registrar ya existe.");
                await _empresaRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<Empresa, bool>> predicate)
        {
            await _empresaRepository.Delete(predicate);
        }
    }
}
