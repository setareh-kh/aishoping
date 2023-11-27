
using Aishopping.DTos.Requests;
using Aishopping.DTos.Responses;
using Aishopping.Models;
using AutoMapper;


namespace Aishopping.Mapper
{
    public class AiShoppingMapperProfile:Profile
    {
        public AiShoppingMapperProfile()
        {
            // mapping requestes
            CreateMap<AddProduct,Product>();
            CreateMap<AddUser,User>();
            CreateMap<AddOrder,Order>();
            CreateMap<UpdateProduct,Product>();
            CreateMap<UpdateUser,User>();
            CreateMap<UpdateOrder,Order>();
            // mapping responses
            CreateMap<Product, ProductResponseDto>();
            CreateMap<User, UserResponseDto>().ForMember(userResponseDto => userResponseDto.FullName,user=>user.MapFrom(user=> String.Concat(user.FirstName," ",user.LastName)));
            CreateMap<Order,OrderResponseDto>();
        }
    }
}