[![Build Status](https://dev.azure.com/peterasamoah7/LearnDevOps/_apis/build/status/peterasamoah7.CleanMusicMaker?branchName=main)](https://dev.azure.com/peterasamoah7/LearnDevOps/_build/latest?definitionId=24&branchName=main)

<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Thanks again! Now go create something AMAZING! :D
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->

<!-- PROJECT LOGO -->
<br />
<p align="center">
<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
      </ul>
      <ul>
        <li><a href="#setup">Setup & Running</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#license">License</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project
If you have tried to create a karaoke video for an office party or just to have fun with friends and realised you've spent more time removing unwanted content and still not sure you got all out. This tool was made for you. 

Clean Music Maker is a prototype online tool that helps users make music clean. The tool acheives this by analysing the lyrics of your music using Expert AI Information Detection APIs to identify any lyrics that may be considered offensive to listeners.

You can view the demo [here](https://youtu.be/K_tMPIIyOKQ)

You can try the live application here [Live site](https://cleanmusicmaker.azurewebsites.net/)

### Built With
* [ASP.NET Core](https://dotnet.microsoft.com/)
* [Expert AI](https://www.expert.ai/)

<!-- GETTING STARTED -->
## Getting Started

To run the application locally, please follow the steps below.

### Prerequisites

* [Visual Studio 2022](https://visualstudio.microsoft.com/)
* [Expert AI Developer account](https://developer.expert.ai/)
* [Azure Subscription](https://azure.microsoft.com/en-gb/free/)
* [Azure Speech Service](https://azure.microsoft.com/en-us/products/cognitive-services/speech-services/)


### Setup

1. Clone the repo 
2. Create a developer account at [Expert AI](https://developer.expert.ai/)
3. Create a free Azure account at [Azure account](https://azure.microsoft.com/en-gb/free/)
4. Create a free Azure Speech resource at [Azure Speech SDK](https://learn.microsoft.com/en-gb/azure/cognitive-services/speech-service/speech-sdk)

3. Update `appsettings.json`
  ```sh
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "NlpConfig": {
    "ApiUrl": "https://nlapi.expert.ai",
    "AuthUrl": "https://developer.expert.ai",
    "Username": "Enter your expert ai username",
    "Password": "Enter yout expert ai password"
  },
  "SpeechConfig": {
    "SpeechKey": "Enter your Azure Speech API Key",
    "SpeechRegion": "Enter your Azure Speech resource region"
  }
}
```

### Running from Visual Studio

1. From Visual Studio, press `F5`
 
<!-- USAGE EXAMPLES -->
## Usage

Please refer to the [demo](https://youtu.be/K_tMPIIyOKQ)

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.
