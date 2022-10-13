The following repository is still being worked upon and changes may occur.

<i> Visual attention is critical for everyday task performance and safety. It allows people to detect and process critical visual objects, information, and potential hazards in an environment to respond to (Carrasco, 2011). An individual’s ability to distribute visual attention in space can be assessed by a computerized task that measures an ability to detect and respond to visual targets in a wide area of one’s focal and peripheral visual field. The Attentional Visual Field (AVF) task is a computerized task that displays a visual stimulus on a computer screen, and people need to identify a target among distractors while attending to a large visual field (Feng et al., 2017; Feng & Spence 2014). </i>

## Attentional Visual Field (AVF) Task
 

Traditionally, an Attentional Visual Field task is developed for and conducted on a desktop computer. While completing this task, participants are instructed to keep their heads in a chinrest to ensure that the visual stimuli are displayed at the appropriate size and distance. Participants must also fixate on a central point on the screen around which the other visual stimuli are calibrated to be at certain distances from the center of the visual field. This task measures the spread of attention across the visual field by displaying targets at different locations in the visual field based on the target's direction and distance from the center of the visual field. Participants are instructed to indicate which direction the target appears in for each trial, and their accuracy and response time are used to describe the shape of their attentional visual field.
<br>


## XR Attentional Visual Field Task

<img width="410" alt="Screenshot 2022-10-06 144643 1632" src="https://user-images.githubusercontent.com/105318271/194405056-48a09161-5136-4298-980b-5557f87527e6.png">
A condensed version of the AVF task in the Virtual Environment.
<br>
<br>
This XR Attentional Visual Field Task is based on the computer-based AVF task. It has been developed to work with most VR and AR headsets by implementing the OpenXR API within the Unity3D game engine. This project uses Unity version 2020.3.7f1. Participants respond to the trials by using a numpad to indicate the direction that the target stimulus appeared in. For example, a response of 7 on the numpad would indicate that the target appeared in the top left or Northeast area of the visual field.

<br>For a detailed explanation, please refer to the CHI EA article: https://dl.acm.org/doi/10.1145/3491101.3519698
</br>

### Table of contents

The project has been tested on the HTC Vive (Pro) and the Valve Index, however visual angle may differ in other VR or AR devices. 

- [Getting Started](https://github.com/Applied-Cognition-and-Safety-Lab/XR-Attentional-Visual-Field-Task/blob/main/Getting%20Started.md)
- [Experiment Settings Explanation](https://github.com/Applied-Cognition-and-Safety-Lab/XR-Attentional-Visual-Field-Task/blob/main/ExperimentSettings.md)
- [Data Output Explanation](https://github.com/Applied-Cognition-and-Safety-Lab/XR-Attentional-Visual-Field-Task/blob/main/DataOutput.md)

In case of any further questions or problems in the documentation, please contact: heesun.choi@ttu.edu.


# Copyright

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions: 
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
