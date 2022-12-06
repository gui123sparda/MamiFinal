using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public WheelJoint2D frontWheel,rearWheel;
    JointMotor2D engine;
    public Rigidbody2D car;
    public float acceleration;
    public float torqueEngine;

    public float rpmEngine;
    public float maxRpmEngine;
    public float km;
    public float maxKm;
    public int gear;
    public float gearRatio;

    public Transform resetPos;
    // Start is called before the first frame update
    void Start()
    {
        rpmEngine=1000;
        maxRpmEngine=7000;
        maxKm = 220;
        gear=1;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.R)){
            this.transform.position=resetPos.transform.position;

        }

        if(Input.GetKeyDown(KeyCode.UpArrow)&&gear<6){
            gear++;
            rpmEngine-=700f;
        }else if(Input.GetKeyDown(KeyCode.DownArrow)&&gear>0){
            gear--;
            rpmEngine+=1000f;
        }
        if(gear==0){
            Debug.Log("R");
            gearRatio=3.62f;
        }else if(gear ==1){      
            Debug.Log("N");
            gearRatio=0f;
        }else if(gear ==2){
            Debug.Log("1");
            gearRatio=3.58f;
        }else if(gear ==3){
            Debug.Log("2");
            gearRatio=1.91f;
        }else if(gear ==4){
            Debug.Log("3");
            gearRatio=1.28f;
        }else if(gear ==5){
            Debug.Log("4");
            gearRatio=0.95f;
        }else if(gear ==6){
            Debug.Log("5");
            gearRatio=0.76f;
        }
        float x = Input.GetAxis("Horizontal");
        if(x>0&&gear==1){
            rpmEngine+=7f;
        }
        if(x>0&&gear>1){
            frontWheel.useMotor=true;
            rpmEngine+=7f;
            engine.motorSpeed=(acceleration/gearRatio*10);
            engine.maxMotorTorque =torqueEngine;

            frontWheel.motor = engine;

        }else if(x>0&&gear==0){
            frontWheel.useMotor=true;
            rpmEngine+=7f;
            engine.motorSpeed=((acceleration/gearRatio)*10)*-1;
            engine.maxMotorTorque=torqueEngine;

            frontWheel.motor = engine;
        }else if(x==0){
            rpmEngine-=7f;
            frontWheel.useMotor=false;
        }else if(x==0&&gear>1){
            rpmEngine-=7f;
        }
        km=car.velocity.magnitude*3.6f;
        if(rpmEngine>6500f){
            rpmEngine=Random.Range(6400f,6500f);
        }
        
    }
}
