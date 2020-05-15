# _Word Counter_

#### _Epicodus Project May 15, 2020_

#### By _**Matt Stroud**_

## Description

_An Epicodus individual project using C# and MSTest. This project prioritizes unit testing to validate code and logic before writing code._  

_The application will take two inputs from the user:_
1. _A sentence, paragraph, or other string of words._
2. _A search word._  

_The application will return and display the amount of times the search word occured in the first input._

## Demo
![Gif of application running](demogif/wordorder.gif)

## Specs
| Behavior                                                                | Input                         | Output                        |
|:------------------------------------------------------------------------|:------------------------------|------------------------------:|
| The program will accept a word as input.                                | "The"                         | "The"                         |
| The program will accept a sentence as input.                            | "He ate the cake."            | "He ate the cake."            |
| The program will validate input word.                                   | "The3"                        | Error                         |
| The program will validate input sentence.                               | "He ate5 cakes."              | Error                         |
| The program will convert the input word to lowercase.                   | "The"                         | "the"                         |
| The program will convert the input sentence to lowercase.               | "He ATE the cake."            | "he ate the cake."            |
| The program will remove punctuation from input word.                    | "The!"                        | "the"                         |
| The program will remove punctuation from input sentence.                | "He ate the cake."            | "he ate the cake"             |
| The program will compare the search word vs the first word in sentence. | "the" vs "he"                 | False (the:0)               |
| The program will compare the search word vs the rest of the sentence.   | "the" vs "ate", "the", "cake" | False, True, False (the:1) |

## Setup/Installation Requirements
> This application required the .NETCore SDK - [Find your version here](https://dotnet.microsoft.com/download/dotnet-core/2.2)

1. Create a WordCounter.Solution directory.
```
mkdir WordCounter.Solution
```
2. Navigate inside your new directory.
```
cd WordCounter.Solution
```
3. Clone this repository to your directory.
```
git clone https://github.com/mlstroud/word-counter.git
```
4. Run the application with the following command:
```
dotnet run
```

## Known Bugs

There are no known bugs at the time of this update.
 
## Support and contact details

_Have a bug or an issue with this application? [Open a new issue](https://github.com/mlstroud/word-counter/issues) here on GitHub._

## Technologies Used

* C#
* .NET Core
* MSTest
* Git

### License

This software is licensed under the MIT license.

Copyright © 2020 **_Matt Stroud_**