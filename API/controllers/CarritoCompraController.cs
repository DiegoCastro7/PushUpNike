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
public class CarritoCompraController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarritoCompraController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CarritoCompra>>> Get()
        {
            var entidades = await _unitOfWork.CarritoCompras.GetAllAsync();
            return _mapper.Map<List<CarritoCompra>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CarritoCompraDto>> Get(int id)
        {
            var entidad = await _unitOfWork.CarritoCompras.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<CarritoCompraDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CarritoCompra>> Post(CarritoCompraDto CarritoCompraDto)
        {
            var entidad = _mapper.Map<CarritoCompra>(CarritoCompraDto);
            this._unitOfWork.CarritoCompras.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            CarritoCompraDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = CarritoCompraDto.Id}, CarritoCompraDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CarritoCompraDto>> Put(int id, [FromBody] CarritoCompraDto CarritoCompraDto)
        {
            if(CarritoCompraDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<CarritoCompra>(CarritoCompraDto);
            _unitOfWork.CarritoCompras.Update(entidades);
            await _unitOfWork.SaveAsync();
            return CarritoCompraDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.CarritoCompras.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.CarritoCompras.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
