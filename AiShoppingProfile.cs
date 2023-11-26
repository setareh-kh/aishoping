
using Aishopping.DTos.Requests;
using Aishopping.Models;
using AutoMapper;


namespace Aishopping.Mapper
{
    public class AiShoppingMapperProfile:Profile
    {
        public AiShoppingMapperProfile()
        {
            CreateMap<AddProduct,Product>();
            CreateMap<AddUser,User>();
            CreateMap<AddOrder,Order>();
            CreateMap<UpdateProduct,Product>();
            CreateMap<UpdateUser,User>();
            CreateMap<UpdateOrder,Order>();
        }
    }
}