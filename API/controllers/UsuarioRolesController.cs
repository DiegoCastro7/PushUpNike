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
public class UsuarioRolesController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioRolesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UsuarioRoles>>> Get()
        {
            var entidades = await _unitOfWork.UsuarioRoless.GetAllAsync();
            return _mapper.Map<List<UsuarioRoles>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UsuarioRolesDto>> Get(int id)
        {
            var entidad = await _unitOfWork.UsuarioRoless.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<UsuarioRolesDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioRoles>> Post(UsuarioRolesDto UsuarioRolesDto)
        {
            var entidad = _mapper.Map<UsuarioRoles>(UsuarioRolesDto);
            this._unitOfWork.UsuarioRoless.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            UsuarioRolesDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = UsuarioRolesDto.Id}, UsuarioRolesDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UsuarioRolesDto>> Put(int id, [FromBody] UsuarioRolesDto UsuarioRolesDto)
        {
            if(UsuarioRolesDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<UsuarioRoles>(UsuarioRolesDto);
            _unitOfWork.UsuarioRoless.Update(entidades);
            await _unitOfWork.SaveAsync();
            return UsuarioRolesDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.UsuarioRoless.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.UsuarioRoless.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
