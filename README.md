# Strava MAUI

A Strava-inspired mobile application built with .NET MAUI, focused on activity tracking, custom UI, onboarding experience, map visualization and recording flow.

This project was created to practice and demonstrate mobile engineering concepts such as component-based UI, navigation structure, platform-specific styling and clean separation of responsibilities in a cross-platform app.

<img width="2530" height="1410" alt="Captura de Tela 2026-05-05 às 20 45 17" src="https://github.com/user-attachments/assets/0a54c595-39da-4f32-a2ca-7a027adc197e" />


## Overview

Strava MAUI is a mobile interface inspired by the Strava experience, built using C# and .NET MAUI.  
The project includes screens for feed, activity recording, maps, onboarding and a customized tab bar experience.

The main goal is not only to reproduce a visual interface, but also to structure the app with maintainability, scalability and good mobile development practices.

## Features

- Custom TabBar implementation
- Activity feed screen
- Map-based interface
- Activity recording flow
- Onboarding screens
- Mobile-first UI components
- Cross-platform .NET MAUI structure
- Organized project architecture
- Custom icons and visual refinements

## Tech Stack

- C#
- .NET MAUI
- XAML
- MVVM-oriented structure
- Mobile UI/UX
- Cross-platform development

## Architecture Goals

This project was structured with attention to:

- Separation between UI and logic
- Reusable visual components
- Clear folder organization
- Maintainable navigation flow
- Scalable screen structure
- Clean and readable XAML
- Consistent styling across the app

## Project Structure

```txt
Strava_Maui/
├── Strava/
│   ├── Views/
│   ├── ViewModels/
│   ├── Models/
│   ├── Components/
│   ├── Resources/
│   ├── Platforms/
│   └── AppShell.xaml
├── Strava.sln
└── README.md

```
## What I practiced in this project
- Building mobile interfaces with .NET MAUI
- Creating reusable XAML components
- Structuring navigation with Shell
- Customizing the visual experience beyond default controls
- Organizing a mobile app for future scalability
- Improving UI consistency and component reuse

## Future Improvements
- Add real activity tracking data
- Integrate GPS recording
- Add authentication flow
- Persist activities locally
- Add cloud synchronization
- Improve map interactions
- Add unit tests for ViewModels
- Add CI pipeline with GitHub Actions
- Add light/dark theme support
