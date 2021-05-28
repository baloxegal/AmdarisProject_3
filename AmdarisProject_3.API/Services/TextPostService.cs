﻿using AmdarisProject_3.Infrastucture.Repositories;
using AmdarisProject_3.Domain.Models;
using AmdarisProject_3.Domain.Models.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AmdarisProject_3.API.Services
{
    public class TextPostService
    {
        private readonly IRepository<TextPost, long> _repository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public TextPostService(IRepository<TextPost, long> repository, UserManager<User> userManager, IMapper mapper)
        {
            _repository = repository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<TextPostDto>>> GetEntities()
        {
            var result = await _repository.GetEntities();
            var listResult = result.Value.ToList();

            var dtoResult = listResult.Select(res => _mapper.Map(res, new TextPostDto())).ToList();

            for (int i = 0; i < listResult.Count; i++)
            {
                for (int j = 0; j < dtoResult.Count; j++)
                {
                    dtoResult[j].Author = listResult[i].Author.UserName;                   
                }
            }

            return dtoResult;
        }

        public async Task<ActionResult<TextPostDto>> GetEntity(long identityKey)
        {
            var result = await _repository.GetEntity(identityKey);

            var dtoResult = _mapper.Map(result.Value, new TextPostDto());

            if (result.Value.Author != null)
                dtoResult.Author = result.Value.Author.UserName;

            return dtoResult;
        }

        public async Task<IActionResult> UpdateEntity(TextPostDto entity, long identityKey)
        {
            var baseEntity = await _repository.GetEntity(identityKey);
            if (baseEntity.Value == null)
            {
                return new BadRequestObjectResult(new { message = $"Entity with identity key {identityKey} doesn't exist" });
            }

            _mapper.Map(entity, baseEntity.Value);

            if (baseEntity.Value.Author != null)
                baseEntity.Value.Author.UserName = entity.Author;

            return await _repository.Save();
        }

        public async Task<IActionResult> CreateEntity(TextPostDto entity)
        {
            var baseEntity = _mapper.Map(entity, new TextPost());

            var author = _userManager.FindByNameAsync(entity.Author);

            baseEntity.Author = author.Result;

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
