using System;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _player1Points = 0;
        private int _player2Points = 0;

        public TennisGame2(string player1Name, string player2Name)
        {
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
        private string GetPlayer1Score()
        {
            return GetTextScore(_player1Points);
        }
        private string GetPlayer2Score()
        {
            return GetTextScore(_player2Points);
        }
        private bool IsLateGame => _player1Points >= 4 || _player2Points >= 4;
        private int Advantage()
        {
            return Math.Abs(_player1Points - _player2Points);
        }
        private bool IsAdvantageAtLeast2 => Advantage() >= 2;
        private bool IsGameOver => IsLateGame && IsAdvantageAtLeast2;
        private bool IsPlayer1Ahead => _player1Points > _player2Points;
        private bool IsEqualScore => _player1Points == _player2Points;
        private bool IsDeuce => _player1Points == _player2Points && _player1Points > 2;

        public string GetScore()
        {
            if (IsGameOver)
            {
                if (IsPlayer1Ahead)
                    return "Win for player1";
                else
                    return "Win for player2";
            }

            if (IsDeuce) return "Deuce";

            if (IsLateGame)
            {
                if (IsPlayer1Ahead)
                    return "Advantage player1";
                else
                    return "Advantage player2";
            }

            if(IsEqualScore)
                return $"{GetPlayer1Score()}-All";

            return $"{GetPlayer1Score()}-{GetPlayer2Score()}";
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
