using System.Collections.Generic;

public class PhaseEnd
{
    public PhaseEnd()
    {
    }

    public PhaseEnd(List<string> BeforeInfo, TempleInfo templeInfo, List<string> AfterInfo)
    {
        this.BeforeInfo = BeforeInfo;
        this.templeInfo = templeInfo;
        this.AfterInfo = AfterInfo;
    }
    public List<string> BeforeInfo { get; set; }
    public TempleInfo templeInfo { get; set; }
    public List<string> AfterInfo { get; set; }
}
