using System.Collections.Generic;
using UnityEngine;

static public class GlobalVariables
{
    public static string PlayerName { get; set; } = "Jones";
    public const string NPCsPath = "NPC_SOs";
    public const string QuestObjectsPath = "QuestObjects_SOs";
    public static bool IsThereAnySaveFiles { get; set; }
    public static Sprite MagnifyingGlass = Resources.Load<Sprite>("Magnifying_small");
    public static Sprite ThreeDots = Resources.Load<Sprite>("Interaction_small");
    public static Dictionary<Npcs, string> NpcNames => new Dictionary<Npcs, string>(){
        {Npcs.SanatTarihiUzmani, "Sanat Tarihi Uzmanı"},
        {Npcs.Jeolog, "Jeolog"},
        {Npcs.Profesor, "Profesör"},
    };


}
