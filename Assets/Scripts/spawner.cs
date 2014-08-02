using UnityEngine; 
using System.Collections; 
 
public class spawner : MonoBehaviour { 
 
     public Rigidbody2D enemi; 
 
     float SpawnStartDelay = 0f; 
     float SpawnRate = 3.5f; 
 
     void Start () { 
 
          InvokeRepeating("Spawn", SpawnStartDelay, SpawnRate); 
 
     } 
 
     void Spawn () { 
           
          Instantiate(enemi, transform.position, transform.rotation); 
           
     } 
}  