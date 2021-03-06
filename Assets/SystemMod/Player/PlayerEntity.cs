using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    
    public class PlayerEntity : EntityBase
    {
        public override void Init()
        {

        }
        public override void Start()
        {
            SetComponent();
            gameObject.transform.position = new Vector3(0, 10, 0);
        }

        public override void Update()
        {

        }

        public void SetComponent()
        {
            CharacterController cc = gameObject.AddComponent<CharacterController>();
            PlayerController pc = gameObject.AddComponent<PlayerController>();
            GameObject go = GameObject.Instantiate(SystemModResource.Instance.PlayerModelPrefab);
            gameObject.tag = "Player";
            go.transform.SetParent(gameObject.transform);
            go.transform.localPosition = Vector3.zero;

            cc.slopeLimit = 45;
            cc.stepOffset = 0.3f;
            cc.skinWidth = 0.08f;
            cc.minMoveDistance = 0;
            cc.center = new Vector3(0, 0, 0);
            cc.radius = 0.5f;
            cc.height = 2;
            
            pc.WalkSpeed = 7;
            pc.DushSpeed = 14;
            pc.GravityScale = 40f;
            pc.JumpForce = 10;
            pc.Velocity = new Vector3(0, 0, 0);
        }
        
        public override void Deserialize(DataReader dataReader)
        {
            D_Transform(dataReader.GetBytes());
            SetComponent();
            CameraEntity.CvCamera.Follow = gameObject.transform;
        }
        public override DataWriter Serialize()
        {
            DataWriter dw = new DataWriter();
            dw.Put(S_Transform());
            return dw;
        }
    }
}