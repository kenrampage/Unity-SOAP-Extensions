# Unity SOAP Extensions

Unity SOAP Extensions is an addon package for the Obvious SOAP package [available from the Unity Asset Store](https://assetstore.unity.com/packages/tools/utilities/soap-scriptableobject-architecture-pattern-232107?srsltid=AfmBOoq50efPZ-9k1mTLjuLdR9qWUaXgY4C4KpRLr5_UqcQZREA6R1go)

This package adds listener components that expand SOAP (ScriptableObject Architecture Pattern) workflows with additional value-driven behavior and inspector-friendly setup.

- These extensions are designed to follow SOAP patterns while adding value-filtered listener workflows.
- Inspector fields include summaries and tooltips to make setup and maintenance easier.

## Requirements
- Unity v6.0 or newer
- SOAP Package v3.8 or newer - [available from the Unity Asset Store](https://assetstore.unity.com/packages/tools/utilities/soap-scriptableobject-architecture-pattern-232107?srsltid=AfmBOoq50efPZ-9k1mTLjuLdR9qWUaXgY4C4KpRLr5_UqcQZREA6R1go)

## Install With UPM

1. Open your Unity project.
2. Go to Window > Package Manager.
3. Click the plus button and choose Add package from git URL...
4. Paste the package Git URL for this repository and click Add.

After the package is installed, you can import the sample from Package Manager:

1. In Package Manager, select Unity SOAP Extensions.
2. Open the Samples tab.
3. Click Import next to Examples.
4. Unity will copy the sample content into your project so you can open the sample scenes and assets.

## Features

- Variable Listeners
  - Listen to SOAP ScriptableVariables and invoke UnityEvents on value changes.

- Variable Value Listeners
  - Listen to a single ScriptableVariable and invoke events only when the incoming value matches configured entries.
  - If multiple entries match, all matching entries are invoked in array order.

- Event Value Listeners
  - Listen to SOAP ScriptableEvents and invoke events only when the raised event value matches configured entries.
  - If multiple entries match, all matching entries are invoked in array order.

- Bindings
  - `BindTransform` — Reads or writes transform position, rotation, or scale to/from a Vector3Variable. Supports world and local space, per-axis constraints, and auto-resolves to this GameObject's transform if no target is assigned.
  - `BindGameObjectActiveState` — Binds a BoolVariable to a GameObject's active state. Supports an invert toggle to flip the relationship. Auto-falls back to this GameObject if no target is assigned.

## Supported Types

The listener sets cover the following SOAP types:

- `bool`
- `float`
- `int`
- `string`
- `Vector2`
- `Vector3`
- `Vector2Int`
- `Color`
- `Quaternion`
- `Component`
- `GameObject`


## Sample Scene Usage

### SOAP-Extensions_Example_VariableListeners.scene

The Variable Listeners sample scene is meant to be observed, not clicked through. Start Play Mode, then edit the ScriptableObject assets in the Project window while the game is running. The scene UI listens for those runtime changes and updates live to reflect the current values.

For example, if you change `Samples/Scriptable Objects/Variables/scriptable_variable_bool_KenRampage.asset` from `true` to `false`, the toggle in the scene updates right away.

The GameObject variable demo works the same way, except it swaps prefabs instead of updating a label or control. Two prefabs are included in `Samples/Prefabs/`, so you can assign one or the other to `Samples/Scriptable Objects/Variables/scriptable_variable_gameObject_KenRampage.asset` at runtime and watch the sample instantiate the matching prefab.

In short, this scene shows how components react when you change ScriptableObject values at runtime.
