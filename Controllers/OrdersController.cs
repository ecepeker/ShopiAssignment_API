using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopiAssignment.Data;
using ShopiAssignment.Dtos;
using ShopiAssignment.Models;
using System;
using System.Collections.Generic;

namespace ShopiAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepo _repository;

        public OrdersController(IOrderRepo repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpPost]
        [Route("FilterOrder")]

        public ActionResult<IEnumerable<Order>> PostFilterOrder(OrderFilterDto orderFilterDto)
        {
            var orderModel = _mapper.Map<OrderFilterModel>(orderFilterDto);
            var b = _repository.FilterOrder(orderModel);

            return Ok(b);
        }


        [HttpGet]
        public ActionResult<IEnumerable<OrderReadDto>> GetOrders(){


            var orderItem = _repository.GetAllOrders();
            return Ok(_mapper.Map<IEnumerable<OrderReadDto>>(orderItem));
        }

        [HttpGet("{id}", Name = "GetOrderById")]
        public ActionResult<OrderReadDto> GetOrderById(int id) {
            var orderItem = _repository.GetById(id);
            if (orderItem !=null)
            {
                return Ok(_mapper.Map<OrderReadDto>(orderItem));
            }

            return NotFound();  
        }

        [HttpPost]
        [Route("CreateOrder")]

        public ActionResult<OrderReadDto> PostCreateOrder(OrderCreateDto orderCreateDto)
        {

            var orderModel = _mapper.Map<Order>(orderCreateDto);
            _repository.CreateOrder(orderModel);
            _repository.SaveChanges();

            var orderReadDto = _mapper.Map<OrderReadDto>(orderModel);
            return CreatedAtRoute(nameof(GetOrderById), new { Id = orderReadDto.Id }, orderReadDto);
        }

    }
}
