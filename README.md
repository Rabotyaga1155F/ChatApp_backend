### README.md

# ChatApp Backend

This repository contains the backend for the ChatApp, an online chat application that supports real-time messaging between users. The backend is built using C# Web API, SignalR for real-time communication, and Redis for distributed caching and state management. It is designed to work seamlessly with the [ChatApp Frontend](https://github.com/Rabotyaga1155F/chatapp_frontend).

## Features

- **Real-time Communication**: Utilizes SignalR to enable real-time messaging between connected clients.
- **Scalable Architecture**: Redis is used to manage state across distributed systems, ensuring scalability and consistency.
- **Dockerized Deployment**: Includes Docker and Docker Compose configurations for easy deployment and management.

## Project Structure

- **C# Web API**: The core of the backend, handling API requests, SignalR connections, and business logic.
- **SignalR**: Enables real-time communication between the server and clients.
- **Redis**: Manages state and caching, ensuring consistent and scalable data handling across the application.

## Prerequisites

- .NET 8 SDK
- Docker

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/Rabotyaga1155F/chatapp_backend.git
cd chatapp_backend
```


### 2. Run the Application

You can run the application either directly on your local machine or using Docker.

#### Option A: Running Locally

Ensure that Redis is running and accessible, then execute:

```bash
dotnet run
```

The backend will be accessible at `http://localhost:5000`.

#### Option B: Running with Docker Compose

To run the backend along with Redis using Docker Compose, simply run:

```bash
docker-compose up --build
```

This will build the Docker images and start the backend along with Redis. The backend will be accessible at `http://localhost:5000`.

## API Endpoints

- **/chat**: The primary SignalR hub for real-time messaging.

## Integration with Frontend

The backend is designed to work with the [ChatApp Frontend](https://github.com/Rabotyaga1155F/chatapp_frontend). Ensure the `NEXT_PUBLIC_BACKEND_URL` in the frontend's `.env` file points to the backend's `/chat` endpoint.

## Docker Setup

### 1. Build the Docker Image

If you want to build the Docker image separately, use the following command:

```bash
docker build -t chatapp-backend .
```

### 2. Run the Docker Container

```bash
docker run -d -p 5000:5000 chatapp-backend
```

This will start the backend in a Docker container, exposing it on port 5000.

## Troubleshooting

- **Connection Issues**: Verify that Redis is running and accessible from the backend.
- **SignalR Problems**: Check the SignalR connection logs for any errors during client-server communication.
- **Docker Issues**: Ensure Docker and Docker Compose are installed correctly and that no port conflicts exist.

## Acknowledgements

- **ASP.NET Core**: For providing a robust framework for building scalable web APIs.
- **SignalR**: For enabling real-time communication in web applications.
- **Redis**: For its powerful distributed caching and state management capabilities.

---