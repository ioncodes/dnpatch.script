# dnpatch.script
This is the standalone of dnpatch.script and it's main repo. The dnpatch.script.patcher is the runner.

## JSON
Create a file called "patcher.json" in the patcher directory. Here is a small example:
```json
{
    "target":"Example.exe",
    "save":"Example.Scripted.exe",
    "targets":[{
        "ns":"Example",
        "cl":"Program",
        "me":"Print",
        "ac":"empty"
    },{
        "ns":"Example",
        "cl":"Program",
        "me":"Main",
        "ac":"remove",
        "indices":[2,3,4,5]
    },{
        "ns":"Example",
        "cl":"Program",
        "me":"Main",
        "ac":"return",
        "optional":"true"
    },{
        "ns":"Example",
        "cl":"Program",
        "me":"Main",
        "ac":"remove",
        "indices":[2,3,4,5],
        "instructions":[{
            "opcode":"ldstr",
            "operand":"new text"
        }]
    }]
}
```
(The above example wont run like that!)

Root attributes:
* "target": the target to patch
* "save": If you're scripting with the standalone, you put here the new filename. If it's the same as the original, it will create a backup.
* "targets": The targets like the Target object in [dnpatch](https://github.com/ioncodes/dnpatch#targeting-methods). It's an array.

Targets' attributes:
* "ns": The namespace
* "cl": The class
* "me": The method
* "ac": The action
* "index": The index to patch (optional)
* "indices": The indices to patch (optional)
* "instructions": The instructions (optional)
* "optional": Optional parameters, like "true"/"false" for action "return" (optional)

List of supported actions:
* "empty": Clear a methodbody
* "replace": Replace the instruction(s) at the given index/indices
* "return": Write true/false as return body and delete everything else, requires "optional" attribute

## Create own runners
A script will be loaded within the constructor and if needed with LoadScript();
```c#
Script script = new Script("script.json");
script.Patch(); // apply patches
script.Save("scriped.exe"); // save the file (only if save attribute isn't in the json)
```
