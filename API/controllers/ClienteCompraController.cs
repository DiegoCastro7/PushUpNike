using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class ClienteCompraController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClienteCompraController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteCompra>>> Get()
        {
            var entidades = await _unitOfWork.ClienteCompras.GetAllAsync();
            return _mapper.Map<List<ClienteCompra>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteCompraDto>> Get(int id)
        {
            var entidad = await _unitOfWork.ClienteCompras.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<ClienteCompraDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteCompra>> Post(ClienteCompraDto ClienteCompraDto)
        {
            var entidad = _mapper.Map<ClienteCompra>(ClienteCompraDto);
            this._unitOfWork.ClienteCompras.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            ClienteCompraDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = ClienteCompraDto.Id}, ClienteCompraDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteCompraDto>> Put(int id, [FromBody] ClienteCompraDto ClienteCompraDto)
        {
            if(ClienteCompraDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<ClienteCompra>(ClienteCompraDto);
            _unitOfWork.ClienteCompras.Update(entidades);
            await _unitOfWork.SaveAsync();
            return ClienteCompraDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.ClienteCompras.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.ClienteCompras.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
