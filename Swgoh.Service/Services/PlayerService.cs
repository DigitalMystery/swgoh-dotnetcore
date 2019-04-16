using System;
using System.Collections.Generic;
using System.Linq;
using Flurl.Http;
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
        public Player GetPlayer(PlayerRequest playerRequest)
        {
            var path = Client.BaseAddress + UrlConstants.Player;
            var response = path.WithHeaders(new { Content_Type = "application/json", Authorization = Token }).PostJsonAsync(playerRequest).Result;

            var result = response.Content.ReadAsStringAsync().Result;

            var players = JsonConvert.DeserializeObject<List<Player>>(result);

            return players.FirstOrDefault();
        }

        public List<Player> GetPlayers()
        {
            throw new NotImplementedException();
        }
    }
}
