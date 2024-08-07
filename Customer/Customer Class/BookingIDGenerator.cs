using System;

namespace OOP_GROUP_29
{
    public static class BookingIDGenerator
    {
        private static Random random = new Random();
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Digits = "0123456789";

        public static string GenerateBookingID()
        {
            // Generate two random alphabets
            string alphabets = "";
            for (int i = 0; i < 2; i++)
            {
                alphabets += Alphabet[random.Next(Alphabet.Length)];
            }

            // Generate three random digits
            string digits = "";
            for (int i = 0; i < 3; i++)
            {
                digits += Digits[random.Next(Digits.Length)];
            }

            // Combine alphabets and digits to form the booking ID
            string bookingID = alphabets + digits;
            return bookingID;
        }
    }
}
