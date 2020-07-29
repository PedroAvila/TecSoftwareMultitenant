using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdOrdenCompra : ISdOrdenCompra
    {
        private readonly OrdenCompraRepository _ordenCompraRepository = new OrdenCompraRepository();

        public async Task Registrar(OrdenCompra entity)
        {
            entity.NumeroOrden = await _ordenCompraRepository.GenerarCodigo();
            await _ordenCompraRepository.Registrar(entity);
        }

        public async Task<IEnumerable<OrdenCompraExtend>> ListarOrdenCompra(int ordenCompraId)
        {
            return await _ordenCompraRepository.ListarOrdenCompra(ordenCompraId);
        }

        public async Task<OrdenCompra> Single(Expression<Func<OrdenCompra, bool>> predicate,
            List<Expression<Func<OrdenCompra, object>>> includes)
        {
            return await _ordenCompraRepository.Single(predicate, includes);
        }
    }
}
