using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using GameUtils;

public class _GameManager : MonoBehaviour
{
    public CustomDoubleLinkedList<CustomNode> turnHistory = new CustomDoubleLinkedList<CustomNode>();
    public int currentTurn = 0;
    public bool itchanged;
    public List<Entity> allEntities = new List<Entity>();
    private void Awake()
    {
        itchanged = true;
    }
    public void SaveTurn()
    {
        List<EntityData> entityStates = new List<EntityData>();

        foreach (Entity e in allEntities)
        {
            entityStates.Add(new EntityData(e));
        }
        turnHistory.Add(new CustomNode(currentTurn++, entityStates));
        itchanged = false;
        Debug.Log("Turno guardado.");
    }
    private void ApplyTurn(Node<CustomNode> node)
    {
        if (node == null)
        {
            return;
        }
        foreach (EntityData data in node.Value.entitiesList)
        {
            Entity e = allEntities.Find(x => x.id == data.id);
            if (e != null)
            {
                e.transform.position = data.position;
                e.health = data.health;
                e.attack = data.attack;
                e.speed = data.speed;
            }
        }
    }
    [Button]
    public void NextTurn()
    {
        if (itchanged)
        {
            SaveTurn();
        }
        else if(turnHistory.Peak != null && turnHistory.Peak.Next != null)
        {
            turnHistory.MovePeakNext();
            ApplyTurn(turnHistory.Peak);
        }
        else
        {
            Debug.Log("No hay turnos siguientes");
        }
    }
    [Button]
    public void PrevTurn()
    {
        if (itchanged)
        {
            SaveTurn();
        }
        if (turnHistory.Peak != null && turnHistory.Peak.Prev != null)
        {
            turnHistory.MovePeakPrev();
            ApplyTurn(turnHistory.Peak);
        }
        else
        {
            Debug.Log("No hay turnos anteriores");
        }
    }    
}


//public class _GameManager : MonoBehaviour
//{
//    public CustomDoubleLinkedList<EntityData> entities;

//    public Node<EntityData> PeekEntityByID(int id)
//    {
//        Node<EntityData> current = entities.Peek();
//        if (current != null && current.Value.id == id)
//        {
//            return current;      
//        }
//        current = current.Next;
//        return null; 
//    }
//}
