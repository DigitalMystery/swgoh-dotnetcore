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
        List<Player> GetPlayers(PlayersRequest playersRequest);
    }

    internal class PlayerService : ServiceBase, IPlayerService
    {
        private readonly ISwgohFlurlService _swgohFlurlService;
        private readonly string _path;

        public PlayerService(ISwgohFlurlService swgohFlurlService)
        {
            _swgohFlurlService = swgohFlurlService;
            _path = Client.BaseAddress + UrlConstants.Player;
        }

        public Player GetPlayer(PlayerRequest playerRequest)
        {
            var playersRequest = new PlayersRequest
            {
                AllyCodes = new List<int> {playerRequest.AllyCode},
                Language = playerRequest.Language,
                Enums = playerRequest.Enums,
                Structure = playerRequest.Structure,
                Project = playerRequest.Project
            };

            var players = PostAndDeserializedPlayers(playersRequest);

            return players.FirstOrDefault();
        }

        public List<Player> GetPlayers(PlayersRequest playersRequest)
        {
            var players = PostAndDeserializedPlayers(playersRequest);

            return players;
        }

        private List<Player> PostAndDeserializedPlayers(PlayersRequest playersRequest)
        {
            var result = _swgohFlurlService.SwgohPost(_path, playersRequest);

            var players = JsonConvert.DeserializeObject<List<Player>>(result);
            return players;
        }
    }
}
