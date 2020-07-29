using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdUbigeo : ISdUbigeo
    {
        private readonly UbigeoRepository _ubigeoRepository = new UbigeoRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Ubigeo, UniversalExtend>> source)
        {
            return await _ubigeoRepository.SelectList(source);
        }

        public Task<IEnumerable<UniversalExtend>> ListaUbigeo(Expression<Func<Ubigeo, UniversalExtend>> source)
        {
            var listItem = Task.Run(() => SelectList(source)).Result;
            listItem.ToList().Insert(0, new UniversalExtend() { Codigo = Convert.ToString(-1), Descripcion = "<<Seleccione>>" });
            return (Task<IEnumerable<UniversalExtend>>)listItem;
        }

        public async Task<Ubigeo> Single(Expression<Func<Ubigeo, bool>> predicate)
        {
            return await _ubigeoRepository.Single(predicate);
        }

        public async Task Create(Ubigeo entity)
        {
            if (entity.UbigeoId != default(int))
                await _ubigeoRepository.Update(entity);
            else
            {
                //bool exist = _ubigeoRepository.Exist(x => x. == entity.Numero);
                //if (exist)
                //    throw new CustomException("El número de documento que intenta registrar ya existe.");
                await _ubigeoRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<Ubigeo, bool>> predicate)
        {
            await _ubigeoRepository.Delete(predicate);
        }
    }
}
