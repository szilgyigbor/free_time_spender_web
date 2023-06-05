# Free Time Spender

## Introduction

This is a versatile ASP.Net API application designed to provide a variety of features for entertainment and information. It's perfect for applications in need of diverse data sources such as current events, weather data, chatbot functionality, and more.

Originally designed as an ASP.Net MVC application, Free Time Spender has now been refactored to serve as a backend API service. This change provides greater flexibility and decoupling, allowing frontend applications to interact with the API according to their specific needs.

## Features

1. **Chat with ChatGPT API**: This feature uses the OpenAI API to facilitate engaging and human-like conversations with the AI model ChatGPT. It provides an interactive discussion endpoint for frontend applications.

2. **Play Amoeba (or Gomoku) API**: This API provides the rules and game logic for the classic strategy game. This allows frontend applications to focus on the user interface and interaction.

3. **News Reader API**: Stay updated on the latest news. This feature uses the NewsAPI.org API to pull in recent news articles from a variety of sources.

4. **Weather Checker API**: Check the current weather in any location in the world. It uses the Weather.com API to provide accurate, up-to-date weather information.

## Dependencies

For the application to function correctly, it requires API keys from the following providers:

- [flickr.com](https://www.flickr.com/)
- newsapi.org
- [openai.com](https://www.openai.com/)
- [weather.com](https://www.weatherapi.com/)

Please refer to the respective API documentation to learn how to obtain these keys. 

## Getting Started

To get started with this project, follow these steps:

1. Clone the repository to your local machine.
2. Add your API keys to your environment variables in windows with the referred names:
  - "NewsApiKey"
  - "BotApiKey"
  - "WeatherApiKey"
  - "FlickrApiKey"
3. Build the application in your preferred .NET environment.
4. Run the application and explore the API endpoints.


Note: This is a backend API service. For a frontend application that interacts with this API, please see [Time Spender Frontend](https://github.com/szilgyigbor/time-spender-frontend).
