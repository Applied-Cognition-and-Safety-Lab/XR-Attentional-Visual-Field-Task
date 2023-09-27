using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//this class will hold static data about the task design: visual angle of distractors and stimulus, Eccentricity, presence of distractors,
//number of directions
//ensure that images for distractors and targets are 66 x 66 pixels to ensure they are sized appropriately
public class ExperimentSettings : MonoBehaviour
{
    private InputField dateField;
    private InputField participantNumberField;
    private bool distractorsPresent;
    private int numberOfDirec;
    private string targetDirection;
    private float targetEccentricity;
    private string date;
    private int participantNumber;
    private int numOfTrials;
    public int numOfBlocks;
    public float targetVisualAngle;
    public float distractorVisualAngle;
    private float screenDistance;
    private int numberOfEcc;
    public float[] degEccentricities;
    private float[] eccentricities;
    public float[] exposureTimes;
    private int numberOfExp;
    private float targetExposure;
    public int trialRepetitions;
    public float maskDisplayTime;
    public float responseWindow;
    public float breakTime;
    public int practiceTrialNum;
    public bool useDistractors;
    public Color targetColor;
    public Color distractorColor;
    public Texture targetImg;
    public Texture distractorImg;

    private void Awake()
    {
        distractorsPresent = true;
        numberOfEcc = degEccentricities.Length;
        numberOfExp = exposureTimes.Length;
        numberOfDirec = 8;
        numOfTrials = numberOfDirec * numberOfEcc * numberOfExp * trialRepetitions;
        screenDistance = 350;
        dateField = GameObject.Find("DateInput").GetComponent<InputField>();
        participantNumberField = GameObject.Find("ParticipantNumberInput").GetComponent<InputField>();
    }

    //Need to actually set these data points from dialog boxes
    void Start()
    {
        targetDirection = "";
        targetEccentricity = 0f;
        targetExposure = 0;
        ConvEccs();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDate()
    {
        date = dateField.text;
    }

    public void SetParticipantNumber()
    {
        participantNumber = Convert.ToInt32(participantNumberField.text);
    }

    public string GetDate()
    {
        return date;
    }

    public int GetParticipantNumber()
    {
        return participantNumber;
    }

    //sets target direction, eccentricity, exposure, and number of trials based on these values and repetition for each
    public void SetDirEccExpo(int direction, int eccentricity, int exposure)
    {
        switch (direction)
        {
            case 0:
                targetDirection = "N";
                break;

            case 1:
                targetDirection = "NE";
                break;

            case 2:
                targetDirection = "E";
                break;

            case 3:
                targetDirection = "SE";
                break;

            case 4:
                targetDirection = "S";
                break;

            case 5:
                targetDirection = "SW";
                break;

            case 6:
                targetDirection = "W";
                break;

            case 7:
                targetDirection = "NW";
                break;
        }

        targetEccentricity = degEccentricities[eccentricity];
        targetExposure = exposureTimes[exposure];
        
    }

    public string GetDir()
    {
        return targetDirection;
    }

    public float GetEcc()
    {
        return targetEccentricity;
    }

    public float GetTargVisualAngle()
    {
        return targetVisualAngle;
    }
    public float GetDistrVisualAngle()
    {
        return distractorVisualAngle;
    }

    public bool GetDistrPresent()
    {
        return distractorsPresent;
    }

    public int GetNumEcc()
    {
        print("Ecc " + numberOfEcc);
        return numberOfEcc;
    }

    public float GetDegEccs(int index)
    {
        return degEccentricities[index];
    }

    private float CalcEccs(int index)
    {
        float distConv;
        distConv = (Mathf.Tan((GetDegEccs(index)) * Mathf.Deg2Rad) * GetScreenDistance()) / 12.8542f;
        print("whatever this " + Mathf.Tan((GetDegEccs(index)) * Mathf.Deg2Rad));
        print("whatever this is 2 " + Mathf.Tan((GetDegEccs(index)) * Mathf.Deg2Rad) * GetScreenDistance());
        print("distConv " + distConv);
        print("Degrees Got " + GetDegEccs(index));
        return distConv;
    }

    private void ConvEccs()
    {
        eccentricities = new float[degEccentricities.Length];
        for (int i = 0; i < degEccentricities.Length; i++)
        {
            eccentricities[i] = CalcEccs(i);
        }
    }

    public float GetEccs(int index)
    {
        return eccentricities[index];
    }

    public int GetNumDir()
    {
        return numberOfDirec;
    }

    public int GetNumExpos()
    {
        return exposureTimes.Length;
    }

    public float GetScreenDistance()
    {
        return screenDistance;
    }

    
    public float GetExpTime()
    {
        return targetExposure;
    }

    public int GetNumReps()
    {
        return trialRepetitions;
    }

    public float GetIndexedExp(int exposureIndex)
    {
        return exposureTimes[exposureIndex];
    }

    public float GetMaskTime()
    {
        return maskDisplayTime;
    }

    public float GetRespWindow()
    {
        return responseWindow;
    }

    public float GetBreakTime()
    {
        return breakTime;
    }

    public int GetTrialNum()
    {
        return numOfTrials;
    }

    public int GetBlockNum()
    {
        return numOfBlocks;
    }

    public int GetPracticeTrialNum()
    {
        return practiceTrialNum;
    }

    public bool DistractorsUsed()
    {
        return useDistractors;
    }

    public Color GetTargColor()
    {
        return targetColor;
    }

    public Color GetDistrColor()
    {
        return distractorColor;
    }

    public Texture GetDistrImg()
    {
        return distractorImg;
    }

    public Texture GetTargImg()
    {
        return targetImg;
    }
}
