using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Swgoh.Dto;
using Swgoh.Dto.Requests;
using Swgoh.Service.Constants;

namespace Swgoh.Service.Services
{
    internal interface IPlayerService
    {
        Player GetPlayer(PlayerRequest playerRequest);
        List<Player> GetPlayers();
    }

    internal class PlayerService : ServiceBase, IPlayerService
    {
        private readonly ISwgohFlurlService _swgohFlurlService;

        public PlayerService(ISwgohFlurlService swgohFlurlService)
        {
            _swgohFlurlService = swgohFlurlService;
        }

        public Player GetPlayer(PlayerRequest playerRequest)
        {
            var path = Client.BaseAddress + UrlConstants.Player;

            var playersRequest = new PlayersRequest
            {
                AllyCodes = new List<int> {playerRequest.AllyCode},
                Language = playerRequest.Language,
                Enums = playerRequest.Enums,
                Structure = playerRequest.Structure,
                Project = playerRequest.Project
            };

            var result = _swgohFlurlService.SwgohPost(path, playersRequest);

            var players = JsonConvert.DeserializeObject<List<Player>>(result);

            return players.FirstOrDefault();
        }

        public List<Player> GetPlayers()
        {
            throw new NotImplementedException();
        }
    }
}
