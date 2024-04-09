using DapperService.Models.Entities;
using DapperService.Query;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using DapperService.Models.RequestModels;

namespace DapperService.Services
{
    public class IncomeService
    {
        private readonly IConfiguration _configuration;

        public IncomeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Get Income List Service
        public async Task<IEnumerable<IncomeDataModel>> GetIncomeListService()
        {
            try
            {
                using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
                string query = IncomeQueryList.GetIncomeQuery();
                var parameters = new
                {
                    IsActive = true
                };
                IEnumerable<IncomeDataModel> lst = await db.QueryAsync<IncomeDataModel>(query, parameters);

                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region Create Income Service
        public async Task<int> CreateIncomeService(CreateIncomeRequestModel requestModel)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
                string query = IncomeQueryList.CreateIncomeQuery();
                var paramaters = new DynamicParameters();
                paramaters.Add("@Amount", requestModel.Amount);
                paramaters.Add("@Date", DateTime.Now);
                paramaters.Add("@IsActive", true);
                int result = await db.ExecuteAsync(query, paramaters);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region Update Income Service
        public async Task<int> UpdateIncomeService(UpdateIncomeRequestModel requestModel)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
                string query = IncomeQueryList.UpdateIncomeQuery();
                var paramaters = new DynamicParameters();
                paramaters.Add("@Amount", requestModel.Amount);
                paramaters.Add("@IncomeId", requestModel.IncomeId);
                int result = await db.ExecuteAsync(query, paramaters);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region Delete Income Service
        public async Task<int> DeleteIncomeService(long id)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
                string query = IncomeQueryList.DeleteIncomeQuery();
                var parameters = new
                {
                    IsActive = false,
                    IncomeId = id
                };
                int result = await db.ExecuteAsync(query, parameters);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
