﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Mycity.Data;
using Mycity.Dtos;
using Mycity.Helpers;
using Mycity.Models;

namespace Mycity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;
        IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public PhotosController(IAppRepository appRepository,IMapper mapper,IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _appRepository = appRepository;
            _mapper = mapper;
            _cloudinaryConfig = cloudinaryConfig;
            Account account = new Account
                (_cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }

        [HttpPost]
        public IActionResult AddPhotoForCity(int cityId,[FromBody] PhotoForCreationDto photoForCreationDto)
        {
            var city = _appRepository.GetCityById(cityId);
            if (city==null)
            {
                return BadRequest("Could not find the city");
            }
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (currentUserId!=city.UserId)
            {
                return Unauthorized();
            }
            var file = photoForCreationDto.File;
            var uploadResult = new ImageUploadResult();
            if (file.Length>0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File=new FileDescription(file.Name,stream)
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }
            photoForCreationDto.Url = uploadResult.Uri.ToString();
            photoForCreationDto.PublicId = uploadResult.PublicId;

            var photo = _mapper.Map<Photo>(photoForCreationDto);
            photo.City = city;


            if (!city.Photos.Any(x=>x.IsMain))
            {
                photo.IsMain = true;
            }
            city.Photos.Add(photo);
            if (_appRepository.SaveAll())
            {
                var photoToReturn = _mapper.Map<PhotoForReturnDto>(photo);
                return CreatedAtRoute("GetPhoto", new { id = photo.Id }, photoToReturn);
            }
            return BadRequest("Could not  add the photo");
        }

        [HttpGet()]
        public IActionResult GetPhoto(int id)
        {
            var photoFromDb = _appRepository.GetPhotosByCity(id);
            var photo = _mapper.Map<List<PhotoForReturnDto>>(photoFromDb);
            return Ok(photo);
        }

    }
}