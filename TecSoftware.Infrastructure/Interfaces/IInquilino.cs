namespace TecSoftware.Infrastructure
{
    public interface IInquilino<T> where T : class
    {
        void ConexionInquilino(string nombre);
    }
}
