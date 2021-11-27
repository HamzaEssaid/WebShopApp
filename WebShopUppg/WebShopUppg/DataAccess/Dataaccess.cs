using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using WebShopUppg.Data;
using WebShopUppg.DataSource;
using WebShopUppg.DTOs;

namespace WebShopUppg.DataAccess
{
    public class Dataaccess : IDataAccess
    {
        private readonly Datasource _dataSource;

        public Dataaccess(Datasource dataSource)
        {
            _dataSource = dataSource;
        }
        public IEnumerable<CustomerDTO> GetAll()
        {
            string jsonRes = _dataSource.Data();
            return JsonConvert.DeserializeObject<IEnumerable<CustomerDTO>>(jsonRes);
        }

        public IEnumerable<ItemsDTO> GetAllitems()
        {
            string jsonRes = _dataSource.ItemData();
            return JsonConvert.DeserializeObject<IEnumerable<ItemsDTO>>(jsonRes);
        }
        public CustomerDTO GetCustomerById(int id)
        {
            string jsonResponse = _dataSource.Data();
            foreach (CustomerDTO user in GetAll())
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        public ItemsDTO GetItemsById(int id)
        {
            string jsonResponse = _dataSource.ItemData();
            foreach (ItemsDTO item in GetAllitems())
            {
                if (item.itemId == id)
                {
                    return item;
                }
            }
            return null;
        }

        public void SaveCustomer(CustomerDTO cust)
        {
            string jsonRes = _dataSource.Data();
            var customers = JsonConvert.DeserializeObject<IEnumerable<CustomerDTO>>(jsonRes).ToList();
            for (int i = 0; i < customers.Count(); i++)
            {
                if (cust.Id == customers[i].Id)
                {
                    customers[i] = cust;
                    var updatedData = JsonConvert.SerializeObject(customers, Formatting.Indented);
                    _dataSource.UpdateData(updatedData);
                    break;
                }
            }

        }
        //public void SaveCustomer(CustomerDTO cust)
        //{

        //    string jsonRes = _dataSource.Data();
        //    var customers = JsonConvert.DeserializeObject<IEnumerable<CustomerDTO>>(jsonRes);
        //    var newList = customers.ToList();
        //    newList.Add(cust);
        //    var updatedData = JsonConvert.SerializeObject(newList);
        //    _dataSource.UpdateData(updatedData);
        //}

        public void SaveItem(ItemsDTO item)
        {
            string jsonRes = _dataSource.ItemData();
            var items = JsonConvert.DeserializeObject<IEnumerable<ItemsDTO>>(jsonRes);
            var newList1 = items.ToList();
            newList1.Add(item);
            var updateditemData = JsonConvert.SerializeObject(newList1);
            _dataSource.UpdateItems(updateditemData);
        }
    }
}
