using Backend.Services.Interface;
using System.Collections.Generic;
using System;
using Backend.Controllers.DTO;
using FluentValidation.Results;
using Backend.Utils.Common;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Backend.Utils;
using Backend.DAO.Interface;
using Backend.Models;
using Backend.Utils.Locale;

namespace Backend.Services
{
    public class OrderService : IOrderService
    {
        private readonly DBContext DBContext;
        private readonly IOrderRepository OrderRepository;
        private readonly ICartService CartService;
        private readonly IProductService ProductService;
        public OrderService(IProductService productService, ICartService cartService, DBContext dBContext, IOrderRepository orderRepository)
        {
            this.DBContext = dBContext;
            this.OrderRepository = orderRepository;
            this.CartService = cartService;
            this.ProductService = productService;
        }
        public List<Order> GetOrders(string userId)
        {
            return this.OrderRepository.GetOrders(userId);
        }
        public List<OrderItem> GetOrderDetail(string orderId)
        {
            return this.OrderRepository.GetOrderDetail(orderId);
        }
        public List<Order> GetAllOrders()
        {
            return this.OrderRepository.GetAllOrders();
        }
        public List<Order> SearchOrders(string startDate, string endDate, string search)
        {
            return this.OrderRepository.SearchOrders(startDate, endDate, search);
        }

        public bool CreateOrderHandler(Order order)
        {
            return this.OrderRepository.CreateOrderHandler(order);
        }

        public bool CreateOrderItemHandler(OrderItem orderItem)
        {
            return this.OrderRepository.CreateOrderItemHandler(orderItem);
        }
    }
}