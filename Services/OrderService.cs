using Backend.Services.Interface;
using System.Collections.Generic;
using System;
using Backend.Controllers.DTO;
using FluentValidation.Results;
using Backend.Utils.Common;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Backend.Utils;
using Backend.DAO.Interface;
using Backend.Utils.Locale;
using Backend.Models;

namespace Backend.Services
{
    public class OrderService : IOrderService
    {
        private readonly DBContext dBContext;
        private readonly IOrderRepository OrderRepository;
        public OrderService(DBContext dBContext, IOrderRepository orderRepository)
        {
            this.dBContext = dBContext;
            this.OrderRepository = orderRepository;
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
    }
}