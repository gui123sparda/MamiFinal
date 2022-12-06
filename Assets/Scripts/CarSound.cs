using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{
    CarController carInfo;
    AudioSource carAudio;

    public float minRpm;
    public float maxRpm;
    public float currentRpm;
    public float minPitch;
    public float maxPitch;
    float pitchFromCar;

    void Awake(){
        carAudio = GetComponent<AudioSource>();
        carInfo = GetComponent<CarController>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EngineSound();
    }

    void EngineSound(){
        currentRpm = carInfo.rpmEngine/100;
        pitchFromCar=carInfo.rpmEngine/500f;

        if(currentRpm<minRpm){
            carAudio.pitch=minPitch;

        }
        if(currentRpm>minRpm&&currentRpm<maxRpm){
            carAudio.pitch=minPitch+pitchFromCar;

        }
        if(currentRpm>maxRpm){
            carAudio.pitch=maxPitch;
        }

    }
}
