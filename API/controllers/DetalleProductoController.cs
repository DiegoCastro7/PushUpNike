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
public class DetalleProductoController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetalleProductoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DetalleProducto>>> Get()
        {
            var entidades = await _unitOfWork.DetalleProductos.GetAllAsync();
            return _mapper.Map<List<DetalleProducto>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleProductoDto>> Get(int id)
        {
            var entidad = await _unitOfWork.DetalleProductos.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<DetalleProductoDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleProducto>> Post(DetalleProductoDto DetalleProductoDto)
        {
            var entidad = _mapper.Map<DetalleProducto>(DetalleProductoDto);
            this._unitOfWork.DetalleProductos.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            DetalleProductoDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = DetalleProductoDto.Id}, DetalleProductoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleProductoDto>> Put(int id, [FromBody] DetalleProductoDto DetalleProductoDto)
        {
            if(DetalleProductoDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<DetalleProducto>(DetalleProductoDto);
            _unitOfWork.DetalleProductos.Update(entidades);
            await _unitOfWork.SaveAsync();
            return DetalleProductoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.DetalleProductos.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.DetalleProductos.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
