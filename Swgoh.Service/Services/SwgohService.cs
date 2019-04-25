using System.Collections.Generic;
using Swgoh.Dto;
using Swgoh.Dto.Requests;
using Swgoh.Dto.Swgoh.Dto;

namespace Swgoh.Service.Services
{
    public class SwgohService
    {
        private readonly IPlayerService _playerService;
        private readonly IGuildService _guildService;
        private static readonly ISwgohFlurlService SwgohFlurlService;

        public SwgohService() : this(
            new PlayerService(SwgohFlurlService), 
            new GuildService(SwgohFlurlService)) { }

        private SwgohService(
            IPlayerService playerService, 
            IGuildService guildService)
        {
            this._playerService = playerService;
            this._guildService = guildService;
        }

        public Player GetPlayer(PlayerRequest playerRequest)
        {
            return _playerService.GetPlayer(playerRequest);
        }

        public List<Player> GetPlayers(PlayersRequest playersRequest)
        {
            return _playerService.GetPlayers(playersRequest);
        }

        public List<Guild> GetGuilds(GuildsRequest guildsRequest)
        {
            return _guildService.GetGuilds(guildsRequest);
        }
    }
}
