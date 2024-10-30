using backend_smarthome.DTO;
using System.Net;
using System.Text.Json;
using System.Text;
using backend_smarthome.Service.Devices;


namespace backend_smarthome.Service.SSE
{
    public class EventStreamService : IEventStreamService
    {
        private readonly IDeviceService _deviceService;
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        public EventStreamService(IDeviceService deviceService, HttpClient httpClient, IConfiguration configuration)
        {
            _deviceService = deviceService;
            _httpClient = httpClient;
            _baseUrl = configuration["PythonApi:BaseUrl"];
        }

        public async Task StreamEventsAsync(Guid userId, HttpResponse response)
        {
            var url = $"{_baseUrl}/api/devices";
            response.Headers.Add("Content-Type", "text/event-stream");
            response.Headers.Add("Cache-Control", "no-cache");
            response.Headers.Add("Connection", "keep-alive");

            var request = WebRequest.CreateHttp(url);
            request.Method = "GET";
            request.Accept = "text/event-stream";

            using (var eventStream = await request.GetResponseAsync())
            using (var reader = new StreamReader(eventStream.GetResponseStream()))
            {
                while (true)
                {
                    var line = await reader.ReadLineAsync();
                    if (line == null)
                        break;

                    if (line.StartsWith("data: "))
                    {
                        var json = line.Substring(6);
                        EventDataDto eventData = JsonSerializer.Deserialize<EventDataDto>(json, new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });

                        if (eventData != null)
                        {
                            bool isAssigned = await _deviceService.IsSerialNumberAssignedToUserAsync(eventData.DeviceId, userId);

                            if (isAssigned)
                            {
                                var data = Encoding.UTF8.GetBytes($"data: {line}\n\n");
                                await response.Body.WriteAsync(data, 0, data.Length);
                                await response.Body.FlushAsync();
                            }
                        }
                    }
                }
            }
        }

        public async Task SetHeatingSetpointAsync(string id, HeatingSetpointDto heatingSetpointDto)
        {
            _httpClient.BaseAddress = new Uri(_baseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var heatingSetpoint = heatingSetpointDto.OccupiedHeatingSetpoint;
            var json = new { occupied_heating_setpoint = heatingSetpoint };
            var content = new StringContent(JsonSerializer.Serialize(json).ToString(), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync($"/api/devices/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response Data: " + responseData);
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
            }
        }
    }
}