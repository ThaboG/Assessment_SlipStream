using Assessment_SlipStream.DAL.DataContext;
using Assessment_SlipStream.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment_SlipStream.DAL.Data
{
    public class ClientsRepository
    {
        public List<Clients> GetAll()
        {
            return (new AppConfiguration()).Get<Clients>("Select * from Clients", null, System.Data.CommandType.Text).ToList();
        }
        public bool Add(Clients client)
        {
            //var itemParams = new List<System.Data.SqlClient.SqlParameter>()
            //{
            //    new System.Data.SqlClient.SqlParameter("@ID", client.ID) { IsNullable = false },
            //    new System.Data.SqlClient.SqlParameter("@Firstname", client.Firstname) { IsNullable = false },
            //    new System.Data.SqlClient.SqlParameter("@Lastname", client.Lastname) { IsNullable = false },
            //    new System.Data.SqlClient.SqlParameter("@Gender", client.Gender) { IsNullable = false },
            //    new System.Data.SqlClient.SqlParameter("@GenderName", client.GenderName) { IsNullable = true },
            //    new System.Data.SqlClient.SqlParameter("@IDNumber", client.IDNumber) { IsNullable = false },
            //    new System.Data.SqlClient.SqlParameter("@ResidentailAddress", client.ResidentailAddress) { IsNullable = false },
            //    new System.Data.SqlClient.SqlParameter("@WorkAddress", client.WorkAddress) { IsNullable = true },
            //    new System.Data.SqlClient.SqlParameter("@PostalAddres", client.PostalAddres) { IsNullable = true },
            //    new System.Data.SqlClient.SqlParameter("@CellNumber", client.CellNumber) { IsNullable = false },
            //    new System.Data.SqlClient.SqlParameter("@WorkNumber", client.WorkNumber) { IsNullable = true },
            //};

            string query = $@"INSERT INTO [dbo].[Clients]
           ([ID]
           ,[Firstname]
           ,[Lastname]
           ,[Gender]
           ,[GenderName]
           ,[IDNumber]
           ,[ResidentailAddress]
           ,[WorkAddress]
           ,[PostalAddres]
           ,[CellNumber]
           ,[WorkNumber])
     VALUES
           (@ID
           ,@Firstname
           ,@Lastname
           ,@Gender
           ,@GenderName
           ,@IDNumber
           ,@ResidentailAddress
           ,@WorkAddress
           ,@PostalAddres
           ,@CellNumber
           ,@WorkNumber)";

            return (new AppConfiguration()).AddUpdate<Clients>(query, client, System.Data.CommandType.Text);
        }

        public bool Update(Clients clients)
        {
            string query = $@"update [dbo].[Clients]
            set [Firstname] = @Firstname
           ,[Lastname] = @Lastname
           ,[Gender] = @Gender
           ,[GenderName] = @GenderName
           ,[IDNumber] = @IDNumber
           ,[ResidentailAddress] = @ResidentailAddress
           ,[WorkAddress] = @WorkAddress
           ,[PostalAddres] = @PostalAddres
           ,[CellNumber] = @CellNumber
           ,[WorkNumber] = @WorkNumber
            where ID = @ID;";

            return (new AppConfiguration()).AddUpdate<Clients>(query, clients, System.Data.CommandType.Text);
        }

        public Clients GetByID(Guid id)
        {
            return (new AppConfiguration()).Get<Clients>("select * from Clients where ID = @ID", new Clients() { ID = id }, System.Data.CommandType.Text).FirstOrDefault();
        }
    }
}
