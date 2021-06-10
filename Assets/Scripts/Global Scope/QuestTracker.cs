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
    };

}