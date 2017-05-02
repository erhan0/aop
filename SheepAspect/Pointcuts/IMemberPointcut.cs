namespace SheepAspect.Pointcuts.Impl
{
    public interface IMemberPointcut<in TDefinition>: ITypePointcut
    {
        bool Match(TDefinition def);
        bool MatchFull(TDefinition def);
    }
}