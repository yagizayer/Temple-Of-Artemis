using System.Collections.Generic;

static public class GlobalVariables
{
    public const string NPCsListPath = "NPC_SOs";
    public static bool IsThereAnySaveFiles { get; set; }
    public static Dictionary<Npcs,string> NpcNames => new Dictionary<Npcs,string>(){
        {Npcs.SanatTarihiUzmani, "Sanat Tarihi Uzmanı"},
        {Npcs.Jeolog, "Jeolog"},
        {Npcs.Profesor, "Profesör"},
    };
    public static string PlayerName { get; set; }
}
