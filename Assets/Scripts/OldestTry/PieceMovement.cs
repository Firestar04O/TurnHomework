using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PieceData
{
    public int ID;
    public int Health;
    public int Attack;
    public int Speed;
    public Vector3 position;

    public PieceData(PieceMovement piece)
    {
        ID = piece.ID;
        Health = piece.Health;
        Attack = piece.Attack;
        Speed = piece.Speed;
        position = piece.transform.position;
    }
}
public class TurnData
{
    public int TurnNumber;
    public List<PieceData> EntitiesData;

    public TurnData(int turnNumber)
    {
        TurnNumber = turnNumber;
        EntitiesData = new List<PieceData>();
    }

    public void AddEntityData(PieceData data)
    {
        EntitiesData.Add(data);
    }
}
public class PieceMovement : MonoBehaviour
{
    //public MovementsManager manager;
    //PieceData data;
    public int ID;
    public int Health;
    public int Attack;
    public int Speed;
}