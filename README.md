<h1 align="center">Vertical-Shooter-Proto _ Unity/C# Project</h1>
<br>
<p align="center">
    This is a prototype for a Vertical Shooter game.
</p>
<p align="center">
    This is a code-only repository.
</p>
<p align="center">
    And obviously, there's room for improvement.
</p>
<br>

> [!IMPORTANT]<br/>
> This is a project solely for learning and training purposes.

# Introduction
This game is based in the idea of the old game 1942 mainly. It will be an open-to-upgrades project.
Also, this repository shows the code of the project and won't focus on the assets used.

# Patterns
### Builder Programming Pattern
A Builder class is a design pattern that simplifies the construction of complex objects setp by step. It allows you to create objects with various configurations and options, providing a flexible and readable way to construct instances without the need for multiple constructors or overloaded methods.

### Factory Programming Pattern
A Factory class is a design pattern that provides a centralized way to create objects of different types. It encapsulates the object creation logic, allowing you to easily create instances based on specific configurations or conditions. This way we will create different enemies by also using the Build method seen in the previous pattern.

### Strategy Programming Pattern
The Strategy pattern is a behavioral design pattern that enables the object to alter its behavior dynamically by encapsulating interchangeable algortihms or stratefies. It's useful when you want to define a family of algorithms, encapsulate each one, and make them interchangeable at runtime without modifying the object structure.
In this case, we'll use this pattern to assign different firing strategies to the different weapons in the game.

# Content
- Splines for enemies path
- Parallax controller for the background
- Event driven Boss stages
- Use of [SceneReference library by Eflatun](https://github.com/starikcetin/Eflatun.SceneReference)

# Caveats
- By the time you're reading this, most of the assets will probably be nonoperative (due to Unity version update)
- Same goes for the library used (it works best when downloaded into disk)
