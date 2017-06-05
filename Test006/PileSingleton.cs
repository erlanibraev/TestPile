namespace NFX.ApplicationModel.Pile
{
    public class PileSingleton
    {
        public static IPile PILE { get; private set; } = initPile();

        private static IPile initPile()
        {
            DefaultPile result = new DefaultPile();
            result.Configure(null);
            result.AllocMode = AllocationMode.ReuseSpace;

            result.SegmentSize = 256 * 1025 * 1024;

            result.Start();
            return result;
        }

        public static void donePile()
        {
            ((DefaultPile)PILE).WaitForCompleteStop(); 
        }
    }
}