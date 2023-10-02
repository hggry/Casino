using CasinoLib;
using CasinoLib.GameFlow;
using CasinoLib.GameRules;
using CasinoLib.GameRules.PlayerChoice;
using CasinoLib.GameRules.PlayerChoice.Blackjack;
using CasinoLib.InputMethod;
using CasinoLib.TimeOnTableAllowed;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace CasinoLib_UnitTest
{
    [TestClass]
    public class BlackJackGameFlow_Tests
    {
        [TestMethod]
        public void Test_GetPlayers()
        {
            #region Arrange
            var players = new List<IPlayer>();
            players.Add(new Player("Test", new U20TimeOnTableAllowed()));

            BlackJackGameFlow blackJackGameFlow = new BlackJackGameFlow(null, null, players);
            #endregion

            #region Act
            var result = blackJackGameFlow.GetPlayers();
            #endregion

            #region Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(typeof(Player), result[0].GetType());
            Assert.AreEqual("Test", ((Player)result[0]).Name);
            #endregion
        }

        [TestMethod]
        public void Test_GetCurrentPlayer()
        {
            #region Arrange
            var players = new List<IPlayer>
            {
                new Player("Test1", new U20TimeOnTableAllowed()),
                new Player("Test2", new U20TimeOnTableAllowed()),
                new Player("Test3", new U20TimeOnTableAllowed())
            };

            BlackJackGameFlow blackJackGameFlow = new BlackJackGameFlow(null, null, players);
            #endregion

            #region Act
            blackJackGameFlow.GetNextPlayer();
            blackJackGameFlow.GetNextPlayer();
            blackJackGameFlow.GetNextPlayer();
            var result = blackJackGameFlow.GetCurrentPlayer();
            #endregion

            #region Assert
            Assert.AreEqual(typeof(Player), result.GetType());
            Assert.AreEqual("Test3", ((Player)result).Name);
            #endregion
        }

        [TestMethod]
        public void Test_GetNextPlayer()
        {
            #region Arrange
            var players = new List<IPlayer>();
            players.Add(new Player("Test", new U20TimeOnTableAllowed()));

            BlackJackGameFlow blackJackGameFlow = new BlackJackGameFlow(null, null, players);
            #endregion

            #region Act
            var result = blackJackGameFlow.GetNextPlayer();
            #endregion

            #region Assert
            Assert.AreEqual(typeof(Player), result.GetType());
            Assert.AreEqual("Test", ((Player)result).Name);
            #endregion
        }

        [TestMethod]
        public void Test_GetNextPlayer_NullPlayerList()
        {
            #region Arrange
            BlackJackGameFlow blackJackGameFlow = new BlackJackGameFlow(null, null, null);
            #endregion

            #region Act
            var result = blackJackGameFlow.GetNextPlayer();
            #endregion

            #region Assert
            Assert.IsNull(result);
            #endregion
        }

        [TestMethod]
        public void Test_GetNextPlayer_EmtyPlayerList()
        {
            #region Arrange
            var players = new List<IPlayer>();
            BlackJackGameFlow blackJackGameFlow = new BlackJackGameFlow(null, null, players);
            #endregion

            #region Act
            var result = blackJackGameFlow.GetNextPlayer();
            #endregion

            #region Assert
            Assert.IsNull(result);
            #endregion
        }

        [TestMethod]
        public void Test_SetPlayerBet_Success()
        {
            #region Arrange
            const int initialChips = 2000;
            const int betAmount = 300;

            int chips = initialChips;
            int executedBetAmount = 0;

            var players = new List<IPlayer>();

            var playerMock = new Mock<IPlayer>();
            playerMock.Setup(p => p.GetChips()).Returns(() =>
            {
                return chips;
            });
            playerMock.Setup(p => p.SetChips(It.IsAny<int>())).Callback<int>(chp =>
            {
                chips = chp;
            });
            playerMock.Setup(p => p.SetBetAmount(It.IsAny<int>())).Callback<int>(amt =>
            {
                executedBetAmount = amt;
            });

            players.Add(playerMock.Object);

            BlackJackGameFlow blackJackGameFlow = new BlackJackGameFlow(null, null, players);
            #endregion

            #region Act
            blackJackGameFlow.SetPlayerBet(betAmount, blackJackGameFlow.GetNextPlayer());
            #endregion

            #region Assert
            Assert.AreEqual(betAmount, executedBetAmount);
            Assert.AreEqual(initialChips - betAmount, blackJackGameFlow.GetCurrentPlayer().GetChips());
            #endregion
        }

        [TestMethod]
        public void Test_SetPlayerBet_ZeroBet()
        {
            #region Arrange
            const int initialChips = 100;
            const int betAmount = 0;

            bool doneWithRound = false;
            int chips = initialChips;
            int executedBetAmount = 0;

            var players = new List<IPlayer>();
            var playerMock = new Mock<IPlayer>();
            playerMock.Setup(p => p.GetChips()).Returns(chips);
            playerMock.Setup(p => p.SetChips(It.IsAny<int>())).Callback<int>(chp =>
            {
                chips = chp;
            });
            playerMock.Setup(p => p.SetBetAmount(It.IsAny<int>())).Callback<int>(amt =>
            {
                executedBetAmount = amt;
            });
            playerMock.Setup(p => p.SetDoneWithRound(true)).Callback<bool>(dwr =>
            {
                doneWithRound = dwr;
            });

            players.Add(playerMock.Object);

            BlackJackGameFlow blackJackGameFlow = new BlackJackGameFlow(null, null, players);
            #endregion

            #region Act
            blackJackGameFlow.SetPlayerBet(betAmount, blackJackGameFlow.GetNextPlayer());
            #endregion

            #region Assert
            Assert.IsTrue(doneWithRound);
            Assert.AreEqual(chips, blackJackGameFlow.GetCurrentPlayer().GetChips());
            #endregion
        }

        [TestMethod]
        public void Test_ValidateBet_Successfull()
        {
            #region Arrange
            int chips = 2000;

            var players = new List<IPlayer>();
            var playerMock = new Mock<IPlayer>();
            playerMock.Setup(p => p.GetChips()).Returns(chips);
            playerMock.Setup(p => p.SetChips(It.IsAny<int>())).Callback<int>(chp =>
            {
                chips = chp;
            });

            players.Add(playerMock.Object);

            BlackJackGameFlow blackJackGameFlow = new BlackJackGameFlow(null, null, players);
            #endregion

            #region Act
            var result = blackJackGameFlow.ValidateBetAmount(300, blackJackGameFlow.GetNextPlayer());
            #endregion

            #region Assert
            Assert.IsTrue(result);
            #endregion
        }

        [TestMethod]
        public void Test_ValidateBet_BetAmountToHigh()
        {
            #region Arrange
            int chips = 100;

            var players = new List<IPlayer>();
            var playerMock = new Mock<IPlayer>();
            playerMock.Setup(p => p.GetChips()).Returns(chips);
            playerMock.Setup(p => p.SetChips(It.IsAny<int>())).Callback<int>(chp =>
            {
                chips = chp;
            });

            players.Add(playerMock.Object);

            BlackJackGameFlow blackJackGameFlow = new BlackJackGameFlow(null, null, players);
            #endregion

            #region Act
            var result = blackJackGameFlow.ValidateBetAmount(300, blackJackGameFlow.GetNextPlayer());
            #endregion

            #region Assert
            Assert.IsFalse(result);
            #endregion
        }

        [TestMethod]
        public void Test_ValidateBet_InvalidBetAmount()
        {
            #region Arrange
            int chips = 100;

            var players = new List<IPlayer>();
            var playerMock = new Mock<IPlayer>();
            playerMock.Setup(p => p.GetChips()).Returns(chips);
            playerMock.Setup(p => p.SetChips(It.IsAny<int>())).Callback<int>(chp =>
            {
                chips = chp;
            });

            players.Add(playerMock.Object);

            BlackJackGameFlow blackJackGameFlow = new BlackJackGameFlow(null, null, players);
            #endregion

            #region Act
            var result = blackJackGameFlow.ValidateBetAmount(-300, blackJackGameFlow.GetNextPlayer());
            #endregion

            #region Assert
            Assert.IsFalse(result);
            #endregion
        }

        [TestMethod]
        public void Test_IsRoundOver()
        {
            #region Arrange
            var p = new Player("Test", new U20TimeOnTableAllowed());
            p.SetDoneWithRound(true);

            var players = new List<IPlayer>();
            players.Add(p);

            BlackJackGameFlow blackJackGameFlow = new BlackJackGameFlow(new BlackJackGameRules(), null, players);
            #endregion

            #region Act
            bool result = blackJackGameFlow.IsRoundOver();
            #endregion

            #region Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(true, blackJackGameFlow.GetNextPlayer().GetDoneWithRound());
            #endregion
        }

        [TestMethod]
        public void Test_PerformPlayerChoice()
        {
            #region Arrange
            var p = new Player("Test", new U20TimeOnTableAllowed());

            var players = new List<IPlayer>();
            players.Add(p);

            var playerChoice = new CardRequestPlayerChoice(new ConsoleInputMethod(1, "hit"));

            var blackJackGameRulesMock = new Mock<IGameRules>();
            blackJackGameRulesMock.Setup(m => m.IsPlayerChoiceValid(It.IsAny<IPlayerChoice>())).Returns(true);

            BlackJackGameFlow blackJackGameFlow = new BlackJackGameFlow(blackJackGameRulesMock.Object, new Dealer(new ExpertTimeOnTableAllowed()), players);
            blackJackGameFlow.GetNextPlayer();
            #endregion

            #region Act
            blackJackGameFlow.PerformPlayerChoice(playerChoice);
            #endregion

            #region Assert
            Assert.AreEqual(1, p.GetHand().GetCards().Count);
            #endregion
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "user is not allowed to perform this action")]
        public void Test_PerformInvalidPlayerChoice()
        {
            #region Arrange
            var p = new Player("Test", new U20TimeOnTableAllowed());

            var players = new List<IPlayer>();
            players.Add(p);

            var playerChoice = new CardRequestPlayerChoice(new ConsoleInputMethod(1, "hit"));

            var blackJackGameRulesMock = new Mock<IGameRules>();
            blackJackGameRulesMock.Setup(m => m.IsPlayerChoiceValid(It.IsAny<IPlayerChoice>())).Returns(false);

            BlackJackGameFlow blackJackGameFlow = new BlackJackGameFlow(blackJackGameRulesMock.Object, null, players);
            blackJackGameFlow.GetNextPlayer();
            #endregion

            #region Act
            blackJackGameFlow.PerformPlayerChoice(playerChoice);
            #endregion

            #region Assert

            #endregion
        }

        [TestMethod]
        public void Test_PourOutWinnings_Win()
        {
            #region Arrange
            var p = new Player("Test", new U20TimeOnTableAllowed());

            var players = new List<IPlayer>();
            players.Add(p);

            var blackJackGameRulesMock = new Mock<IGameRules>();
            blackJackGameRulesMock.Setup(m => m.IsWinner(It.IsAny<IPlayer>(), It.IsAny<int>())).Returns(1);

            BlackJackGameFlow blackJackGameFlow = new BlackJackGameFlow(blackJackGameRulesMock.Object, new Dealer(new ExpertTimeOnTableAllowed()), players);
            blackJackGameFlow.SetPlayerBet(100, p);
            #endregion

            #region Act
            blackJackGameFlow.PourOutWinnings();
            #endregion

            #region Assert
            Assert.AreEqual(1100, p.GetChips());
            #endregion
        }

        [TestMethod]
        public void Test_PourOutWinnings_Draw()
        {
            #region Arrange
            var p = new Player("Test", new U20TimeOnTableAllowed());

            var players = new List<IPlayer>();
            players.Add(p);

            var blackJackGameRulesMock = new Mock<IGameRules>();
            blackJackGameRulesMock.Setup(m => m.IsWinner(It.IsAny<IPlayer>(), It.IsAny<int>())).Returns(0);

            BlackJackGameFlow blackJackGameFlow = new BlackJackGameFlow(blackJackGameRulesMock.Object, new Dealer(new ExpertTimeOnTableAllowed()), players);
            blackJackGameFlow.SetPlayerBet(100, p);
            #endregion

            #region Act
            blackJackGameFlow.PourOutWinnings();
            #endregion

            #region Assert
            Assert.AreEqual(1000, p.GetChips());
            #endregion
        }

        [TestMethod]
        public void Test_PourOutWinnings_Lose()
        {
            #region Arrange
            var players = new List<IPlayer>();

            var p = new Player("Test", new U20TimeOnTableAllowed());
            players.Add(p);

            var blackJackGameRulesMock = new Mock<IGameRules>();
            blackJackGameRulesMock.Setup(m => m.IsWinner(It.IsAny<IPlayer>(), It.IsAny<int>())).Returns(-1);

            BlackJackGameFlow blackJackGameFlow = new BlackJackGameFlow(blackJackGameRulesMock.Object, new Dealer(new ExpertTimeOnTableAllowed()), players);
            blackJackGameFlow.SetPlayerBet(100, p);
            #endregion

            #region Act
            blackJackGameFlow.PourOutWinnings();
            #endregion

            #region Assert
            Assert.AreEqual(900, p.GetChips());
            #endregion
        }

        [TestMethod]
        public void Test_DoDealersTurn_StartHandLessThan17()
        {
            #region Arrange
            var hand = new Hand();
            hand.RecieveCard(new Card("Ace", "Heart", 11));
            hand.RecieveCard(new Card("2", "Heart", 2));

            var dealerMock = new Mock<IDealer>();
            dealerMock.Setup(dM => dM.GetHand()).Returns(hand);
            dealerMock.Setup(dM => dM.Deal(It.IsAny<Hand>())).Callback<Hand>(dM =>
            {
                dM.RecieveCard(new Card("6", "Heart", 6));
            });

            BlackJackGameFlow blackJackGameFlow = new BlackJackGameFlow(new BlackJackGameRules(), dealerMock.Object, null);
            #endregion

            #region Act
            blackJackGameFlow.DoDealersTurn();
            #endregion

            #region Assert
            Assert.IsTrue(hand.GetCards().Count > 2);
            Assert.IsTrue(17 < blackJackGameFlow.GetPoints(hand));
            #endregion
        }

        [TestMethod]
        public void Test_DoDealersTurn_StartHandGreaterThan17()
        {
            #region Arrange

            var hand = new Hand();
            hand.RecieveCard(new Card("Ace", "Heart", 11));
            hand.RecieveCard(new Card("7", "Heart", 7));

            var dealerMock = new Mock<IDealer>();
            dealerMock.Setup(dM => dM.GetHand()).Returns(hand);

            BlackJackGameFlow blackJackGameFlow = new BlackJackGameFlow(new BlackJackGameRules(), dealerMock.Object, null);
            #endregion

            #region Act
            blackJackGameFlow.DoDealersTurn();
            #endregion

            #region Assert
            Assert.IsTrue(blackJackGameFlow.GetPoints(hand) > 17);
            Assert.AreEqual(2, hand.GetCards().Count);
            #endregion
        }
    }
}
