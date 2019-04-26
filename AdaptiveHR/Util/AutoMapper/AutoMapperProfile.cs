using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Util.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            pdsDTOMap();
        }

        private void pdsDTOMap(){
            CreateMap<Pds, PDSDTO>().IgnoreAllNonExisting();
        }


    }
}
