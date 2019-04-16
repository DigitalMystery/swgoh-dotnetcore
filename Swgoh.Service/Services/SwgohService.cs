using System.Collections.Generic;
using Swgoh.Dto;
using Swgoh.Dto.Requests;

namespace Swgoh.Service.Services
{
    public class SwgohService
    {
        private readonly IPlayerService _playerService;
        private static readonly ISwgohFlurlService SwgohFlurlService;

        public SwgohService() : this(new PlayerService(SwgohFlurlService)) { }

        private SwgohService(IPlayerService playerService)
        {
            this._playerService = playerService;
        }

        public Player GetPlayer(PlayerRequest playerRequest)
        {
            return _playerService.GetPlayer(playerRequest);
        }

        public List<Player> GetPlayers()
        {
            return _playerService.GetPlayers();
        }
    }
}
