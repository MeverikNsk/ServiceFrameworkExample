namespace Vsk.VooDoo.Core.Module
{
    using AutoMapper;

    public interface IAutoMapperConfiguration
    {
        void RegisterMaps(IProfileExpression cfgMap);
    }
}
