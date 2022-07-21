using AutoMapper;
using CityInfoAPI.Models;
using CityInfoAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CityInfoAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/cities")]
    [ApiVersion("1.0")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;
        const int maxCitiespageSize = 20;
        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(_cityInfoRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCities
            (string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            if(pageSize > maxCitiespageSize)
            {
                pageSize = maxCitiespageSize;
            }
            var (cityEntities, paginationMetaData) = await _cityInfoRepository.GetCitySearchsync(name, searchQuery, pageNumber, pageSize);
            //var results = new List<CityWithoutPointsOfInterestDto>();

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetaData));

            return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities));
            //return Ok (_citiesDataStore.Cities);
        }

        /// <summary>
        /// Get a city by Id
        /// </summary>
        /// <param name="id">The id of the city to get</param>
        /// <param name="includePointsOfInterest">Whether or not to include the point of interest</param>
        /// <returns>An IAction Result</returns>
        /// <response code="200">Return requested city</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCity(int id, bool includePointsOfInterest = false)
        {
            //Find city with Id
            var cityToReturn = await _cityInfoRepository.GetCityAsync(id, includePointsOfInterest);
            if (cityToReturn == null)
            {
                NotFound();
            }
            if (includePointsOfInterest)
            {
                return Ok(_mapper.Map<CityDto>(cityToReturn));
            }
            return Ok(_mapper.Map<CityWithoutPointsOfInterestDto>(cityToReturn));

        }
    }
}
