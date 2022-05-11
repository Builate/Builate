using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public static class EntityData
    {
        /// <summary>
        /// Entity�𗅗񂵂Ă���
        /// Entity�̌��f�[�^
        /// </summary>
        public static Dictionary<(string, int), EntityBase> EntityDataList = new Dictionary<(string, int), EntityBase>();

        /// <summary>
        /// ���ۂɎ��݂��Ă���Entity�𗅗񂵂Ă���
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
            EntityList.Add(entity.EntityID, entity);

            return entity;
        }

        public static void Update()
        {
            foreach (var item in EntityList.Values)
            {
                item.Update();
            }
        }
    }
}