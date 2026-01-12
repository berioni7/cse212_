public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length) // number : base number - length : how many multiples
    {
            // step 1: create a space in memory that stores data. In this case, it will be an array. 

            double[] dataEnter = new double[length]; // I created an array named dataEnter that can hold 'length' number of doubles. 
            // Thinking like “Reserve exactly X spaces in memory now.” Length is my size.

            for (int i = 0; i < length; i++) // here I create a for loop that will iterate until i is less than length
            {
                dataEnter[i] = number * (i + 1); // for each iteration, I am setting the value of the array at index i to be equal to 
                // number multiplied by (i + 1) 
            }
            return dataEnter; // finally, I return the array dataEnter
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int lastElementIndex = data.Count - 1;  // get the index of the last element in the list
            int valueToMove = data[lastElementIndex]; // get the value of the last element in the list

            data.RemoveAt(lastElementIndex); // remove the last element from the list

            data.Insert(0, valueToMove); // insert the value we removed at the front of the list
        }         
    }
}
