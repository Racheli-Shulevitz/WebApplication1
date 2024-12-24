using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //Get category 
    public record CategoryDTO(string CategoryName);
    

    //Get product
    public record ProductDTO(string ProductName, string Description,double Price,string CategoryCategoryName);




    //Get order by Id
    public record OrderDTO(int OrderId, DateTime OrderDate, double OrderSum, string UserFirstName, List<OrderItemDTO> OrderItems);
    //Add order
    public record AddOrderDTO(DateTime OrderDate, double OrderSum, int UserId, List<OrderItemDTO> OrderItems);




    public record OrderItemDTO(int ProductId, int Quantity);


 
    //Add user
    public record AddUserDTO(string Email, string FirstName, string? LastName,string Password);
    //Get user by Id
    public record UserDTO(string Email, string FirstName, string? LastName, List<OrderDTO> Orders);
}
