# CTRM-Final-Assembly
 Unity-ARFLP2
Steps to run this project: 
1. Clone this project to a PC with Unity 5.5.1f1 installed. (download from https://unity.com/releases/editor/archive)
2. Open this project with Unity 5.5.1f1, a scene named "_ARFLP2-Layup" should be opened.
3. Print out the AR marker from the folder "CTRM Final Assembly Master\Assets\Editor\Vuforia\ImageTargetTextures\ARFLP2".

For LPT/SPT/TCT optimization simulation. we need to open a scene named "_ARFLP2-Layup" found in folder "CTRM Final Assembly\Assets" if the scene in step 2 is not opened.

4. Connect a webcam to the laptop, run the Unity Editor. AR scene will start.
5. Scan the AR marker with webcam, a green wireframe place will appear.
6. In the hierarchy tab of the Unity, the Cube, Cube (1) and Cylinder are used to represent any obstacle found. These shape can be activated, duplicated, resized, relocated and reoriented based on the real scenario.
7. In case where there is no obstacle, we can start the simulation by activating the "Check collision" function. The number of table/workstation planned can be set based on the requirement. By default, it is set to 8 tables. 
8. We should see 8 tables appeared within the green place boundary. If obstacles are defined, the tables will be arranged without colliding/overlapping witht the obstacles.
9. Once the tables are loaded, we can run either LPT, SPT or TCT optimization by activating one of the "AllCSVScript" gameobject. Activatin the gameobject will initiate the coding to check for product list with production cycle time. (LPT arrange the products with longest process time first to the workstations while SPT arrange the products with shortest process time first to the workstation. TCT will balance the workstations' total cycle time, default it balances the workstation cycle time within 95-105% of the total product cycle time divided by the total of workstations available. There is a setting to avaoid iteration >100000 in the script. These settings can be changed in the script named "CSVLineBalancingAutoTCT2.cs" in folder "CTRM Final Assembly\Assets\CheeHau's Scripts".)
10. Result with .csv format will be saved in the folders "CTRM Final Assembly Master'\_Data\Results" and "CTRM Final Assembly Master'\_Data\Results\Compute". 
11. At one time, there is only one type of simulation can be activated. We need to stop the Unity editor and run step 4 if we would like to check for another optimization simulation.

For CoG optimization simulation, we need to open a scene named "_ARFLP2-CG" found in folder "CTRM Final Assembly\Assets". 
1. Print out the AR marker from the folder "CTRM Final Assembly\Assets\Editor\Vuforia\ImageTargetTextures\ARFLP2".
2. Connect a webcam to the laptop, run the Unity Editor. AR scene will start.
3. Scan the AR marker with webcam, a green wireframe place will appear.
4. Hit "B" button on keyboard, a machine MC1 will appear. MC1 can be moved and oriented in the AR environment to overlap with the real machine.
5. Hit "B" button on keyboard again to generate another machine. The script allows adding up to 5 machines in the scene.
6. When a new AR machine is added, the shared facility's position will be updated by the CG algorithm.

The tests were conducted with AR marker (ARFLP2_scaled.jpg) printed 1:1 scale on A4 paper, Unity 5.5.1f1 installed in ASUS ROG Strix G15 laptop with NVIDIA GeForce RTX2070 graphic card, 16 GB RAM and Logitech C920 webcam. 
Note on the TCT optimization, the percentage may need to change to a wider range and the max iteration number may need to change to a larger number if the script is not able to complete the optimization process. 

Remark: Raw data files are available in the folder CTRM Final Assembly Master'\_Data\Results
