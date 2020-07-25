using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Infrastructure
{
    public class RecuentoRepository : BaseInquilinoRepository<Recuento>, IRecuento<Recuento>
    {
        public async Task<IEnumerable<CierreCajaExtend>> MostrarCierreCaja(int operacion, int puntoEmision)
        {
            using (var context = new BusinessContext())
            {
                var result = await context.CierreCajaExtends.FromSqlRaw(
                    "SELECT e.Nombre AS NombreEstablecimiento, pe.Nombre AS NombrePuntoEmision, " +
                    "o.FechaApertura, o.FechaCierre, u.Nombre AS NombreUsuario, " +
                    "SUM(mc.MontoInicial) AS MontoInicial, SUM(mc.Ingreso)AS Ingreso, SUM(mc.Egreso)AS Egreso, " +
                    "SUM(mc.Ingreso) - SUM(mc.Egreso)AS Saldo, " +
                    "SUM(mc.MontoInicial) + SUM(mc.Ingreso) - SUM(mc.Egreso) AS MontoInicialSaldo " +
                    "FROM dbo.MovimientoCajas mc " +
                    "JOIN dbo.Operaciones o ON mc.OperacionId = o.OperacionId " +
                    "JOIN dbo.PuntoEmisiones pe  ON  o.PuntoEmisionId = pe.PuntoEmisionId " +
                    "JOIN dbo.Establecimientos e ON pe.EstablecimientoId = e.EstablecimientoId " +
                    "JOIN dbo.Usuarios u ON mc.UsuarioId = u.UsuarioId " +
                    "WHERE o.OperacionStatus = 2  " +
                    "AND o.OperacionId = @operacion AND o.PuntoEmisionId = @puntoEmision " +
                    "GROUP BY e.Nombre, pe.Nombre, o.FechaApertura, o.FechaCierre, u.Nombre",
                        new SqlParameter("@operacion", operacion),
                        new SqlParameter("@puntoEmision", puntoEmision)).ToListAsync();
                return result;
            }

        }

        public async Task<IEnumerable<RecuentoDenominacionExtend>> MostrarRecuentoDenominacion(int operacion)
        {
            using (var context = new BusinessContext())
            {
                var result = await context.RecuentoDenominacionExtends.FromSqlRaw(
                    "SELECT d.Nombre, r.Cantidad, d.Valor, r.Cantidad * d.Valor as Total" +
                    " FROM dbo.Denominaciones d" +
                    " JOIN dbo.Recuentos r ON r.DenominacionId = d.DenominacionId" +
                    " JOIN dbo.Operaciones o ON r.OperacionId = o.OperacionId" +
                    " WHERE r.OperacionId = @operacion AND r.Cantidad > 0 AND o.OperacionStatus = 2" +
                    " GROUP BY d.Nombre, r.Cantidad, d.Valor",
                        new SqlParameter("@operacion", operacion)).ToListAsync();
                return result;
            }
        }

    }
}
