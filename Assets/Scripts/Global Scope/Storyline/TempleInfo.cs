using System.Collections.Generic;

public class TempleInfo
{
    public TempleInfo()
    {
    }

    public TempleInfo(string Header, string BuildingDate, List<string> Lines)
    {
        this.Header = Header;
        this.BuildingDate = BuildingDate;
        this.Lines = Lines;
    }
    public string Header { get; set; }
    public string BuildingDate { get; set; }
    public List<string> Lines { get; set; }
}
