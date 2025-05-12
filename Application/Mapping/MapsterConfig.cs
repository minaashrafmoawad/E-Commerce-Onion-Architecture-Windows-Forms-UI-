using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using Applications.DTOs;
using Castle.Components.DictionaryAdapter.Xml;
using Mapster;
using Models;

namespace Application.Mapping
{
    public class MapsterConfig
    {
        public static void Configure()
        {
            // User Mapping
            TypeAdapterConfig<User, UserDTO>.NewConfig()
                .Map(dest => dest.Role, src => src.Role.ToString());

            // Product Mapping
            TypeAdapterConfig<Product, ProductDTO>.NewConfig()
                .Map(dest => dest.CategoryName, src => src.Category.Name);

            // Category Mapping
            TypeAdapterConfig<Category, CategoryDTO>.NewConfig();

            // CartItem Mapping
            TypeAdapterConfig<CartItem, CartItemDTO>.NewConfig()
                 .Map(dest => dest.ProductName, src => src.Product.Name)
                 .Map(dest => dest.Price, src => src.Product.Price)
                 .Map(dest => dest.Quantity, src => src.Quantity)
                 .Map(dest => dest.TotalPrice, src => src.Quantity * src.Product.Price);


            // Order Mapping
            TypeAdapterConfig<Order, OrderDTO>.NewConfig()
                .Map(dest => dest.Status, src => src.Status.ToString());

            // OrderDetail Mapping
            TypeAdapterConfig<OrderDetail, OrderDetailDTO>.NewConfig()
                .Map(dest => dest.ProductName, src => src.Product.Name)
                .Map(dest => dest.Price, src => src.Product.Price);

            TypeAdapterConfig<Models.Order, OrderDTO>
                .NewConfig()
                .Map(dest => dest.OrderDetails, src => src.OrderDetails);

            

        }
    }
}
