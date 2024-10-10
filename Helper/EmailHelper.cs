
namespace EasyAbsenceManager.Helper
{
    internal static class EmailHelper
    {
        public static int FindAtSign(string address)
        {
            for (int i = 0; i < address.Length; i++)
            {
                if (address[i] is '@')
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
