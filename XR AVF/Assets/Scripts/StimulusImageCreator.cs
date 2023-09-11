using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StimulusImageCreator : MonoBehaviour
{
    private ExperimentSettings dataHolder;
    public GameObject target;
    public GameObject distractor;
    private GameObject[][] distractors;
    private Vector2[][] locations;
    private int numOfDis;
    private int numOfDirects;
    private int numOfEcc;
    private bool valuesSet = false;
    private int distrCount = 0;
    private int[] horzMod;
    private int[] vertMod;
    private Vector2 lastLocation;
    private Color targColor;
    private Color distrColor;
    private Color clearedColor;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetValues()
    {
        dataHolder = GameManager.Instance.dataHolder;
        numOfDirects = dataHolder.GetNumDir();
        numOfEcc = dataHolder.GetNumEcc();


        lastLocation = new Vector2(0f, 0f);
        

        //change this for different numbers of directions; this is for 8 directions
        horzMod = new int[numOfDirects];
        vertMod = new int[numOfDirects];

        for(int i = 0; i < numOfDirects; i++)
        {
            switch (i)
            {
                case 0:
                    horzMod[i] = 0;
                    vertMod[i] = 1;
                    break;

                case 1:
                    horzMod[i] = 1;
                    vertMod[i] = 1;
                    break;

                case 2:
                    horzMod[i] = 1;
                    vertMod[i] = 0;
                    break;

                case 3:
                    horzMod[i] = 1;
                    vertMod[i] = -1;
                    break;

                case 4:
                    horzMod[i] = 0;
                    vertMod[i] = -1;
                    break;

                case 5:
                    horzMod[i] = -1;
                    vertMod[i] = -1;
                    break;

                case 6:
                    horzMod[i] = -1;
                    vertMod[i] = 0;
                    break;

                case 7:
                    horzMod[i] = -1;
                    vertMod[i] = 1;
                    break;
            }
        }
        


        //subtract 1 here to account for target's location
        numOfDis = (numOfDirects * numOfEcc) - 1;

        locations = new Vector2[numOfDirects][];
        for (int i = 0; i < numOfDirects; i++)
        {
            locations[i] = new Vector2[numOfEcc];

        }

        distractors = new GameObject[numOfDirects][];
        for (int i = 0; i < numOfDirects; i++)
        {
            distractors[i] = new GameObject[numOfEcc];

        }



        for (int i = 0; i < numOfDirects; i++)
        {
            for (int j = 0; j < numOfEcc; j++)
            {
                //add in horizontal and vertical ecc modifiers
                if (i % 2 == 0)
                {
                    locations[i][j] = new Vector2(horzMod[i] * dataHolder.GetEccs(j), vertMod[i] * dataHolder.GetEccs(j));
                    print("locations  " + locations[i][j]);
                }

                //diagonal eccentricities
                else
                {
                    locations[i][j] = new Vector2(horzMod[i] * dataHolder.GetEccs(j) * Mathf.Sqrt(2) / 2,  vertMod[i] * dataHolder.GetEccs(j) * Mathf.Sqrt(2) / 2);
                    print("location diaganol " + locations[i][j]);
                }
                
                if (dataHolder.DistractorsUsed())
                {
                    distractors[i][j] = GameObject.Instantiate(distractor, distractor.transform.parent);
                    distractors[i][j].GetComponent<RectTransform>().anchoredPosition = locations[i][j];
                    distrCount++;
                    print("Distractor count: " + distrCount);
                }

            }

        }

        print("object distance: " + locations[0][0]);

        targColor = target.GetComponent<RawImage>().color;
        clearedColor = new Color(targColor.r, targColor.g, targColor.b, 0);

        if (dataHolder.DistractorsUsed())
        {
            distrColor = distractor.GetComponent<RawImage>().color;
            distractor.SetActive(false);
        }

        valuesSet = true;
        ClearScreen();
    }

    //sets location of target and distractors for a given trial; also sets the trial information for data recording: direction and eccentricity
    public void DisplayTarget(int direction, int eccentricity)
    {
        if (dataHolder.DistractorsUsed())
        {

            for (int i = 0; i < numOfDirects; i++)
            {
                for (int j = 0; j < numOfEcc; j++)
                {
                    distractors[i][j].GetComponent<RawImage>().color = distrColor;

                }
            }

            distractors[direction][eccentricity].GetComponent<RawImage>().color = clearedColor;
        }

        target.GetComponent<RectTransform>().anchoredPosition = locations[direction][eccentricity];
        target.GetComponent<RawImage>().color = targColor;
    }

    public void StartMask(int direction, int eccentricity)
    {
        target.GetComponent<RawImage>().color = clearedColor;
        target.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);

        if (dataHolder.DistractorsUsed())
        {
            distractors[direction][eccentricity].GetComponent<RawImage>().color = distrColor;
        }
    }

    public void ClearScreen()
    {
        target.GetComponent<RawImage>().color = clearedColor;

        if (dataHolder.DistractorsUsed())
        {
            for (int i = 0; i < numOfDirects; i++)
            {
                for (int j = 0; j < numOfEcc; j++)
                {
                    distractors[i][j].GetComponent<RawImage>().color = clearedColor;
                }
            }
        }
    }
}
