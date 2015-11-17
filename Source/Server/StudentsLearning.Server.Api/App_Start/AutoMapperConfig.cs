namespace StudentsLearning.Server.Api
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;

    using StudentsLearning.Server.Api.Infrastructure.Mapping;
    using Models.ExampleTransferModels;
    using Data.Models;
    using Models.TopicTransferModels;

    #endregion

    public static class AutoMapperConfig
    {
        public static void RegisterMappings(params Assembly[] assemblies)
        {
            var types = new List<Type>();
            foreach (var assembly in assemblies)
            {
                types.AddRange(assembly.GetExportedTypes());
            }

            LoadStandardMappings(types);
            LoadCustomMappings(types);
            ConfigureCustomMappings();
        }

        private static void ConfigureCustomMappings()
        {
            AutoMapper.Mapper.CreateMap<ExampleRequestModel, Example>();
            AutoMapper.Mapper.CreateMap<TopicRequestModel, Topic>();
        }

        private static void LoadStandardMappings(IEnumerable<Type> types)
        {
            var maps =
                types.SelectMany(t => t.GetInterfaces(), (t, i) => new { t, i })
                    .Where(
                        type =>
                        type.i.IsGenericType && type.i.GetGenericTypeDefinition() == typeof(IMapFrom<>)
                        && !type.t.IsAbstract && !type.t.IsInterface)
                    .Select(type => new { Source = type.i.GetGenericArguments()[0], Destination = type.t });

            foreach (var map in maps)
            {
                Mapper.CreateMap(map.Source, map.Destination);
                Mapper.CreateMap(map.Destination, map.Source);
            }
        }

        private static void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps =
                types.SelectMany(t => t.GetInterfaces(), (t, i) => new { t, i })
                    .Where(
                        type =>
                        typeof(IHaveCustomMappings).IsAssignableFrom(type.t) && !type.t.IsAbstract
                        && !type.t.IsInterface)
                    .Select(type => (IHaveCustomMappings)Activator.CreateInstance(type.t));

            foreach (var map in maps)
            {
                map.CreateMappings(Mapper.Configuration);
            }
        }
    }
}