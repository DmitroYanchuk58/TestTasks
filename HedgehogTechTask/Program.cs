public class Program {
    public static void Main(String[] args) {
        int[] hedgehogs = new int[3];
        hedgehogs[0] = 32;
        hedgehogs[1] = 34;
        hedgehogs[2] = 1;
        Console.WriteLine(GetCountMeeting(hedgehogs, 0));
    }

    public static int GetCountMeeting(int[] hedgehogs, int color)
    {
        if (hedgehogs == null||hedgehogs.Count()!=3)
        {
            return -1;
        }
        int meetingCount = 0;
        int otherColorCount = 0;
        long sumArray = (long)hedgehogs[0] + hedgehogs[1] + hedgehogs[2];
        int targetColorHedgehog = 0, otherColorHedgehog1 = 0, otherColorHedgehog2 = 0;
        if (sumArray > Int32.MaxValue)
        {
            return -1;
        }

        switch (color)
        {
            case (int)Color.Blue:
                targetColorHedgehog = hedgehogs[2];
                otherColorHedgehog1 = hedgehogs[0];
                otherColorHedgehog2 = hedgehogs[1];
                break;
            case (int)Color.Green:
                targetColorHedgehog = hedgehogs[1];
                otherColorHedgehog1 = hedgehogs[0];
                otherColorHedgehog2 = hedgehogs[2];
                break;
            case (int)Color.Red:
                targetColorHedgehog = hedgehogs[0];
                otherColorHedgehog1 = hedgehogs[1];
                otherColorHedgehog2 = hedgehogs[2];
                break;
        }

        if (otherColorHedgehog1 == 0 || otherColorHedgehog2 == 0)
        {
            return -1;
        }

        otherColorCount = otherColorHedgehog1 + otherColorHedgehog2;

        meetingCount = MeetingsAlgorithm(otherColorCount, otherColorHedgehog1,otherColorHedgehog2, targetColorHedgehog);

        return meetingCount;

    }
    private static int MeetingsAlgorithm(int otherColorCount, int otherColorHedgehog1, int otherColorHedgehog2,int targetColorHedgehog)
    {
        int meetingCount = 0;
        while (otherColorCount != 0 && otherColorCount != 1)
        {
            if (!(otherColorHedgehog1 == 0 || otherColorHedgehog2 == 0))
            {
                Meet(ref otherColorHedgehog1, ref otherColorHedgehog2, ref targetColorHedgehog);
                otherColorCount -= 2;
            }
            else if (otherColorHedgehog1 > 0 && targetColorHedgehog > 0)
            {
                Meet(ref otherColorHedgehog1, ref targetColorHedgehog, ref otherColorHedgehog2);
                otherColorCount++;
            }
            else if (otherColorHedgehog2 > 0 && targetColorHedgehog > 0)
            {
                Meet(ref otherColorHedgehog2, ref targetColorHedgehog, ref otherColorHedgehog1);
                otherColorCount++;
            }
            else if ((targetColorHedgehog + otherColorHedgehog1) == 0 || (otherColorHedgehog2 + targetColorHedgehog) == 0)
            {
                return -1;
            }
            else
            {
                break;
            }

            meetingCount++;
            if (otherColorCount == 1)
            {
                return -1;
            }
        }
        return meetingCount;
    }

    private static void Meet(ref int hedgehogs1, ref int hedgehogs2, ref int targetColorHedgehogs)
    {
        hedgehogs1--;
        hedgehogs2--;
        targetColorHedgehogs += 2;
    }
}
public enum Color
{
    Red, Green, Blue
}