using AutoMapper;
using DTO;
using Entities;

namespace OurStore2
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<AddOrderDTO, Order>();
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<OrderItemDTO, OrderItem>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<AddUserDTO, User>();
        }
    }
}
