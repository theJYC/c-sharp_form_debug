# C# Web Form Debugging

This repository illustrates a problem-solving process concerning an interactive web form that, upon submit, sends a couple of system-generated emails from noreply@buncombecounty.org to the end user and the webmaster. 


## Directory Map

The repository is organised as the below tree structure:

```
root
│   README.md
│   original.cs
│   annotated.cs    
│
└───solutions
│   │   README.md
│   │   solution1.cs
│   │   solution2.cs
│   │   solution3.cs
│   │   solution4.cs
│   │   suggestion.cs
│
```

### Index

- `original.cs`: The original code snippet that has been provided as the problematic code.
- `annotated.cs`: Line-by-line analysis of `original.cs`, illustrated by multi-line comments to demonstrate the problem-solving process.
    - N.B. Skip to `/*[4]*/` for problem identification.
- `solutions`: directory that holds the four possible solutions to fix the problem. At the top of each file is a brief summary of the solution, with its advantage and disadvantages outlined. 
    - N.B. `solution4.cs` is my optimal solution.
- `suggestion.cs`: A bonus piece to illustrate a potential area of improvement in the code, in order to improve UX. 
- `/root/README.md`: Documentation that holds the directory map and the detailed index of the children files and subdirectory.
