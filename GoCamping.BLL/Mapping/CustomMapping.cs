using AutoMapper;
using GoCamping.DAL.DBModel;
using GoCamping.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoCamping.BLL.Mapping
{
    public class CustomMapping:Profile
    {
        public CustomMapping()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
       
        }
    }
}
