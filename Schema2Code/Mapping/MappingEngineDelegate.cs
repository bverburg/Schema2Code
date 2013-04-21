using System;
using System.Linq.Expressions;
using AutoMapper;
using Ninject;

namespace Schema2Code.Mapping
{
    public class MappingEngineDelegate : IMappingEngine, IMappingEngineRunner
    {
        private readonly IKernel kernel;

        private MappingEngine mappingEngine;

        private MappingEngine DelegatedMappingEngine
        {
            get { return mappingEngine ?? (mappingEngine = kernel.Get<MappingEngine>()); }
        }

        public MappingEngineDelegate(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public object Map(ResolutionContext context)
        {
            return ((IMappingEngineRunner)DelegatedMappingEngine).Map(context);
        }

        public object CreateObject(ResolutionContext context)
        {
            return ((IMappingEngineRunner)DelegatedMappingEngine).CreateObject(context);
        }

        public string FormatValue(ResolutionContext context)
        {
            return ((IMappingEngineRunner)DelegatedMappingEngine).FormatValue(context);
        }

        public bool ShouldMapSourceValueAsNull(ResolutionContext context)
        {
            return ((IMappingEngineRunner)DelegatedMappingEngine).ShouldMapSourceValueAsNull(context);
        }

        public bool ShouldMapSourceCollectionAsNull(ResolutionContext context)
        {
            return ((IMappingEngineRunner)DelegatedMappingEngine).ShouldMapSourceCollectionAsNull(context);
        }

        public void Dispose()
        {
            DelegatedMappingEngine.Dispose();
        }

        public TDestination Map<TDestination>(object source)
        {
            return DelegatedMappingEngine.Map<TDestination>(source);
        }

        public TDestination Map<TDestination>(object source, Action<IMappingOperationOptions> opts)
        {
            return DelegatedMappingEngine.Map<TDestination>(source, opts);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return DelegatedMappingEngine.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions> opts)
        {
            return DelegatedMappingEngine.Map<TSource, TDestination>(source, opts);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return DelegatedMappingEngine.Map(source, destination);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions> opts)
        {
            return DelegatedMappingEngine.Map(source, destination, opts);
        }

        public object Map(object source, System.Type sourceType, System.Type destinationType)
        {
            return DelegatedMappingEngine.Map(source, sourceType, destinationType);
        }

        public object Map(object source, System.Type sourceType, System.Type destinationType, Action<IMappingOperationOptions> opts)
        {
            return DelegatedMappingEngine.Map(source, sourceType, destinationType, opts);
        }

        public object Map(object source, object destination, System.Type sourceType, System.Type destinationType)
        {
            return DelegatedMappingEngine.Map(source, destination, sourceType, destinationType);
        }

        public object Map(object source, object destination, System.Type sourceType, System.Type destinationType, Action<IMappingOperationOptions> opts)
        {
            return DelegatedMappingEngine.Map(source, destination, sourceType, destinationType, opts);
        }

        public TDestination DynamicMap<TSource, TDestination>(TSource source)
        {
            return DelegatedMappingEngine.DynamicMap<TSource, TDestination>(source);
        }

        public void DynamicMap<TSource, TDestination>(TSource source, TDestination destination)
        {
            DelegatedMappingEngine.DynamicMap(source, destination);
        }

        public TDestination DynamicMap<TDestination>(object source)
        {
            return DelegatedMappingEngine.DynamicMap<TDestination>(source);
        }

        public object DynamicMap(object source, System.Type sourceType, System.Type destinationType)
        {
            return DelegatedMappingEngine.DynamicMap(source, sourceType, destinationType);
        }

        public void DynamicMap(object source, object destination, System.Type sourceType, System.Type destinationType)
        {
            DelegatedMappingEngine.DynamicMap(source, destination, sourceType, destinationType);
        }

        public Expression<Func<TSource, TDestination>> CreateMapExpression<TSource, TDestination>()
        {
            return DelegatedMappingEngine.CreateMapExpression<TSource, TDestination>();
        }

        public TDestination Map<TSource, TDestination>(ResolutionContext parentContext, TSource source)
        {
            return DelegatedMappingEngine.Map<TSource, TDestination>(parentContext, source);
        }

        public IConfigurationProvider ConfigurationProvider
        {
            get { return DelegatedMappingEngine.ConfigurationProvider; }
        }
    }
}
