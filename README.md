<i>"The Attention Visual Field (AVF) task is a computerized task used to map visualspatial attention in the whole visual field" (Feng and Spence, 2014). 
In this task, people need to attend to a large visual field and identify a target among 15 distractors. The target and distractors are located in eight different 
directions and two eccentricities. This laboratory task uses a rigorous paradigm setting of fixation, interval, target, mask, and response.</i>

![1-s2 0-S0003687022001272-gr1_lrg](https://user-images.githubusercontent.com/105318271/193877517-d1339ffb-e356-497a-8121-3ec1c17871a9.jpg) An illustration of the the displays in an example trial of the Attentional Visual Field Task as shown by Yuan et al., 2022. 

# Attentional Visual Field (AVF) Task

Traditionally, an Attentional Visual Field task is developed for and conducted on a desktop computer. While completing this task, participants are instructed to keep their heads in a chinrest to ensure that the visual stimuli are displayed at the appropriate size and distance. Participants must also fixate on a central point on the screen around which the other visual stimuli are calibrated to be at certain distances from the center of the visual field. This task measures the spread of attention across the visual field by displaying targets at different locations in the visual field based on the target's direction and distance from the center of the visual field. Participants are instructed to indicate which direction the target appears in for each trial, and their accuracy and response time are used to describe the shape of their attentional visual field.
<br>
<br>
# XR Attentional Visual Field Task

This XR Attentional Visual Field Task is based on the computer-based AVF task. It has been developed to work with most VR and AR headsets by implementing the OpenXR API within the Unity3D game engine. This project uses Unity version 2020.3.7f1. Participants respond to the trials by using a numpad to indicate the direction that the target stimulus appeared in. For example, a response of 7 on the numpad would indicate that the target appeared in the top left or Northeast area of the visual field.
<br>
<br>

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

# Explanation of Experiment Settings
![Exp Settings](https://user-images.githubusercontent.com/105318271/177431751-725002e8-59d5-478c-ad72-bf67ff205285.png)
Setting | Description
------------ | -------------
Num Of Blocks | Determines how many blocks the experiment will have.
Target Visual Angle | The size of the target stimulus in the number of degrees in visual angle.
Distractor Visual Angle | The size of the distractor stimuli in the number of degrees in visual angle.
Eccentricities | The number of locations in each direction that a target will appear in. Expand this list to set the individual eccentricity values to control exactly where the stimuli will appear in the number of degrees in visual angle. Example values include 10, 20, and 30. These values would represent 10, 20, and 30 degrees of visual angle.
Exposure Times | The number of different display times that each target will appear for. Expand this list to set the individual exposure time values to control exactly how long the target stimulus will be visible for in each trial in seconds. Example values include .04, .06, .10. These values would represent 40, 60, and 100 ms, respectively.
Trial Repetitions | Determines how many times each unique trial will be presented in each block. A unique trial is comprised of an eccentricity, an exposure time, and a direction within the visual field. Stimuli will appear in 8 different directions in any iteration of this experiment as it is based on the computer AVF task. In this example image, there would be 72 unique trials (8 directions x 3 eccentricities x 3 exposure times) per block. 2 trial repetitions would lead to there being 144 total trials in the experiment.
Mask Display Time | The length of time in seconds that the masking image will be displayed after the target stimulus is presented. The value of .2 shown in the image represents 200 ms.
Response Window | The length of time in seconds that participants will have to respond after the target stimulus is presented. The value of 2 shown in the image represents 2 seconds.
Break Time | The length of time in seconds that participants will have between the presentation of each trial. The value of 2 shown in the image represents 2 seconds.
Practice Trial Num | The number of randomly selected trials (based on the criteria entered in each setting) that participants will have the chance to respond to in the practice session that occurs before the experiment starts.
Use Distractors | Determines if distractor images will be used during the stimulus presentation.
Target Color | Determines what color the target stimulus will appear as.
Distractor Color | Determines what color the distractor stimuli will appear as.
Target Img | Determines what image the target stimulus is. Note: if an alternate target image is desired, ensure that it is equal in height and length and approximately 66 x 66 pixels.
Distractor Img | Determines what image the distractor stimuli are. Note: if an alternate distractor image is desired, ensure that it is equal in height and length and approximately 66 x 66 pixels.
<br>
<br>

# Data Output
Data collected with this experiment will be stored in a CSV file with the entered date and participant number. This file will be available in the same directory as the executable used to run the experiment. The following image and table provide more information on what data is collected.

![Response File](https://user-images.githubusercontent.com/105318271/177618335-23054912-c553-4d07-8872-c1fb93b08f4e.png)

Setting | Description
------------ | -------------
Block | Provides which block number the trial occurred in. Presented in ascending order.
Trial | Provides which trial number the row is for. Presented in ascending order.
Reaction Time | Provides the length of time in seconds it took for the participant to respond. Will provide either a decimal value or "Miss" when participants do not respond. Data from this column should be filtered based on whether the response was correct.
Eccentricity | Provides which eccentricity the target appeared at in terms of degrees of visual angle.
StimulusDirection | Provides which direction the target appeared at in terms of cardinal directions.
Response | Provides which direction the participant indicated that the target appeared at in terms of cardinal directions.
Acutal Display Time | Provides the length of time in seconds that the target stimulus was displayed for. Due to frame timing of Unity and the device being used, there will likely always be some level of error between this and the set display time.
Set Display Time | Provides the length of time in seconds that the target stimulus was selected to be displayed for.

# Copyright

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions: 
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
