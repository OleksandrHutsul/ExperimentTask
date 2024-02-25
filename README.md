# ExperimentTask
A simple program that checks 2 user-input hypotheses. If the user enters "button_color" or "price" and the unique device name, an experiment is generated with the following options:

1) We have a hypothesis that the color of the "buy" button affects the purchase conversion.
Key: button_color
Options:
#FF0000 → 33.3%
#00FF00 → 33.3%
#0000FF → 33.3%
or:

2) We have a hypothesis that changing the purchase cost in the app can impact our profit margin. To avoid losing money in case of an unsuccessful experiment, 75% of users will receive the old price, and only a small portion of the audience will test the change:
Key: price
Options:
10 → 75%
20 → 10%
50 → 5%
5 → 10%
If the device name has already been used, the result from the database is returned. Also, if the user enters incorrect data in the experimentKey field or leaves the deviceToken field blank, an appropriate error message will be displayed.

The database consists of only one table(I will add a screenshot at the bottom). Additionally, we have the ability to view experiment statistics, summarizing the total number of devices participating in the experiment and providing statistics for each option.

In addition, the program includes comments, and I utilized asynchronous methods to implement application optimization. The main advantage of asynchronous methods lies in their ability to more efficiently use computational resources. The fundamental idea is that when a method is waiting for the execution of a certain operation (in our case, a database query), it can yield control to other tasks that can run in parallel. This allows other parts of the program to work without blocking the execution thread.

![image](https://github.com/OleksandrHutsul/ExperimentTask/assets/111017111/864ded3f-a5a4-42d2-9e60-06aba84586bf)
