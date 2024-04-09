namespace DapperService.Query
{
    public class IncomeQueryList
    {
        #region Get income query
        public static string GetIncomeQuery()
        {
            return @"SELECT [IncomeId]
      ,[Amount]
      ,[Date]
      ,[IsActive]
  FROM [dbo].[Income] WHERE IsActive = @IsActive
  ORDER BY IncomeId DESC";
        }
        #endregion

        #region Create income query
        public static string CreateIncomeQuery()
        {
            return @"INSERT INTO Income (Amount, Date, IsActive) VALUES(@Amount, @Date, @IsActive)";
        }
        #endregion

        #region Update income query
        public static string UpdateIncomeQuery()
        {
            return @"UPDATE Income SET Amount = @Amount WHERE IncomeId = @IncomeId";
        }
        #endregion

        #region Delete income query
        public static string DeleteIncomeQuery()
        {
            return @"UPDATE Income SET IsActive = @IsActive WHERE IncomeId = @IncomeId";
        }
        #endregion
    }
}
