using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [Header("EarlyPhase")]
    [SerializeField] private bool CompleteTest = false;
    [SerializeField] private bool GetItemPaintingOfAmazons = false;
    [SerializeField] private bool GetItemPaintingOfTreeOfLife = false;
    [SerializeField] private bool GetItemBrokenSculpture = false;
    [SerializeField] private bool GetItemAmberNecklace = false;
    [SerializeField] private bool GetItemFigureOfTreeOfLife = false;

    [Header("FirstTemple")]
    [SerializeField] private bool GetItemSculpture = false;
    [SerializeField] private bool GetItemGoldCoins = false;
    [SerializeField] private bool GetItemBurnMarks = false;
    [SerializeField] private bool GetItemPieceOfFineClothing = false;

    [Header("LastTemple")]
    [SerializeField] private bool GetItemPaintingOfAlexanderTheGreat = false;
    [SerializeField] private bool GetItemPaintingOfArtemis = false;
    [SerializeField] private bool GetItemNyxFigure = false;
    [SerializeField] private bool GetItemTalePiece1 = false;
    [SerializeField] private bool GetItemTalePiece2 = false;
    [SerializeField] private bool GetItemTalePiece3 = false;

    private void OnValidate()
    {

        // // foreach (KeyValuePair<(PhaseNames, string), bool> item in QuestTracker.questObjectTracker)
        // //     if (item.Key.Item1 == PhaseNames.EarlyPhase) QuestTracker.questObjectTracker[(item.Key.Item1, item.Key.Item2)] = CompleteEarlyPhase;
        // QuestTracker.questObjectTracker[(PhaseNames.EarlyPhase, "GetItemPaintingOfAmazons")] = GetItemPaintingOfAmazons;
        // QuestTracker.questObjectTracker[(PhaseNames.EarlyPhase, "GetItemPaintingOfTreeOfLife")] = GetItemPaintingOfTreeOfLife;
        // QuestTracker.questObjectTracker[(PhaseNames.EarlyPhase, "GetItemBrokenSculpture")] = GetItemBrokenSculpture;
        // QuestTracker.questObjectTracker[(PhaseNames.EarlyPhase, "GetItemAmberNecklace")] = GetItemAmberNecklace;
        // QuestTracker.questObjectTracker[(PhaseNames.EarlyPhase, "GetItemFigureOfTreeOfLife")] = GetItemFigureOfTreeOfLife;

        // // foreach (KeyValuePair<(PhaseNames, string), bool> item in QuestTracker.questObjectTracker)
        // //     if (item.Key.Item1 == PhaseNames.FirstTemple) QuestTracker.questObjectTracker[(item.Key.Item1, item.Key.Item2)] = CompleteFirstTemple;
        // QuestTracker.questObjectTracker[(PhaseNames.FirstTemple, "GetItemSculpture")] = GetItemSculpture;
        // QuestTracker.questObjectTracker[(PhaseNames.FirstTemple, "GetItemGoldCoins")] = GetItemGoldCoins;
        // QuestTracker.questObjectTracker[(PhaseNames.FirstTemple, "GetItemBurnMarks")] = GetItemBurnMarks;
        // QuestTracker.questObjectTracker[(PhaseNames.FirstTemple, "GetItemPieceOfFineClothing")] = GetItemPieceOfFineClothing;

        // // foreach (KeyValuePair<(PhaseNames, string), bool> item in QuestTracker.questObjectTracker)
        // //     if (item.Key.Item1 == PhaseNames.LastTemple) QuestTracker.questObjectTracker[(item.Key.Item1, item.Key.Item2)] = CompleteLastTemple;
        // QuestTracker.questObjectTracker[(PhaseNames.LastTemple, "GetItemPaintingOfAlexanderTheGreat")] = GetItemPaintingOfAlexanderTheGreat;
        // QuestTracker.questObjectTracker[(PhaseNames.LastTemple, "GetItemPaintingOfArtemis")] = GetItemPaintingOfArtemis;
        // QuestTracker.questObjectTracker[(PhaseNames.LastTemple, "GetItemNyxFigure")] = GetItemNyxFigure;
        // QuestTracker.questObjectTracker[(PhaseNames.LastTemple, "GetItemTalePiece1")] = GetItemTalePiece1;
        // QuestTracker.questObjectTracker[(PhaseNames.LastTemple, "GetItemTalePiece2")] = GetItemTalePiece2;
        // QuestTracker.questObjectTracker[(PhaseNames.LastTemple, "GetItemTalePiece3")] = GetItemTalePiece3;

        // if(CompleteTest)
        //     FindObjectOfType<DialogManagement>().InteractWithNpc(Npcs.Profesor); 
    }


}
