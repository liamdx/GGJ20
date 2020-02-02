using UnityEngine;

public static class PlayerColors {
    public static Color getColorByPlayer(int playerNumber)
    {
        switch (playerNumber + 1)
        {
            case 1:
                return new Color(0.90f, 0.28f, 0.33f, 1f);
            case 2:
                return new Color(0.97f, 0.86f, 0.36f, 1f);
            case 3:
                return new Color(0.19f, 0.51f, 0.98f, 1f);
            case 4:
                return new Color(0.93f, 0.73f, 0.83f, 1f);
            default:
                return new Color(1f, 1f, 1f, 1f);
        }
    }

     public static string getColorNameByPlayer(int playerNumber)
    {
        switch (playerNumber + 1)
        {
            case 1:
                return "Red";
            case 2:
                return "Yellow";
            case 3:
                return "Blue";
            case 4:
                return "Pink";
            default:
                return "";
        }
    }
}