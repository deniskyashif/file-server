# File Server

A command-line http server for loading static content. It can be used for local development, testing, and production purposes.

## Installation

```sh
dotnet tool install -g FileServer
```

## Usage

Simply navigate to a given directory from the command line and run `file-server`. Then access it from the browser on `localhost:8080`, 8080 being the default port number.

To run file-server on a custom port, provide `--port` or `-p` as an argument. For example

```file-server --port <PORT>```

It is possible to run multiple insances of file-server where each listens on a subsequent port unless a custom one is provided.

## Development

FileServer runs on [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)

### Installation from Source

0. `git clone https://github.com/deniskyashif/file-server.git`
1. `cd file-server`
2. Run `dotnet pack`
3. Run `dotnet tool install --global --add-source .\nupkg\ FileServer`
