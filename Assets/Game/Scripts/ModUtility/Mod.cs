using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    /// <summary>
    /// �S�Ă�Mod���p������N���X
    /// </summary>
    public abstract class Mod
    {
        public string modID;

        /// <summary>
        /// Entity�𗅗񂵂Ă���
        /// Entity�̌��f�[�^
        /// </summary>
        public static List<EntityBase> ModEntityDataList = new List<EntityBase>();

        /// <summary>
        /// ���[���h�̃��[�h���ɌĂ΂��ݒ�p���\�b�h�ł�
        /// ������Mod��ID�̐ݒ�����Ă�������
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// ���[���h�̃��[�h�������ɌĂ΂��Z�b�g�A�b�v�p���\�b�h�ł�
        /// �����ŃI�u�W�F�N�g�̐����Ȃǂ����Ă�������
        /// </summary>
        public abstract void Start();

        public void SetEntityData()
        {
            for (int i = 0; i < ModEntityDataList.Count; i++)
            {
                ModEntityDataList[i].Data.EntityDataID.Item2 = i;
                ModEntityDataList[i].Data.EntityDataID.Item1 = modID;
                ModEntityDataList[i].Data.mod = this;
                EntityData.AddEntityData(ModEntityDataList[i]);
            }
        }

        public Entity CreateEntity(int id)
        {
            return EntityData.CreateEntity((modID, id));
        }

        public Entity CreateEntity(string modId,int id)
        {
            return EntityData.CreateEntity((modId, id));
        }
    }
}