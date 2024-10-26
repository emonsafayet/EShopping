﻿using Asp.Versioning;
using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Specs;
using Catalog.Infrastructure.Repositories;
using DnsClient;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
 
    public class CatalogController : ApiController
    {
        public IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("[action]/{id}",Name = "GetProductById")]
        [ProducesResponseType(typeof(ProductResponse),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ProductResponse>> GetProductById(string id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{productName}", Name = "GetProductByProductName")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)] 
        public async Task<ActionResult<ProductResponse>> GetProductByProductName(string productName)
        {
            var query = new GetProductByNameQuery(productName);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route( "GetAllProducts")]
        [ProducesResponseType(typeof(Pagination<ProductResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Pagination<ProductResponse>>> GetAllProducts([FromQuery] CatalogSpecParams catalogSpecParams)
        {
            var query = new GetAllProductsQuery(catalogSpecParams);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllBrands")]
        [ProducesResponseType(typeof(IList<BrandResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BrandResponse>> GetAllBrands()
        {
            var query = new GetAllBrandsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllTypes")]
        [ProducesResponseType(typeof(IList<TypesResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TypesResponse>> GetAllTypes()
        {
            var query = new GetAllTypesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        } 

        [HttpGet]
        [Route("[action]/{brand}", Name = "GetProductByBrandName")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponse>> GetProductByBrandName(string brand)
        {
            var query = new GetProductByBrandQuery(brand);
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpPost]
        [Route("CreateProduct")]
        [ProducesResponseType(typeof(ProductResponse),(int)HttpStatusCode.OK)]

        public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand productCommand)
        {
            var result = await _mediator.Send<ProductResponse>(productCommand);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponse>> UpdateProduct([FromBody] UpdateProductCommand productCommand)
        {
            var result = await _mediator.Send(productCommand);
            return Ok(result);
        }
        [HttpDelete]
        [Route("{id}",Name = "DeleteProduct")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponse>> DeleteProduct(string id)
        {
            var query = new DeleteProductByIdCommand(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        } 
    }
}
