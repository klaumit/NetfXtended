namespace NetfXtended.Core
{
    public static class Funcs
    {
        public static ToStrFunc<T> Print<T>()
        {
            return it => $"{it}";
        }
    }
}