namespace Clientes.Dominio.Core.Extensoes
{
    public static class ObjectExtensions
    {
        public static bool NaoENulo(this object objeto)
        {
            return objeto != null;
        }

        public static bool ENulo(this object objeto)
        {
            return objeto == null;
        }
    }
}
