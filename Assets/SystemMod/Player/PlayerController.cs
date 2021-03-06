using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KYapp.Utility.Standard;

namespace KYapp.Builate
{
    public class PlayerController : MonoBehaviour
    {
        public CharacterController cc;
        public float WalkSpeed;
        public float DushSpeed;
        public float GravityScale;
        public float JumpForce;
        public Vector3 Velocity;
        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cc = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            #region 移動
            float Horizontal = Input.GetAxisRaw("Horizontal");
            float Vertical = Input.GetAxisRaw("Vertical");
            Quaternion horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);
            Vector3 MoveVec = horizontalRotation * new Vector3(Horizontal, 0, Vertical);


            MoveVec.Normalize();
            #endregion
            #region 重力
            if (cc.isGrounded)
            {
                Velocity = new Vector3(0, -0.1f, 0);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Velocity += new Vector3(0, JumpForce, 0);
                }
            }
            else
            {
                Velocity -= new Vector3(0, GravityScale, 0) * Time.deltaTime;
            }
            #endregion

            #region 設置

            Ray pointRay = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));
            if (Input.GetMouseButtonDown(0) &&
                Physics.Raycast(pointRay,out var hit))
            {
                SetEntity(hit.point, "SystemMod",2);
            }

            #endregion
            
            cc.Move(MoveVec * (Input.GetKey(KeyCode.LeftShift) ? DushSpeed : WalkSpeed) * Time.deltaTime + Velocity * Time.deltaTime);
        }

        private void SetEntity(Vector3 position, string modName,int entityID)
        {
            Entity testEntity = EntityData.CreateEntity((modName, entityID));
            testEntity.EntityBase.gameObject.transform.position = position;
        }
    }
}