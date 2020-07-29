namespace TecSoftware.EntidadesDominio
{
    public class RolFuncion
    {
        public int RolId { get; set; }
        public int FuncionId { get; set; }

        public virtual Rol Rol { get; set; }
        public virtual Funcion Funcion { get; set; }
    }
}
