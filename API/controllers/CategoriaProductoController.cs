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
public class CategoriaProductoController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaProductoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoriaProducto>>> Get()
        {
            var entidades = await _unitOfWork.CategoriaProductos.GetAllAsync();
            return _mapper.Map<List<CategoriaProducto>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaProductoDto>> Get(int id)
        {
            var entidad = await _unitOfWork.CategoriaProductos.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<CategoriaProductoDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaProducto>> Post(CategoriaProductoDto CategoriaProductoDto)
        {
            var entidad = _mapper.Map<CategoriaProducto>(CategoriaProductoDto);
            this._unitOfWork.CategoriaProductos.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            CategoriaProductoDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = CategoriaProductoDto.Id}, CategoriaProductoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaProductoDto>> Put(int id, [FromBody] CategoriaProductoDto CategoriaProductoDto)
        {
            if(CategoriaProductoDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<CategoriaProducto>(CategoriaProductoDto);
            _unitOfWork.CategoriaProductos.Update(entidades);
            await _unitOfWork.SaveAsync();
            return CategoriaProductoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.CategoriaProductos.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoriaProductos.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
