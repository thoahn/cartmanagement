﻿using CartManagement.API.Consts;
using CartManagement.API.DTOs;
using CartManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartManagement.API.Filters
{
    public class ProductNotFoundFilter : ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public ProductNotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _productService.GetByIdAsync(id);

            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;
                errorDto.Errors.Add($"{ErrorConsts.PRODUCT_NOT_FOUND} {id}");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
