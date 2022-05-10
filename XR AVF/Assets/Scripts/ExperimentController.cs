using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Diagnostics;
using UnityEngine.InputSystem;

public class ExperimentController : MonoBehaviour
{
    public string filePath;
    public string headers = "Block,Trial,Reaction Time,Eccentricity,StimulusDirection,Response,Actual Display Time,Set Display Time";
    private int[][][] rndTrialCount;
    private int numOfDirects;
    private int numOfEccs;
    private int numOfExpos;
    private int currentDir;
    private int currentEcc;
    private int currentExpos;
    private int trialRepetitions;
    public GameObject practiceCanvas;
    public GameObject practiceInst;
    public GameObject practiceGoing;
    public GameObject practiceEnded;
    public RectTransform taskCanvasTransform;
    private bool practiceIsOver;
    private bool readyToPractice;
    private bool isPracticing;
    private float maskEnded = 0f;
    public GameObject[] responses;
    public int numResp = 9;

    private int trialCount = 0;
    private int blockCount = 0;
    private bool lastLineWritten = false;

    public int[] positionToResponse = new int[] { 11, 12, 13, 21, 22, 23, 31, 32, 33 };

    //public string[] responseDirection = new string[] { "NW", "N", "NE", "W", "E", "SW", "S", "SE" };

    //                                                1      2    3   4     6     7    8     9
    //                                                0       1   2   3     4     5     6     7
    private string[] responseDirection = new string[] { "SW", "S", "SE", "W", "E", "NW", "N", "NE" };
    private DataHolder dataHolder;
    public StimulusImageCreator stimImgCrtr;

    public float startTime = 0;
    public float reactionTime = 0;
    public float timeDisplayed;
    public bool expStarted = false;

    //public bool upState;
    //public bool downState;
    //public bool rightState;
    //public bool leftState;
    public Vector2 trackPadLocation;
    public bool buttonPressed;
    public bool responding = false;
    public int responsePosition = 22;
    public int lastPos;

    private bool displayNextResponse = false;
    private float taskTime = 0f;

    private System.Random rndTrial = new System.Random();



    // Start is called before the first frame update
    void Start()
    {
        dataHolder = GameManager.Instance.dataHolder;
        //responding = true;
        filePath = dataHolder.GetDate() + "-Participant-" + dataHolder.GetParticipantNumber() + ".csv";
        StreamWriter sw = File.AppendText(filePath);
        sw.WriteLine(headers);
        sw.Close();

        readyToPractice = true;
        isPracticing = false;
        practiceIsOver = false;

        practiceCanvas.SetActive(true);
        practiceInst.SetActive(true);
        practiceGoing.SetActive(false);
        practiceEnded.SetActive(false);

        //trialCount = 72;



        if (responses == null)
        {
            responses = new GameObject[numResp];
        }

        foreach (GameObject obj in responses)
        {
            obj.SetActive(false);
        }

        numOfDirects = dataHolder.GetNumDir();
        numOfEccs = dataHolder.GetNumEcc();
        numOfExpos = dataHolder.GetNumExpos();
        trialRepetitions = dataHolder.GetNumReps();

        rndTrialCount = new int[numOfDirects][][];
        for (int i = 0; i < numOfDirects; i++)
        {
            rndTrialCount[i] = new int[numOfEccs][];

            for (int j = 0; j < numOfEccs; j++)
            {
                rndTrialCount[i][j] = new int[numOfExpos];
            }

        }

        //for (int i = 0; i < numOfDirects; i++)
        //{
        //    for (int j = 0; j < numOfEccs; j++)
        //    {
        //        rndTrialCount[i] = new int[numOfEccs][];
        //        for (int k = 0; k < numOfExpos; k++)
        //        {
        //            rndTrialCount[i][j] = new int[numOfExpos];
        //        }
        //    }
        //}

        ResetIndStimCount();
        taskCanvasTransform.localPosition = new Vector3 (0, 0, .3f);
    }

    // Update is called once per frame
    void Update()
    {
        //practice session 1
        if (readyToPractice && Keyboard.current.enterKey.wasReleasedThisFrame)
        {
            readyToPractice = false;
            isPracticing = true;
            practiceInst.SetActive(false);
            practiceGoing.SetActive(true);
            practiceEnded.SetActive(false);
            print("Practice started");
            StartCoroutine(ShowStimuli());
        }

        else if ((readyToPractice || isPracticing) && Keyboard.current.backspaceKey.wasReleasedThisFrame)
        {
            print("Practice ended");
            readyToPractice = false;
            practiceIsOver = true;
            responding = false;
            practiceCanvas.SetActive(false);
            StopAllCoroutines();
            stimImgCrtr.ClearScreen();
            isPracticing = false;




            foreach (GameObject obj in responses)
            {
                obj.SetActive(false);
            }


            ResetIndStimCount();
        }

        //practice session 2
        else if (isPracticing && trialCount == dataHolder.GetPracticeTrialNum())
        {
            practiceGoing.SetActive(false);
            practiceEnded.SetActive(true);
            StopAllCoroutines();
            stimImgCrtr.ClearScreen();
            print("Coroutines stopped");

            if(Keyboard.current.rightShiftKey.wasReleasedThisFrame)
            {
                ResetIndStimCount();
                trialCount = 0;
                isPracticing = true;
                practiceEnded.SetActive(false);
                practiceGoing.SetActive(true);
                print("Practice started, trial count " + trialCount);
                StartCoroutine(ShowStimuli());
            }
        }  
        
        else if (!expStarted && practiceIsOver && Keyboard.current.enterKey.wasReleasedThisFrame && blockCount == 0)
        {
            trialCount = 0;
            expStarted = true;
            taskTime = Time.realtimeSinceStartup;
            StartCoroutine(ShowStimuli());
        }

        if (practiceIsOver && trialCount == dataHolder.GetTrialNum() && blockCount < dataHolder.GetBlockNum())
        {
            trialCount = 0;
            blockCount++;


            ResetIndStimCount();

            StartCoroutine(ShowStimuli());
        }

        

        //this will end the experimental session/program
        if (trialCount == dataHolder.GetTrialNum() && blockCount == dataHolder.GetBlockNum() - 1 && !lastLineWritten)
        {
            lastLineWritten = true;
            taskTime = Time.realtimeSinceStartup - taskTime;
            StreamWriter sw = File.AppendText(filePath);
            sw.WriteLine("Time to complete task:," + taskTime);
            sw.Close();

            Application.Quit();
        }

        if (responding && Keyboard.current.anyKey.wasPressedThisFrame)
        {
            if(Keyboard.current.numpad1Key.wasPressedThisFrame)
            {
                RecordResponse(0);
                
            }

            else if(Keyboard.current.numpad2Key.wasPressedThisFrame)
            {
                RecordResponse(1);
            }

            else if (Keyboard.current.numpad3Key.wasPressedThisFrame)
            {
                RecordResponse(2);
            }

            else if (Keyboard.current.numpad4Key.wasPressedThisFrame)
            {
                RecordResponse(3);
            }

            else if (Keyboard.current.numpad6Key.wasPressedThisFrame)
            {
                RecordResponse(4);
            }

            else if (Keyboard.current.numpad7Key.wasPressedThisFrame)
            {
                RecordResponse(5);
            }

            else if (Keyboard.current.numpad8Key.wasPressedThisFrame)
            {
                RecordResponse(6);
            }

            else if (Keyboard.current.numpad9Key.wasPressedThisFrame)
            {
                RecordResponse(7);
            }

            print("Pos: " + responsePosition);
        }

    }


    //public void DisplayResponseSelection()
    //    {
    //        trackPadLocation = SteamVR_Actions.default_TrackPadLoc.GetAxis(SteamVR_Input_Sources.Any);
    //        buttonPressed = SteamVR_Actions._default.aButton[SteamVR_Input_Sources.Any].state;

    //        //below are trackpad responses; can tweak the values here to get more accurate response positions
    //        //if (trackPadLocation.x < -.25 && displayNextResponse)
    //        //{
    //        //    if (trackPadLocation.y < -.25)
    //        //    {
    //        //        UpdatePosition(6);
    //        //    }

    //        //    else if (trackPadLocation.y > .25)
    //        //    {
    //        //        UpdatePosition(0);
    //        //    }

    //        //    else
    //        //    {
    //        //        UpdatePosition(3);
    //        //    }
    //        //}

    //        //else if (trackPadLocation.x > .25 && displayNextResponse)
    //        //{
    //        //    if (trackPadLocation.y < -.25)
    //        //    {
    //        //        UpdatePosition(8);
    //        //    }

    //        //    else if (trackPadLocation.y > .25)
    //        //    {
    //        //        UpdatePosition(2);
    //        //    }

    //        //    else
    //        //    {
    //        //        UpdatePosition(5);
    //        //    }
    //        //}

    //        //else if (displayNextResponse)
    //        //{
    //        //    if (trackPadLocation.y < -.25)
    //        //    {
    //        //        UpdatePosition(7);
    //        //    }

    //        //    else if (trackPadLocation.y > .25)
    //        //    {
    //        //        UpdatePosition(1);
    //        //    }

    //        //    else
    //        //    {
    //        //        //UpdatePosition(4);
    //        //    }
    //        //}

    //    //if (upState && displayNextResponse && responsePosition > 13)
    //    //{
    //    //    UpdatePosition(-10);
    //    //}

    //    //if (downState && displayNextResponse && responsePosition < 31)
    //    //{
    //    //    UpdatePosition(10);
    //    //}

    //    //if (rightState && displayNextResponse && responsePosition % 10 < 3)
    //    //{
    //    //    UpdatePosition(1);
    //    //}

    //    //if (leftState && displayNextResponse && responsePosition % 10 > 1)
    //    //{
    //    //    UpdatePosition(-1);
    //    //}

    //    //change this to display proper order of stimuli


    //    if(buttonPressed && isPracticing && responsePosition != 22)
    //    {
    //        responsePosition = 22;
    //        responding = false;
    //        responses[lastPos].SetActive(false);
    //        StartCoroutine(PracticeShowStimuli(.2f));
    //    }

    //    else if (buttonPressed && responsePosition != 22)
    //        {

    //            RecordHit();

    //            //check here if next stimuli does not display
    //            //if (trialCount < 96)
    //            //{
    //            //    StartCoroutine(ShowStimuli());
    //            //}
    //            responsePosition = 22;

    //        }
    //    }




    //responses are from 0 to 8 in array as follows
    //0 NW
    //1 N
    //2 NE
    //3 W
    //4 Center
    //5 E
    //6 SW
    //7 S
    //8 SE
    public void AllowResponse()
    {
        //change this to display proper order of stimuli

        responding = true;
        displayNextResponse = true;

        ////displays grid of responses with x in the middle square
        //responses[4].SetActive(true);
        //lastPos = 4;

        //could add second timer here to compare display time of stimuli (get difference btw timer that starts
        // with stimulus presentation and the timer below)
        startTime = Time.realtimeSinceStartup;
    }

    //resets the counter for each individual stimulus (combo of eccentricity, direction, and exposure) to 0 for new block
    public void ResetIndStimCount()
    {
        for (int i = 0; i < numOfDirects; i++)
        {
            for (int j = 0; j < numOfEccs; j++)
            {
                for (int k = 0; k < numOfExpos; k++)
                {
                    rndTrialCount[i][j][k] = 0;
                }
            }
        }
    }

    //code below adds delay to updating response grid, not needed
    IEnumerator TaskDelayBool(float delay)
    {
        displayNextResponse = false;
        yield return new WaitForSecondsRealtime(delay);
        displayNextResponse = true;
    }

    IEnumerator VisualDelayBool(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
    }

    IEnumerator ShowStimuli()
    {
        //adds delay before next trial, gives participants a break
        yield return StartCoroutine(TaskDelayBool(dataHolder.GetBreakTime()));


        currentDir = rndTrial.Next(0, 8);
        currentEcc = rndTrial.Next(0, numOfEccs);
        currentExpos = rndTrial.Next(0, numOfExpos);

        //change the value of the 1 to be the number of repetitions of each stimulus
        while (rndTrialCount[currentDir][currentEcc][currentExpos] == trialRepetitions)
        {
            currentDir = rndTrial.Next(0, 8);
            currentEcc = rndTrial.Next(0, numOfEccs);
            currentExpos = rndTrial.Next(0, numOfExpos);
        }

        dataHolder.SetDirEccExpo(currentDir, currentEcc, currentExpos);
        rndTrialCount[currentDir][currentEcc][currentExpos]++;
        timeDisplayed = Time.realtimeSinceStartup;
        stimImgCrtr.DisplayTarget(currentDir, currentEcc);

        //new response window start
        AllowResponse();

        maskEnded = Time.realtimeSinceStartup;

        yield return new WaitForSecondsRealtime(dataHolder.GetExpTime());
        //displayNextResponse = true;

        timeDisplayed = Time.realtimeSinceStartup - timeDisplayed;

        StartCoroutine(ShowMask());
    }

    IEnumerator ShowMask()
    {
            
        stimImgCrtr.StartMask(currentDir, currentEcc);

        yield return new WaitForSecondsRealtime(dataHolder.GetMaskTime());
        stimImgCrtr.ClearScreen();

        //old start of response window
        //AllowResponse();

        //maskEnded = Time.realtimeSinceStartup;

        //this controls the response window
        yield return (new WaitUntil(()=> !responding || (Time.realtimeSinceStartup - maskEnded >= dataHolder.GetRespWindow())));
        

        if(responding)
        {
            RecordMiss(blockCount, trialCount);
        }

    }

    public void WriteToCSV(int block, int trialNumber, int responseKey)
    {
        trialNumber++;
        block++;
        StreamWriter sw = File.AppendText(filePath);
        sw.WriteLine(block + "," + trialNumber + "," + reactionTime + "," + dataHolder.GetEcc() + "," + dataHolder.GetDir() + "," + responseDirection[responseKey] + "," + timeDisplayed + "," + dataHolder.GetExpTime());
        sw.Close();
        print("Response direction: " + responseDirection[responseKey] + "," + timeDisplayed + "," + dataHolder.GetExpTime());
    }

    public void RecordResponse(int responseKey)
    {
        if (!readyToPractice)
        {
            reactionTime = Time.realtimeSinceStartup - startTime;


            WriteToCSV(blockCount, trialCount, responseKey);
            trialCount++;
            responding = false;
            //responses[lastPos].SetActive(false);

            if (trialCount <= dataHolder.GetTrialNum() - 1)
            {
                StartCoroutine(ShowStimuli());
            }

        }

        else if (readyToPractice)
        {
            trialCount++;
            responding = false;

            //change this
            if (trialCount <= dataHolder.GetPracticeTrialNum() - 1)
            {
                StartCoroutine(ShowStimuli());
            }


        }
    }

    public void RecordMiss(int block, int trialNumber)
    {
        print("Trial " + (trialCount + 1) + " miss");
        if (!readyToPractice)
        {
            print("Missed: " + (Time.realtimeSinceStartup - maskEnded));
            trialNumber++;
            block++;

            StreamWriter sw = File.AppendText(filePath);
            sw.WriteLine(block + "," + trialNumber + "," + "Miss" + "," + dataHolder.GetEcc() + "," + dataHolder.GetDir() + "," + "Miss" + "," + timeDisplayed + "," + dataHolder.GetExpTime());
            sw.Close();


            trialCount++;
            responding = false;
            //responses[lastPos].SetActive(false);

            if (trialCount <= dataHolder.GetTrialNum() - 1)
            {
                StartCoroutine(ShowStimuli());
            }
        }

        else if (readyToPractice)
        {
            trialCount++;
            responding = false;

            if (trialCount <= dataHolder.GetPracticeTrialNum() - 1)
            {
                StartCoroutine(ShowStimuli());
            }
        }
    }

    public bool getState()
    {
        return responding;
    }


}
