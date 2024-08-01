using Investimento.API.V1;
using Investimento.Application._1._1_Interface;
using Investimento.Domain._2._1_Interface;
using Investimento.Domain._2._2_Entity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Investimento.Api.V1
{
    [Route("api/[controller]")]
    public class PositionsController : ApiController
    {
        private readonly IPositionService _positionService;
        private readonly IDomainNotificationHandler _notificator;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;       

        public PositionsController(IPositionService positionService,
                                     IDomainNotificationHandler notifications,
                                     IHttpClientFactory httpClientFactory,
                                     IConfiguration configuration) : base(notifications)
        {
            _positionService = positionService;
            _notificator = notifications;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportPositions()
        {
            var httpClient = _httpClientFactory.CreateClient("ApiClient");
            httpClient.DefaultRequestHeaders.Add("X-Test-Key", _configuration["Chaves:testKey"]);

            var response = await httpClient.GetAsync(_configuration["Chaves:apiUrl"]);

            if (response.IsSuccessStatusCode)
            {
                var positions = await response.Content.ReadFromJsonAsync<List<Position>>();
                if (positions != null)
                {
                    await _positionService.AddPositionsAsync(positions);
                }
                return Response();
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }

        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetPositionsByClient(string clientId)
        {
            var positions = await _positionService.GetPositionsByClientAsync(clientId);
            if (IsValidOperation())
                return Response(positions);

            if (positions == null) return NotFound();
            return Response(positions);
        }

        [HttpGet("client/{clientId}/summary")]
        public async Task<IActionResult> GetSummaryByClient(string clientId)
        {
            var summary = await _positionService.GetSummaryByClientAsync(clientId);
            if (IsValidOperation())
                return Response(summary);

            if (summary == null) return NotFound();
            return Response(summary);
        }

        [HttpGet("top10")]
        public async Task<IActionResult> GetTop10Positions()
        {
            var top10Positions = await _positionService.GetTop10PositionsAsync();
            if (IsValidOperation())
                return Response(top10Positions);

            if (top10Positions == null) return NotFound();
            return Response(top10Positions);
        }
    }

    

}
