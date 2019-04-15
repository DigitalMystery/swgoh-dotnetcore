using System.Collections.Generic;
using Swgoh.Dto;

namespace Swgoh.Service.Services
{
    public class SwgohService
    {
        private readonly IPlayerService _playerService;

        public SwgohService() : this(new PlayerService()) { }

        private SwgohService(IPlayerService playerService)
        {
            this._playerService = playerService;
        }

        public Player GetPlayer()
        {
            return _playerService.GetPlayer();
        }

        public List<Player> GetPlayers()
        {
            return _playerService.GetPlayers();
        }
    }
}
