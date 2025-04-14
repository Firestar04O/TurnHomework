using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomNode
{
    public int turnNumber;
    public List<EntityData> entitiesList;
    public CustomNode(int turnNumber, List<EntityData> entities)
    {
        this.turnNumber = turnNumber;
        this.entitiesList = entities;
    }
}
