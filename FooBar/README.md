**Introduction** \
Greeting!

**Description of the task** \
Task #1 FooBar \
Print numbers 1-100 so that if the number can be divided by 3 print Foo (instead of the number); if it can be divided by 5 print Bar (instead of the number)\
So something like

	1
	2
	Foo
	4


**Description of decisions made**

**Argument validation:** \
Better use fluent validation, for example https://github.com/safakgur/guard \
but because this is more real and not Enterprise Level FooBar, using simple check 
```csharp
if (argumentNotValidCheck)
    throw new ArgumentException(nameof(argument), "Error message.");
```

**Possible improvements** \
add console arguments parsing \
add logging subsystem \
add fluent validation \