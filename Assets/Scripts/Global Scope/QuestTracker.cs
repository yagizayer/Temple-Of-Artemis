using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public static class QuestTracker
{
    public static Dictionary<(PhaseNames, QuestNames), bool> questTracker = new Dictionary<(PhaseNames, QuestNames), bool>(){
        {(PhaseNames.EarlyPhase, QuestNames.Tutorial),false},
        {(PhaseNames.EarlyPhase, QuestNames.FindAncientColumns),false},
        {(PhaseNames.EarlyPhase, QuestNames.TalkToProfessor),false},
        {(PhaseNames.EarlyPhase, QuestNames.GatherInformationAroundTemple),false},
        {(PhaseNames.FirstTemple, QuestNames.GatherInformationAroundTemple),false},
        {(PhaseNames.LastTemple, QuestNames.GatherInformationAroundTemple),false},
        {(PhaseNames.EndPhase, QuestNames.GatherInformationAroundTemple),false},
    };

    public static Dictionary<(PhaseNames, string), bool> questObjectTracker = new Dictionary<(PhaseNames, string), bool>(){
        {(PhaseNames.EarlyPhase, "PaintingOfAmazons"), false},
        {(PhaseNames.EarlyPhase, "PaintingOfTreeOfLife"), false},
        {(PhaseNames.EarlyPhase, "BrokenSculpture"), false},
        {(PhaseNames.EarlyPhase, "AmberNecklace"), false},
        {(PhaseNames.EarlyPhase, "FigureOfTreeOfLife"), false},
        {(PhaseNames.FirstTemple,"Sculpture"), false},
        {(PhaseNames.FirstTemple,"GoldCoins"), false},
        {(PhaseNames.FirstTemple,"BurnMarks"), false},
        {(PhaseNames.FirstTemple,"PieceOfFineClothing"), false},
        {(PhaseNames.LastTemple, "PaintingOfAlexanderTheGreat"), false},
        {(PhaseNames.LastTemple, "PaintingOfArtemis"), false},
        {(PhaseNames.LastTemple, "NyxFigure"), false},
        {(PhaseNames.LastTemple, "TalePiece1"), false},
        {(PhaseNames.LastTemple, "TalePiece2"), false},
        {(PhaseNames.LastTemple, "TalePiece3"), false},
        {(PhaseNames.EndPhase, "PlaceHolder"), false},
    };

    public static PhaseNames CurrentPhaseName { get; set; } = PhaseNames.EarlyPhase;
    public static QuestNames CurrentQuestName { get; set; } = QuestNames.Tutorial;

    public static void NextQuest()
    {
        if (CurrentQuestName == QuestNames.GatherInformationAroundTemple) NextPhase();
        if (CurrentQuestName == QuestNames.TalkToProfessor) CurrentQuestName = QuestNames.GatherInformationAroundTemple;
        if (CurrentQuestName == QuestNames.FindAncientColumns) CurrentQuestName = QuestNames.TalkToProfessor;
        if (CurrentQuestName == QuestNames.Tutorial) CurrentQuestName = QuestNames.FindAncientColumns;
    }
    private static void NextPhase()
    {
        if (CurrentPhaseName == PhaseNames.EarlyPhase && CurrentPhaseCheck()) CurrentPhaseName = PhaseNames.FirstTemple;
        if (CurrentPhaseName == PhaseNames.FirstTemple && CurrentPhaseCheck()) CurrentPhaseName = PhaseNames.LastTemple;
        if (CurrentPhaseName == PhaseNames.LastTemple && CurrentPhaseCheck()) CurrentPhaseName = PhaseNames.EndPhase;

    }

    public static bool CurrentPhaseCheck()
    {
        bool phaseCompleted = false;
        foreach (KeyValuePair<(PhaseNames, string), bool> questObject in questObjectTracker)
        {
            if (questObject.Key.Item1 == CurrentPhaseName)
            {
                if (!questObject.Value)
                {
                    phaseCompleted = false;
                    break;
                }
                else
                {
                    phaseCompleted = true;
                }
            }
        }
        return phaseCompleted;
    }

}