using Mono.Cecil;

namespace SheepAspect.Core
{
    public interface IWeaver
    {
        /// <summary>
        /// Weavers with lower priority values will get processed earlier during compilation
        /// This is useful to ensure certain weavers only get executed after all others, hence ensuring it will not get overruled by accident
        /// </summary>
        int Priority { get; }
        void Weave();
        ModuleDefinition Module { get; }
    }
}