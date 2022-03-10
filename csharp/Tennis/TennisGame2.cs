using System;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _player1Points = 0;
        private int _player2Points = 0;

        private string _player1Result = string.Empty;
        private string _player2Result = string.Empty;
        private readonly string _player1Name;
        private readonly string _player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player1Points = 0;
            _player2Name = player2Name;
        }

        private string GetTextScore(int numericScore)
        {
            switch (numericScore)
            {
                case 0: return "Love";
                case 1: return "Fifteen";
                case 2: return "Thirty";
                case 3: return "Forty";
                default: throw new OutOfRangeScoreException(numericScore);
            }
        }

        public string GetScore()
        {
            var score = "";
            if (_player1Points == _player2Points && _player1Points < 3)
            {
                score = GetTextScore(_player1Points);
                score += "-All";
            }
            if (_player1Points == _player2Points && _player1Points > 2)
                score = "Deuce";

            if (_player1Points > 0 && _player2Points == 0)
            {
                score = GetTextScore(_player1Points);
                _player2Result = "Love";
                score = _player1Result + "-" + _player2Result;
            }
            if (_player2Points > 0 && _player1Points == 0)
            {
                score = GetTextScore(_player2Points);
                _player1Result = "Love";
                score = _player1Result + "-" + _player2Result;
            }

            if (_player1Points > _player2Points && _player1Points < 4)
            {
                _player1Result = GetTextScore(_player1Points);
                _player2Result = GetTextScore(_player2Points);
                score = _player1Result + "-" + _player2Result;
            }
            if (_player2Points > _player1Points && _player2Points < 4)
            {
                _player1Result = GetTextScore(_player1Points);
                _player2Result = GetTextScore(_player2Points);
                score = _player1Result + "-" + _player2Result;
            }

            if (_player1Points > _player2Points && _player2Points >= 3)
            {
                score = "Advantage player1";
            }

            if (_player2Points > _player1Points && _player1Points >= 3)
            {
                score = "Advantage player2";
            }

            if (_player1Points >= 4 && _player2Points >= 0 && (_player1Points - _player2Points) >= 2)
            {
                score = "Win for player1";
            }
            if (_player2Points >= 4 && _player1Points >= 0 && (_player2Points - _player1Points) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            _player1Points++;
        }

        private void P2Score()
        {
            _player2Points++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }

    class OutOfRangeScoreException : Exception
    {
        public OutOfRangeScoreException() { }

        public OutOfRangeScoreException(int score)
            : base(String.Format("Score must be between 0 and 3. Got: {0}", score))
        {

        }
    }
}

