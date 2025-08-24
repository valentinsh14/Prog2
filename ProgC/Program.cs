// In Program.cs

using System.Diagnostics; // Required for Stopwatch

// --- Aufgabe 3 ---
Console.WriteLine("\n--- Aufgabe 3: Distribution Counting (With Negatives) ---");
int[] mixedNumbers = { 5, -2, 9, 5, 0, -5, 2, -2, 8, 1, 9, 3, 5, -5 };
Console.WriteLine("Original Array: " + string.Join(", ", mixedNumbers));
int[] sortedMixed = DistributionCountingWithNegatives(mixedNumbers);
Console.WriteLine("Sorted Array:   " + string.Join(", ", sortedMixed));

// --- Aufgabe 2 ---
Console.WriteLine("\n--- Aufgabe 2: Distribution Counting (Positive Numbers) ---");
int[] positiveNumbers = { 5, 2, 9, 5, 2, 8, 1, 9, 3, 5 };
Console.WriteLine("Original Array: " + string.Join(", ", positiveNumbers));
int[] sortedPositive = DistributionCounting(positiveNumbers);
Console.WriteLine("Sorted Array:   " + string.Join(", ", sortedPositive));

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
    int maxVal = 0; // 1. Start by assuming 0 is the max (safe because numbers are positive)

// 2. Loop through every single 'number' in the 'arr' array
    foreach (int number in arr) 
    {
        // 3. Check if the current number is greater than the max we've found so far
        if (number > maxVal)
        {
            // 4. If it is, we have a new maximum! Update maxVal.
            maxVal = number; 
        }
    }

    int[] count = new int[maxVal + 1];
    foreach (int number in arr)
    {
        // For each 'number' from the input array, we use it as an index
        // into our 'count' array and increment the value.
        // This is the "counting" part.
        count[number]++;
    }

    // Step 4: Rebuild the sorted array
    int[] sortedArr = new int[arr.Length];
    int currentPosition = 0; // This is our "cursor" for the sortedArr

// Loop through the 'count' array. The index 'i' represents the number to place.
    for (int i = 0; i < count.Length; i++)
    {
        // 'count[i]' tells us how many times the number 'i' appeared.
        // We loop that many times.
        for (int j = 0; j < count[i]; j++)
        {
            // Place the number 'i' into the sorted array
            sortedArr[currentPosition] = i;

            // And move our cursor to the next empty spot
            currentPosition++;
        }
    }

    return sortedArr;
}

int[] DistributionCountingWithNegatives(int[] arr)
{
    if (arr == null || arr.Length == 0)
    {
        return new int[0];
    }

    // Step 1: Find min and max values
    // Tip: Initialize both to the first element of the array.
    int minVal = arr[0]; 
    int maxVal = arr[0];
    
    for(int i = 1; i < arr.Length; i++) 
    {
        int number = arr[i];
        // 3. Check if the current number is greater than the max we've found so far
        if (number > maxVal)
        {
            maxVal = number; 
        }
        if (number < minVal)
        {
            minVal = number; 
        }
    }

    // Step 2 & 3: Create the count array based on the range
    int range = maxVal - minVal + 1;
    int[] count = new int[range];

    foreach (int number in arr)
    {
        int shiftedIndex = number - minVal; 
    
        // Increment the counter at that shifted position
        count[shiftedIndex]++;
    }

    // Step 5: Rebuild the sorted array, un-shifting the values
    int[] sortedArr = new int[arr.Length];
    int currentPosition = 0;
    // Loop through the 'count' array. 'i' is the SHIFTED value's index.
    for (int i = 0; i < range; i++) // or count.Length
    {
        // The inner loop runs 'count[i]' times, as before
        for (int j = 0; j < count[i]; j++)
        {
            // Calculate the ORIGINAL value by adding minVal back
            int originalValue = i + minVal;

            // Place the original value into the sorted array at the current position
            sortedArr[currentPosition] = originalValue;
        
            // And increment the position for the next number
            currentPosition++;
        }
    }

    return sortedArr;
}