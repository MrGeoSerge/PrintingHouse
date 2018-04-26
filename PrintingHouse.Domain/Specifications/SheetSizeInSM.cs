namespace PrintingHouse.Domain.Specifications
{
	public struct SheetSizeInSM
    {
        public int lengthInSM;
        public int widthInSM;

        public SheetSizeInSM(int _lengthInSM, int _widthInSM)
        {
            lengthInSM = _lengthInSM;
            widthInSM = _widthInSM;
        }
    }
}
