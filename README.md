# CTRM-Final-Assembly
 Unity-ARFLP2
Steps to run this project: 
1. Clone this project to a PC.
2. Launch this project with a PC with Unity 5.5.1f1 installed. (download from https://unity.com/releases/editor/archive)
3. Open this project with Unity 5.5.1f1, a scene named "_ARFLP2-Layup should be opened.
4. Print out the AR marker from the folder "CTRM Final Assembly\Assets\Editor\Vuforia\ImageTargetTextures\ARFLP2".
5. Connect a webcam to the laptop, run the Unity Editor. AR scene will start.
6. Scan the AR marker with webcam, a green wireframe place will appear.
7. In the hierarchy tab of the Unity, the Cube, Cube (1) and Cylinder are used to represent any obstacle found. These shape can be activated, duplicated, resized, relocated and reoriented based on the real scenario.
8. In case where there is no obstacle, we can start the simulation by activating the "Check collision" function. The number of table/workstation planned can be set based on the requirement. By default, it is set to 8 tables. 
9. We should see 8 tables appeared within the green place boundary. If obstacles are defined, the tables will be arranged without colliding/overlapping witht the obstacles.
10. Once the tables are loaded, we can run either LPT, SPT or TCT optimization by activating one of the "AllCSVScript" gameobject. Activatin the gameobject will initiate the coding to check for product list with production cycle time. (LPT arrange the products with longest process time first to the workstations while SPT arrange the products with shortest process time first to the workstation. TCT will balance the workstations' total cycle time, default it balances the workstation cycle time within 95-105% of the total product cycle time divided by the total of workstations available. There is a setting to avaoid iteration >100000 in the script. These settings can be changed in the script named "CSVLineBalancingAutoTCT2.cs" in folder "CTRM Final Assembly\Assets\CheeHau's Scripts".)
11. At one time, there is only one type of simulation can be activated. We need to stop the Unity editor and run step 5 if we would like to check for another optimization simulation.

For CoG optimization simulation, we need to open a scene named "_ARFLP2-CG" found in folder "CTRM Final Assembly\Assets". 
1. Print out the AR marker from the folder "CTRM Final Assembly\Assets\Editor\Vuforia\ImageTargetTextures\ARFLP2".
2. Connect a webcam to the laptop, run the Unity Editor. AR scene will start.
3. Scan the AR marker with webcam, a green wireframe place will appear.
4. Hit "B" button on keyboard, a machine MC1 will appear. MC1 can be moved and oriented in the AR environment to overlap with the real machine.
5. Hit "B" button on keyboard again to generate another machine. The script allows adding up to 5 machines in the scene.
6. When a new AR machine is added, the shared facility's position will be updated by the CG algorithm.

