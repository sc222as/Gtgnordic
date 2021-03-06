﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Management_ManageProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)        
            GetImages();
        
    }

    private void GetImages()
    {
        try
        {
            //get all filepaths
            string[] images = Directory.GetFiles(Server.MapPath("~/Images/Products/"));

            ArrayList ImageList = new ArrayList();
            foreach (string image in images)
            {
                string imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                ImageList.Add(imageName);
            }
            ddlImage.DataSource = ImageList;
            ddlImage.AppendDataBoundItems = true;
            ddlImage.DataBind();
        }

        catch (Exception e)
        {
            lblResult.Text = e.ToString();
        }


    }

    private Product CreateProduct()
    {
        Product product = new Product();

        product.Name = txtName.Text;
        product.Price = Convert.ToInt32(txtPrice.Text);
        product.TypeId = Convert.ToInt32(ddlType.SelectedValue);
        product.Description = txtDescription.Text;
        product.Image = ddlImage.SelectedValue;

        return product;





    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ProductModel productModel = new ProductModel();
        Product product = CreateProduct();

        lblResult.Text = productModel.InsertProduct(product);
    }
}