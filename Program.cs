using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace GrpcPokemon
{
  internal class Program
  {
    /// <summary>
    /// Application entry point that calls a new 
    /// Pokemon Manager to control the game.
    /// </summary>
    /// <param name="args">Arguments passed by CLI</param>
    static void Main(string[] args)
    {
      try
      {
        Console.ResetColor();
        SetConsoleSize();
        PokemonManager manager = new PokemonManager();

#warning Need to add IP Address of machine.
        CreateServer(IPAddress.Parse("192.168.1.1"), 5001).Services
    //                  .AddSingleton<BattleService>()
                      .AddSingleton(manager);
        Console.Read();
      }
      catch(Exception ex)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
      }
    }

    /// <summary>
    /// Set the size of the console. 
    /// </summary>
    private static void SetConsoleSize()
    {
      Console.SetWindowSize(80, 50);
      Console.SetBufferSize(100, 100);
    }

    internal static WebApplicationBuilder CreateServer(IPAddress address, int port)
    {
      IPEndPoint myEndpoint = new IPEndPoint(address, port);
      return BuildWebApplication(myEndpoint);
    }

   
    private static WebApplicationBuilder BuildWebApplication(IPEndPoint myEndpoint)
    {
      Action<KestrelServerOptions> WithKestrelConfig = kestrel => kestrel.Listen(myEndpoint);
      WebApplicationBuilder builder = WebApplication.CreateBuilder();

      builder.Host.UseWindowsService();
      builder.Services.AddGrpc();
      builder.WebHost.UseKestrel(WithKestrelConfig);

      return builder;
    }

  }
}
