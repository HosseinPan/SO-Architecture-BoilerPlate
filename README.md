# SO-Architecture-Boilerplate
Unity code architecture boilerplate based on the [Ryan Hipple's 2017 Unite talk](https://www.youtube.com/watch?v=raQ3iHhE_Kk)

# Features
* ScriptableObject Categories
  - Events
  - Managers
  - SharedData
    - Variables
    - Lists
* CommonSO
* StateMachine
* Object Pooling

## Event System
It uses C# events instead of unity events.

## CommonSO
CommonSO tries to solve these problems:
- Each ScriptableObject can have dozens of references in the scenes, which increases the likelihood of human error.
- Debugging and tracking all the references of a ScriptableObject is difficult.
- Whenever we change the name of a ScriptableObject, we need to reassign it to all references in all scenes.

CommonSO is a singleton prefab that serves as a single source of the ScriptableObjects in a scene.
When referencing ScriptableObjects, MonoBehaviours should use CommonSO. It is a good practice to map CommonSO names and structures to your Scriptable Object assets folder.

## StateMachine
There are two types of transition conditions:
- Event List Condition: We provide a list of VoidEventSO as a condition for transition of a state. The condition is met when all the events are raised after entering the state.
- Statement Condition: We provide a Func<bool> as condition.
  
## Object Pooling
It lives in ScriptableObjects > Managers folder. All GameObjects can be pooled into it.

# Examples
The usage of all features is demonstrated in the Example folder.

