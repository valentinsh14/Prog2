// In Program.cs

using System.Diagnostics; // Required for Stopwatch

// --- Aufgabe 1 ---
Console.WriteLine("--- Aufgabe 1: Sorting Algorithms ---");

int[] sizes = { 10_000, 20_000, 50_000, 100_000 };
Random random = new Random();

foreach (int size in sizes)
{
    // Create a large array with random double values
    double[] array = new double[size];
    for (int i = 0; i < size; i++)
    {
        array[i] = random.NextDouble() * 1000; // Random doubles between 0 and 1000
    }

    // Clone the array for each sort, so we don't sort an already sorted array
    double[] arrayForBubble = (double[])array.Clone();
    double[] arrayForSelection = (double[])array.Clone();
    double[] arrayForInsertion = (double[])array.Clone();

    Console.WriteLine($"\n--- Testing with {size} elements ---");
    
    // Measure Bubblesort
    MeasureSort("Bubblesort", BubbleSort, arrayForBubble);
    
    // Measure Selection Sort
    MeasureSort("Selection Sort", SelectionSort, arrayForSelection);
    
    // Measure Insertion Sort
    MeasureSort("Insertion Sort", InsertionSort, arrayForInsertion);
}


// Helper function to measure and print the time
void MeasureSort(string name, Action<double[]> sortMethod, double[] array)
{
    Stopwatch stopwatch = Stopwatch.StartNew();
    sortMethod(array);
    stopwatch.Stop();
    bool sortedCorrectly = IsSorted(array);
    
    Console.WriteLine($"{name} took: {stopwatch.ElapsedMilliseconds} ms, Is sorted: {sortedCorrectly}");
}
//Helper to see if sorted right
bool IsSorted(double[] arr)
{
    // Loop up to the second-to-last element
    for (int i = 0; i < arr.Length - 1; i++)
    {
        if (arr[i] > arr[i + 1]) return false;
    }

    // If the loop completes, it means no element was out of order.
    return true;
}

void BubbleSort(double[] arr)
{
    int n = arr.Length; // Get the total number of elements

    // The outer loop. This controls the number of passes.
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - 1 - i; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                double temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }
}

void SelectionSort(double[] arr)
{
    int n = arr.Length;

    // The outer loop moves the boundary of the sorted subarray.
    for (int i = 0; i < n - 1; i++)
    {
        int minIndex = i;

        for (int j = i + 1; j < n; j++)
        {
            if (arr[j] < arr[minIndex])
            {
                minIndex = j;
            }
        }
        
        double temp = arr[minIndex];
        arr[minIndex] = arr[i];
        arr[i] = temp;
    }
}

void InsertionSort(double[] arr)
{
    int n = arr.Length;

    for (int i = 1; i < n; i++)
    {

        double key = arr[i];

        int j = i - 1;
        
        
        while (j >= 0 && arr[j] > key)
        {
            // Shift the larger element to the right
            arr[j + 1] = arr[j];
            j = j - 1; // Move to the previous element
        }

        arr[j + 1] = key;
    }
}


// --- Aufgabe 2 & 3 ---

// You can add your functions for the other tasks here, for example:

int[] DistributionCounting(int[] arr)
{
    // Handle empty or null arrays
    if (arr == null || arr.Length == 0)
    {
        return new int[0];
    }

    // Step 1: Find the maximum value
    int maxVal = 0;
    // TODO: Write a loop to find the maximum value in 'arr' and store it in maxVal.
    // Tip: You can find it with a simple for or foreach loop.

    // Step 2: Create the count array
    // TODO: Create an integer array called 'count' with a size of 'maxVal + 1'.

    // Step 3: Count occurrences
    // TODO: Loop through the input 'arr'. For each element, increment the correct index in the 'count' array.

    // Step 4: Rebuild the sorted array
    int[] sortedArr = new int[arr.Length];
    int currentPosition = 0;
    // TODO: Loop through the 'count' array from 0 to maxVal.
    // Inside, have a nested loop that runs 'count[i]' times.
    // In the nested loop, add the number 'i' to 'sortedArr' at 'currentPosition' and increment 'currentPosition'.

    return sortedArr;
}

int[] DistributionCountingWithNegatives(int[] arr)
{
    // TODO: Implement Distribution Counting for positive and negative numbers
    return arr;
}