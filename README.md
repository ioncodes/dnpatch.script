# dnpatch.script
This is the standalone of dnpatch.script and it's main repo. The dnpatch.script.patcher is the runner.

## JSON
Create a file called "patcher.json" in the patcher directory. Here is a small example:
```json
{
    "target":"Example.exe",
    "save":"Example.Scripted.exe",
    "targets":[{
        "namespace":"Example",
        "class":"Program",
        "method":"Print",
        "action":"empty"
    },{
        "namespace":"Example",
        "class":"Program",
        "method":"Main",
        "action":"remove",
        "indices":[2,3,4,5]
    },{
        "namespace":"Example",
        "class":"Program",
        "method":"Main",
        "action":"return",
        "optional":"true"
    },{
        "namespace":"Example",
        "class":"Program",
        "method":"Main",
        "action":"remove",
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
* "namespace": The namespace
* "class": The class
* "method": The method
* "action": The action
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
script.Save("scripted.exe"); // save the file (only if save attribute isn't in the json)
```
