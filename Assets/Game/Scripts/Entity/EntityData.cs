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

        public static void CreateEntity((string, int) id, Guid guid)
        {
            Client.Instance.CreateEntity(id, guid);
        }
        
        public static void CreateEntity((string, int) id)
        {
            CreateEntity(id, Guid.NewGuid());
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