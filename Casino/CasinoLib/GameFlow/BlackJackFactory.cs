using Autofac;
using CasinoLib.GameRules;
using CasinoLib.TimeOnTableAllowed;
using System.Collections.Generic;

namespace CasinoLib.GameFlow
{
    public class BlackJackFactory
    {
        private static BlackJackFactory _factoryInstance;

        private static List<IPlayer> _players;

        private IContainer _container;
        private ContainerBuilder _builder;
        public static BlackJackFactory Instance
        {
            get
            {
                if (_factoryInstance == null)
                {
                    _factoryInstance = new BlackJackFactory();
                }
                return _factoryInstance;
            }
        }
        
        private BlackJackFactory()
        {
            
        }

        public void Initialise()
        {
            if (_players == null || _players.Count == 0)
            {
                throw new System.Exception("no players have been set. Cannot create gameflow");
            }
            _builder = new ContainerBuilder();

            _builder.RegisterType<BlackJackGameFlow>().As<IGameFlow>().WithParameter("players", _players).SingleInstance();
            _builder.RegisterType<BlackJackGameRules>().As<IGameRules>().SingleInstance();
            _builder.RegisterType<Dealer>().As<IDealer>().SingleInstance();
            _builder.RegisterType<U20TimeOnTableAllowed>().As<IPlayerTimeOnTableAllowed>().SingleInstance();
            _builder.RegisterType<ExpertTimeOnTableAllowed>().As<IDealerTimeOnTableAllowed>().SingleInstance();

            _container = _builder.Build();
        }

        public void SetPlayers(List<IPlayer> players)
        {
            _players = players;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
