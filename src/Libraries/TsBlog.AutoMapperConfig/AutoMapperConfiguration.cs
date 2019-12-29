using AutoMapper;
using TsBlog.Domain.Entities;
using TsBlog.ViewModel.Post;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.AutoMapperConfig
{
    public static class AutoMapperConfiguration
    {
        public static void Init()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {

                #region Post
                // Mapping domain entities to view entities
                cfg.CreateMap<Post, PostViewModel>()
                    .ForMember(D => D.IsDeleted,  D => D.MapFrom( s => s.IsDeleted)); // Mapping Boolean type to string type yes / no

                // Mapping view entities to domain entities
                cfg.CreateMap<PostViewModel, Post>();
                #endregion
            });

            Mapper = MapperConfiguration.CreateMapper();
        }

        public static IMapper Mapper { get; private set; }
        public static MapperConfiguration MapperConfiguration { get; private set; }
    }
}
