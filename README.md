# File Server

A simple, command-line http server for loading static content. It can be used for local development and testing purposes.

## Install

FileServer is cross-platform and runs on [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0).

```sh
dotnet tool install -g FileServer
```

## Usage

Simply navigate to a given directory from the command line and run `file-server`. Then access it from the browser on <http://localhost:8080>, being the default port number.

To run file-server on a custom port, provide `--port` or `-p` as an argument. For example

```file-server --port <PORT>```

It is possible to run multiple insances of file-server where each listens on a subsequent port unless a custom one is provided.

### Install from Source

0. `git clone https://github.com/deniskyashif/file-server.git`
1. `cd file-server/src`
2. Run `dotnet pack`
3. Run `dotnet tool install --global --add-source ./nupkg/ FileServer`
