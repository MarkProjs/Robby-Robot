namespace RobbyTheRobot
{
    public static class Robby
    {
        public static IRobbyTheRobot CreateRobby() {
            return new RobbyTheRobot();
        }
    }
}