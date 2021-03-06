using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public static class EntityData
    {
        /// <summary>
        /// Entityを羅列してある
        /// Entityの元データ
        /// </summary>
        public static Dictionary<(string, int), EntityBase> EntityDataList = new Dictionary<(string, int), EntityBase>();

        /// <summary>
        /// 実際に実在しているEntityを羅列してある
        /// </summary>
        public static Dictionary<Guid, Entity> EntityList = new Dictionary<Guid, Entity>();

        public static (string, int) AddEntityData(EntityBase eb)
        {
            eb.Init();
            EntityDataList.Add(eb.Data.EntityDataID, eb);
            return eb.Data.EntityDataID;
        }

        public static Entity CreateEntity((string, int) id)
        {
            EntityBase eb = (EntityBase)Activator.CreateInstance(EntityDataList[id].GetType());
            eb.Data = EntityDataList[id].Data;
            Entity entity = new Entity(eb);
            
            AddEntity(entity);
            
            entity.EntityBase.Start();

            return entity;
        }

        public static void AddEntity(Entity entity)
        {
            EntityList.Add(entity.EntityID, entity);
        }

        public static void Update()
        {
            List<Entity> values = new List<Entity>();
            foreach (var item in EntityList.Values)
            {
                values.Add(item);
            }
            foreach (var item in values)
            {
                item.Update();
            }
        }
    }
}