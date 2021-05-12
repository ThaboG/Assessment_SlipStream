using Assessment_SlipStream.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Data = Assessment_SlipStream.DAL.Data;

namespace Assessment_SlipStream.BAL.Services
{
    public class ClientsService
    {
        public ClientsService() { }
        public bool Add(Clients clients)
        {
            return (new Data.ClientsRepository().Add(clients));
        }
        public bool Update(Clients clients)
        {
            return (new Data.ClientsRepository().Update(clients));
        }
        public List<Clients> GetAll()
        {
            return (new Data.ClientsRepository().GetAll());
        }

        public Clients GetByID(Guid id)
        {
            return (new Data.ClientsRepository().GetByID(id));
        }
    }
}
