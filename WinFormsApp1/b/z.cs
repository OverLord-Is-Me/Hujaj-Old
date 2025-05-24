using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Configuration;

public abstract class z
{
    protected DBC DB = new DBC();

    protected virtual bool lsl(char op)
    {
        return false;
    }
    protected bool a()
    {
        return lsl('a');
    }
    protected bool u()
    {
        return lsl('u');
    }
    protected bool q()
    {
        return lsl('d');
    }
    //protected bool m()
    //{
    //    return lsl('n');
    //}
    protected bool p() //proset
    {
        return lsl('p');
    }
    protected bool b() //probuy
    {
        return lsl('b');
    }
    protected bool c() //bcs
    {
        return lsl('c');
    }
    protected bool r() //bcs
    {
        return lsl('r');
    }
    protected bool n() //sell_buy_num
    {
        return lsl('n');
    }
    protected DataTable ss(string query)
    {
        try
        {
            return DB.RunQury(query);
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);
            return new DataTable();
        }
    }
}