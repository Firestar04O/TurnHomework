using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;

public class EntityData
{
    public int id;
    public int health;
    public int attack;
    public float speed;
    public Vector2 position;

    public EntityData(Entity entity)
    {
        id = entity.id;
        health = entity.health;
        attack = entity.attack;
        speed = entity.speed;
        position = entity.position;
    }
}
public class Entity : MonoBehaviour
{
    public int id;
    public int health;
    public int attack;
    public float speed;
    public Vector2 position;
    public _GameManager manager;
    private void Update()
    {
        position = transform.position;
        ModifyEntity(this);
    }
    public void ModifyEntity(Entity modifiedEntity)
    {
        if (manager.turnHistory.Peak == null)
        {
            return;
        }
        EntityData savedData = manager.turnHistory.Peak.Value.entitiesList.Find(data => data.id == modifiedEntity.id);

        if (savedData != null && GameUtils.Ricardo.EntityChanged(savedData, modifiedEntity))
        {
            manager.itchanged = true;
        }
    }
}

