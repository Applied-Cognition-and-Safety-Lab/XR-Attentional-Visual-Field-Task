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

### Table of contents

The project is intended to work on the HTC Vive (Pro). Please refer to the according sections for the Setup Intrstructions.

- [Getting Started](https://github.com/Applied-Cognition-and-Safety-Lab/XR-Attentional-Visual-Field-Task/blob/main/Getting%20Started.md)
- [Experiment Settings](https://github.com/Applied-Cognition-and-Safety-Lab/XR-Attentional-Visual-Field-Task/blob/main/ExperimentSettings.md)
- [Data Output](https://github.com/Applied-Cognition-and-Safety-Lab/XR-Attentional-Visual-Field-Task/blob/main/DataOutput.md)

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
