namespace TicTacToeApi.TicTacToe.Entities
{ 
    public record Constants{

        public static readonly char Empty = '?';
        public static readonly char X = 'X';
        public static readonly char Y = 'Y';

        public static readonly char[] XWin = new char[]{X, X, X};

        public static readonly char[] YWin = new char[]{Y, Y, Y};

        //Diagonal Win Indices
        public static readonly int[] DiagWin1 = new int[] {0,4,8};
        public static readonly int[] DiagWin2 = new int[] {2,4,6};       

        //Horizontal Win Indices                                        
        public static readonly int[] HorWin1 = new int[]{0,1,2};
        public static readonly int[] HorWin2 = new int[]{3,4,5};
        public static readonly int[] HorWin3 = new int[]{6,7,8};

        //Vertical Win Indices
        public static readonly int[] VertWin1 = new int[]{0,3,6};
        public static readonly int[] VertWin2 = new int[]{1,4,7};
        public static readonly int[] VertWin3 = new int[]{2,5,8};

                                                            









    }
}
