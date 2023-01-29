using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turning : MonoBehaviour
{
    private Transform Ball;
    private Transform Cube;

    public float speed;
    public Vector3 Aim;
    public float Cubedistance;
    private Slider speedSlider;
    private Slider distanceSlider;

    // Start is called before the first frame update
    void Start()
    {
        Ball = GameObject.FindWithTag("Ball").GetComponent<Transform>();
        Cube = GameObject.FindWithTag("Cube").GetComponent<Transform>();
        speedSlider = GameObject.Find("SpeedSlider").GetComponent<Slider>();
        distanceSlider = GameObject.Find("DistanceSlider").GetComponent<Slider>();
        
        Aim = new Vector3(0.0f,0.0f,0.0f);

        DefaultSetting();
    }

    public void DefaultSetting(){

        speed = 100.0f;
        speedSlider.value = speed;

        Cubedistance = 2.0f;
        distanceSlider.value = Cubedistance;

    }

    // Update is called once per frame
    void Update()
    {
        speed = speedSlider.value;
        Cubedistance = distanceSlider.value;

        Aim = new Vector3(Aim.x + Time.deltaTime*speed, 0.00f, Aim.z + Time.deltaTime*speed);

        Ball.Translate(Cubedistance*Mathf.Sin((Aim.x/180)*Mathf.PI) - Ball.position.x, 0, Cubedistance*Mathf.Cos((Aim.z/180)*Mathf.PI) - Ball.position.z);
    }
}
