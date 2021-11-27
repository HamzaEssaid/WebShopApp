using System.Collections.Generic;
using WebShopUppg.DTOs;

namespace WebShopUppg.DataAccess
{
    public interface IDataAccess
    {
        IEnumerable<CustomerDTO> GetAll();
        void SaveCustomer(CustomerDTO cust);

        public IEnumerable<ItemsDTO> GetAllitems();

        void SaveItem(ItemsDTO item);

        public CustomerDTO GetCustomerById(int id);
        public ItemsDTO GetItemsById(int id);

    }
}