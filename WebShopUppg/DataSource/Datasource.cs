using System.IO;

namespace WebShopUppg.DataSource
{
    public class Datasource
    {
        public string Data()
        {
            var path = @"C:\Users\New PC\Source\Repos\You\You.DataSource\customers.json";
            return File.ReadAllText(path);
        }
        public string ItemData()
        {
            var path = @"C:\Users\New PC\Source\Repos\You\You.DataSource\items.json";
            return File.ReadAllText(path);
        }

        public void UpdateData(string updatedData)
        {
            var path = @"C:\Users\New PC\Source\Repos\You\You.DataSource\customers.json";
            File.WriteAllText(path, updatedData);
        }
        public void UpdateItems(string updateditemData)
        {
            var path = @"C:\Users\New PC\Source\Repos\You\You.DataSource\items.json";
            File.WriteAllText(path, updateditemData);
        }


    }
}
