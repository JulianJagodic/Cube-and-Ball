using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
     Ray ray;

     RaycastHit hit;

     private Renderer Cube;
     private Renderer Ball;

     private Color[] colorList = {Color.green, Color.yellow, Color.black, Color.blue, Color.red};

     private int[] random = {0, 0, 0, 0};

     private Turning script;

     void Start(){

        Cube = GameObject.FindWithTag("Cube").GetComponent<Renderer>();
        Ball = GameObject.FindWithTag("Ball").GetComponent<Renderer>();

        script = Ball.GetComponent<Turning>();
     }
     
     void Update()
     {
         ray = Camera.main.ScreenPointToRay(Input.mousePosition);

         if(Physics.Raycast(ray, out hit))
         {
             if(Input.GetMouseButtonDown(0) && hit.transform.tag == "Cube")
             {
                while(random[0] == random[1] || random[2] == random[3]){

                    random[1] = Random.Range(0,5);
                    random[3] = Random.Range(0,5);

                }
                
                Cube.material.color = colorList[random[1]];
                Ball.material.color = colorList[random[3]];
                random[0] = random[1];
                random[2] = random[3];
             }

             if(Input.GetMouseButtonDown(0) && hit.transform.tag == "Ball")
             {
                Reset();
             }
         }
     }

     public void Reset(){

        //Reset the scene
        Cube.material.color = Color.white;
        Ball.material.color = Color.white;

        script.DefaultSetting();

     }
}
