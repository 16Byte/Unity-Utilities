# PMG Utilies Package
### A collection of QOL scripting improvements for Unity.
#### Utilities:
**SceneEvents** - An abstraction of Unity's activeSceneChanged callback from SceneManager. Improved scope explicitly by addressing the dead scene handle that gets returned. We instead return it as a string for a reference to the scene's name. 