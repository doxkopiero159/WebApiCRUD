using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DAL
    {
        static APIDBEntities DBcontext;
        static DAL()
        {
            DBcontext = new APIDBEntities();

        }
        public static List<Product> GetProducts()
        {
            return DBcontext.Products.ToList();
        }
        public static Product GetProduct(int productId)
        {
            return DBcontext.Products.Where(p => p.ProductID == productId).FirstOrDefault();
        }

        public static bool InsertProduct(Product productItem)
        {
            bool status;
            try
            {
                DBcontext.Products.Add(productItem);
                DBcontext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;

        }
        public static bool UpdateProduct(Product productItem) {

            bool status;

            try
            {
                Product prodItem = DBcontext.Products.Where(p => p.ProductID == productItem.ProductID).FirstOrDefault();
                if (prodItem !=null)
                {
                    prodItem.ProductName = productItem.ProductName;
                    prodItem.Quantity = productItem.Quantity;
                    prodItem.Price = productItem.Price;
                    DBcontext.SaveChanges();
                }
                status = true;

            }
            catch (Exception)
            {

                status = false;
            }
            return status;

        }

        public static bool DeleteProduct(int id) {
            bool status;
            try
            {
                Product prodItem = DBcontext.Products.Where(p => p.ProductID == id).FirstOrDefault();
                if (prodItem !=null)
                {
                    DBcontext.Products.Remove(prodItem);
                    DBcontext.SaveChanges();

                }
                status = true;
            }
            catch (Exception)
            {
                status = false;

                
            }
            return status;
        
        }
    }
}
