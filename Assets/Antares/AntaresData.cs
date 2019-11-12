using System;

[Serializable]
public class AntaresData
{
    public string con;
    public string rn;
    public string ct;

    public AntaresData()
    {
        rn = "null";
        con = "null";
    }

    public AntaresData(string rn, string con)
    {
        this.rn = rn;
        this.con = con;
    }
}