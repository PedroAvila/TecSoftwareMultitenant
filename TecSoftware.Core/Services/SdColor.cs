using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdColor : ISdColor
    {
        private readonly ColorRepository _colorRepository = new ColorRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Colour, UniversalExtend>> source)
        {
            return await _colorRepository.SelectList(source);
        }

        public List<Colour> MostrarColors()
        {
            return _colorRepository.DetalleItemTemp;
        }

        public void Agregar(Colour entity)
        {
            _colorRepository.Agregar(entity);
        }

        public void CleanColor()
        {
            _colorRepository.CleanColor();
        }

        public async Task<Colour> Single(Expression<Func<Colour, bool>> predicate)
        {
            return await _colorRepository.Single(predicate);
        }

        public async Task Create(Colour entity)
        {
            if (entity.ColorId != default)
                await _colorRepository.Update(entity);
            else
            {
                var exist = await _colorRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El color que intenta registrar ya existe.");
                await _colorRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<Colour, bool>> predicate)
        {
            await _colorRepository.Delete(predicate);
        }
    }
}
