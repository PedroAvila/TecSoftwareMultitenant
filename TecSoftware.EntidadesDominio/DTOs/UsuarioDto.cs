namespace TecSoftware.EntidadesDominio
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public int RolId { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public byte[] Foto { get; set; }
        public UsuarioStatus Estado { get; set; }
    }
}
