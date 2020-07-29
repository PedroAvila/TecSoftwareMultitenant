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
    public class SdMedida : ISdMedida
    {
        private readonly MedidaRepository _medidaRepository = new MedidaRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Medida, UniversalExtend>> source)
        {
            return await _medidaRepository.SelectList(source);
        }

        public Task<IEnumerable<UniversalExtend>> ListaMedida(Expression<Func<Medida, UniversalExtend>> source)
        {
            var listItem = Task.Run(() => SelectList(source)).Result;
            listItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<Seleccione>>" });
            return (Task<IEnumerable<UniversalExtend>>)listItem;
        }

        public async Task Create(Medida entity)
        {
            if (entity.MedidaId != default)
                await _medidaRepository.Update(entity);
            else
            {
                var exist = await _medidaRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La medida que intenta registrar ya existe.");
                await _medidaRepository.Create(entity);
            }
        }

        public async Task<Medida> Single(Expression<Func<Medida, bool>> predicate)
        {
            return await _medidaRepository.Single(predicate);
        }

        public async Task Delete(Expression<Func<Medida, bool>> predicate)
        {
            await _medidaRepository.Delete(predicate);
        }
    }
}
