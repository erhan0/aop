namespace SheepAspect.Pointcuts
{
    public interface IWhereAny<in T>
    {
        void WhereAny(params T[] pointcuts);
    }
}