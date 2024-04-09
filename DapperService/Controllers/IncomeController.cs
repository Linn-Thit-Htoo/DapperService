using DapperService.Models.Entities;
using DapperService.Models.RequestModels;
using DapperService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        #region Initializations
        private readonly IncomeService _incomeService;
        private readonly IConfiguration _configuration;

        public IncomeController(IncomeService incomeService, IConfiguration configuration)
        {
            _incomeService = incomeService;
            _configuration = configuration;
        }
        #endregion

        #region Get
        [HttpGet]
        public async Task<IActionResult> GetIncomeList()
        {
            try
            {
                IEnumerable<IncomeDataModel> lst = await _incomeService.GetIncomeListService();
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion


        #region Create
        [HttpPost]
        public async Task<IActionResult> CreateIncome([FromBody] CreateIncomeRequestModel requestModel)
        {
            try
            {
                if (requestModel.Amount == 0)
                    return BadRequest();

                int result = await _incomeService.CreateIncomeService(requestModel);
                return result > 0 ? StatusCode(201, "Income Created.") : BadRequest("Creating Fail.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Update
        [HttpPut]
        public async Task<IActionResult> UpdateIncome(UpdateIncomeRequestModel requestModel)
        {
            try
            {
                if (requestModel.IncomeId == 0 || requestModel.Amount == 0)
                    return BadRequest();

                int result = await _incomeService.UpdateIncomeService(requestModel);
                return result > 0 ? StatusCode(202, "Updating Successful.") : BadRequest("Updating Fail.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome(long id)
        {
            try
            {
                if (id == 0)
                    return BadRequest();

                int result = await _incomeService.DeleteIncomeService(id);
                return result > 0 ? StatusCode(202, "Income Deleted.") : BadRequest("Deleting Fail.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
