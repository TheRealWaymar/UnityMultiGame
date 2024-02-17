using TMPro;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;
using Unity.Collections;
using System.Collections;
using System.Collections.Generic;
namespace HelloWorld
{
    public class HelloWorldPlayer : NetworkBehaviour
    {
        public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();
        public NetworkVariable<Quaternion> Rotation = new NetworkVariable<Quaternion>();
        public NetworkVariable<Color> playerColour = new NetworkVariable<Color>();
        public float positionRange = 5f;
        public Animator animator;
        public float movementSpeed = 5f;
        public float rotationSpeed = 300f;

        private void Awake()
        {
            //meshRenderer = GetComponent<MeshRenderer>();
        }
        private void Start()
        {
            //playerColour.Value = GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        }
        public override void OnNetworkSpawn()
        {
            Debug.Log("spawned");
            playerColour.OnValueChanged += OnStateChanged;
            playerColoursServerRpc();
            
            //playerColoursClientRpc();
           // playerColour.OnValueChanged += OnStateChanged;
            Position.Value = new Vector3(Random.Range(positionRange, -positionRange),0, Random.Range(positionRange, -positionRange));
            Rotation.Value = new Quaternion(0,0,0,0);
        }

        private void OnStateChanged(Color previousValue, Color newValue)
        {
            if(previousValue != newValue)
            {
                GetComponent<Renderer>().material.color = newValue;
            }
        }

        /*[ServerRpc]
        void ForwardServerRpc(ServerRpcParams rpcParams = default)
        {   
            Position.Value = transform.position += transform.forward * Time.deltaTime;  
            animator.Play("anim1");
        }
        [ServerRpc]
        void BackwardServerRpc(ServerRpcParams rpcParams = default)
        {
            Position.Value = transform.position -= transform.forward * Time.deltaTime;
            animator.Play("anim1");
        }
        [ServerRpc]
        void RightServerRpc(ServerRpcParams rpcParams = default)
        {
            Position.Value = transform.position += transform.right * Time.deltaTime;
            animator.Play("anim1");
        }
        [ServerRpc]
        void LeftServerRpc(ServerRpcParams rpcParams = default)
        {
            Position.Value = transform.position -= transform.right * Time.deltaTime;
            animator.Play("anim1");
        }
        
        [ClientRpc]
        void playerColoursClientRpc(ClientRpcParams rpcParams = default)
        {
            GetComponent<Renderer>().material.color = playerColour.Value;
        } */
        [ServerRpc]
        void playerColoursServerRpc(ServerRpcParams rpcParams = default)
        {
             playerColour.Value = GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        }


        void Update()
        {
            //old movement code
            //if (IsOwner || IsClient)
            //{
                //if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.S))|| (Input.GetKey(KeyCode.A))|| (Input.GetKey(KeyCode.D)))
                //{
                //    Debug.Log("Firing");
                //    Move();
                //}
                //if ((Input.GetKey(KeyCode.W)))
              //  {
              //      ForwardServerRpc();
             //       
             //   }
             //   if ((Input.GetKey(KeyCode.S)))
             //   {
             //       BackwardServerRpc();  
                      
            //    }
            //    if ((Input.GetKey(KeyCode.D)))
            //    {
            //        RightServerRpc();  
                     
            //    }
            //    if ((Input.GetKey(KeyCode.A)))
            //    {
            //        LeftServerRpc();
                    
            //    }
            //    else {animator.Play("idle");}
                
            //}
            
            if(!IsOwner) return;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
            movementDirection.Normalize();

            transform.Translate(movementDirection * movementSpeed * Time.deltaTime, Space.World);

            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
            //transform.position = Position.Value;
            animator.SetFloat("move", movementDirection.magnitude);
        }
    }
}
