using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductTypeModel
/// </summary>
public class ProductTypeModel
{
    public string InsertProductType(ProductType productType)
    {
        try
        {
            GtgNordicEntities db = new GtgNordicEntities();
            db.ProductTypes.Add(productType);
            db.SaveChanges();

            return productType.Name + " Was succesfully inserted";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string UpdateProductType(int id, ProductType productType)
    {
        try
        {
            GtgNordicEntities db = new GtgNordicEntities();
            //Fetch Object from DB
            ProductType p = db.ProductTypes.Find(id);

            p.Name = productType.Name;            

            db.SaveChanges();

            return productType.Name + " Was succesfully updated";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string DeleteProductType(int id)
    {
        try
        {
            GtgNordicEntities db = new GtgNordicEntities();
            ProductType productType = db.ProductTypes.Find(id);

            db.ProductTypes.Attach(productType);
            db.ProductTypes.Remove(productType);
            db.SaveChanges();

            return productType.Name + " Was succesfully deleted";


        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }
}