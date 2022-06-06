using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    /// <summary>
    /// �S�Ă�Mod���p������N���X
    /// EntityData��錾����ɂ�EntityData�Ƃ���Enum�^�̕ϐ����`���܂��B
    /// </summary>
    public abstract class Mod
    {
        /// <summary>
        /// modID�͈�ӂł���K�v������܂�
        /// </summary>
        public string modID;

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


        public void CreateEntity(int id)
        {
            EntityData.CreateEntity((modID, id));
        }

        public void CreateEntity(string modId,int id)
        {
            EntityData.CreateEntity((modId, id));
        }
        public void CreateEntity(int id,Guid guid)
        {
            EntityData.CreateEntity((modID, id), guid);
        }

        public void CreateEntity(string modId,int id,Guid guid)
        {
            EntityData.CreateEntity((modId, id), guid);
        }
    }
}