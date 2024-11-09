using EmployeeDetailsEntity.Models.emp;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

    

        [ApiController]
        [Route("EmployeeDetailsApiRedirect")]
        public class EmployeeController : ControllerBase
        {
            private readonly HttpClient _httpClient;

            public EmployeeController(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            [HttpGet("GetAllEmployee")]
            public async Task<IActionResult> GetAllEmployee()
            {
                try
                {
                    var getResultApi = await _httpClient.GetAsync("https://localhost:44317/EmployeeDetailsApi/GetAllEmployee");

                    if (getResultApi.IsSuccessStatusCode)
                    {
                        var result = await getResultApi.Content.ReadAsStringAsync();
                        var employeeList = JsonConvert.DeserializeObject<List<Employee>>(result);
                        return Ok(employeeList);
                    }
                    else
                    {

                        return BadRequest("Error: " + getResultApi.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }


        }
    


