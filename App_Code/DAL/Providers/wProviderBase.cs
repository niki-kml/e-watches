using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for nfProviderBase
/// </summary>
public class wProviderBase
{
    protected wDetails GetWDetailsFromReader(IDataReader reader)
    {
        return new wDetails(
            (int)reader["id"],
            (string)reader["image"],
            (Decimal)reader["price"]);
    }
    // Converting a list of objects
    protected List<wDetails> GetWDetailsCollectionFromReader(IDataReader reader)
    {
        List<wDetails> nf = new List<wDetails>();
        while (reader.Read())
            nf.Add(GetWDetailsFromReader(reader));
        return nf;
    }

    // Coversion methods when using DataTables
    // Note: I did not use these methods in this example

    // single row
    protected wDetails GetWDetailsFromToolRecord(DataRow myDataRecord)
    {
        wDetails wDetailObject = new wDetails();

        wDetailObject.Id = Convert.ToInt32(myDataRecord["id"]);
        wDetailObject.Image = Convert.ToString(myDataRecord["image"]);
        wDetailObject.Price = Convert.ToDecimal(myDataRecord["price"]);


        return wDetailObject;
    }

    // convert whole table to a detail list
    protected List<wDetails> GetWDetailsListFromToolRecordList(DataTable myDataTable)
    {
        List<wDetails> wDetailObjectList = new List<wDetails>();

        for (int i = 0; i < myDataTable.Rows.Count; i++)
            wDetailObjectList.Add(GetWDetailsFromToolRecord(myDataTable.Rows[i]));

        return wDetailObjectList;

    }
}