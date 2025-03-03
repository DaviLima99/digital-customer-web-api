﻿using Domain.Contracts.UseCases.AddCustomer;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.AddCostumer;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddCustomerController : Controller
    {
        private readonly IAddCustomerUseCase _addCustomerUseCase;


        public AddCustomerController(IAddCustomerUseCase addCustomerUseCase)
        {
            _addCustomerUseCase = addCustomerUseCase;
        }

        [HttpPost]
        public IActionResult AddCustomer(AddCustomerInput input)
        {
            // ChamarUseCase para adicionar o customer
            var customer = new Domain.Entities.Customer(input.Name, input.Email, input.Document);
            _addCustomerUseCase.AddCustomer(customer);
            return Created("", customer);
        }
    }
}
