using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public abstract class EntityBase
    {
        /// <summary>
        /// ���̂�gameObject
        /// </summary>
        public GameObject gameObject;

        /// <summary>
        /// �S�Ẵu���b�N�ŋ��L�����ׂ��f�[�^��EntityBaseData���p�����Ă���Data�ɑ�����Ă��������B
        /// </summary>
        public EntityBaseData Data = new EntityBaseData();

        /// <summary>
        /// EntityDataList�ǉ����ɌĂ΂�܂��B
        /// mesh,material�̐ݒ�ȂǃQ�[���N�����ɍs�����������������Ă��������B
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// entity�̏o�����Ɉ�x�����Ă΂�܂��B
        /// Unity��Start�֐��Ɠ����悤�ɍl���Ă��������B
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// entity�o���㖈�t���[���Ă΂�܂��B
        /// Unity��Update�֐��Ɠ����悤�ɍl���Ă��������B
        /// </summary>
        public abstract void Update();
    }

    public class EntityBaseData
    {
        public string Name;
        public (string, int) EntityDataID;
        public Mesh mesh;
        public Material material;
    }
}