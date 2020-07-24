using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdHistoricoProductoPrecio
    {
        private readonly HistoricoProductoPrecioRepository _historicoProductoPrecioRepository =
            new HistoricoProductoPrecioRepository();

        public void Create(HistoricoProductoPrecio entity)
        {
            //var result = _categoriaValidator.Validate(entity);
            //if (!result.IsValid)
            //    throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.Id != default(int))
                _historicoProductoPrecioRepository.Update(entity);
            else
            {
                //var exist = _categoriaRepository.Exist(x => x.Nombre == entity.Nombre);
                //if (exist)
                //    throw new CustomException("La categoría que intenta registrar ya existe.");
                _historicoProductoPrecioRepository.Create(entity);
            }
        }
    }
}
