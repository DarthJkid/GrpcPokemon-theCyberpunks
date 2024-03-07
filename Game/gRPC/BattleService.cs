using Grpc.Core;

namespace GrpcPokemon
{
 /* public class BattleService(PokemonManager manager) : Pokemon.PokemonBase
  {
    private readonly PokemonManager injectedManager = manager;

    public override Task<DamageDone> SendAttack(AttackInfo attack, ServerCallContext context)
    {
      return Task.FromResult(injectedManager.RecieveDamage()); 
    }
  }*/
}
