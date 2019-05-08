**Description of the task** \
Task #6 Rearrange array
How to rearrange an array so that it starts from a specified element?

Array contains items “red”, “green”, “yellow”, “blue”, “purple” \
We can start the array from yellow (instead of red), ending up with the following array:\
“yellow”, “blue”, “purple”, “red”, “green”

Code example:

```csharp
var array = new List<string> { “red”, “green”, “yellow”, “blue”, “purple” }
var newArray = ChangeStartingPoint (array, “blue”)
// “blue”, “purple”, “red”, “green”, “yellow”
```
