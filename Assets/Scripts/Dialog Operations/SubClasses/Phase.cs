using System.Collections;
using System.Collections.Generic;

public class Phase
{
    public Phase()
    {
    }

    public Phase(Dictionary<QuestNames, Quest> Quests, PhaseEnd PhaseEnd)
    {
        this.Quests = Quests;
        this.PhaseEnd = PhaseEnd;
    }
    public Dictionary<QuestNames, Quest> Quests { get; set; } = new Dictionary<QuestNames, Quest>();
    public PhaseEnd PhaseEnd { get; set; } = new PhaseEnd();
}
