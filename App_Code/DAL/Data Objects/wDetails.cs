using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

/// <summary>
/// Summary description for nfDetails
/// </summary>
public class wDetails
{
    private int id;
    private string image;
    private Decimal price;


    public wDetails()
    {
    }

    public wDetails(int id, string image, Decimal price)
    {
        this.Id = id;
        this.Image = image;
        this.Price = price;

    }

    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }

    public string Image
    {
        get
        {
            return image;
        }
        set
        {
            image = value;
        }
    }

    public Decimal Price
    {
        get
        {
            return price;
        }
        set
        {
            price = value;
        }
    }
}

    

   