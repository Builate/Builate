using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public abstract class ItemBase
    {
        /// <summary>
        /// ���̂̃Q�[���I�u�W�F�N�g
        /// </summary>
        public GameObject gameObject;
        
        /// <summary>
        /// �S�Ă̋��ʂ̃A�C�e���ŋ��L�����ׂ��f�[�^
        /// </summary>
        public ItemBaseData Data;
    }

    public class ItemBaseData
    {
        /// <summary>
        /// Item�̖��O
        /// </summary>
        public string Name;
        /// <summary>
        /// (modID,itemDataID)
        /// </summary>
        public (string, int) ItemDataID;
        /// <summary>
        /// �emod
        /// </summary>
        public Mod mod;
    }
}