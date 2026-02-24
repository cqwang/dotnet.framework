namespace Cqwang.BackEnd.CSharp.MySQL.TestCase
{
    class TestEFQuery
    {
        //public static List<AccountVO> GetList(MarketAccountQueryRequest request)
        //{
        //    var sql = new StringBuilder();
        //    sql.Append(@"SELECT tb_account.AccountId, tb_account.Name AS 'AccountName',tb_account.Source,tb_account.Status AS 'AccountStatus',
        //        tb_account_address.City,tb_account_address.Region,tb_account_address.BoothNo,tb_account_address.Detail AS 'AddressDetail',
        //        tb_account_category.Name AS 'Category',
        //        tb_account_contact.MobilePhone,tb_account_contact.Telephone,tb_account_contact.OtherPhones,tb_account_contact.Email,tb_account_contact.Wechat,
        //        tb_account_description.AccountDescription,tb_account_description.TradeType,
        //        tb_account_description.GoodsDescription,tb_account_description.PageUrl,tb_account_description.Score,tb_account_description.ConsumptionPerPerson
        //        FROM tb_account
        //        INNER JOIN tb_account_address ON tb_account_address.AddressId=tb_account.AddressId
        //        INNER JOIN tb_account_category ON tb_account_category.CategoryId=tb_account.CategoryId
        //        INNER JOIN tb_account_contact ON tb_account_contact.ContactId=tb_account.ContactId
        //        INNER JOIN tb_account_description ON tb_account_description.DescriptionId=tb_account.DescriptionId
        //        WHERE");

        //    var parameters = new List<MySqlParameter>();
        //    if (!string.IsNullOrEmpty(request.Source))
        //    {
        //        sql.Append(" tb_account.Source=@Source");
        //        parameters.Add(new MySqlParameter("@Source", MySqlDbType.VarChar) { Value = request.Source });
        //    }
        //    if (request.AccountStatus.HasValue)
        //    {
        //        sql.AppendFormat(" AND tb_account.Status=@Status");
        //        parameters.Add(new MySqlParameter("@Status", MySqlDbType.Byte) { Value = request.AccountStatus.Value });
        //    }
        //    if (!string.IsNullOrEmpty(request.City))
        //    {
        //        sql.AppendFormat(" AND tb_account_address.City=@City");
        //        parameters.Add(new MySqlParameter("@City", MySqlDbType.VarChar) { Value = request.City });
        //    }
        //    if (!string.IsNullOrEmpty(request.Region))
        //    {
        //        sql.AppendFormat(" AND tb_account_address.Region=@Region");
        //        parameters.Add(new MySqlParameter("@Region", MySqlDbType.VarChar) { Value = request.Region });
        //    }
        //    if (!string.IsNullOrEmpty(request.Category))
        //    {
        //        sql.AppendFormat(" AND tb_account_category.Name=@Category");
        //        parameters.Add(new MySqlParameter("@Category", MySqlDbType.VarChar) { Value = request.Category });
        //    }
        //    if (!string.IsNullOrEmpty(request.ContactName))
        //    {
        //        sql.AppendFormat(" AND tb_account_contact.Name=@ContactName");
        //        parameters.Add(new MySqlParameter("@ContactName", MySqlDbType.VarChar) { Value = request.ContactName });
        //    }
        //    if (!string.IsNullOrEmpty(request.ContactMobilePhone))
        //    {
        //        sql.AppendFormat(" AND tb_account_contact.MobilePhone=@ContactMobilePhone");
        //        parameters.Add(new MySqlParameter("@ContactMobilePhone", MySqlDbType.VarChar) { Value = request.ContactMobilePhone });
        //    }
        //    if (request.Score.HasValue)
        //    {
        //        sql.AppendFormat(" AND tb_account_description.Score=@Score");
        //        parameters.Add(new MySqlParameter("@Score", MySqlDbType.Decimal) { Value = request.Score.Value });
        //    }

        //    //参数化查询，防止注入

        //    List<AccountVO> list = null;
        //    using (var context = new MarketDbContext())
        //    {
        //        list = context.Database.SqlQuery<AccountVO>(sql.ToString(), parameters).ToList();
        //    }
        //    return list;
        //}

        //like
       //var str=$"{request.SearchKeyWord}%";
        //query = query.Where(p => SqlFunctions.PatIndex(str, p.AuthCode) > 0
        //              || SqlFunctions.PatIndex(str, p.SerialNo) > 0);
    }
}
