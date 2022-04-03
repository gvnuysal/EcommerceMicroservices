﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using Teknosol.Services.Catalog.Dtos;
using Teknosol.Services.Catalog.Models;
using Teknosol.Services.Catalog.Settings;
using Teknosol.Shared.Dtos;

namespace Teknosol.Services.Catalog.Services
{
    public class CourseService:ICourseService
    {
        private readonly IMongoCollection<Course> _courseCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;


        public CourseService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _courseCollection = database.GetCollection<Course>(databaseSettings.CourseCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);

            _mapper = mapper;
        }

        /// <summary>
        /// return courses
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<List<CourseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var courses = await _courseCollection.Find(course => true).ToListAsync(cancellationToken);
            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstAsync(cancellationToken);
                }
            }
            else
            {
                courses = new List<Course>();
            }

            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        /// <summary>
        /// get course given by id
        /// </summary>
        /// <param name="id">course id information</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<CourseDto>> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var course = await _courseCollection.Find<Course>(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
            if (course == null)
            {
                return Response<CourseDto>.Fail("Course not found", 404);
            }

            course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstAsync(cancellationToken);
            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(course), 200);
        }

        /// <summary>
        /// get all course by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId, CancellationToken cancellationToken = default)
        {
            var courses = await _courseCollection.Find<Course>(x => x.UserId == userId).ToListAsync(cancellationToken: cancellationToken);
            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId)
                        .FirstAsync(cancellationToken: cancellationToken);
                }
            }
            else
            {
                courses = new List<Course>();
            }

            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        /// <summary>
        /// Create a user given by dto
        /// </summary>
        /// <param name="courseCreateDto"></param>
        /// <returns></returns>
        public virtual async Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto)
        {
            var newCourse = _mapper.Map<Course>(courseCreateDto);
            newCourse.CreatedTime = DateTime.Now;
            await _courseCollection.InsertOneAsync(newCourse);
            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(newCourse), 200);
        }

        /// <summary>
        /// update a course given by dto
        /// </summary>
        /// <param name="courseUpdateDto"></param>
        /// <returns></returns>
        public virtual async Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto)
        {
            var updateCourse = _mapper.Map<Course>(courseUpdateDto);
            var result = await _courseCollection.FindOneAndReplaceAsync(x => x.Id == courseUpdateDto.Id, updateCourse);
            if (result == null)
            {
                return Response<NoContent>.Fail("Course not found", 404);
            }

            return Response<NoContent>.Success(204);
        }

        /// <summary>
        /// Delete a course given by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _courseCollection.DeleteOneAsync(x => x.Id == id);
            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Course not found", 404);
            }
        }
    }
}