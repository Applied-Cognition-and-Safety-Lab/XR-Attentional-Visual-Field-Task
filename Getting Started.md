# Getting Started 

1. Install Unity version 2020.3.7f1 if it is not already present on your device to ensure the project works as intended.

2. Download the zip folder with all of the required files for Unity. 

3. Extract the files from the zip folder and add the project folder titled "XR AVF" as a new project through the Unity Hub.

4. Launch the project through the Unity Hub.

5. Add any assets necessary for your experiment to the TaskRoom scene. This could include things such as, a virtual environment, virtual objects, eye-tracking add-ons, etc.

6. Modify the experiment settings on the Experiment Settings object located in the InfoScreen scene.

7. If the headset cannot connect to a numpad for responding and controlling the flow of the experiment or if you would like to use a different response mechanism, modify the Experiment Controller script to implement an alternative method to start the experiment and for participants to respond to the trials with.

7. Build the Unity project and run the Unity-generated executable.

8. The application has a built-in interface that is used to control the flow of the experiment, including starting the practice session, ending the practice session, and starting the experiment. In situations where the participant's view cannot be seen or interacted with by the experimenter, the Enter key is used to start the practice session, the Right Shift key is used to run an additional practice session, the Backspace key clears out the practice mode and prepares the experiment for the task mode, and the Enter key after clearing out practice mode will start the task.
<br>
<br>
