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

    //scale based on 10 degrees of visual angle and 350 mm from the screen, obj is 61.24 mm vert and horiz, base stimulus is 10 deg circle
    // with 6 degree filled in square inside
    //Visual angle formula: Visual angle = 2 * inverse tan ((object size / 2) / object distance)
    //size = 2 * object distance * (tan (visual angle / 2))
    //objType 0 is distractor; objType 1 is target
    public void ScaleImage(GameObject obj, int objType)
    {
        float sizeMili;

        //calculate size for distractor
        if(objType == 0)
        {
            sizeMili = 2 * dataHolder.GetSreenDistance() * (Mathf.Tan((dataHolder.GetDistrVisualAngle() / 2) * Mathf.Deg2Rad));
            print("Distractor scale");
        }

        //calculate size for target
        else
        {
            sizeMili = 2 * dataHolder.GetSreenDistance() * (Mathf.Tan((dataHolder.GetTargVisualAngle() / 2) * Mathf.Deg2Rad));
            print("Target scale");
        }

        float sizeModifier = sizeMili / 61.24f;
        //float sizeModifier = sizeMili / 17.5f;
        print("Size Modifier: " + sizeModifier);
        obj.transform.localScale = sizeModifier * obj.transform.localScale;
    }


}
