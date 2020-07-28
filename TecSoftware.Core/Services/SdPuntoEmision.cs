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
    public class SdPuntoEmision
    {
        private readonly PuntoEmisionRepository _puntoEmisionRepository = new PuntoEmisionRepository();

        public IEnumerable<PuntoEmision> GetAll()
        {
            return _puntoEmisionRepository.GetAll();
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<PuntoEmision, UniversalExtend>> source)
        {
            return await _puntoEmisionRepository.SelectList(source);
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList
            (Expression<Func<PuntoEmision, bool>> predicate, Expression<Func<PuntoEmision, UniversalExtend>> source)
        {
            return await _puntoEmisionRepository.SelectList(predicate, source);
        }

        public Task<IEnumerable<UniversalExtend>> ListaPuntoEmision(Expression<Func<PuntoEmision, bool>> predicate,
            Expression<Func<PuntoEmision, UniversalExtend>> source)
        {
            var listaItem = Task.Run(() => SelectList(predicate, source)).Result;
            listaItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return (Task<IEnumerable<UniversalExtend>>)listaItem;
        }

        public async Task<IEnumerable<PuntoEmision>> Filter
            (Expression<Func<PuntoEmision, bool>> predicate, List<Expression<Func<PuntoEmision, object>>> includes)
        {
            return await _puntoEmisionRepository.Filter(predicate, includes);
        }

        public async Task<PuntoEmision> Single(Expression<Func<PuntoEmision, bool>> predicate)
        {
            return await _puntoEmisionRepository.Single(predicate);
        }

        public async Task<bool> Exist(Expression<Func<PuntoEmision, bool>> predicate)
        {
            return await _puntoEmisionRepository.Exist(predicate);
        }

        public async Task Create(PuntoEmision entity)
        {
            if (entity.PuntoEmisionId != default(int))
                await _puntoEmisionRepository.Update(entity);
            else
            {
                bool exist =
                    await _puntoEmisionRepository.Exist(
                        x => x.EstablecimientoId == entity.EstablecimientoId && x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El Punto de emisión que intenta registrar ya existe.");
                await _puntoEmisionRepository.Create(entity);
            }
        }

        public async Task Update(PuntoEmision entity)
        {
            await _puntoEmisionRepository.Update(entity);
        }

        public async Task UpdatePuntoEmision(PuntoEmision entity)
        {
            await _puntoEmisionRepository.UpdatePuntoEmision(entity);
        }

        public async Task Delete(Expression<Func<PuntoEmision, bool>> predicate)
        {
            await _puntoEmisionRepository.Delete(predicate);
        }

        public async Task<IEnumerable<UniversalExtend>> ListaPtoEmision()
        {
            return await _puntoEmisionRepository.ListaPtoEmision();
        }

        public async Task<IEnumerable<UniversalExtend>> ListaPtoEmision(int id)
        {
            return await _puntoEmisionRepository.ListaPtoEmision(id);
        }

        public async Task<string> NumeroSerie(int puntoEmision)
        {
            return await _puntoEmisionRepository.NumeroSerie(puntoEmision);
        }
    }
}
