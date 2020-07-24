using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdAlmacen
    {
        private readonly AlmacenRepository _almacenRepository = new AlmacenRepository();
        //private readonly AlmacenValidator _almacenValidator = new AlmacenValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Almacen, UniversalExtend>> source)
        {
            return _almacenRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> SelectList
            (Expression<Func<Almacen, bool>> predicate, Expression<Func<Almacen, UniversalExtend>> source)
        {
            return _almacenRepository.SelectList(predicate, source);
        }

        public IEnumerable<UniversalExtend> ListarBodega
            (Expression<Func<Almacen, bool>> predicate, Expression<Func<Almacen, UniversalExtend>> source)
        {
            var listaItem = SelectList(predicate, source).ToList();
            listaItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return listaItem;
        }

        public Almacen Single(Expression<Func<Almacen, bool>> predicate)
        {
            return _almacenRepository.Single(predicate);
        }

        public void Create(Almacen entity)
        {
            if (entity.AlmacenId != default)
                _almacenRepository.Update(entity);
            else
            {
                bool exist = _almacenRepository.Exist(x => x.EstablecimientoId == entity.EstablecimientoId
                 && x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El almacén que intenta registrar ya existe.");
                _almacenRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<Almacen, bool>> predicate)
        {
            _almacenRepository.Delete(predicate);
        }
    }
}
