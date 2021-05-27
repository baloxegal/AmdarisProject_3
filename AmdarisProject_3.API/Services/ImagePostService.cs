using AmdarisProject_3.Domain.Models;
using AmdarisProject_3.Domain.Models.Dtos;
using AmdarisProject_3.Infrastucture.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisProject_3.API.Services
{
    public class ImagePostService
    {
        private readonly IRepository<ImagePost, long> _repository;
        private readonly IMapper _mapper;

        public ImagePostService(IRepository<ImagePost, long> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<ImagePostDto>>> GetEntities()
        {
            var result = await _repository.GetEntities();

            return result.Value.Select(res => _mapper.Map(res, new ImagePostDto())).ToList();             
        }

        public async Task<ActionResult<ImagePostDto>> GetEntity(long identityKey)
        {
            var result = await _repository.GetEntity(identityKey);

            return _mapper.Map(result.Value, new ImagePostDto());
        }

        public async Task<IActionResult> UpdateEntity(ImagePostDto entity, long identityKey)
        {
            var baseEntity = await _repository.GetEntity(identityKey);
            if (baseEntity.Value == null)
            {
                return new BadRequestObjectResult(new { message = $"Entity with identity key {identityKey} doesn't exist" });
            }

            _mapper.Map(entity, baseEntity.Value);            

            return await _repository.Save();
        }

        public async Task<IActionResult> CreateEntity(ImagePostDto entity)
        {
            var baseEntity = _mapper.Map(entity, new ImagePost());
            try
            {
                return await _repository.CreateEntity(baseEntity);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = $"Entity wasn't created. " + ex.Message });
            }
        }

        public async Task<IActionResult> DeleteEntity(long identityKey)
        {
            var baseEntity = await _repository.GetEntity(identityKey);
            if (baseEntity.Value == null)
            {
                return new BadRequestObjectResult(new { message = $"Entity with identity key {identityKey} doesn't exist" });
            }

            try
            {
                return await _repository.Remove(baseEntity.Value);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = $"Entity with identity key {identityKey} doesn't deleted. Error in database. " + ex.Message });
            }
        }
    }
}
