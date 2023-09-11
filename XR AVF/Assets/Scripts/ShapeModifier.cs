using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeModifier : MonoBehaviour
{
    //can add other images for the program to select from: circles, triangles, filled in shapes, etc
    public GameObject distractor;
    public GameObject target;
    private ExperimentSettings dataHolder;
    public StimulusImageCreator imageCreator;
    // Start is called before the first frame update
    void Start()
    {
        dataHolder = GameManager.Instance.dataHolder;
        ChangeImage(distractor, dataHolder.GetDistrImg());
        ChangeImage(target, dataHolder.GetTargImg());
        ScaleImage(distractor, 0);
        ScaleImage(target, 1);
        ChangeColor(distractor, dataHolder.GetDistrColor());
        ChangeColor(target, dataHolder.GetTargColor());
        imageCreator.SetValues();
        print("Direction: " + dataHolder.GetDir() + " Ecc: " + dataHolder.GetEcc());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeImage(GameObject obj, Texture texture)
    {
        obj.GetComponent<RawImage>().texture = texture;
    }

    //
    public void ChangeColor(GameObject obj, Color color)
    {
        obj.GetComponent<RawImage>().color = color;
    }


    //size = 2 * object distance * (tan (visual angle / 2))
    //objType 0 is distractor; objType 1 is target
    public void ScaleImage(GameObject obj, int objType)
    {
        //sizeCanv is the size of the object in unity canvas units 
        float sizeCanv;

        //calculate size for distractor
        if (objType == 0)
        {
            //Using Mathf.Deg2Rad to convert visual angle from degrees to radians b/c Mathf.Tan uses radians
            sizeCanv = 2 * ((Mathf.Tan((dataHolder.GetDistrVisualAngle() / 2) * Mathf.Deg2Rad) * dataHolder.GetScreenDistance()) / 24.4965f);
        }

        //calculate size for target
        else
        {
            //Using Mathf.Deg2Rad to convert visual angle from degrees to radians b/c Mathf.Tan uses radians
            sizeCanv = 2 * ((Mathf.Tan((dataHolder.GetTargVisualAngle() / 2) * Mathf.Deg2Rad) * dataHolder.GetScreenDistance()) / 24.4965f);
        }

        obj.transform.localScale = new Vector3(sizeCanv, sizeCanv);
        
        print("tan " + 2 * ((Mathf.Tan((dataHolder.GetTargVisualAngle() / 2) * Mathf.Deg2Rad) * dataHolder.GetScreenDistance())));
        print("object size: " + obj.transform.localScale);
        print("screen distance " + dataHolder.GetScreenDistance());
        print("visual angle " + dataHolder.GetTargVisualAngle());
        print("sizeCanv " + sizeCanv);
    }
}
