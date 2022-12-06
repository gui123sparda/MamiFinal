using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelController : MonoBehaviour
{
    public Transform rpmPointer;
    public Transform kmPointer;
    const float ZERO_RPM_ANGLE = 145f;
    const float MAX_RPM_ANGLE=-96f;
    const float ZERO_KM_ANGLE=150f;
    const float MAX_KM_ANGLE=-150f;
    public CarController carInfo;
    public int currentGear;
    public TextMeshProUGUI[] textGear;
    
    void Awake(){
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentGear = carInfo.gear;
        SelectedGear();
        //carInfo.rpmEngine+=30f*Time.deltaTime;
        if(carInfo.rpmEngine>carInfo.maxRpmEngine) carInfo.rpmEngine=Random.Range(carInfo.maxRpmEngine-100f,carInfo.maxRpmEngine);
        if(carInfo.rpmEngine<950)carInfo.rpmEngine=1000;
        rpmPointer.eulerAngles = new Vector3(0f,0f,GetRpmRotation());

        kmPointer.eulerAngles=new Vector3(0f,0f,GetKmRotation());
    }

    void SelectedGear(){
        
            textGear[currentGear].color = Color.red;
            for(int i=0;i<7;i++){
                if(textGear[i]!=textGear[currentGear]){
                    textGear[i].color=Color.white;
                }
            }
        
    }

    float GetRpmRotation(){
        float totalAngleSize=ZERO_RPM_ANGLE - MAX_RPM_ANGLE;
        float rpmNormalized = carInfo.rpmEngine/carInfo.maxRpmEngine;
        return ZERO_RPM_ANGLE-rpmNormalized*totalAngleSize;

    }
    float GetKmRotation(){
        float totalAngleSize= ZERO_KM_ANGLE-MAX_KM_ANGLE;
        float kmNormalized = carInfo.km/carInfo.maxKm;
        return ZERO_KM_ANGLE-kmNormalized*totalAngleSize;

    }
}
