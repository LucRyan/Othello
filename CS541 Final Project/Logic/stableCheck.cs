using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS541_Final_Project
{
    public class stableCheck
    {
        /*
        public static void main(String[] args)
        {
            stableCheck t = new stableCheck();
            int[][] testList = new int[8][];
            for (int i = 0; i < 8; i++)
            {
                testList[i] = new int[8];
            }
            int player = 7;
            long startTime = 0;
            long endTime = 0;
            long costTime = 0;

            int outNum = 0;

            startTime = System.DateTime.Now.Millisecond;

            t.setChessList(testList, player);
            for (int i = 0; i < 1; i++)
            {
                outNum = stableCount(testList, player);
            }
            endTime = System.DateTime.Now.Millisecond;
            costTime = endTime - startTime;

            System.Console.WriteLine("There has " + outNum + " stable stones.\n");
            System.Console.WriteLine("Cost Time is: " + costTime + " ms");
        }
        */

        /**
         * To count all the stable stones from the given board.
         * 
         * @param chessList is the input board.
         * @param player is the owner of stable stones.   
         * @return the count of stable stone.
         */
        public static int stableCount(int[][] chessList, int player)
        {
            int stoneCount = 0;
            int[] checkCount = new int[13];
            int[][] checkList = new int[8][];
            for (int i = 0; i < 8; i++)
            {
                checkList[i] = new int[8];
            }

            // Initialize the checkCount array to 0.
            for (int i = 0; i < 13; i++)
            {
                checkCount[i] = 0;
            }
            // Start to calculate the numbers of stable Stones.
            if (chessList[0][0] == player || chessList[0][0] == 8)
            { // Start with the upper left corner.
                // Count all the stable stone from 0,0 to 7,7.
                for (int count = 0; count < 13; count++)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (i + j == count + 1)
                            {
                                if (chessList[i][j] == player || chessList[i][j] == 8)
                                {
                                    checkCount[count]++;
                                }
                            }
                        }
                    }
                }
                // update the stable stone list.
                updateStableList(checkCount, checkList, 1);
            }

            // Initialize the checkCount array to 0.
            for (int i = 0; i < 13; i++)
            {
                checkCount[i] = 0;
            }
            if (chessList[7][7] == player || chessList[7][7] == 8)
            { // Start with the down right corner.
                // Count all the stable stone from 7,7 to 0,0.
                for (int count = 12; count >= 0; count--)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (i + j == count + 1)
                            {
                                if (chessList[i][j] == player || chessList[i][j] == 8)
                                {
                                    checkCount[count]++;
                                }
                            }
                        }
                    }
                }
                // update the stable stone list.
                updateStableList(checkCount, checkList, 4);
            }

            // Initialize the checkCount array to 0.
            for (int i = 0; i < 13; i++)
            {
                checkCount[i] = 0;
            }
            if (chessList[0][7] == player || chessList[0][7] == 8)
            { // Start with the upper right corner.
                // Count all the stable stone from 0,7 to 7,0.
                for (int count = 12; count >= 0; count--)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (j - i == count - 6)
                            {
                                if (chessList[i][j] == player || chessList[i][j] == 8)
                                {
                                    checkCount[count]++;
                                }
                            }
                        }
                    }
                }

                // update the stable stone list.
                updateStableList(checkCount, checkList, 3);
            }

            // Initialize the checkCount array to 0.
            for (int i = 0; i < 13; i++)
            {
                checkCount[i] = 0;
            }
            if (chessList[7][0] == player || chessList[7][0] == 8)
            { // Start with the down left corner.
                // Count all the stable stone from 0,7 to 7,0.
                for (int count = 0; count < 13; count++)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (j - i == count - 6)
                            {
                                if (chessList[i][j] == player || chessList[i][j] == 8)
                                {
                                    checkCount[count]++;
                                }
                            }
                        }
                    }
                }

                // update the stable stone list.
                updateStableList(checkCount, checkList, 2);
            }


            stoneCount = countStable(checkList); // get the value of the stable stone.
            return stoneCount;
        }


        /**
         * The test function to set up the test list.
         * @param chessList
         */
        private void setChessList(int[][] chessList, int player)
        { // update the ChessList. All the pieces.
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    chessList[i][j] = player;
                }
            }
            //chessList[2][2] = -1;
            //chessList[6][6] = -1;
            //chessList[1][6] = -1;
            //chessList[6][1] = -1;
        }

        /**
         * Update the stable stone list.
         * 
         * @param count is the Count value.
         * @param chessList Get the chessList and reference it then update.
         * @param corner 1 is upper left, 2 is upper right, 3 is down left, 4 is down right.
         */
        private static void setStableList(int count, int[][] chessList, int corner)
        { // update the ChessList. All the pieces.
            int[][] chessListReference = chessList;

            if (corner == 1)
            {
                chessListReference[0][0] = 8;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (i + j == count + 1)
                        {
                            chessListReference[i][j] = 8;
                        }
                    }
                }
            }

            if (corner == 2)
            {
                chessListReference[0][7] = 8;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (j - i == count - 6)
                        {
                            chessListReference[i][j] = 8;
                        }
                    }
                }
            }

            if (corner == 3)
            {
                chessListReference[7][0] = 8;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (j - i == count - 6)
                        {
                            chessListReference[i][j] = 8;
                        }
                    }
                }
            }

            if (corner == 4)
            {
                chessListReference[7][7] = 8;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (i + j == count + 1)
                        {
                            chessListReference[i][j] = 8;
                        }
                    }
                }
            }


        }

        /**
         * Count the stable stone from the whole list
         * 
         * @param chessList is the stable board.
         * @return the number of stable stones.
         */
        private static int countStable(int[][] chessList)
        { // count the stable stone.
            int stableCount = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (chessList[i][j] == 8)
                    {
                        stableCount++;
                    }
                }
            }
            return stableCount;
        }

        /**
         * To update the Stable Stone List. 
         * 
         * @param checkCount is the array contains your checksum.
         * @param checkListInput input the board
         * @param corner 1 is upper left, 2 is upper right, 3 is down left, 4 is down right.
         */
        private static void updateStableList(int[] checkCount, int[][] checkListInput, int corner)
        {
            int[][] checkList = checkListInput;

            if (corner == 1 || corner == 3)
            {
                if (checkCount[0] == 2)
                {
                    setStableList(0, checkList, corner); // update the stable stone list.
                    if (checkCount[1] == 3)
                    {
                        setStableList(1, checkList, corner); // update the stable stone list.
                        if (checkCount[2] == 4)
                        {
                            setStableList(2, checkList, corner); // update the stable stone list.
                            if (checkCount[3] == 5)
                            {
                                setStableList(3, checkList, corner); // update the stable stone list.
                                if (checkCount[4] == 6)
                                {
                                    setStableList(4, checkList, corner); // update the stable stone list.
                                    if (checkCount[5] == 7)
                                    {
                                        setStableList(5, checkList, corner); // update the stable stone list.
                                        if (checkCount[6] == 8)
                                        {
                                            setStableList(6, checkList, corner); // update the stable stone list.
                                            if (checkCount[7] == 7)
                                            {
                                                setStableList(7, checkList, corner); // update the stable stone list.
                                                if (checkCount[8] == 6)
                                                {
                                                    setStableList(8, checkList, corner); // update the stable stone list.
                                                    if (checkCount[9] == 5)
                                                    {
                                                        setStableList(9, checkList, corner); // update the stable stone list.
                                                        if (checkCount[10] == 4)
                                                        {
                                                            setStableList(10, checkList, corner); // update the stable stone list.
                                                            if (checkCount[11] == 3)
                                                            {
                                                                setStableList(11, checkList, corner); // update the stable stone list.
                                                                if (checkCount[12] == 2)
                                                                {
                                                                    setStableList(12, checkList, corner); // update the stable stone list.
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (corner == 2 || corner == 4)
            {
                if (checkCount[12] == 2)
                {
                    setStableList(12, checkList, corner); // update the stable stone list.
                    if (checkCount[11] == 3)
                    {
                        setStableList(11, checkList, corner); // update the stable stone list.
                        if (checkCount[10] == 4)
                        {
                            setStableList(10, checkList, corner); // update the stable stone list.
                            if (checkCount[9] == 5)
                            {
                                setStableList(9, checkList, corner); // update the stable stone list.
                                if (checkCount[8] == 6)
                                {
                                    setStableList(8, checkList, corner); // update the stable stone list.
                                    if (checkCount[7] == 7)
                                    {
                                        setStableList(7, checkList, corner); // update the stable stone list.
                                        if (checkCount[6] == 8)
                                        {
                                            setStableList(6, checkList, corner); // update the stable stone list.
                                            if (checkCount[5] == 7)
                                            {
                                                setStableList(5, checkList, corner); // update the stable stone list.
                                                if (checkCount[4] == 6)
                                                {
                                                    setStableList(4, checkList, corner); // update the stable stone list.
                                                    if (checkCount[3] == 5)
                                                    {
                                                        setStableList(3, checkList, corner); // update the stable stone list.
                                                        if (checkCount[2] == 4)
                                                        {
                                                            setStableList(2, checkList, corner); // update the stable stone list.
                                                            if (checkCount[1] == 3)
                                                            {
                                                                setStableList(1, checkList, corner); // update the stable stone list.
                                                                if (checkCount[0] == 2)
                                                                {
                                                                    setStableList(0, checkList, corner); // update the stable stone list.
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


    }
}