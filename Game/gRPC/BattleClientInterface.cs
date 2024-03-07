using Grpc.Net.Client;
using System.Net;

namespace GrpcPokemon
{
  /// <summary>
  /// Send information to the opposition
  /// in a battle
  /// </summary>
  public static class BattleClientInterface
  {
    //private static Pokemon.PokemonClient s_battleClient;

    ///// <summary>
    ///// Create the client to the player we are battling
    ///// </summary>
    ///// <param name="iPEndPoint"></param>
    //public static void CreateClient(IPEndPoint iPEndPoint)
    //{
    //  s_battleClient = new Pokemon.PokemonClient(Connect($"http://{iPEndPoint.Address}:{iPEndPoint.Port}"));
    //}

    ///// <summary>
    ///// Convert an IP Address and a Port to a Grpc channel
    ///// </summary>
    ///// <param name="serviceAddress">The full address</param>
    ///// <returns></returns>
    //private static GrpcChannel Connect(string serviceAddress) => GrpcChannel.ForAddress(serviceAddress);

    ///// <summary>
    ///// Send an attack to the opposition.
    ///// </summary>
    ///// <returns>The damage done to the opponent</returns>
    //public static DamageDone Attack()
    //{
    //  return s_battleClient.SendAttack(new AttackInfo() { PokemonName = "Test", TrainerName = "Trainer_Test", PokemonAttack = "Attack_Test", PokemonAttackDamage = 5 });
    //}
  }
}
