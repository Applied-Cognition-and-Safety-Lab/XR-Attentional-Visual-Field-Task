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
