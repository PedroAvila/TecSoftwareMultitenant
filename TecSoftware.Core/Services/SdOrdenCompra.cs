using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdOrdenCompra
    {
        private readonly OrdenCompraRepository _ordenCompraRepository = new OrdenCompraRepository();

        public void Registrar(OrdenCompra entity)
        {
            entity.NumeroOrden = _ordenCompraRepository.GenerarCodigo();
            _ordenCompraRepository.Registrar(entity);
        }

        public IEnumerable<OrdenCompraExtend> ListarOrdenCompra(int ordenCompraId)
        {
            return _ordenCompraRepository.ListarOrdenCompra(ordenCompraId);
        }

        public OrdenCompra Single(Expression<Func<OrdenCompra, bool>> predicate,
            List<Expression<Func<OrdenCompra, object>>> includes)
        {
            return _ordenCompraRepository.Single(predicate, includes);
        }
    }
}
