﻿using AutoMapper;
using GoCamping.BLL.Exceptions;
using GoCamping.BLL.Services.Interface;
using GoCamping.DAL.Repository.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoCamping.BLL.Exceptions;

namespace GoCamping.BLL.Services
{
    public class GenericService<TDto, TEntity> : IGenericService<TDto, TEntity> where TDto : class where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        protected readonly IMapper _mapper;
        private readonly ILogger<GenericService<TDto, TEntity>> _logger;
        public GenericService(IGenericRepository<TEntity> genericRepository, IMapper mapper, ILogger<GenericService<TDto, TEntity>> logger)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TDto> AddAsync(TDto item)
        {
            try
            {
                _logger.LogInformation("Open");

                TEntity entity = _mapper.Map<TEntity>(item);
                TEntity dbEntity = await _genericRepository.AddAsync(entity);
                return _mapper.Map<TDto>(dbEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                throw new CustomException("BLL də əlavə edillərkən xəta yarandı. Xahiş olunur adminsitrator ilə əlaqə saxla.");

            }
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
            _logger.LogInformation("Delete");
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            try
            {
                TEntity entity = await _genericRepository.GetByIdAsync(id);
                return _mapper.Map<TDto>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                throw new CustomException("BLL də əlavə edillərkən xəta yarandı. Xahiş olunur adminsitrator ilə əlaqə saxla.");
            }

        }

        public async Task<List<TDto>> GetListAsync()
        {
            var list = await _genericRepository.GetListAsync();
            List<TDto> dtos = _mapper.Map<List<TDto>>(list);
            return dtos;
        }

        public TDto Update(TDto item)
        {
            try
            {
                _logger.LogInformation("Update edildi.");
                TEntity entity = _mapper.Map<TEntity>(item);
                TEntity dbEntity = _genericRepository.Update(entity);

                return _mapper.Map<TDto>(dbEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                throw new CustomException("BLL də əlavə edillərkən xəta yarandı. Xahiş olunur adminsitrator ilə əlaqə saxla.");
            }
        }
    }
}
