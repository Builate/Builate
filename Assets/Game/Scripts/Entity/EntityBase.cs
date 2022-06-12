using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        public EntityBaseData Data;

        /// <summary>
        /// EntityDataList�ǉ����ɌĂ΂�܂��B
        /// mesh,material�̐ݒ�ȂǃQ�[���N�����ɍs�����������������Ă��������B
        /// </summary>
        public virtual void Init()
        {
            
        }

        /// <summary>
        /// entity�̏o�����Ɉ�x�����Ă΂�܂��B
        /// Unity��Start�֐��Ɠ����悤�ɍl���Ă��������B
        /// </summary>
        public virtual void Start()
        {
            
        }

        /// <summary>
        /// entity�o���㖈�t���[���Ă΂�܂��B
        /// Unity��Update�֐��Ɠ����悤�ɍl���Ă��������B
        /// </summary>
        public virtual void Update()
        {
            
        }

        /// <summary>
        /// �l�b�g���[�N�ʐM����A�f�[�^�̃��[�h���Ɏg�p����Deserialize�֐��ł��B
        /// </summary>
        public virtual void Deserialize(DataReader dataReader)
        {
            
        }

        /// <summary>
        /// �l�b�g���[�N�ʐM����A�f�[�^�̃Z�[�u���Ɏg�p����Serialize�֐��ł��B
        /// </summary>
        public virtual DataWriter Serialize()
        {
            return new DataWriter();
        }

        #region SerializeUtility

        public byte[] S_Transform()
        {
            DataWriter dataWriter = new DataWriter();

            dataWriter.Put(gameObject.transform.position);
            dataWriter.Put(gameObject.transform.rotation.eulerAngles);
            dataWriter.Put(gameObject.transform.localScale);
            
            return dataWriter.GetData();
        }

        #endregion

        #region DeserializeUtility

        public void D_Transform(byte[] data)
        {
            DataReader dataReader = new DataReader(data);

            gameObject.transform.position = dataReader.GetVector3();
            gameObject.transform.rotation = Quaternion.Euler(dataReader.GetVector3());
            gameObject.transform.localScale = dataReader.GetVector3();
        }

        #endregion
    }

    public class EntityBaseData
    {
        /// <summary>
        /// Entity��Name
        /// ��ӂł���K�v�͂Ȃ�
        /// </summary>
        public string Name;
        /// <summary>
        /// (modID,entityDataID)
        /// </summary>
        public (string, int) EntityDataID;
        /// <summary>
        /// �emod
        /// </summary>
        public Mod mod;
    }
}