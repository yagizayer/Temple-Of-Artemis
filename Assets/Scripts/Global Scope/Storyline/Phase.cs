using System.Collections;
using System.Collections.Generic;

public class Phase
{
    public Phase()
    {
    }

    public Phase(Dictionary<string, Quest> Quests, PhaseEnd PhaseEnd)
    {
        this.Quests = Quests;
        this.PhaseEnd = PhaseEnd;
    }
    public Dictionary<string, Quest> Quests { get; set; } = new Dictionary<string, Quest>();
    public PhaseEnd PhaseEnd { get; set; } = new PhaseEnd();
}
