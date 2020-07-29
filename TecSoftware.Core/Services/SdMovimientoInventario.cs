using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdMovimientoInventario : ISdMovimientoInventario
    {
        private readonly MovimientoInventarioRepository _movimientoInventarioRepository
            = new MovimientoInventarioRepository();

        public async Task<decimal> ObtenerCantidadSaldoFinal(int producto)
        {
            return await _movimientoInventarioRepository.ObtenerCantidadSaldoFinal(producto);
        }

        public async Task Create(MovimientoInventario entity)
        {
            //var result = _productoAlmacenValidator.Validate(entity);
            //if (!result.IsValid)
            //    throw new CustomException(Validator.GetErrorMessages(result.Errors));
            //if (entity.ProductoAlmacenId != default)
            //    _productoAlmacenRepository.Update(entity);
            //else
            //{
            //    bool exist = _productoAlmacenRepository.Exist(x =>

            //    x.AlmacenId == entity.AlmacenId && x.ProductoId == entity.ProductoId
            //         && x.PresentacionId == entity.PresentacionId);
            //    if (exist)
            //        throw new CustomException("El producto almacén que intenta registrar ya existe.");
            //    _productoAlmacenRepository.Create(entity);
            //}
            await _movimientoInventarioRepository.Create(entity);
        }
    }
}
