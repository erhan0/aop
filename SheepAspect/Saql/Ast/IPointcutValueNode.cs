namespace SheepAspect.Saql.Ast
{
    public interface IPointcutValueNode
    {
        object Build(object pointcut);
    }
}