﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartModel
/// </summary>
public class CartModel
{
    public string InsertCart(Cart cart)
    {
        try
        {
            GtgNordicEntities db = new GtgNordicEntities();
            db.Carts.Add(cart);
            db.SaveChanges();

            return cart.DatePurchased + " Was succesfully inserted";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string UpdateCart(int id, Cart cart)
    {
        try
        {
            GtgNordicEntities db = new GtgNordicEntities();
            //Fetch Object from DB
            Cart p = db.Carts.Find(id);

            p.DatePurchased = cart.DatePurchased;
            p.ClientID = cart.ClientID;
            p.Amount = cart.Amount;
            p.IsInCart = cart.IsInCart;
            p.ProductID = cart.ProductID;


            db.SaveChanges();

            return cart.DatePurchased + " Was succesfully updated";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string DeleteCart(int id)
    {
        try
        {
            GtgNordicEntities db = new GtgNordicEntities();
            Cart cart = db.Carts.Find(id);

            db.Carts.Attach(cart);
            db.Carts.Remove(cart);
            db.SaveChanges();

            return cart.DatePurchased + " Was succesfully deleted";


        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }
}