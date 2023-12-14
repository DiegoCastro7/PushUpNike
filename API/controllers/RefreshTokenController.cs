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
public class RefreshTokenController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RefreshTokenController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RefreshToken>>> Get()
        {
            var entidades = await _unitOfWork.RefreshTokens.GetAllAsync();
            return _mapper.Map<List<RefreshToken>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RefreshTokenDto>> Get(int id)
        {
            var entidad = await _unitOfWork.RefreshTokens.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<RefreshTokenDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RefreshToken>> Post(RefreshTokenDto RefreshTokenDto)
        {
            var entidad = _mapper.Map<RefreshToken>(RefreshTokenDto);
            this._unitOfWork.RefreshTokens.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            RefreshTokenDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = RefreshTokenDto.Id}, RefreshTokenDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RefreshTokenDto>> Put(int id, [FromBody] RefreshTokenDto RefreshTokenDto)
        {
            if(RefreshTokenDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<RefreshToken>(RefreshTokenDto);
            _unitOfWork.RefreshTokens.Update(entidades);
            await _unitOfWork.SaveAsync();
            return RefreshTokenDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.RefreshTokens.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.RefreshTokens.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
