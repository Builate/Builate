using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using LiteNetLib;
using LiteNetLib.Utils;

namespace KYapp.Builate
{
    public static class MultiUtil
    {
        /// <summary>
        /// Server���X�^�[�g����֐�
        /// </summary>
        /// <param name="Server">�X�^�[�g����NetManager�̃C���X�^���X</param>
        /// <param name="Port">�g�p����|�[�g</param>
        /// <param name="UpdateTime">�A�b�v�f�[�g���鎞�̎��ԁi�~���b�j</param>
        public static void StartServer(NetManager Server,int Port,int UpdateTime)
        {
            Debug.Log("StartServer");
            Server.Start(Port);
            Server.UpdateTime = UpdateTime;
        }

        /// <summary>
        /// Client���X�^�[�g����֐�
        /// </summary>
        /// <param name="Client">�X�^�[�g����NetManager�̃C���X�^���X</param>
        /// <param name="UpdateTime">�A�b�v�f�[�g����Ƃ��̎��ԁi�~���b�j</param>
        public static void StartClient(NetManager Client, int UpdateTime)
        {
            Debug.Log("StartClient");
            Client.UnconnectedMessagesEnabled = true;
            Client.UpdateTime = UpdateTime;
            Client.Start();
        }
    }
}