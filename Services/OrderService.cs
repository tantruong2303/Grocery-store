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

        public void CreateOrderHandler(CreateOrderDTO input, ViewDataDictionary dataView, Dictionary<string, CartItem> cart)
        {
            User customer = (User)dataView["user"];
            Order order = new Order();
            order.OrderId = Guid.NewGuid().ToString();
            order.Status = OrderStatus.ACTIVE;
            order.Total = 0;
            order.Profit = 0;
            order.CreateDate = DateTime.Now.ToShortDateString();
            order.PaymentMethod = input.PaymentMethod;
            order.CustomerId = customer.UserId;
            this.DBContext.Order.Add(order);
            this.DBContext.SaveChanges();


            foreach (var cartItem in cart)
            {
                Product product = this.ProductService.GetProductById(cartItem.Key);
                OrderItem orderItem = new OrderItem();
                orderItem.OrderItemId = Guid.NewGuid().ToString();
                orderItem.Quantity = cartItem.Value.Quantity;
                orderItem.CreateDate = DateTime.Now.ToShortDateString();
                orderItem.SalePrice = product.RetailPrice;
                orderItem.OrderId = order.OrderId;
                orderItem.ProductId = product.ProductId;
                this.DBContext.OrderItem.Add(orderItem);
                this.DBContext.SaveChanges();

                order.Total += product.RetailPrice;
                order.Profit += (product.RetailPrice - product.OriginalPrice);

                product.Quantity -= orderItem.Quantity;
            }

            this.DBContext.SaveChanges();

        }
    }
}