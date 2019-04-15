using System;
using System.Collections.Generic;
using System.Text;
using Swgoh.Dto;

namespace Swgoh.Service.Services
{
    internal interface IPlayerService
    {
        Player GetPlayer();
        List<Player> GetPlayers();
    }

    internal class PlayerService : ServiceBase, IPlayerService
    {
        public Player GetPlayer()
        {
            throw new NotImplementedException();
        }

        public List<Player> GetPlayers()
        {
            throw new NotImplementedException();
        }
    }
}
