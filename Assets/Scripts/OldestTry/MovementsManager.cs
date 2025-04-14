using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class MovementsManager : MonoBehaviour
{
    public DoubleLinkedList<TurnData> TurnData = new DoubleLinkedList<TurnData>();
    private int currentTurn = 0;
    [Button]
    public void RegisterTurn(List<PieceMovement> allPieces)
    {
        TurnData newTurn = new TurnData(currentTurn);
        for(int i = 0; i<allPieces.Count; i++)
        {
            newTurn.AddEntityData(new PieceData(allPieces[i]));
        }
        TurnData.Add(newTurn);
        currentTurn++;
        Debug.Log("Turno " + currentTurn + " registrado con " + allPieces.Count + " entidades.");
    }

    public TurnData GetTurn(int turnNumber)
    {
        return TurnData.Seek(turnNumber).Value;
    }
}
