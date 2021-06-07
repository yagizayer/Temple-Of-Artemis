using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameProgression
{
    public static Phase CurrentPhase { get; set; } = new Phase();
    public static Quest CurrentQuest { get; set; } = new Quest();
    public static Dictionary<string, Quest> EndedQuests { get; set; } = new Dictionary<string, Quest>();
    public static Vector3 PlayerPosition { get; set; } = new Vector3();
    public static GameObject CurrentTarget { get; set; }
}
